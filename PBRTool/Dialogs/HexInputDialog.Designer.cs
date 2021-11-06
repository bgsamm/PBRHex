
namespace PBRTool.Dialogs
{
    partial class HexInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.decimalRadioButton = new System.Windows.Forms.RadioButton();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(59, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 24);
            this.textBox1.TabIndex = 0;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.Location = new System.Drawing.Point(100, 22);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(73, 18);
            this.promptLabel.TabIndex = 1;
            this.promptLabel.Text = "[Prompt]";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(179, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // decimalRadioButton
            // 
            this.decimalRadioButton.AutoSize = true;
            this.decimalRadioButton.Location = new System.Drawing.Point(78, 12);
            this.decimalRadioButton.Name = "decimalRadioButton";
            this.decimalRadioButton.Size = new System.Drawing.Size(77, 21);
            this.decimalRadioButton.TabIndex = 3;
            this.decimalRadioButton.Text = "decimal";
            this.decimalRadioButton.UseVisualStyleBackColor = true;
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Checked = true;
            this.hexRadioButton.Location = new System.Drawing.Point(161, 12);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(51, 21);
            this.hexRadioButton.TabIndex = 4;
            this.hexRadioButton.TabStop = true;
            this.hexRadioButton.Text = "hex";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "base:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hexRadioButton);
            this.panel1.Controls.Add(this.decimalRadioButton);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 44);
            this.panel1.TabIndex = 6;
            // 
            // HexInputDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 131);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "HexInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton decimalRadioButton;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}