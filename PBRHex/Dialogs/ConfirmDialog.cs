using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBRHex.Dialogs
{
    public partial class ConfirmDialog : Form
    {
        public readonly string Message;

        public ConfirmDialog(string msg) {
            InitializeComponent();

            Message = msg;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            messageLabel.Text = Message;

            Width = messageLabel.Width + 20;

            int x = (Width - messageLabel.Width) / 2,
                y = messageLabel.Location.Y;
            messageLabel.Location = new Point(x - 5, y);
        }
    }
}
