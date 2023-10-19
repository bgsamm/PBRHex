using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace PBRHex.Core.IO
{
    internal enum Endianness
    {
        LittleEndian,
        BigEndian
    }

    internal interface IByteStream
    {
        byte[] ReadBytes(long offset, int count);
    }

    internal class BytesReader
    {
        private readonly IByteStream stream;
        private readonly Endianness endianness;

        internal BytesReader(IByteStream stream, Endianness endianness) {
            this.stream = stream;
            this.endianness = endianness;
        }

        internal byte ReadByte(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 1);
            return bytes[0];
        }

        internal Int16 ReadInt16(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 2);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadInt16BigEndian(bytes)
                : BinaryPrimitives.ReadInt16LittleEndian(bytes);
        }

        internal Int32 ReadInt32(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 4);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadInt32BigEndian(bytes)
                : BinaryPrimitives.ReadInt32LittleEndian(bytes);
        }

        internal Int64 ReadInt64(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 8);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadInt64BigEndian(bytes)
                : BinaryPrimitives.ReadInt64LittleEndian(bytes);
        }

        internal UInt16 ReadUInt16(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 2);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadUInt16BigEndian(bytes)
                : BinaryPrimitives.ReadUInt16LittleEndian(bytes);
        }

        internal UInt32 ReadUInt32(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 4);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadUInt32BigEndian(bytes)
                : BinaryPrimitives.ReadUInt32LittleEndian(bytes);
        }

        internal UInt64 ReadUInt64(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 8);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadUInt64BigEndian(bytes)
                : BinaryPrimitives.ReadUInt64LittleEndian(bytes);
        }

        internal Single ReadSingle(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 4);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadSingleBigEndian(bytes)
                : BinaryPrimitives.ReadSingleLittleEndian(bytes);
        }

        internal Double ReadDouble(long offset) {
            byte[] bytes = stream.ReadBytes(offset, 8);
            
            return endianness == Endianness.BigEndian
                ? BinaryPrimitives.ReadDoubleBigEndian(bytes)
                : BinaryPrimitives.ReadDoubleLittleEndian(bytes);
        }

        internal string ReadString(long offset, int? length = null) {
            StringBuilder sb = new();
            char c;

            if (length is null) {
                // Null-terminated strings
                while ((c = (char)ReadByte(offset)) != '\0') {
                    sb.Append(c);
                    offset++;
                }
            }
            else {
                // Fixed-length strings
                for (int i = 0; i < length; i++) {
                    c = (char)ReadByte(offset);
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
