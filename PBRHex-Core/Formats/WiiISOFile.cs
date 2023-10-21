using PBRHex.Core.IO;

namespace PBRHex.Core.Formats
{
    public class WiiISOFile
    {
        public string gameID;
        public byte[] wiiMagicBytes;
        public byte[] gcnMagicBytes;

        private WiiISOFile(string gameID, byte[] wiiMagicBytes, byte[] gcnMagicBytes) {
            this.gameID = gameID;
            this.wiiMagicBytes = wiiMagicBytes;
            this.gcnMagicBytes = gcnMagicBytes;
        }

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

            WiiISOFile _file = new(
                gameID,
                wiiMagicBytes,
                gcnMagicBytes
            );

            return _file;
        }
    }
}