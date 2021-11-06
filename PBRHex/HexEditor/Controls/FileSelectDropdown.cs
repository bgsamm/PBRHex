using System.Drawing;
using System.Windows.Forms;

namespace PBRHex.HexEditor.Controls
{
    public partial class FileSelectDropdown : ComboBox
    {
        public FileSelectDropdown() {
            InitializeComponent();
        }
        
        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);

            if(SelectedIndex == -1) return;
            string fileName = Items[e.Index].ToString();
            e.DrawBackground();
            e.Graphics.DrawString(fileName, e.Font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
