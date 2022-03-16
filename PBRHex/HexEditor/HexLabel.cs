using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

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