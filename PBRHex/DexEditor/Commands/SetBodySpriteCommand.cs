using PBRHex.Tables;
using System;
using System.Drawing;

namespace PBRHex.DexEditor.Commands
{
    public class SetBodySpriteCommand : Command<DexEditorWindow>
    {
        private readonly Bitmap NewSprite;
        private readonly int MonID, FormID;
        private readonly int Gender;
        private readonly bool Shiny;
        private Image OldImage, NewImage;

        public SetBodySpriteCommand(DexEditorWindow editor, Image sprite, int dex, int form, 
                                    int gender, bool shiny = false) : base(editor) {
            MonID = dex;
            FormID = form;
            Gender = gender;
            NewSprite = (Bitmap)sprite;
            Shiny = shiny;
        }

        public override bool Execute() {
            OldImage = SpriteTable.GetBodySprite(MonID, FormID, Gender);
            NewImage = new Bitmap(OldImage);
            var newBitmap = (Bitmap)NewImage;
            for(int x = 0; x < NewSprite.Width; x++) {
                for(int y = 0; y < NewSprite.Height; y++) {
                    if(Shiny)
                        newBitmap.SetPixel(x, y + NewSprite.Height, NewSprite.GetPixel(x, y));
                    else
                        newBitmap.SetPixel(x, y, NewSprite.GetPixel(x, y));
                }
            }
            SpriteTable.SetBodySprite(MonID, FormID, Gender, NewImage);
            Editor.SetBodySprite(NewImage);
            return true;
        }

        public override void Redo() {
            SpriteTable.SetBodySprite(MonID, FormID, Gender, NewImage);
            Editor.SetBodySprite(NewImage);
        }

        public override void Undo() {
            SpriteTable.SetBodySprite(MonID, FormID, Gender, OldImage);
            Editor.SetBodySprite(OldImage);
        }
    }
}
