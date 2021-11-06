using System;
using System.Drawing;
using System.Windows.Forms;
using PBRHex.HexLabels;

namespace PBRHex.HexEditor.Controls
{
    public partial class LabelsListBox : ListBox
    {
        public LabelsListBox() {
            InitializeComponent();
        }

        // keeps labels in ascending address order
        public void AddItem(HexLabel label) {
            int i;
            for(i = 0; i < Items.Count; i++) {
                if(label.Address < ((HexLabel)Items[i]).Address)
                    break;
            }
            Items.Insert(i, label);
        }

        public void RemoveItem(HexLabel label) {
            Items.Remove(label);
        }

        public Size MeasureLabel(int index) {
            return TextRenderer.MeasureText($"{index}: {Items[index]}", Font);
        }

        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);

            if(Items.Count == 0 || e.Index == -1) return;
            float x = e.Bounds.Left + 2, y = e.Bounds.Top + 3;
            e.DrawBackground();
            e.Graphics.DrawString($"{e.Index}: {Items[e.Index]}", e.Font,
                Brushes.Black, new PointF(x, y));
            e.DrawFocusRectangle();
        }
    }
}
