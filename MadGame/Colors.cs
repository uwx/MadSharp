using System;
using Microsoft.Xna.Framework;

namespace MadGame
{
    public class Colors
    {
        public static float[] RGBtoHSB(int r, int g, int b, float[] hsbvals) {



            float hue, saturation, brightness;



            if (hsbvals == null) {



                hsbvals = new float[3];



            }



            int cmax = (r > g) ? r : g;



            if (b > cmax) cmax = b;



            int cmin = (r < g) ? r : g;



            if (b < cmin) cmin = b;







            brightness = ((float) cmax) / 255.0f;



            if (cmax != 0)



                saturation = ((float) (cmax - cmin)) / ((float) cmax);



            else



                saturation = 0;



            if (saturation == 0)



                hue = 0;



            else {



                float redc = ((float) (cmax - r)) / ((float) (cmax - cmin));



                float greenc = ((float) (cmax - g)) / ((float) (cmax - cmin));



                float bluec = ((float) (cmax - b)) / ((float) (cmax - cmin));



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
            return new Color(HSBtoRGB(hue,saturation,brightness));
        }

        public static uint HSBtoRGB(float hue, float saturation, float brightness) {



            int r = 0, g = 0, b = 0;



            if (saturation == 0) {



                r = g = b = (int) (brightness * 255.0f + 0.5f);



            } else {



                float h = (hue - (float)Math.Floor(hue)) * 6.0f;



                float f = h - (float)Math.Floor(h);



                float p = brightness * (1.0f - saturation);



                float q = brightness * (1.0f - saturation * f);



                float t = brightness * (1.0f - (saturation * (1.0f - f)));



                switch ((int) h) {



                    case 0:



                        r = (int) (brightness * 255.0f + 0.5f);



                        g = (int) (t * 255.0f + 0.5f);



                        b = (int) (p * 255.0f + 0.5f);



                        break;



                    case 1:



                        r = (int) (q * 255.0f + 0.5f);



                        g = (int) (brightness * 255.0f + 0.5f);



                        b = (int) (p * 255.0f + 0.5f);



                        break;



                    case 2:



                        r = (int) (p * 255.0f + 0.5f);



                        g = (int) (brightness * 255.0f + 0.5f);



                        b = (int) (t * 255.0f + 0.5f);



                        break;



                    case 3:



                        r = (int) (p * 255.0f + 0.5f);



                        g = (int) (q * 255.0f + 0.5f);



                        b = (int) (brightness * 255.0f + 0.5f);



                        break;



                    case 4:



                        r = (int) (t * 255.0f + 0.5f);



                        g = (int) (p * 255.0f + 0.5f);



                        b = (int) (brightness * 255.0f + 0.5f);



                        break;



                    case 5:



                        r = (int) (brightness * 255.0f + 0.5f);



                        g = (int) (p * 255.0f + 0.5f);



                        b = (int) (q * 255.0f + 0.5f);



                        break;



                }



            }



            return (0xff000000 | (byte)(r << 16) | (byte)(g << 8) | (byte)(b << 0));



        }
    }
}