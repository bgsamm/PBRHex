using PBRTool.Tables;
using System;
using System.Drawing;

namespace PBRTool.DexEditor.Commands
{
    public class SetFaceSpriteCommand : Command<DexEditorWindow>
    {
        private readonly Bitmap NewSprite;
        private readonly int MonID, FormID;
        private readonly int Gender;
        private readonly bool Shiny;
        private Image OldImage, NewImage;

        public SetFaceSpriteCommand(DexEditorWindow editor, Image sprite, int dex, int form,
                                    int gender, bool shiny = false) : base(editor) {
            MonID = dex;
            FormID = form;
            Gender = gender;
            NewSprite = (Bitmap)sprite;
            Shiny = shiny;
        }

        public override bool Execute() {
            OldImage = SpriteTable.GetFaceSprite(MonID, FormID, Gender);
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
            SpriteTable.SetFaceSprite(MonID, FormID, Gender, NewImage);
            Editor.SetFaceSprite(NewImage);
            return true;
        }

        public override void Redo() {
            SpriteTable.SetFaceSprite(MonID, FormID, Gender, NewImage);
            Editor.SetFaceSprite(NewImage);
        }

        public override void Undo() {
            SpriteTable.SetFaceSprite(MonID, FormID, Gender, OldImage);
            Editor.SetFaceSprite(OldImage);
        }
    }
}
