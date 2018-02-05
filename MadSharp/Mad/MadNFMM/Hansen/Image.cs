using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;
using Bitmap = SharpDX.Direct2D1.Bitmap;

namespace Cum
{
    public class Image : Bitmap
    {
        private readonly int _width;
        private readonly int _height;

        public Image(RenderTarget renderTarget, Size2 size) : base(renderTarget, size)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public Image(RenderTarget renderTarget, Size2 size, BitmapProperties bitmapProperties) : base(renderTarget,
            size, bitmapProperties)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public Image(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch) : base(renderTarget,
            size, dataPointer, pitch)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public Image(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch,
            BitmapProperties bitmapProperties) : base(renderTarget, size, dataPointer, pitch, bitmapProperties)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public Image(RenderTarget renderTarget, Bitmap bitmap) : base(renderTarget, bitmap)
        {
            _width = (int) bitmap.Size.Width;
            _height = (int) bitmap.Size.Height;
        }

        public Image(RenderTarget renderTarget, Bitmap bitmap, BitmapProperties? bitmapProperties) : base(renderTarget,
            bitmap, bitmapProperties)
        {
            _width = (int) bitmap.Size.Width;
            _height = (int) bitmap.Size.Height;
        }

        public Image(RenderTarget renderTarget, Surface surface) : base(renderTarget, surface)
        {
            _width = (int) Size.Width;
            _height = (int) Size.Height;
        }

        public Image(RenderTarget renderTarget, Surface surface, BitmapProperties? bitmapProperties) : base(
            renderTarget, surface, bitmapProperties)
        {
            _width = (int) Size.Width;
            _height = (int) Size.Height;
        }

        public Image(RenderTarget renderTarget, BitmapLock bitmapLock) : base(renderTarget, bitmapLock)
        {
            _width = (int) Size.Width;
            _height = (int) Size.Height;
        }

        public Image(RenderTarget renderTarget, BitmapLock bitmapLock, BitmapProperties? bitmapProperties) : base(
            renderTarget, bitmapLock, bitmapProperties)
        {
            _width = (int) Size.Width;
            _height = (int) Size.Height;
        }

        public Image(IntPtr nativePtr) : base(nativePtr)
        {
            _width = (int) Size.Width;
            _height = (int) Size.Height;
        }

        public int GetHeight(object o)
        {
            return _height;
        }

        public int GetWidth(object o)
        {
            return _width;
        }
    }
}