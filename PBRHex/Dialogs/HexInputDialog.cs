using System;
using System.Drawing;
using System.Windows.Forms;
using PBRHex.Utils;

namespace PBRHex.Dialogs
{
    public partial class HexInputDialog : Form
    {
        public readonly string Prompt;
        public string Default { get; set; }
        public int? Response
        {
            get {
                try {
                    if (decimalRadioButton.Checked)
                        return int.Parse(textBox1.Text);
                    return HexUtils.HexToInt(textBox1.Text);
                } catch {
                    new AlertDialog("Invalid input.").ShowDialog();
                    return null;
                }
            } 
        }

        public HexInputDialog(string prompt) {
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
