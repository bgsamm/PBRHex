using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PBRHex.Utils
{
    public static class HexUtils
    {
        /// <summary>
        /// Converts an array of bytes to an ASCII string, replacing
        /// non-alphanumeric or symbolic characters with periods.
        /// </summary>
        /// <param name="bytes">The bytes to be converted to ASCII.</param>
        public static string BytesToAscii(byte[] bytes) {
            byte[] buf = new byte[bytes.Length];
            for(int i = 0; i < bytes.Length; i++) {
                byte b = bytes[i];
                if(b >= 32 && b <= 126)
                    buf[i] = b;
                else
                    buf[i] = 46; // period char
            }
            return Encoding.ASCII.GetString(buf);
        }

        public static byte[] AsciiToBytes(string ascii, bool nullTerminated = false) {
            byte[] bytes =  Encoding.ASCII.GetBytes(ascii);
            if(nullTerminated)
                bytes = bytes.Concat(new byte[] { 0 }).ToArray();
            return bytes;
        }

        public static int BytesToInt(byte[] bytes) {
            uint n = 0;
            for(int i = 0; i < bytes.Length; i++) {
                // since I'm not capping at 4 bytes, need to check if calculation overflows
                n = checked(n + (uint)(bytes[bytes.Length - i - 1] * Math.Pow(256, i)));
            }
            return (int)n;
        }

        public static float BytesToFloat(byte[] bytes) {
            return BitConverter.ToSingle(bytes.Reverse().ToArray(), 0);
        }

        public static byte[] ShortToBytes(short val) {
            return new byte[] {
                (byte)((val >> 8) % 0x100),
                (byte)(val % 0x100)
            };
        }

        public static byte[] IntToBytes(uint val) {
            return IntToBytes((int)val);
        }

        public static byte[] IntToBytes(int val) {
            return new byte[] {
                (byte)((val >> 24) % 0x100),
                (byte)((val >> 16) % 0x100),
                (byte)((val >> 8) % 0x100),
                (byte)(val % 0x100)
            };
        }

        public static byte[] FloatToBytes(float f) {
            return BitConverter.GetBytes(f).Reverse().ToArray();
        }

        public static byte[] FloatToBytes(double d) {
            return FloatToBytes((float)d);
        }

        public static string IntToHex(int val, int len = 8) {
            return IntToHex((uint)val, len);
        }

        public static string IntToHex(uint val, int len = 8) {
            string hex = Convert.ToString(val, 16).ToUpper().PadLeft(len, '0');
            return hex.Substring(hex.Length - len);
        }

        public static int HexToInt(string hex) {
            if(hex.StartsWith("-"))
                return -Convert.ToInt32(hex.Substring(1), 16);
            return Convert.ToInt32(hex, 16);
        }

        public static uint HexToUInt(string hex) {
            return Convert.ToUInt32(hex, 16);
        }

        public static float HexToFloat(string hex) {
            return BytesToFloat(HexToBytes(hex));
        }

        public static byte[] HexToBytes(string hex) {
            // remove spaces
            hex = Regex.Replace(hex, @"[\s]", "").ToUpper();
            // ensure string has even num. of digits
            if(hex.Length % 2 == 1)
                hex = "0" + hex;
            var bytes = new byte[hex.Length / 2];
            for(int i = 0; i < hex.Length / 2; i++) {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        public static string BytesToHex(byte[] bytes) {
            var hex = new StringBuilder();
            foreach(byte b in bytes)
                hex.Append($"{b:X2}");
            return hex.ToString();
        }

        public static string IntToSignedHex(int i) {
            return $"{(i < 0 ? "-" : "")}0x{Math.Abs(i):X}";
        }

        public static int SignedHexToInt(string hex) {
            if(hex[0] == '-')
                return -Convert.ToInt32(hex.Substring(1), 16);
            return Convert.ToInt32(hex, 16);
        }
    }
}