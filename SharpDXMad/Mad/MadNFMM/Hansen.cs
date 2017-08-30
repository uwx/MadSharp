using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;
using Bitmap = SharpDX.Direct2D1.Bitmap;

namespace Cum
{
    public class HansenSystem
    {
        public static void ArrayCopy(int[] src, int srcPos, int[] dest, int destPos, int length)
        {
            throw new System.NotImplementedException();
        }
    }
    public class HansenRandom
    {
        public static double Double()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class Math
    {
        public static int sqrt(int p0)
        {
            throw new System.NotImplementedException();
        }

        public static int abs(int p0)
        {
            throw new NotImplementedException();
        }

        public static float cos(double d)
        {
            throw new NotImplementedException();
        }

        public static float sin(double d)
        {
            throw new NotImplementedException();
        }

        public static double abs(float p0)
        {
            throw new NotImplementedException();
        }

        public static double abs(double p0)
        {
            throw new NotImplementedException();
        }

        public static double sqrt(float p0)
        {
            throw new NotImplementedException();
        }

        public static int toDegrees(object atan2)
        {
            throw new NotImplementedException();
        }

        public static object atan2(int i, int i1)
        {
            throw new NotImplementedException();
        }
    }

    internal class Image : Bitmap
    {
        public Image(RenderTarget renderTarget, Size2 size) : base(renderTarget, size)
        {
        }

        public Image(RenderTarget renderTarget, Size2 size, BitmapProperties bitmapProperties) : base(renderTarget, size, bitmapProperties)
        {
        }

        public Image(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch) : base(renderTarget, size, dataPointer, pitch)
        {
        }

        public Image(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch, BitmapProperties bitmapProperties) : base(renderTarget, size, dataPointer, pitch, bitmapProperties)
        {
        }

        public Image(RenderTarget renderTarget, Bitmap bitmap) : base(renderTarget, bitmap)
        {
        }

        public Image(RenderTarget renderTarget, Bitmap bitmap, BitmapProperties? bitmapProperties) : base(renderTarget, bitmap, bitmapProperties)
        {
        }

        public Image(RenderTarget renderTarget, Surface surface) : base(renderTarget, surface)
        {
        }

        public Image(RenderTarget renderTarget, Surface surface, BitmapProperties? bitmapProperties) : base(renderTarget, surface, bitmapProperties)
        {
        }

        public Image(RenderTarget renderTarget, BitmapLock bitmapLock) : base(renderTarget, bitmapLock)
        {
        }

        public Image(RenderTarget renderTarget, BitmapLock bitmapLock, BitmapProperties? bitmapProperties) : base(renderTarget, bitmapLock, bitmapProperties)
        {
        }

        public Image(IntPtr nativePtr) : base(nativePtr)
        {
        }
    }
}