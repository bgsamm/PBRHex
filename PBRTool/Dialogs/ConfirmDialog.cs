using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBRTool.Dialogs
{
    public partial class ConfirmDialog : Form
    {
        public string Message { get; set; }

        public ConfirmDialog() {
            InitializeComponent();
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
