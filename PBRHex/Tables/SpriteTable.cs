﻿using System;
using System.Drawing;
using System.IO;
using PBRHex.Files;
using PBRHex.Properties;
using PBRHex.Utils;

namespace PBRHex.Tables
{
    public static class SpriteTable
    {
        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common0 => Common.Files[0];
        /// <summary>
        /// Body sprite map
        /// </summary>
        private static FileBuffer Common15 => Common.Files[0x15];
        /// <summary>
        /// Face sprite map
        /// </summary>
        private static FileBuffer Common16 => Common.Files[0x16];

        /// <param name="gender">male/unknown: 0, female: 1</param>
        public static Image GetBodySprites(Pokemon mon) {
            int id = GetBodySpriteID(mon);
            using (var stream = new FileStream(MakeBodySpritePath(id), FileMode.Open,
                                              FileAccess.Read)) {
                return Image.FromStream(stream);
            }
        }

        /// <param name="gender">male/unknown: 0, female: 1</param>
        public static Image GetFaceSprites(Pokemon mon) {
            int id = GetFaceSpriteID(mon);
            using (var stream = new FileStream(MakeFaceSpritePath(id), FileMode.Open,
                                              FileAccess.Read)) {
                return Image.FromStream(stream);
            }
        }

        public static void SetBodySprites(Pokemon mon, Image spriteSheet) {
            int id = GetBodySpriteID(mon);
            string spritePath = MakeBodySpritePath(id);
            var temp = CreateGTX(spritePath, spriteSheet);
            temp.ID = id;
            FileUtils.ReplaceLZSS("menu_pokemon", temp);
            FileUtils.DeleteFile(temp.Path);
        }

        public static void SetFaceSprites(Pokemon mon, Image spriteSheet) {
            int id = GetFaceSpriteID(mon);
            string spritePath = MakeFaceSpritePath(id);
            var temp = CreateGTX(spritePath, spriteSheet);
            temp.ID = id;
            FileUtils.ReplaceLZSS("menu_face", temp);
            FileUtils.DeleteFile(temp.Path);
        }

        public static void AddSpriteSlots(int dex) {
            int count = Common0.ReadInt(0),
                start = Common0.ReadInt(0x10),
                tableSize = Common0.ReadInt(0x14),
                fileSize = Common0.ReadInt(0x18);
            Common0.WriteInt(0, count + 1);
            Common0.WriteInt(0x14, tableSize + 0x10);
            Common0.WriteInt(0x18, fileSize + 0x10);
            Common0.AddRange(0x10);

            AddBodySpriteSlot(dex, count);
            AddFaceSpriteSlot(dex, count);

            string path = $@"{Program.TempDir}\temp.png";

            var body = CreateGTX(path, Resources.Unknown_Body);
            body.ID = FileUtils.AddLZSS("menu_pokemon", body);
            Resources.Unknown_Body.Save(MakeBodySpritePath(body.ID));

            var face = CreateGTX(path, Resources.Unknown_Face);
            face.ID = FileUtils.AddLZSS("menu_face", face);
            Resources.Unknown_Face.Save(MakeFaceSpritePath(face.ID));

            int offset = start + count * 0x10;
            Common0.WriteInt(offset, face.ID); // male face
            Common0.WriteInt(offset + 4, body.ID); // male body
            Common0.WriteInt(offset + 8, face.ID); // female face
            Common0.WriteInt(offset + 0xc, body.ID); // female body

            FileUtils.DeleteFile(path);
        }

        private static void AddBodySpriteSlot(int dex, int index) {
            int count = Common15.ReadInt(0),
                start = Common15.ReadInt(0x10),
                tableSize = Common15.ReadInt(0x14),
                fileSize = Common15.ReadInt(0x18);
            Common15.WriteInt(0, count + 1);
            Common15.WriteInt(0x14, tableSize + 0xc);
            Common15.WriteInt(0x18, fileSize + 0xc);
            Common15.AddRange(0xc);
            int offset = start + count * 0xc;
            Common15.WriteShort(offset + 2, (short)dex);
            Common15.WriteShort(offset + 4, (short)index);
            Common15.WriteShort(offset + 6, 1); // form count
        }

