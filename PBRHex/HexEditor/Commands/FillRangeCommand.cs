using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBRHex.Dialogs;

namespace PBRHex.HexEditor.Commands
{
    public class FillRangeCommand : Command<HexEditorWindow>
    {
        private int Address;
        private byte[] OldBytes, NewBytes;

        public FillRangeCommand(HexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            var input = new InputDialog()
            {
                Prompt = "Fill value:",
                Default = "00"
            };
            if(input.ShowDialog() == DialogResult.OK) {
                Program.NotifyWaiting();
                var selectionRange = Editor.GetSelectionRange();
                int size = selectionRange.Y - selectionRange.X + 1;
                Address = selectionRange.X;
                byte value = Convert.ToByte(input.Response, 16);
                OldBytes = Editor.GetRange(Address, size);
                NewBytes = new byte[size];
                for(int i = 0; i < size; i++) {
                    if(Editor.IsCellSelected(Address + i))
                        NewBytes[i] = value;
                    else
                        NewBytes[i] = OldBytes[i];
                }
                Editor.SetRange(Address, NewBytes);
                Program.NotifyDone();
                return true;
            }
            return false;
        }

        public override void Redo() {
            Editor.SetRange(Address, NewBytes);
        }

        public override void Undo() {
            Editor.SetRange(Address, OldBytes);
        }
    }
}
