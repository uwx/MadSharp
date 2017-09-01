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
    
    internal class Random {
        public Random(long l)
        {
            throw new NotImplementedException();
        }

        public double nextDouble()
        {
            throw new NotImplementedException();
        }
    }

    internal class FontMetrics
    {
        
    }

    public class Color
    {
        public Color(int r, int g, int b, int a)
        {
            throw new NotImplementedException();
        }
        public Color(int r, int g, int b)
        {
            throw new NotImplementedException();
        }

        public static Color getHSBColor(float p0, float p1, float p2)
        {
            throw new NotImplementedException();
        }

        public int getRed()
        {
            throw new NotImplementedException();
        }
        public int getGreen()
        {
            throw new NotImplementedException();
        }
        public int getBlue()
        {
            throw new NotImplementedException();
        }

        public static void RGBtoHSB(int i, int i1, int i2, float[] fs)
        {
            throw new NotImplementedException();
        }

        public Color darker()
        {
            throw new NotImplementedException();
        }

        public Color brighter()
        {
            throw new NotImplementedException();
        }
    }

    internal class RadicalMusic
    {
        
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

        public static double atan(double p0)
        {
            throw new NotImplementedException();
        }

        public static int max(int i, int i1)
        {
            throw new NotImplementedException();
        }

        public static int round(double d)
        {
            throw new NotImplementedException();
        }
    }

    public static class ArrayExt
    {
        public static T[] CloneArray<T>(this T[] arr)
        {
            var to = new T[arr.Length];
            arr.CopyTo(to, 0);
            return to;
        }
        
        public static T[] Slice<T>(this T[,] arr2, int i)
        {
            var len = arr2.GetLength(0);
            var arr = new T[len];
            for (var j = 0; j < len; j++)
            {
                arr[j] = arr2[i, j];
            }
            return arr;
        }

        public static T[][] New<T>(int l0, int l1)
        {
            var arr = new T[l0][];
            for (var i = 0; i < l0; i++)
            {
                arr[i] = new T[l1];
            }
            return arr;
        }
        
        public static T[][][] New<T>(int l0, int l1, int l2)
        {
            var arr = new T[l0][][];
            for (var i = 0; i < l0; i++)
            {
                arr[i] = new T[l1][];
                for (var j = 0; j < l0; j++)
                {
                    arr[i][j] = new T[l2];
                }
            }
            return arr;
        }

        public static void sort<T>(T[] arr)
        {//TODO
            Array.Sort(arr);
        }

        public static void sort<T>(T[] arr, int from, int to)
        {
            Array.Sort(arr, from, to);
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

    internal class SoundClip
    {
        public void play()
        {
            throw new NotImplementedException();
        }

        public void checkopen()
        {
            throw new NotImplementedException();
        }
    }
}