        private static void AddFaceSpriteSlot(int dex, int index) {
            int count = Common16.ReadInt(0),
                start = Common16.ReadInt(0x10),
                tableSize = Common16.ReadInt(0x14),
                fileSize = Common16.ReadInt(0x18);
            Common16.WriteInt(0, count + 1);
            Common16.WriteInt(0x14, tableSize + 8);
            Common16.WriteInt(0x18, fileSize + 8);
            Common16.AddRange(8);
            int offset = start + count * 8;
            Common16.WriteShort(offset + 2, (short)dex);
            Common16.WriteShort(offset + 4, (short)index);
            Common16.WriteShort(offset + 6, 2); // form count << 1
        }

        private static FileBuffer CreateGTX(string path, Image image) {
            FileUtils.DeleteFile(path);
            image.Save(path);
            var buf = ImageUtils.ImageToGTX(image, ImageEncoding.RGB5A3);
            string gtxPath = $@"{Program.TempDir}\temp.gtx";
            FileUtils.CreateFile(gtxPath, buf);
            return new FileBuffer(gtxPath, Program.TempDir);
        }

        private static int GetFaceSpriteIndex(int dex) {
            int start = Common16.ReadInt(0x10),
                count = Common16.ReadInt(0);
            // The game simply calculates the offset; I want to work in terms of dex #s
            // though, and I think this will work fine as long as the order of entries in
            // common 8 is the same as in common 16. Time will tell though ;)
            for (int i = 0; i < count; i++) {
                int offset = start + i * 8;
                if (Common16.ReadShort(offset + 2) == dex)
                    return Common16.ReadShort(offset + 4);
            }
            throw new ArgumentException();
        }

        private static int GetBodySpriteIndex(int dex) {
            int start = Common15.ReadInt(0x10),
                count = Common15.ReadInt(0);
            // see above
            for (int i = 0; i < count; i++) {
                int offset = start + i * 0xc;
                if (Common15.ReadShort(offset + 2) == dex)
                    return Common15.ReadShort(offset + 4);
            }
            throw new ArgumentException();
        }

        private static int GetFaceSpriteID(Pokemon mon) {
            int start = Common0.ReadInt(0x10),
                idx = GetFaceSpriteIndex(mon.DexNo);
            // alternate form sprites need to be in consecutive rows
            return Common0.ReadInt(start + (idx + mon.FormID) * 0x10 + 8 * mon.Gender);
        }

        private static int GetBodySpriteID(Pokemon mon) {
            int start = Common0.ReadInt(0x10),
                idx = GetBodySpriteIndex(mon.DexNo);
            // alternate form sprites need to be in consecutive rows
            return Common0.ReadInt(start + (idx + mon.FormID) * 0x10 + 8 * mon.Gender + 4);
        }

        private static string MakeFaceSpritePath(int id) {
            return $@"{Program.SpritesDir}\faces\{id:X8}.png";
        }

        private static string MakeBodySpritePath(int id) {
            return $@"{Program.SpritesDir}\bodies\{id:X8}.png";
        }

        public static void DecodeSprites() {
            Program.NotifyWaiting();
            var MenuFace = FSYSTable.GetFile("menu_face");
            var MenuPokemon = FSYSTable.GetFile("menu_pokemon");
            FileUtils.CreateDirectory(Program.SpritesDir, true);
            FileUtils.CreateDirectory($@"{Program.SpritesDir}\faces", true);
            FileUtils.CreateDirectory($@"{Program.SpritesDir}\bodies", true);
            foreach (GTX texture in MenuFace.Files) {
                var img = ImageUtils.DecodeTexture(texture);
                img.Save(MakeFaceSpritePath(texture.ID));
            }
            foreach (GTX texture in MenuPokemon.Files) {
                var img = ImageUtils.DecodeTexture(texture);
                img.Save(MakeBodySpritePath(texture.ID));
            }
            FSYSTable.WriteFile("menu_face");
            FSYSTable.WriteFile("menu_pokemon");
            Program.NotifyDone();
        }
    }
}
