using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBRHex.HexEditor.Commands
{
    public class PasteCommand : Command<HexEditorWindow>
    {
        private int Address;
        private byte[] OldBytes, NewBytes;

        public PasteCommand(HexEditorWindow editor) : base(editor) { }

        // is this the best implementation? I don't know. But it works :) (mostly)
        public override bool Execute() {
            try {
                string data = Clipboard.GetText();
                var rows = data.Split(new char[] { '\n' });
                Address = Editor.GetSelectionRange().X;
                // copying pads to fit a rectangle, so need to figure out
                // where data actually starts and ends
                int first;
                var firstRow = rows[0].Split(new char[] { '\t' });
                for(first = 0; first < firstRow.Length; first++) {
                    if(firstRow[first].Length > 0)
                        break;
                }
                int last = 0;
                var lastRow = rows.Last().Split(new char[] { '\t' });
                for(int i = 0; i < lastRow.Length; i++) {
                    if(lastRow[i].Length > 0)
                        last = i;
                }

                var temp = new List<byte>();
                for(int r = 0; r < rows.Length; r++) {
                    int offset = Address + r * 16 - first;
                    var vals = rows[r].Split(new char[] { '\t' });
                    for(int c = 0; c < vals.Length; c++) {
                        if((r == 0 && c < first) || (r == rows.Length - 1 && c > last))
                            continue;
                        if(vals[c].Trim().Length > 0)
                            temp.Add(Convert.ToByte(vals[c].Trim(), 16));
                        else
                            temp.Add(Editor.GetRange(offset + c, 1)[0]);
                        // fill in gaps with pre-existing values
                        if(vals[c].EndsWith("\r"))
                            temp.AddRange(Editor.GetRange(offset + c + 1, 15 - c));
                    }
                }
                OldBytes = Editor.GetRange(Address, temp.Count);
                NewBytes = temp.ToArray();
                Editor.SetRange(Address, NewBytes);
            } catch {
                // main points of failure are a) trying to paste invalid hex,
                // or b) trying to paste past the end of the file
                return false;
            }
            return true;
        }

        public override void Redo() {
            Editor.SetRange(Address, NewBytes);
        }

        public override void Undo() {
            Editor.SetRange(Address, OldBytes);
        }
    }
}
