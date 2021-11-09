using System;
using System.Drawing;
using PBRHex.Tables;

namespace PBRHex.Commands.SpriteCommands
{
    public class SetBodySpriteCommand : Command
    {
        private readonly ISpriteEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly Bitmap NewSprite;
        private Image OldImage, NewImage;

        public SetBodySpriteCommand(ISpriteEditor editor, Image sprite, Pokemon mon) {
            Editor = editor;
            Pokemon = mon;
            NewSprite = (Bitmap)sprite;
        }

        private Image MakeNewSpriteSheet() {
            var spriteSheet = new Bitmap(OldImage);
            for(int x = 0; x < NewSprite.Width; x++) {
                for(int y = 0; y < NewSprite.Height; y++) {
                    if(Pokemon.Shiny)
                        spriteSheet.SetPixel(x, y + NewSprite.Height, NewSprite.GetPixel(x, y));
                    else
                        spriteSheet.SetPixel(x, y, NewSprite.GetPixel(x, y));
                }
            }
            return spriteSheet;
        }

        public override bool Execute() {
            OldImage = SpriteTable.GetBodySprites(Pokemon);
            NewImage = MakeNewSpriteSheet();
            SpriteTable.SetBodySprites(Pokemon, NewImage);
            Editor.SetBodySprites(Pokemon, NewImage);
            return true;
        }

        public override void Redo() {
            SpriteTable.SetBodySprites(Pokemon, NewImage);
            Editor.SetBodySprites(Pokemon, NewImage);
        }

        public override void Undo() {
            SpriteTable.SetBodySprites(Pokemon, OldImage);
            Editor.SetBodySprites(Pokemon, OldImage);
        }
    }
}
