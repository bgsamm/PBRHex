using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBRHex.Dialogs
{
    public partial class InputDialog : Form
    {
        public readonly string Prompt;
        public string Default { get; set; }
        public string Response { get { return textBox1.Text; } }

        public InputDialog(string prompt) {
            InitializeComponent();
            Prompt = prompt;
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
