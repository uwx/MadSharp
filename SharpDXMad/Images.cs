using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;

namespace SharpDXMad
{
    public class Images
    {
        /// <summary>
        /// Loads a Direct2D Bitmap from a file using System.Drawing.Image.FromFile(...)
        /// </summary>
        /// <param name="renderTarget">The render target.</param>
        /// <param name="file">The file.</param>
        /// <returns>A D2D1 Bitmap</returns>
        public static Bitmap LoadFromFile(SharpDX.Direct2D1.RenderTarget renderTarget, string file)
        {
            // Loads from file using System.Drawing.Image
            using (var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(file))
            {
                return BitmapToImage(renderTarget, bitmap);
            }
        }

        /// <summary>
        /// Loads a Direct2D Bitmap from a file using System.Drawing.Image.FromFile(...)
        /// </summary>
        /// <param name="renderTarget">The render target.</param>
        /// <param name="file">The file.</param>
        /// <returns>A D2D1 Bitmap</returns>
        public static Bitmap LoadFromFile(SharpDX.Direct2D1.RenderTarget renderTarget, byte[] file)
        {
            // Loads from file using System.Drawing.Image
            using (var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(new MemoryStream(file)))
            {
                return BitmapToImage(renderTarget, bitmap);
            }
        }

        private static Bitmap BitmapToImage(RenderTarget renderTarget, System.Drawing.Bitmap bitmap)
        {
            var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapProperties = new SharpDX.Direct2D1.BitmapProperties(
                new SharpDX.Direct2D1.PixelFormat(Format.R8G8B8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied));
            var size = new Size2(bitmap.Width, bitmap.Height);

            // Transform pixels from BGRA to RGBA
            var stride = bitmap.Width * sizeof(int);
            using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
            {
                // Lock System.Drawing.Bitmap
                var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                // ReSharper disable TooWideLocalVariableScope
                int r, g, b, a, rgba, offset;
                IntPtr zerothPixel;
                // ReSharper restore TooWideLocalVariableScope

                // Convert all pixels 
                for (var y = 0; y < bitmap.Height; y++)
                {
                    offset = bitmapData.Stride * y;
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        zerothPixel = bitmapData.Scan0;
                        b = Marshal.ReadByte(zerothPixel, offset++);
                        g = Marshal.ReadByte(zerothPixel, offset++);
                        r = Marshal.ReadByte(zerothPixel, offset++);
                        a = Marshal.ReadByte(zerothPixel, offset++);
                        rgba = r | (g << 8) | (b << 16) | (a << 24);
                        tempStream.Write(rgba);
                    }
                }
                bitmap.UnlockBits(bitmapData);
                tempStream.Position = 0;

                return new Bitmap(renderTarget, size, tempStream, stride, bitmapProperties);
            }
        }
    }
}