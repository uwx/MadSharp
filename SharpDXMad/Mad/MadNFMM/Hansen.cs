using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MadGame;
using MiscUtil;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;
using SharpDXMad;
using Bitmap = SharpDX.Direct2D1.Bitmap;

namespace Cum
{
    internal struct DistHolder
    {
        public int Id;
        public int Dist;

        public DistHolder(int dist, int id)
        {
            Dist = dist;
            Id = id;
        }
    }
    
    public class HansenData
    {
        public static void SetCookie(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
    public class HansenSystem
    {
        public static void ArrayCopy(int[] src, int srcPos, int[] dest, int destPos, int length)
        {
            Array.Copy(src, srcPos, dest, destPos, length);
        }
        public static void ArrayCopy<T>(T[] src, int srcPos, T[] dest, int destPos, int length)
        {
            Array.Copy(src, srcPos, dest, destPos, length);
        }

        public static void RequestSleep(long ms)
        {
            throw new NotImplementedException();
        }

        public static void Exit(int i)
        {
            if (System.Windows.Forms.Application.MessageLoop) 
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }
    }
    public class HansenRandom
    {
    
        public static double Double()
        {
            return StaticRandom.NextDouble();
        }
    }
    
    internal class Random {
        private System.Random _rand;

        public Random(long l)
        {
            _rand = new System.Random((int)l);
        }

        public double nextDouble()
        {
            return _rand.NextDouble();
        }
    }

    public class Date
    {
        private readonly long _time;

        public Date()
        {
            _time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public long getTime()
        {
            return _time;
        }
    }

    internal class FileUtil
    {
        public static void loadFiles(string folder, string[] fileNames, Action<byte[], int> p3)
        {
            fileNames = fileNames.CloneArray();
            foreach (var file in Directory.GetFiles(folder))
            {
                var a = fileNames.IndexOf(Path.GetFileNameWithoutExtension(file));
                if (a != -1)
                {
                    p3.Invoke(System.IO.File.ReadAllBytes(file), a);
                }
            }
        }
    }

    public class FontMetrics
    {
        public int stringWidth(string astring)
        {
            return 50;
        }
    }

    public struct Color
    {
        public int _r, _g, _b, _a;
        
        public Color(int r, int g, int b, int a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
        public Color(int r, int g, int b)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = 255;
        }

        public Color(int packed)//TODO uint
        {
            // TODO order?
            _b = (byte)(packed);
            _g = (byte)(packed >> 8);
            _r = (byte)(packed >> 16);
            _a = (byte)(packed >> 24);
        }
        
        public Color(uint packed)
        {
            // TODO order?
            _b = (byte)(packed);
            _g = (byte)(packed >> 8);
            _r = (byte)(packed >> 16);
            _a = (byte)(packed >> 24);
        }

        public static Color getHSBColor(float p0, float p1, float p2)
        {
            return new Color(Colors.HSBtoRGB(p0, p1, p2));
        }

        public int getRed()
        {
            return _r;
        }
        public int getGreen()
        {
            return _g;
        }
        public int getBlue()
        {
            return _b;
        }

        public static void RGBtoHSB(int i, int i1, int i2, float[] fs)
        {
            Colors.RGBtoHSB(i, i1, i2, fs);
        }

        public Color darker()
        {
            throw new NotImplementedException();
        }

        public Color brighter()
        {
            throw new NotImplementedException();
        }

        public int getRGB()
        {
            throw new NotImplementedException();
        }
    }

    internal class RadicalMusic
    {
        public RadicalMusic(File file)
        {
//            throw new NotImplementedException();
        }

        public void setPaused(bool p0)
        {
//            throw new NotImplementedException();
        }

        public void unload()
        {
//            throw new NotImplementedException();
        }

        public void play()
        {
//            throw new NotImplementedException();
        }
    }
    
    public static class ArrayExt
    {
        private static readonly System.Random Rng = new System.Random();
        
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

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = Rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }
            return list;
        }

        public static void sort<T>(T[] arr, Comparer<T> comparator)
        {
            Array.Sort(arr, comparator);
        }
        
        public static void sort<T>(T[,] arr, Comparer<T[]> comparator)
        {
            Array.Sort(arr, comparator);
        }
        
        ///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="predicate">The expression to test the items against.</param>
        ///<returns>The index of the first matching item, or -1 if no items match.</returns>
        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate) {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var retVal = 0;
            foreach (var item in items) {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }

        ///<summary>Finds the index of the first occurrence of an item in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="target">The item to find.</param>
        ///<returns>The index of the first matching item, or -1 if the item was not found.</returns>
        public static int IndexOf<T>(this IEnumerable<T> items, T target)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var retVal = 0;
            foreach (var item in items) {
                if (Equals(item, target)) return retVal;
                retVal++;
            }
            return -1;
        }
    }

