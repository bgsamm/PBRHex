using System;
using System.Drawing;
using PBRHex.Utils;

namespace PBRHex.Files
{
    public class GTX
    {
        public int ID => Buffer.ID;

        public readonly int Width;
        public readonly int Height;
        public readonly ImageEncoding Encoding;
        public readonly PaletteFormat PaletteEncoding;

        private readonly int ImageAddress;
        private readonly int PaletteAddress;
        private readonly FileBuffer Buffer;

        public GTX(FileBuffer buffer) {
            Buffer = buffer;

            Width = Buffer.ReadShort(0);
            Height = Buffer.ReadShort(2);
            Encoding = (ImageEncoding)Buffer.ReadInt(8);
            PaletteEncoding = (PaletteFormat)Buffer.ReadInt(0xC);

            ImageAddress = Buffer.ReadInt(0x28);
            PaletteAddress = Buffer.ReadInt(0x48);
        }

        public int GetImageDataSize() {
            if(PaletteAddress > 0)
                return Width * Height;
            return Buffer.ReadInt(0x4c);
        }

        public Color GetPixel(int x, int y) {
            if(PaletteEncoding != PaletteFormat.RGB5A3)
                throw new NotImplementedException();
            int block_width = 8, block_height = 4,
                block_x = x / block_width, 
                block_y = y / block_height,
                data_width = (Width + 7) / block_width * block_width;
            int idx = block_y * block_height * data_width +
                block_x * block_height * block_width +
                (y % block_height) * block_width +
                (x % block_width);
            return GetColorFromPalette(Buffer.ReadByte(ImageAddress + idx));
        }

        public Color GetColorFromPalette(int index) {
            if(PaletteEncoding != PaletteFormat.RGB5A3)
                throw new NotImplementedException();
            int rgb5a3 = Buffer.ReadShort(PaletteAddress + index * 2);
            return ImageUtils.RGB5A3toColor(rgb5a3);
        }

        public static explicit operator GTX(FileBuffer file) => new GTX(file);
    }
}
