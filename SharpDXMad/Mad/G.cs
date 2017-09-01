using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace MadGame
{
    public static class G
    {
        private const FigureBegin FigureBegin = new FigureBegin();
        private const FigureEnd FigureEnd = new FigureEnd();
        
        public static RenderTarget D2D { get; set; }
        public static Factory Factory { get; set; }
        
        private static SolidColorBrush _currentColor = null;

        private static RawColor4 ToRaw(Color c)
        {
            return new RawColor4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        }

        public static void SetColor(Color c)
        {
            if (_currentColor == null)
            {
                _currentColor = new SolidColorBrush(D2D, ToRaw(c));
            }
            else
            {
                _currentColor.Color = ToRaw(c);
            }
        }

        public static void FillPolygon(int[] x, int[] y, int n)
        {
            if (n < 3) return;

            var pta = new RawVector2[n-1];

            var pta0 = new RawVector2(x[0], y[0]);
            for (var i = 1; i < n; i++)
            {
                pta[i-1] = new RawVector2(x[i], y[i]);
            }
            
            using (var geo1 = new PathGeometry(Factory))
            using (var sink1 = geo1.Open())
            {
                sink1.BeginFigure(pta0, FigureBegin);
                sink1.AddLines(pta);
                sink1.EndFigure(FigureEnd);
                sink1.Close();

                D2D.FillGeometry(geo1, _currentColor);
            }
        }
        
        public static void DrawPolygon(int[] x, int[] y, int n)
        {
            if (n < 2) return;
            for (int i = 0, l = n-1; i < l; i++)
            {
                D2D.DrawLine(new RawVector2(x[i], y[i]), new RawVector2(x[i+1], y[i+1]), _currentColor);
            }
        }

        public static void setColor(Cum.Color color)
        {
            throw new NotImplementedException();
        }

        public static void fillPolygon(int[] is78, int[] is79, int i)
        {
            throw new NotImplementedException();
        }

        public static void fillRect(int p0, int i217, int p2, int p3)
        {
            throw new NotImplementedException();
        }

        public static void drawPolygon(int[] is85, int[] is86, int i)
        {
            throw new NotImplementedException();
        }

        public static void drawLine(int i252, int i253, int i254, int i255)
        {
            throw new NotImplementedException();
        }

        public static void setAlpha(float f)
        {
            throw new NotImplementedException();
        }
    }
}