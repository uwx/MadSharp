using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MadGame;
using MiscUtil;
using NAudio.Wave;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.WIC;
using SharpDXMad;
using Bitmap = SharpDX.Direct2D1.Bitmap;
using TextRenderer = System.Windows.Forms.TextRenderer;

namespace Cum
{
    internal struct DistHolder
    {
        public int Id;
        public int Dist;

        public DistHolder(int id, int dist)
        {
            Dist = dist;
            Id = id;
        }
    }

    public class HansenData
    {
        public static void SetCookie(string[] lines)
        {
//            throw new NotImplementedException();
        }
    }

    public static class HansenSystem
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
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        public static float Cap(this float f)
        {
            return float.IsNaN(f) ? 0 : f;
        }

        public static double Cap(this double f)
        {
            return double.IsNaN(f) ? 0 : f;
        }

        public static float CapF(this double f)
        {
            return (float) (double.IsNaN(f) ? 0 : f);
        }
    }

    public class HansenRandom
    {
        public static double Double()
        {
            return StaticRandom.NextDouble();
        }
    }

    internal class Random
    {
        private System.Random _rand;

        public Random(long l)
        {
            _rand = new System.Random((int) l);
        }

        public double NextDouble()
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

        public long GetTime()
        {
            return _time;
        }
    }

    internal class FileUtil
    {
        public static void LoadFiles(string folder, string[] fileNames, Action<byte[], int> p3)
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

    public struct FontMetrics
    {
        private readonly TextFormat _textFormat;

        public FontMetrics(TextFormat font)
        {
            _textFormat = font;
        }

        public int StringWidth(string astring)
        {
            var layout = new TextLayout(G.FactoryDW, astring, _textFormat, 1024, _textFormat.FontSize);
            return (int)layout.Metrics.Width;
        }

        public int Height(string astring)
        {
            return (int)_textFormat.FontSize;
        }
    }

    public struct CachedFont
    {
        public readonly TextFormat Format;
        public FontMetrics Metrics;

        public CachedFont((TextFormat, FontMetrics) res)
        {
            Format = res.Item1;
            Metrics = res.Item2;
        }
    }

    public static class Fonts
    {
        private static readonly Dictionary<Font, CachedFont> Dict = new Dictionary<Font, CachedFont>();

        public static CachedFont GetOrCompute(Font fontCached, Func<(TextFormat, FontMetrics)> func)
        {
            if (Dict.ContainsKey(fontCached))
            {
                return Dict[fontCached];
            }
            return Dict[fontCached] = new CachedFont(func());
        }
    }

    public struct Color
    {
        public readonly int R, G, B, A;

        public Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Color(int packed) //TODO uint
        {
            // TODO order?
            B = (byte) (packed & 0xFF);
            G = (byte) (packed >> 8 & 0xFF);
            R = (byte) (packed >> 16 & 0xFF);
            A = (byte) (packed >> 24 & 0xFF);
        }

        public Color(uint packed)
        {
            // TODO order?
            B = (byte) (packed & 0xFF);
            G = (byte) (packed >> 8 & 0xFF);
            R = (byte) (packed >> 16 & 0xFF);
            A = (byte) (packed >> 24 & 0xFF);
        }

        public static Color GetHSBColor(float hue, float saturation, float brightness)
        {
            var v = Colors.HSBtoRGB(hue, saturation, brightness);
            return new Color(v.r, v.g, v.b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetRed()
        {
            return R;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetGreen()
        {
            return G;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetBlue()
        {
            return B;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RGBtoHSB(int i, int i1, int i2, float[] fs)
        {
            Colors.RGBtoHSB(i, i1, i2, fs);
        }

        private const double Factor = 0.7;

        public Color Darker()
        {
            return new Color(Math.Max((int) (R * Factor), 0),
                Math.Max((int) (G * Factor), 0),
                Math.Max((int) (B * Factor), 0),
                A);
        }

        public Color Brighter()
        {
            var r = R;
            var g = G;
            var b = B;
            var alpha = A;

            /* From 2D group:
             * 1. black.brighter() should return grey
             * 2. applying brighter to blue will always return blue, brighter
             * 3. non pure color (non zero rgb) will eventually return white
             */
            const int i = (int) (1.0 / (1.0 - Factor));
            if (r == 0 && g == 0 && b == 0)
            {
                return new Color(i, i, i, alpha);
            }
            if (r > 0 && r < i)
            {
                r = i;
            }

            if (g > 0 && g < i)
            {
                g = i;
            }

            if (b > 0 && b < i)
            {
                b = i;
            }

            return new Color(Math.Min((int) (r / Factor), 255),
                Math.Min((int) (g / Factor), 255),
                Math.Min((int) (b / Factor), 255),
                alpha);
        }

        public int GetRGB()
        {
            var packed = 0;
            packed |= (byte) (B & 0xFF);
            packed |= (byte) ((G & 0xFF) >> 8);
            packed |= (byte) ((R & 0xFF) >> 16);
            packed |= (byte) ((A & 0xFF) >> 24);
            return packed;
        }
    }

    internal class RadicalMusic
    {
        public RadicalMusic(File file)
        {
//            throw new NotImplementedException();
        }

        public RadicalMusic()
        {
//            throw new NotImplementedException();
        }

        public void SetPaused(bool p0)
        {
//            throw new NotImplementedException();
        }

        public void Unload()
        {
//            throw new NotImplementedException();
        }

        public void Play()
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
            var len = arr2.GetLength(1);
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

        public static void Sort<T>(T[] arr)
        {
//TODO
            Array.Sort(arr);
        }

        public static void Sort<T>(T[] arr, int from, int to)
        {
            Array.Sort(arr, from, to);
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void Sort<T>(T[] arr, Comparer<T> comparator)
        {
            Array.Sort(arr, comparator);
        }

        public static void Sort<T>(T[,] arr, Comparer<T[]> comparator)
        {
            Array.Sort(arr, comparator);
        }

        ///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="predicate">The expression to test the items against.</param>
        ///<returns>The index of the first matching item, or -1 if no items match.</returns>
        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var retVal = 0;
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    return retVal;
                }

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
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var retVal = 0;
            foreach (var item in items)
            {
                if (Equals(item, target))
                {
                    return retVal;
                }

                retVal++;
            }
            return -1;
        }
    }

    public static class StringShim
    {
        public static int Length(this string self)
        {
            return self.Length;
        }

        public static char CharAt(this string self, int at)
        {
            return self[at];
        }

        public static bool EqualsIgnoreCase(this string self, string other)
        {
            return self.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static string SubFromEnd(this string self, int amount)
        {
            return self.Substring(0, self.Length - amount);
        }
    }

    internal static class ImageIo
    {
        public static Image Read(File file)
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

        public static Image Read(byte[] file)
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

        public File Parent => new File(_getParent());
        public string file => System.IO.Path.GetFileNameWithoutExtension(Path);

        private string _getParent() => System.IO.Path.GetDirectoryName(Path);
    }

    public struct Font
    {
        internal string FontName;
        private int _flags;
        internal int Size;

        public Font(string fontName, int flags, int size)
        {
            FontName = fontName;
            _flags = flags;
            Size = size;
        }
    }

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
    
    // http://mark-dot-net.blogspot.com/2009/10/looped-playback-in-net-with-naudio.html
    /// <summary>
    /// Stream for looping playback
    /// </summary>
    public class LoopStream : WaveStream
    {
        WaveStream sourceStream;

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        /// <summary>
        /// Use this to turn looping on or off
        /// </summary>
        public bool EnableLooping { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        /// <inheritdoc />
        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length => sourceStream.Length;

        /// <inheritdoc />
        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                var bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }

    internal class SoundClip
    {
        public static ContO Source;
        public static ContO Player;
        private readonly AudioFileReader _audioFile;
        private readonly WaveOutEvent _outputDevice;
        private readonly LoopStream _loop;

        public SoundClip(string s)
        {
            _audioFile = new AudioFileReader(s);
            _loop = new LoopStream(_audioFile);
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_loop);
        }

        public void Play()
        {
            _loop.EnableLooping = false;
            _outputDevice.Play();
        }

        public void Checkopen()
        {
        }

        public void Loop()
        {
            _loop.EnableLooping = true;
            _outputDevice.Play();
        }

        public void Stop()
        {
            _outputDevice.Stop();
        }

        public static void StopAll()
        {
//            _audioFile.Dispose();
//            _outputDevice.Dispose();
        }
    }

    internal class TrackZipLoader
    {
        public static RadicalMusic LoadLegacy(int i, string astring, int i52)
        {
//            throw new NotImplementedException();
            return new RadicalMusic();
        }
    }
}