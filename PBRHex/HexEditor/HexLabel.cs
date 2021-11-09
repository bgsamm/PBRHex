using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Text.Json;

namespace PBRHex.HexLabels
{
    public class HexLabel
    {
        public static ReadOnlyDictionary<LabelType, Color> LabelColors;

        public string Name { get; set; }
        public int Address { get; set; }
        public int Size { get; set; }
        public LabelType Type { get; set; }

        static HexLabel() {
            var colors = new Dictionary<LabelType, Color>
            {
                { LabelType.None, Color.White },
                { LabelType.Empty, Color.Silver },
                { LabelType.Pointer, Color.LightGreen },
                { LabelType.Int, Color.Lavender },
                { LabelType.Float, Color.Violet },
                { LabelType.String, Color.Salmon },
                { LabelType.Color, Color.Magenta },
            };
            LabelColors = new ReadOnlyDictionary<LabelType, Color>(colors);
        }

        public HexLabel(int address, int size, LabelType type, string name) {
            Address = address;
            Size = size;
            Name = name;
            Type = type;
        }

        public override string ToString() {
            return Name;
        }

        public static string Serialize(HexLabel label, int indent) {
            StringBuilder sb = new StringBuilder();
            string indentation = new string('\t', indent);
            sb.Append("{\n");
            sb.Append($"{indentation}\"Name\": \"{label.Name.Replace("\"", "\\\"")}\",\n");
            sb.Append($"{indentation}\"Address\": {label.Address},\n");
            sb.Append($"{indentation}\"Size\": {label.Size},\n");
            sb.Append($"{indentation}\"Type\": \"{label.Type}\",\n");
            sb.Append($"{new string('\t', indent - 1)}}}");
            return sb.ToString();
        }

        public static HexLabel Deserialize(JsonElement json) {
            LabelType type = LabelType.None;
            int address = 0, size = 0;
            string name = "";

            // enumerate over label properties
            foreach(var p2 in json.EnumerateObject()) {
                switch(p2.Name) {
                    case "Name":
                        name = p2.Value.GetString();
                        break;
                    case "Address":
                        address = p2.Value.GetInt32();
                        break;
                    case "Size":
                        size = p2.Value.GetInt32();
                        break;
                    case "Type":
                        type = (LabelType)Enum.Parse(typeof(LabelType), p2.Value.GetString(), false);
                        break;
                }
            }
            return new HexLabel(address, size, type, name);
        }
    }

    public enum LabelType 
    {
        None,
        Empty,
        Pointer,
        Int,
        Float,
        String,
        Color,
    }
}