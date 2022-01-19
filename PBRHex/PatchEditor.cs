using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBRHex
{
    public partial class PatchEditor : Form
    {
        NewPatchEditor newPatchEditor;

        public PatchEditor() {
            InitializeComponent();
        }

        private void NewPatchButton_Click(object sender, EventArgs e) {
            if(newPatchEditor == null) {
                newPatchEditor = new NewPatchEditor();
                newPatchEditor.Show();
            } else {
                newPatchEditor.BringToFront();
            }
        }
    }
}
