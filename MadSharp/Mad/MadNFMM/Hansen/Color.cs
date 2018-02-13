using System;
using System.Runtime.CompilerServices;
using MadGame;

namespace Cum
{
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
}