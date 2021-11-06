using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PBRHex.Events;
using PBRHex.Files;
using PBRHex.HexLabels;
using PBRHex.Utils;

namespace PBRHex.HexEditor.Controls
{
    public partial class HexGridView : DataGridView {
        public event EventHandler<CellEditEventArgs> CellEdited;

        public DataGridViewCell FirstSelectedCell
        {
            get {
                return SelectedCells.Cast<DataGridViewCell>()
                    .OrderBy(c => GetAddress(c)).FirstOrDefault();
            }
        }

        public DataGridViewCell LastSelectedCell
        {
            get
            {
                return SelectedCells.Cast<DataGridViewCell>()
                    .OrderBy(c => GetAddress(c)).LastOrDefault();
            }
        }

        internal FileBuffer File;
        private bool editing, parsing;

        public HexGridView() {
            InitializeComponent();

            // double buffer
            PropertyInfo prop = GetType().GetProperty("DoubleBuffered",
              BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(this, true, null);
        }

        /// <returns>A matrix of bytes corresponding to the values
        /// currently visible in the view.</returns>
        public byte[][] GetDisplayedBytes() {
            byte[][] bytes2D = new byte[DisplayedRowCount(false)][];
            int start = FirstDisplayedScrollingRowIndex;
            for(int i = 0; i < bytes2D.Length; i++) {
                if((start + i) * 0x10 < File.Size)
                    bytes2D[i] = File.GetRange((start + i) * 0x10, 0x10);
                else
                    bytes2D[i] = new byte[0];
            }
            return bytes2D;
        }

        public byte[] GetSelectedBytes() {
            byte[] bytes = new byte[SelectedCells.Count];
            int start = GetAddress(FirstSelectedCell),
                end = GetAddress(LastSelectedCell);
            int n = 0;
            for(int i = 0; i <= end - start; i++) {
                int r = (start + i) / 16, c = (start + i) % 16;
                if(this[c, r].Selected) {
                    bytes[n] = (byte)HexUtils.HexToInt(this[c, r].Value.ToString());
                    n++;
                }
            }
            return bytes;
        }

        public int GetAddress(DataGridViewCell cell) {
            return GetAddress(cell.RowIndex, cell.ColumnIndex);
        }

        public int GetAddress(int RowIndex, int ColumnIndex) {
            return RowIndex * 16 + ColumnIndex;
        }

        public void SelectCell(int row, int col) {
            CurrentCell = Rows[row].Cells[col];
        }

        public void SelectCell(int address) {
            int row = address / 16, col = address % 16;
            SelectCell(row, col);
        }
        
        public void GoTo(int address) {
            FirstDisplayedScrollingRowIndex = address / 16;
            SelectCell(address);
        }

        public bool IsSelectionContiguous() {
            int start = GetAddress(FirstSelectedCell),
                count = SelectedCells.Count;
            foreach(DataGridViewCell cell in SelectedCells) {
                int addr = GetAddress(cell);
                if(addr - start < 0 || addr - start >= count)
                    return false;
            }
            return true;
        }

        public bool IsSelectionRectangular() {
            int start = GetAddress(FirstSelectedCell),
                end = GetAddress(LastSelectedCell);
            int width = LastSelectedCell.ColumnIndex - FirstSelectedCell.ColumnIndex + 1;
            if(width <= 0)
                return false;
            for(int i = start; i <= end; i++) {
                int c = i % 16, r = i / 16;
                if(c < start % 16 && this[c, r].Selected)
                    return false;
                if(c >= (start % 16 + width) && this[c, r].Selected)
                    return false;
                if(c >= start % 16 && c < (start % 16 + width) && !this[c, r].Selected)
                    return false;
            }
            return true;
        }

        private void OnCellEdit(object sender, EventArgs e) {
            if(editing && EditingControl.Text.Length >= 2) {
                int address = GetAddress(CurrentCell) + 1;
                if(address / 16 > RowCount - 1)
                    RowCount++;
                CurrentCell = this[address % 16, address / 16];
            }
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e) {
            base.OnCellEndEdit(e);
            editing = false;
            parsing = false;
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e) {
            base.OnEditingControlShowing(e);
            // would accumulate OnCellEdit handlers if not removed first
            EditingControl.TextChanged -= OnCellEdit;
            EditingControl.TextChanged += OnCellEdit;
            editing = true;
        }

        protected override void OnCellParsing(DataGridViewCellParsingEventArgs e) {
            base.OnCellParsing(e);
            // CellParsing gets raised again if the current cell changes;
            // we only want to respond the first time
            if(!parsing) {
                parsing = true;
                // only accept valid hex
                try {
                    int address = GetAddress(e.RowIndex, e.ColumnIndex);
                    byte value = Convert.ToByte(e.Value.ToString(), 16);
                    CellEdited?.Invoke(this, new CellEditEventArgs(address, value));
                }
                catch { }
            }
        }

        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e) {
            base.OnCellValueNeeded(e);

            int address = GetAddress(e.RowIndex, e.ColumnIndex);
            if(address < File.Size)
                e.Value = File.ReadByte(GetAddress(e.RowIndex, e.ColumnIndex)).ToString("X2");
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e) {
            base.OnCellPainting(e);
            
            // row headers
            if(e.ColumnIndex == -1 && e.RowIndex >= 0) {
                string rowHeader = (e.RowIndex * 16).ToString("X8"); ;
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawString(rowHeader, e.CellStyle.Font,
                    Brushes.Black, new PointF(
                        e.CellBounds.Left + 4,
                        e.CellBounds.Top + 4)
                    );
                e.Handled = true;
            }
            else if(e.RowIndex >= 0) {
                int address = GetAddress(e.RowIndex, e.ColumnIndex);
                if(address >= File.Size) return;
                var cellColor = HexLabel.LabelColors[File.LabelMap[address]];

                // cell background
                if(this[e.ColumnIndex, e.RowIndex].ReadOnly)
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.CellBounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(cellColor), e.CellBounds);
                
                // selection highlight
                if(e.State.HasFlag(DataGridViewElementStates.Selected)) {
                    using(Brush highlightBrush = new SolidBrush(SystemColors.Highlight)) {
                        var insetRect = new Rectangle(e.CellBounds.X,
                            e.CellBounds.Y, e.CellBounds.Width,
                            e.CellBounds.Height);
                        e.Graphics.FillRectangle(highlightBrush, insetRect);
                    }
                }
                // grid lines
                using(Brush gridBrush = new SolidBrush(ControlPaint.Dark(cellColor))) {
                    Pen gridPen = new Pen(gridBrush);
                    // bottom border
                    e.Graphics.DrawLine(gridPen, e.CellBounds.Left,
                        e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                    // right border
                    e.Graphics.DrawLine(gridPen, e.CellBounds.Right - 1,
                        e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom);
                }
                // label numbers
                if(File.Labels.ContainsAddress(address)) {
                    int x = e.CellBounds.X, y = e.CellBounds.Y;
                    using(Brush tagBrush = new SolidBrush(Color.LightGray)) {
                        var tagRect = new Rectangle(x, y, 8, 8);
                        e.Graphics.DrawString(
                            File.Labels.IndexOf(address).ToString(),
                            new Font(e.CellStyle.Font.FontFamily, 7f, FontStyle.Regular),
                            Brushes.Black,
                            new PointF(x - 0.5f, y - 2));
                    }
                }
                
                /*
                if(File.IsByteEdited(address))
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = DefaultForeColor;
                */

                if(!this[e.ColumnIndex, e.RowIndex].ReadOnly)
                    e.PaintContent(e.CellBounds);
                e.Handled = true;
            }

            // Old copy-paste code kept in case I want to revert the current implementation
            /*
            private void RectangularCopy() {
                int startRow = FirstSelectedCell.RowIndex,
                    startCol = FirstSelectedCell.ColumnIndex,
                    height = LastSelectedCell.RowIndex - FirstSelectedCell.RowIndex + 1,
                    width = LastSelectedCell.ColumnIndex - FirstSelectedCell.ColumnIndex + 1;
                var sb = new StringBuilder();
                for(int r = 0; r < height; r++) {
                    for(int c = 0; c < width; c++) {
                        int address = (startRow + r) * 16 + startCol + c;
                        if(r == height - 1 && c == width - 1)
                            sb.Append($"{File[address]:X2}");
                        else if(c == width - 1)
                            sb.Append($"{File[address]:X2}\n");
                        else
                            sb.Append($"{File[address]:X2} ");
                    }
                }
                try {
                    Clipboard.SetText(sb.ToString());
                }
                catch(Exception) {
                    Console.WriteLine(Program.GetProcessLockingClipboard().ProcessName);
                }
            }

            private void ContiguousCopy() {
                var sb = new StringBuilder();
                int start = GetAddress(FirstSelectedCell),
                    end = GetAddress(LastSelectedCell);
                for(int i = start; i <= end; i++) {
                    sb.Append($"{File[i]:X2} ");
                }
                Clipboard.SetText(sb.ToString());
            }

            private void RectangularPaste() {
                string[] rows = Clipboard.GetText().Split('\n');
                byte[][] bytes = new byte[rows.Length][];
                for(int i = 0; i < rows.Length; i++) {
                    bytes[i] = HexUtils.HexToBytes(rows[i]);
                }

                int height = bytes.Length, width = bytes[0].Length;
                byte[] values = new byte[(height - 1) * 16 + width];
                for(int i = 0; i < values.Length; i++) {
                    var address = GetAddress(FirstSelectedCell) + i;
                    if(address % 16 >= FirstSelectedCell.ColumnIndex &&
                        address % 16 < FirstSelectedCell.ColumnIndex + width)
                        values[i] = bytes[i / 16][i % 16];
                    else
                        values[i] = File[address];
                }

                var eventArgs = new SetRangeEventArgs(GetAddress(FirstSelectedCell), values);
            }

            private void ContiguousPaste() {
                byte[] values = HexUtils.HexToBytes(Clipboard.GetText());
                var eventArgs = new SetRangeEventArgs(GetAddress(FirstSelectedCell), values);
            }
            */
        }
    }

    /*
    internal class HexCell
    {
        public byte Value { get; set; }
        public HexLabel.LabelType Type { get; set; }
        public bool IsHeader { get; set; }
        public int LabelNumber { get; set; }

        public bool Edited => Value != OrigVal;
        public Color Color => HexLabel.LabelColors[Type];
        public readonly byte OrigVal;

        public HexCell() : this(0) { }

        public HexCell(byte b) {
            Value = b;
            OrigVal = b;
            Type = HexLabel.LabelType.None;
        }

        public string ToHex() {
            return Value.ToString("X2");
        }
    }
    */
}
