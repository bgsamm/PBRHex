using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace PBRTool.HexLabels
{
    public class ReadOnlyLabelDict : IEnumerable<HexLabel>
    {
        private readonly LabelDict Dict;

        public ReadOnlyLabelDict(LabelDict dict) {
            Dict = dict;
        }

        public bool ContainsAddress(int address) {
            return Dict.ContainsKey(address);
        }

        public int IndexOf(int address) {
            return Dict.IndexOf(address);
        }

        public IEnumerator<HexLabel> GetEnumerator() {
            return Dict.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    public class LabelDict : SortedDictionary<int, HexLabel>
    {
        //public ReadOnlyCollection<HexLabel> List => new ReadOnlyCollection<HexLabel>(Values.ToList());

        public void Add(HexLabel label) {
            Add(label.Address, label);
        }

        public void Remove(HexLabel label) {
            Remove(label.Address);
        }

        public int IndexOf(int address) {
            return Keys.ToList().IndexOf(address);
        }

        public static string Serialize(LabelDict dict, int indent) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n");
            foreach(var label in dict.Values) {
                sb.Append($"{new string('\t', indent)}{HexLabel.Serialize(label, indent + 1)},\n");
            }
            sb.Append($"{new string('\t', indent - 1)}]");
            return sb.ToString();
        }

        public static LabelDict Deserialize(JsonElement json) {
            LabelDict dict = new LabelDict();
            // enumerate over labels
            foreach(var elem in json.EnumerateArray()) {
                dict.Add(HexLabel.Deserialize(elem));
            }
            return dict;
        }
    }
}
