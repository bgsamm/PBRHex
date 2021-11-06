using System.Drawing;
using System.Windows.Forms;
using PBRTool.Utils;

namespace PBRTool.HexEditor.Controls
{
    public partial class AsciiViewer : ListBox
    {
        public AsciiViewer() {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the view's text with the ASCII representation of the provided byte matrix.
        /// </summary>
        /// <param name="bytes">A matrix of bytes to be displayed as ASCII.</param>
        public void UpdateView(byte[][] bytes) {
            Items.Clear();
            for(int row = 0; row < bytes.Length; row++) {
                Items.Add(HexUtils.BytesToAscii(bytes[row]));
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);
            if(Items.Count == 0) return;

            int i = e.Index >= 0 ? e.Index : 0;
            float x = e.Bounds.Left + 2, y = e.Bounds.Top + 4;
            e.DrawBackground();
            e.Graphics.DrawString(Items[i].ToString(), e.Font,
                Brushes.Black, new PointF(x, y));
            e.DrawFocusRectangle();
        }
    }
}
