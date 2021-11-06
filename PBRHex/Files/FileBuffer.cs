using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using PBRHex.HexEditor;
using PBRHex.HexLabels;
using PBRHex.Utils;

namespace PBRHex.Files
{
    public class FileBuffer
    {
        private static Dictionary<string, Dictionary<string, object>> Metadata { get; set; }

        public LabelType[] LabelMap => MakeLabelMap();
        public ReadOnlyLabelDict Labels => new ReadOnlyLabelDict(LabelDict);

        public readonly Tape<Command<HexEditorWindow>> EditHistory;
        public readonly Tape<int> LocationHistory;
        public int SaveHead;

        protected byte[] Buffer { get; set; }
        protected LabelDict LabelDict { get; set; }
        public string Notes { get; set; }

        //public readonly FileType Type;
        /// <summary>
        /// The file's identifier as assigned in-game
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The full path of the item.
        /// </summary>
        public readonly string Path;
        /// <summary>
        /// The path to the containing directory of the item.
        /// </summary>
        public string Directory => System.IO.Path.GetDirectoryName(Path);
        public string Extension => System.IO.Path.GetExtension(Path);
        public string Name => System.IO.Path.GetFileName(Path);
        /// <summary>
        /// The path to the file's working directory when editing.
        /// </summary>
        public string WorkingDir { get; set; }
        public string WorkingPath => $@"{WorkingDir}\{Name}";

        private string Key => Extension == "" ?
            $"{new DirectoryInfo(Directory).Name}:{Name}" : Name;

        protected byte this[int i]
        {
            get => Buffer[i];
            set => Buffer[i] = value;
        }
        public int Size => Buffer.Length;

        static FileBuffer() {
            Metadata = new Dictionary<string, Dictionary<string, object>>();
            if(File.Exists($"{Program.UserDir}\\data.json"))
                LoadMetadata();
        }