    public static class StringShim
    {
        public static bool startsWith(this string self, string other)
        {
            return self.StartsWith(other);
        }
        public static bool endsWith(this string self, string other)
        {
            return self.EndsWith(other);
        }
        public static bool equals(this string self, string other)
        {
            return self.Equals(other);
        }
        public static bool contains(this string self, string other)
        {
            return self.Contains(other);
        }

        public static int length(this string self)
        {
            return self.Length;
        }
        public static char charAt(this string self, int at)
        {
            return self[at];
        }

        public static bool equalsIgnoreCase(this string self, string other)
        {
            return self.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static string SubFromEnd(this string self, int amount)
        {
            return self.Substring(0, self.Length - amount);
        }
    }

    internal static class ImageIO
    {
        public static Image read(File file)
        {
            return new Image(G.D2D, Images.LoadFromFile(G.D2D, file.Path));
        }

        public static void GrabPixels(Image image, int[] flexpix)
        {
            throw new NotImplementedException();
            /*
            
                PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 800, 450, flexpix, 0, 800);
                try {
                    pixelgrabber.grabPixels();
                } catch (InterruptedException ignored) {

                }*/
        }

        public static Image read(byte[] file)
        {
            return new Image(G.D2D, Images.LoadFromFile(G.D2D, file));
        }
    }

    public static class HMath
    {
        public static int SafeAbs(int value)
        {
            return value == int.MinValue ? int.MaxValue : Math.Abs(value);
        }
    }

    internal struct File
    {
        internal string Path;

        public File(string str)
        {
            Path = str;
        }

        public File(File parent, string child)
        {
            Path = $@"{parent.Path}\{child}";
        }

        public File parent => new File(_getParent());
        public string file => System.IO.Path.GetFileNameWithoutExtension(Path);

        private string _getParent() => System.IO.Path.GetDirectoryName(Path);
    }

    public struct Font
    {
        private string _fontName;
        private int _flags;
        private int _size;

        public Font(string fontName, int flags, int size)
        {
            _fontName = fontName;
            _flags = flags;
            _size = size;
        }
    }

    public class Image : Bitmap
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

        public int getHeight(object o)
        {
            throw new NotImplementedException();
        }

        public int getWidth(object o)
        {
            throw new NotImplementedException();
        }
    }

    internal class SoundClip
    {
        public static ContO source;
        public static ContO player;

        public SoundClip(string s)
        {
            throw new NotImplementedException();
        }

        public void play()
        {
            throw new NotImplementedException();
        }

        public void checkopen()
        {
            throw new NotImplementedException();
        }

        public void loop()
        {
            throw new NotImplementedException();
        }

        public void stop()
        {
            throw new NotImplementedException();
        }

        public static void stopAll()
        {
            throw new NotImplementedException();
        }
    }

    internal class TrackZipLoader
    {
        public static RadicalMusic loadLegacy(int i, string astring, int i52)
        {
            throw new NotImplementedException();
        }
    }
}