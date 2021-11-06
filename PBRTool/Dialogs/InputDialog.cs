using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBRTool.Dialogs
{
    public partial class InputDialog : Form
    {
        public string Prompt { get; set; }
        public string Default { get; set; }
        public string Response { get { return textBox1.Text; } }

        public InputDialog() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            promptLabel.Text = Prompt;
            textBox1.Text = Default ?? "";

            int x = (Width - promptLabel.Width) / 2,
                y = promptLabel.Location.Y;
            promptLabel.Location = new Point(x - 5, y);
        }
    }
}
