using System;
using System.Windows.Forms;

namespace PBRHex.Dialogs
{
    public partial class AlertDialog : Form
    {
        public readonly string Message;

        public AlertDialog(string msg) {
            InitializeComponent();
            Message = msg;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            messageLabel.Text = Message;
        }
    }
}
