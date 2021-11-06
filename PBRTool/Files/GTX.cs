using System;
using System.Drawing;
using PBRTool.Utils;

namespace PBRTool.Files
{
    public class GTX : FileBuffer
    {
        public readonly int Width;
        public readonly int Height;
        public readonly ImageEncoding Encoding;
        public readonly PaletteFormat PaletteEncoding;

        private readonly int ImageAddress;
        private readonly int PaletteAddress;

        public GTX(string path) : base(path) {
            Width = ReadShort(0);
            Height = ReadShort(2);
            Encoding = (ImageEncoding)ReadInt(8);
            PaletteEncoding = (PaletteFormat)ReadInt(0xC);

            ImageAddress = ReadInt(0x28);
            PaletteAddress = ReadInt(0x48);
        }

        public int GetImageDataSize() {
            if(PaletteAddress > 0)
                return Width * Height;
            return ReadInt(0x4c);
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
            return GetColorFromPalette(ReadByte(ImageAddress + idx));
        }

        public Color GetColorFromPalette(int index) {
            if(PaletteEncoding != PaletteFormat.RGB5A3)
                throw new NotImplementedException();
            int rgb5a3 = ReadShort(PaletteAddress + index * 2);
            return ImageUtils.RGB5A3toColor(rgb5a3);
        }
    }
}
