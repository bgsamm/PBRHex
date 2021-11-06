using System;
using System.Windows.Forms;

namespace PBRTool.Dialogs
{
    public partial class AlertDialog : Form
    {
        public string Message { get; set; }

        public AlertDialog() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            messageLabel.Text = Message;
        }
    }
}