        public FileBuffer(string filepath) {
            Path = System.IO.Path.GetFullPath(filepath);

            Buffer = File.ReadAllBytes(Path);

            LocationHistory = new Tape<int>();
            LocationHistory.Insert(0);
            EditHistory = new Tape<Command<HexEditorWindow>>();
            EditHistory.Insert(null); // null used to represent starting state
            SaveHead = 0;

            LabelDict = new LabelDict();
            Notes = "";

            if(Metadata.ContainsKey(Key)) {
                var data = Metadata[Key];
                if(data.ContainsKey("Labels"))
                    LabelDict = (LabelDict)data["Labels"];
                if(data.ContainsKey("Notes"))
                    Notes = (string)data["Notes"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">The byte pattern to search for.</param>
        /// <param name="address">The address of the first match, if a match is found.</param>
        /// <param name="offset">The address to start searching from.</param>
        /// <param name="reverse">If true, searches backwards from offset to start.</param>
        /// <returns>A bool indicating whether a match was found.</returns>
        public bool Search(byte[] bytes, out int address, int offset = 0, bool reverse = false) {
            int end = reverse ? 0 : Size - bytes.Length;
            if(reverse)
                offset = Math.Min(offset, Size - bytes.Length);

            byte[] window = new byte[bytes.Length];
            for(address = offset; Math.Abs(address - end) > 0; address += reverse ? -1 : 1) {
                Array.Copy(Buffer, address, window, 0, bytes.Length);
                if(Enumerable.SequenceEqual(window, bytes))
                    return true;
            }
            return false;
        }

        public HexLabel AddLabel(int address, int size, LabelType type, string name) {
            var label = new HexLabel(address, size, type, name);
            LabelDict.Add(label);
            return label;
        }

        public void RenameLabel(int address, string name) {
            LabelDict[address].Name = name;
        }

        public HexLabel DeleteLabel(int address) {
            var label = LabelDict[address];
            LabelDict.Remove(address);
            return label;
        }

        public virtual void InsertRange(int offset, int size) {
            InsertRange(offset, new byte[size]);
        }

        public virtual void InsertRange(int offset, byte[] bytes) {
            var buffer = Buffer.ToList();
            if(offset > Size)
                buffer.AddRange(new byte[offset - Size]);
            buffer.InsertRange(offset, bytes);
            Buffer = buffer.ToArray();

            var temp = new LabelDict();
            foreach(var label in LabelDict.Values) {
                if(label.Address >= offset)
                    label.Address += bytes.Length;
                temp.Add(label);
            }
            LabelDict = temp;
        }

        public virtual void AddRange(int size) {
            InsertRange(Size, size);
        }

        public virtual void AddRange(byte[] bytes) {
            InsertRange(Size, bytes);
        }

        /// <summary>
        /// Also deletes any labels contained in the range.
        /// </summary>
        public virtual byte[] DeleteRange(int offset, int size) {
            var oldBytes = new byte[size];
            Array.Copy(Buffer, offset, oldBytes, 0, size);

            var buffer = Buffer.ToList();
            buffer.RemoveRange(offset, size);
            Buffer = buffer.ToArray();

            var temp = new LabelDict();
            foreach(var label in LabelDict.Values) {
                if(label.Address < offset || label.Address >= offset + size) {
                    if(label.Address >= offset + size)
                        label.Address -= size;
                    temp.Add(label);
                }
            }
            LabelDict = temp;
            return oldBytes;
        }

        public void SetRange(int offset, byte[] bytes) {
            byte[] oldBytes = new byte[bytes.Length];
            Array.Copy(Buffer, offset, oldBytes, 0, bytes.Length);

            for(int i = 0; i < bytes.Length; i++) {
                if(offset + i >= Buffer.Length)
                    break;
                Buffer[offset + i] = bytes[i];
            }
        }

        public void WriteInt(int offset, int value) {
            SetRange(offset, HexUtils.IntToBytes(value));
        }

        public void WriteInt(int offset, uint value) {
            SetRange(offset, HexUtils.IntToBytes(value));
        }

        public void WriteShort(int offset, short value) {
            SetRange(offset, HexUtils.ShortToBytes(value));
        }

        public void WriteByte(int offset, byte value) {
            this[offset] = value;
        }

        public void WriteFloat(int offset, float f) {
            SetRange(offset, HexUtils.FloatToBytes(f));
        }

        public void WriteFloat(int offset, double d) {
            SetRange(offset, HexUtils.FloatToBytes(d));
        }

        public void WriteString(int offset, string s) {
            SetRange(offset, HexUtils.AsciiToBytes(s));
        }

        public byte[] GetRange(int offset, int size) {
            if(offset + size > Size)
                size = Size - offset;
            byte[] range = new byte[size];
            Array.Copy(Buffer, offset, range, 0, size);
            return range;
        }

        public byte ReadByte(int offset) {
            return this[offset];
        }

        public short ReadShort(int offset) {
            return (short)HexUtils.BytesToInt(GetRange(offset, 2));
        }

        public int ReadInt(int offset) {
            return HexUtils.BytesToInt(GetRange(offset, 4));
        }

        public string ReadString(int offset) {
            var sb = new StringBuilder();
            char c;
            while((c = (char)ReadByte(offset++)) != 0) {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public string GetRangeAsHex(int offset, int size) {
            return HexUtils.BytesToHex(GetRange(offset, size));
        }

        public void Overwrite(byte[] bytes) {
            Buffer = (byte[])bytes.Clone();
        }

        public virtual void Save() {
            File.WriteAllBytes(WorkingPath, Buffer);

            if(LabelDict.Count > 0 || Notes != "") {
                if(!Metadata.ContainsKey(Key))
                    Metadata[Key] = new Dictionary<string, object>();

                if(LabelDict.Count > 0)
                    Metadata[Key]["Labels"] = LabelDict;
                else
                    Metadata[Key].Remove("Labels");

                if(Notes != "")
                    Metadata[Key]["Notes"] = Notes.Replace("\r\n", @"\r\n").Replace("\n", @"\n");
                else
                    Metadata[Key].Remove("Notes");
            }
            else {
                Metadata.Remove(Key);
            }

            SaveMetadata();
        }

        public byte[] GetData() {
            return (byte[])Buffer.Clone();
        }

        private LabelType[] MakeLabelMap() {
            var map = new LabelType[Buffer.Length];
            foreach(var label in LabelDict.Values) {
                for(int i = 0; i < label.Size; i++) {
                    map[label.Address + i] = label.Type;
                }
            }
            return map;
        }

        public static void SaveMetadata() {
            StringBuilder sb = new StringBuilder();

            sb.Append("{\n");
            foreach(var key in Metadata.Keys) {
                var data = Metadata[key];
                sb.Append($"\t\"{key}\": {{\n");
                if(data.ContainsKey("Labels"))
                    sb.Append($"\t\t\"Labels\": {LabelDict.Serialize((LabelDict)data["Labels"], 3)},\n");
                if(data.ContainsKey("Notes")) {
                    string notes = ((string)data["Notes"]).Replace("\r\n", @"\r\n").Replace("\n", @"\n");
                    sb.Append($"\t\t\"Notes\": \"{notes}\",\n");
                }
                sb.Append("\t},\n");
            }
            sb.Append("}");

            File.WriteAllText($@"{Program.UserDir}\data.json", sb.ToString());
        }

        public static void LoadMetadata() {
            string raw = File.ReadAllText($@"{Program.UserDir}\data.json");
            var options = new JsonSerializerOptions() { AllowTrailingCommas = true };
            var json = JsonSerializer.Deserialize<JsonElement>(raw, options);
            foreach(var file in json.EnumerateObject()) {
                var labels = new LabelDict();
                var notes = "";
                foreach(var prop in file.Value.EnumerateObject()) {
                    switch(prop.Name) {
                        case "Labels":
                            labels = LabelDict.Deserialize(prop.Value);
                            break;
                        case "Notes":
                            notes = prop.Value.GetString();
                            break;
                    }
                }
                Metadata[file.Name] = new Dictionary<string, object>
                {
                    ["Labels"] = labels,
                    ["Notes"] = notes
                };
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}
