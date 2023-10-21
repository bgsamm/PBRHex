using PBRHex.Core.IO;

namespace PBRHex.Core.Formats
{
    public class WiiISOFile
    {
        public required string gameID;
        public required byte[] wiiMagicBytes;
        public required byte[] gcnMagicBytes;

        private WiiISOFile() { }

        public static WiiISOFile Parse(IByteStream stream) {
            BytesReader reader = new(stream);

            string gameID = reader.ReadString(0x0, 6);

            byte[] wiiMagicBytes = new byte[4];
            uint _offset1 = 0x18;
            for (int _i1 = 0; _i1 < 4; _i1++) {
                wiiMagicBytes[_i1] = reader.ReadByte(_offset1);
                _offset1 += 1;
            }

            byte[] gcnMagicBytes = new byte[4];
            uint _offset2 = 0x1c;
            for (int _i1 = 0; _i1 < 4; _i1++) {
                gcnMagicBytes[_i1] = reader.ReadByte(_offset2);
                _offset2 += 1;
            }

            WiiISOFile _file = new()
            {
                gameID = gameID,
                wiiMagicBytes = wiiMagicBytes,
                gcnMagicBytes = gcnMagicBytes
            };

            return _file;
        }
    }
}