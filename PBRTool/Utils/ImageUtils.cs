using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBRTool.Files;

namespace PBRTool.Utils
{
    public static class ImageUtils
    {
        public static Color RGB5A3toColor(int rgb5a3) {
            int r, g, b, a;
            if((rgb5a3 & 0x8000) == 0) {
                a = (rgb5a3 & 0x7000) >> 7;
                r = ((rgb5a3 & 0xf00) >> 8) * 0x11;
                g = ((rgb5a3 & 0xf0) >> 4) * 0x11;
                b = (rgb5a3 & 0xf) * 0x11;
            } else {
                a = 0xff;
                r = (rgb5a3 & 0x7c00) >> 7;
                g = (rgb5a3 & 0x3e0) >> 2;
                b = (rgb5a3 & 0x1f) << 3;
            }
            return Color.FromArgb(a, r, g, b);
        }

        public static Image DecodeTexture(GTX texture) {
            var bmp = new Bitmap(texture.Width, texture.Height, PixelFormat.Format32bppArgb);
            for(int x = 0; x < texture.Width; x++) {
                for(int y = 0; y < texture.Height; y++) {
                    bmp.SetPixel(x, y, texture.GetPixel(x, y));
                }
            }
            return bmp;
        }

        public static byte[] CompressImage(Image image, ImageEncoding encoding) {
            if(encoding != ImageEncoding.RGB5A3)
                throw new NotImplementedException();
            int w = image.Width, h = image.Height,
                block_width = 4, block_height = 4,
                blocks_x = (w + block_width - 1) / block_width, 
                blocks_y = (h + block_height - 1) / block_height,
                data_width = blocks_x * block_width,
                data_height = blocks_y * block_height;
            var bmp = (Bitmap)image;
            var data = new byte[data_width * data_height * 2]; // 2 bytes per pixel
            for(int x = 0; x < w; x++) {
                for(int y = 0; y < h; y++) {
                    var px = bmp.GetPixel(x, y);
                    int block_x = x / block_width,
                        block_y = y / block_height;
                    int idx = (block_y * block_height * data_width +
                        block_x * block_height * block_width +
                        (y % block_height) * block_width +
                        (x % block_width)) * 2;
                    int val;
                    if(px.A < 255) {
                        val = ((px.A >> 5) << 12) +
                              ((px.R / 0x11) << 8) +
                              ((px.G / 0x11) << 4) +
                              (px.B / 0x11);
                    } else {
                        val = 0x8000 +
                              ((px.R >> 3) << 10) +
                              ((px.G >> 3) << 5) +
                              (px.B >> 3);
                    }
                    byte[] bytes = HexUtils.ShortToBytes((short)val);
                    Array.Copy(bytes, 0, data, idx, 2);
                }
            }
            return data;
        }

        public static byte[] ImageToGTX(Image image, ImageEncoding encoding) {
            if(encoding != ImageEncoding.RGB5A3)
                throw new NotImplementedException();
            int header_size = 0x80;
            byte[] data = CompressImage(image, encoding),
                gtx = new byte[header_size + data.Length];
            gtx[5] = 1;
            HexUtils.ShortToBytes((short)image.Width).CopyTo(gtx, 0);
            HexUtils.ShortToBytes((short)image.Height).CopyTo(gtx, 2);
            HexUtils.IntToBytes((int)encoding).CopyTo(gtx, 8);
            HexUtils.IntToBytes(header_size).CopyTo(gtx, 0x28);
            HexUtils.IntToBytes(data.Length).CopyTo(gtx, 0x4c);
            data.CopyTo(gtx, header_size);
            return gtx;
        }
    }
}
