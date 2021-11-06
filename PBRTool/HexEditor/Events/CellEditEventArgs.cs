using System;

namespace PBRTool.Events
{
    public class CellEditEventArgs : EventArgs
    {
        public readonly int Address;
        public readonly byte Value;

        public CellEditEventArgs(int address, byte value) : base() {
            Address = address;
            Value = value;
        }
    }
}
