using System;
using Cum;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using Color = SharpDX.Color;
using Image = Cum.Image;

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

        public static void SetColor(Cum.Color color)
        {
            if (_currentColor == null)
            {
                _currentColor = new SolidColorBrush(D2D, new RawColor4());
            }
            var currentColorColor = _currentColor.Color;
            currentColorColor.R = color._r / 255f;
            currentColorColor.G = color._g / 255f;
            currentColorColor.B = color._b / 255f;
            currentColorColor.A = color._a / 255f;
            _currentColor.Color = currentColorColor;
        }

        public static void FillRect(int x1, int y1, int width, int height)
        {
            D2D.FillRectangle(new RawRectangleF(x1, y1, 800-width, 450-height), _currentColor);
        }

        public static void DrawLine(int i252, int i253, int i254, int i255)
        {
            //throw new NotImplementedException();
        }

        public static void SetAlpha(float f)
        {
            var currentColorColor = _currentColor.Color;
            currentColorColor.A = f;
            _currentColor.Color = currentColorColor;
        }

        public static void DrawImage(Image image, int x, int y, object p3)
        {
//            D2D.DrawBitmap(image, new RawRectangleF(x, y, image.getWidth(null), image.getHeight(null)), 1.0f, BitmapInterpolationMode.NearestNeighbor);
        }

        public static void SetFont(Font p0)
        {
            //throw new NotImplementedException();
        }

        public static FontMetrics GetFontMetrics()
        {
            //throw new NotImplementedException();
            return new FontMetrics();
        }

        public static void DrawString(string multiplayerTipPressCToAccessChatQuicklyDuringTheGame, int p1, int p2)
        {
            //throw new NotImplementedException();
        }

        public static void FillOval(int p0, int p1, int p2, int p3)
        {
            //throw new NotImplementedException();
        }

        public static void FillRoundRect(int i, int i1, int i2, int i3, int i4, int i5)
        {
            //throw new NotImplementedException();
        }

        public static void DrawRoundRect(int p0, int p1, int p2, int p3, int p4, int p5)
        {
            //throw new NotImplementedException();
        }

        public static void DrawRect(int p0, int p1, int p2, int p3)
        {
            //throw new NotImplementedException();
        }

        public static void DrawImage(Image bggo, int p1, int i429, int p3, int i, object o)
        {
            ////throw new NotImplementedException();
        }
    }
}