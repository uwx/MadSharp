using System;
using SharpDX;

namespace MadGame
{
    public class Colors
    {
        public static float[] RGBtoHSB(int r, int g, int b, float[] hsbvals)
        {
            float hue, saturation;
            if (hsbvals == null)
            {
                hsbvals = new float[3];
            }
            var cmax = (r > g) ? r : g;
            if (b > cmax) cmax = b;
            var cmin = (r < g) ? r : g;
            if (b < cmin) cmin = b;
            var brightness = cmax / 255.0f;
            if (cmax != 0)
                saturation = (cmax - cmin) / ((float) cmax);
            else
                saturation = 0;
            if (saturation == 0)
                hue = 0;
            else
            {
                var redc = (cmax - r) / ((float) (cmax - cmin));
                var greenc = (cmax - g) / ((float) (cmax - cmin));
                var bluec = (cmax - b) / ((float) (cmax - cmin));
                if (r == cmax)
                    hue = bluec - greenc;
                else if (g == cmax)
                    hue = 2.0f + redc - bluec;
                else
                    hue = 4.0f + greenc - redc;
                hue = hue / 6.0f;
                if (hue < 0)
                    hue = hue + 1.0f;
            }
            hsbvals[0] = hue;
            hsbvals[1] = saturation;
            hsbvals[2] = brightness;
            return hsbvals;
        }

        public static Color GetHSBColor(float hue, float saturation, float brightness)
        {
            return new Color(HSBtoRGB(hue, saturation, brightness));
        }

        public static uint HSBtoRGB(float hue, float saturation, float brightness)
        {
            const int alpha = 255;
        
            if (0f > hue
                || 360f < hue)
            {
                throw new ArgumentOutOfRangeException(
                    "hue",
                    hue,
                    "Value must be within a range of 0 - 360.");
            }
        
            if (0f > saturation
                || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException(
                    "saturation",
                    saturation,
                    "Value must be within a range of 0 - 1.");
            }
        
            if (0f > brightness
                || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException(
                    "brightness",
                    brightness,
                    "Value must be within a range of 0 - 1.");
            }
        
            if (0f == saturation)
            {
                return (uint) new Color(
                    Convert.ToInt32(brightness * 255),
                    Convert.ToInt32(brightness * 255),
                    Convert.ToInt32(brightness * 255)).ToRgba();
            }
        
            float fMax, fMid, fMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }
        
            var iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
        
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = (hue * (fMax - fMin)) + fMin;
            }
            else
            {
                fMid = fMin - (hue * (fMax - fMin));
            }
        
            var iMax = Convert.ToInt32(fMax * 255);
            var iMid = Convert.ToInt32(fMid * 255);
            var iMin = Convert.ToInt32(fMin * 255);
        
            switch (iSextant)
            {
                case 1:
                    return (uint) new Color(iMid, iMax, iMin).ToRgba();
                case 2:
                    return (uint) new Color(iMin, iMax, iMid).ToRgba();
                case 3:
                    return (uint) new Color(iMin, iMid, iMax).ToRgba();
                case 4:
                    return (uint) new Color(iMid, iMin, iMax).ToRgba();
                case 5:
                    return (uint) new Color(iMax, iMin, iMid).ToRgba();
                default:
                    return (uint) new Color(iMax, iMid, iMin).ToRgba();
            }
        }
    }
}