using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.Tables
{
    public static class StringTable
    {
        public static int Count => Common5B.ReadInt(4);

        //private readonly static Dictionary<int, GameString> StringMap = new Dictionary<int, GameString>();
        //private readonly static Dictionary<int, int> FileMap = new Dictionary<int, int>();

        private static FSYS Common => FSYSTable.GetFile("common");
        private static FSYS MESCommon => FSYSTable.GetFile("mes_common");
        private static FSYS MenuBPass2 => FSYSTable.GetFile("menu_bpass2");
        private static FSYS MenuName2 => FSYSTable.GetFile("menu_name2");
        private static FSYS MenuBTutorial => FSYSTable.GetFile("menu_btutorial");
        private static FileBuffer[] Files => new FileBuffer[]
        {
            MESCommon.Files[1], MenuBPass2.Files[3], MenuName2.Files[1], MenuBTutorial.Files[1]
        };
        private static FileBuffer Common5B => Common.Files[0x5b];
        private static FileBuffer MESCommon1 => MESCommon.Files[1];

        public static GameString GetString(int id) {
            if (id < 1 || id > Count)
                throw new ArgumentOutOfRangeException();
            int fileIdx = Common5B.ReadShort(id * 4 + 4) - 1,
                stringIdx = Common5B.ReadShort(id * 4 + 6) - 1;
            var file = Files[fileIdx];
            int offset = file.ReadInt(stringIdx * 4 + 0x10);
            var sb = new StringBuilder();
            var gameString = new GameString(id);
            int next;
            while (file.ReadInt(offset) != -1) {
                next = (ushort)file.ReadShort(offset);
                if (next == 0xffff) {
                    switch (file.ReadByte(offset + 2)) {
                        case 0:
                            switch (file.ReadByte(offset + 3)) {
                                case 0x2:
                                    // I think this represents a pause, but I'm not sure it's actually honored by PBR
                                    sb.Append($"[..{file.ReadShort(offset + 4)}]");
                                    offset += 2;
                                    break;
                                case 0x3:
                                    gameString.Alignment = file.ReadShort(offset + 4);
                                    offset += 2;
                                    break;
                                case 0x5:
                                    gameString.Color = file.ReadShort(offset + 4);
                                    offset += 2;
                                    break;
                                default:
                                    sb.Append($"[0x{HexUtils.IntToHex(file.ReadByte(offset + 3), 2)}]");
                                    break;
                            }
                            break;
                        // a little hacky, since the full half-word should be 0x8011
                        case 0x80:
                            gameString.VertOffset = file.ReadInt(offset + 4);
                            offset += 8;
                            break;
                        case 0xf0:
                            gameString.Size = file.ReadByte(offset + 3);
                            break;
                        case 0xf1:
                            gameString.Spacing = (sbyte)file.ReadByte(offset + 3);
                            break;
                        case 0xff:
                            int code = file.ReadInt(offset);
                            switch (code) {
                                case -0x2:
                                    sb.Append(" \n");
                                    break;
                                case -0x4:
                                    sb.Append("[\"No.\"]");
                                    break;
                                case -0x5:
                                    sb.Append("[\"Lv.\"]");
                                    break;
                                case -0x6:
                                    sb.Append("[\"HP\"]");
                                    break;
                                case -0x7:
                                    sb.Append("[\"PP\"]");
                                    break;
                                default:
                                    // I'm not yet sure what -0x3 does
                                    sb.Append($"[-0x{HexUtils.IntToHex(-code, 2)}]");
                                    break;
                            }
                            break;
                        default:
                            sb.Append($"[{file.GetRangeAsHex(offset, 4)}]");
                            break;
                    }
                    offset += 4;
                } else {
                    switch (next) {
                        case 0x3328:
                            sb.Append('\u2642');
                            break;
                        case 0x3329:
                            sb.Append('\u2640');
                            break;
                        case 0xff1f:
                            sb.Append('?');
                            break;
                        default:
                            sb.Append((char)next);
                            break;
                    }
                    offset += 2;
                }
            }
            gameString.Text = sb.ToString();
            return gameString;
        }

        /// <param name="id">String ID</param>
        /// <param name="prop">Property name; one of "Text", "Size", "Spacing", "Alignment", "Color", "VertOffset"</param>
        public static object GetStringProperty(int id, string prop) {
            var gameString = GetString(id);
            return typeof(GameString).GetProperty(prop).GetValue(gameString);
        }

        /// <param name="id">String ID</param>
        /// <param name="prop">Property name; one of "Text", "Size", "Spacing", "Alignment", "Color", "VertOffset"</param>
        /// <param name="value">The new vaue for the specified property</param>
        public static void SetStringProperty(int id, string prop, object value) {
            var gameString = GetString(id);
            typeof(GameString).GetProperty(prop).SetValue(gameString, value);
            ReplaceString(id, gameString);
        }

        private static void ReplaceString(int id, GameString s) {
            int fileIdx = Common5B.ReadShort(id * 4 + 4) - 1,
                stringIdx = Common5B.ReadShort(id * 4 + 6) - 1;
            var file = Files[fileIdx];
            int offset = file.ReadInt(stringIdx * 4 + 0x10);
            file.Search(new byte[] { 0xff, 0xff, 0xff, 0xff }, out int end, offset);
            var bytes = s.ToBytes();
            int count = file.ReadInt(4),
                delta = bytes.Length - (end - offset + 4);
            for (int i = stringIdx + 1; i < count; i++) {
                int oldOffset = file.ReadInt(i * 4 + 0x10);
                file.WriteInt(i * 4 + 0x10, oldOffset + delta);
            }
            file.DeleteRange(offset, end - offset + 4);
            file.InsertRange(offset, bytes);
        }

        /// <returns>index of newly added string</returns>
        //public static int AddString(string s) {
        //    var gameString = new GameString() { Text = s };
        //    return AddString(gameString);
        //}

        public static int AddString(string s) {
            int count = MESCommon1.ReadInt(4);
            for (int i = 0; i < count; i++) {
                int oldOffset = MESCommon1.ReadInt(i * 4 + 0x10);
                MESCommon1.WriteInt(i * 4 + 0x10, oldOffset + 4);
            }
            int numStrs = Common5B.ReadInt(4);
            var gs = new GameString(numStrs + 1) { Text = s };
            MESCommon1.WriteInt(4, count + 1);
            MESCommon1.InsertRange(count * 4 + 0x10, HexUtils.IntToBytes(MESCommon1.Size + 4));
            MESCommon1.AddRange(gs.ToBytes());
            Common5B.WriteInt(4, numStrs + 1);
            Common5B.AddRange(HexUtils.ShortToBytes(1)); // file index
            Common5B.AddRange(HexUtils.ShortToBytes((short)(count + 1))); // string index
            return gs.ID;
        }

        //public static GameString RemoveString(int id) {
        //    int numStrs = Common5B.ReadInt(4),
        //        fileIdx = Common5B.ReadShort(id * 4 + 4) - 1,
        //        stringIdx = Common5B.ReadShort(id * 4 + 6) - 1;
        //    Common5B.WriteInt(4, numStrs - 1);
        //    Common5B.DeleteRange(id * 4 + 4, 4);
        //    var file = Files[fileIdx];
        //    int offset = file.ReadInt(stringIdx * 4 + 0x10);
        //}

        public static void Write() {
            FSYSTable.WriteFile("common");
            FSYSTable.WriteFile("mes_common");
            FSYSTable.WriteFile("menu_bpass2");
            FSYSTable.WriteFile("menu_name2");
            FSYSTable.WriteFile("menu_btutorial");
        }
    }

    public class GameString
    {
        public readonly int ID;
        public string Text { get; set; }

        public int Size { get; set; }
        public int Spacing { get; set; }

        public int Alignment { get; set; }
        public int Color { get; set; }
        public int VertOffset { get; set; }

        public int Length => ToBytes().Length;

        public static GameString Copy(GameString s) {
            return new GameString(s.ID)
            {
                Text = s.Text,
                Size = s.Size,
                Spacing = s.Spacing,
                Alignment = s.Alignment,
                Color = s.Color,
                VertOffset = s.VertOffset
            };
        }

        public GameString(int id) {
            ID = id;
        }

        public byte[] ToBytes() {
            var sb = new StringBuilder();
            sb.Append($"fffff0{HexUtils.IntToHex(Size, 2)}");
            sb.Append($"fffff1{HexUtils.IntToHex(Spacing, 2)}");
            if (VertOffset != 0)
                sb.Append($"ffff8011{HexUtils.IntToHex(VertOffset)}fffffffe");
            if (Alignment != 0)
                sb.Append($"ffff0003{HexUtils.IntToHex(Alignment, 4)}");
            if (Color != 0)
                sb.Append($"ffff0005{HexUtils.IntToHex(Color, 4)}");
            for (int i = 0; i < Text.Length; i++) {
                if (Text[i] == '[' && Text.IndexOf(']', i) != -1) {
                    int len = Text.IndexOf(']', i) - i - 1;
                    string substr = Text.Substring(i + 1, len);
                    if (substr == "\"No.\"")
                        sb.Append("fffffffc");
                    else if (substr == "\"Lv.\"")
                        sb.Append("fffffffb");
                    else if (substr == "\"HP\"")
                        sb.Append("fffffffa");
                    else if (substr == "\"PP\"")
                        sb.Append("fffffff9");
                    else if (substr.StartsWith("-")) {
                        // hacky way of converting signed hex to normal hex
                        int code = HexUtils.HexToInt(substr);
                        sb.Append(HexUtils.IntToHex(code));
                    } else if (substr.StartsWith("..")) {
                        int t = int.Parse(substr.Substring(2));
                        sb.Append($"ffff0002{HexUtils.IntToHex(t, 2)}");
                    } else {
                        int code = HexUtils.HexToInt(substr);
                        sb.Append($"ffff00{HexUtils.IntToHex(code, 2)}");
                    }
                    i += len + 1;
                } else if (Text[i] == '\n') {
                    // remove preceding space
                    sb.Remove(sb.Length - 4, 4);
                    sb.Append("fffffffe");
                } else
                    sb.Append(HexUtils.IntToHex(Text[i], 4));
            }
            sb.Append("ffffffff");
            return HexUtils.HexToBytes(sb.ToString());
        }

        public override string ToString() {
            return Text;
        }
    }
}
