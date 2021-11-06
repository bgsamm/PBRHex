using System;
using System.Drawing;
using System.Windows.Forms;
using PBRTool.Utils;

namespace PBRTool.Dialogs
{
    public partial class HexInputDialog : Form
    {
        public string Prompt { get; set; }
        public string Default { get; set; }
        public int Response 
        { 
            get {
                if(decimalRadioButton.Checked)
                    return int.Parse(textBox1.Text);
                return HexUtils.HexToInt(textBox1.Text);
            } 
        }

        public HexInputDialog() {
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
