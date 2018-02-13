using System;
using Cum;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using DW = SharpDX.DirectWrite;
using D2D = SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using Color = SharpDX.Color;
using Factory = SharpDX.Direct2D1.Factory;
using Font = Cum.Font;
using FontMetrics = Cum.FontMetrics;
using Image = Cum.Image;

namespace MadGame
{
    public static class G
    {
        private const FigureBegin FigureBegin = new FigureBegin();
        private const FigureEnd FigureEnd = new FigureEnd();

        public static RenderTarget D2D { get; set; }
        public static Factory Factory { get; set; }
        public static DW.Factory FactoryDW { get; set; }

        private static SolidColorBrush _currentColor;
        private static TextFormat _textFormat;
        private static CachedFont _fontCached;

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
            if (n < 3)
            {
                return;
            }

            var pta = new RawVector2[n - 1];

            var pta0 = new RawVector2(x[0], y[0]);
            for (var i = 1; i < n; i++)
            {
                pta[i - 1] = new RawVector2(x[i], y[i]);
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
            if (n < 2)
            {
                return;
            }

            for (int i = 0, l = n - 1; i < l; i++)
            {
                D2D.DrawLine(new RawVector2(x[i], y[i]), new RawVector2(x[i + 1], y[i + 1]), _currentColor);
            }
        }

        public static void SetColor(Cum.Color color)
        {
            if (_currentColor == null)
            {
                _currentColor = new SolidColorBrush(D2D, new RawColor4());
            }
            var currentColorColor = _currentColor.Color;
            currentColorColor.R = color.R / 255f;
            currentColorColor.G = color.G / 255f;
            currentColorColor.B = color.B / 255f;
            currentColorColor.A = color.A / 255f;
            _currentColor.Color = currentColorColor;
        }

        public static void FillRect(int x1, int y1, int width, int height)
        {
            D2D.FillRectangle(new RectangleF(x1, y1, width, height), _currentColor);
        }

        public static void DrawLine(int x1, int y1, int x2, int y2)
        {
            D2D.DrawLine(new RawVector2(x1, y1), new RawVector2(x2, y2), _currentColor);
            //throw new NotImplementedException();
        }

        public static void SetAlpha(float f)
        {
            var currentColorColor = _currentColor.Color;
            currentColorColor.A = f;
            _currentColor.Color = currentColorColor;
        }

        public static void DrawImage(Image image, int x, int y)
        {
            if (image == null)
            {
                return;
            }

            D2D.DrawBitmap(image, new RectangleF(x, y, image.GetWidth(null), image.GetHeight(null)), 1.0f,
                BitmapInterpolationMode.NearestNeighbor);
        }

        public static void SetFont(Font p0)
        {
            _fontCached = Fonts.GetOrCompute(p0, () =>
            {
                var fmt = new TextFormat(FactoryDW, p0.FontName, p0.Size);
                return (fmt, new FontMetrics(fmt));
            });
            _textFormat = _fontCached.Format;
        }

        public static FontMetrics GetFontMetrics()
        {
            return _fontCached.Metrics;
        }

        public static void DrawString(string text, int x, int y)
        {
            D2D.DrawText(text, _textFormat, new RectangleF(x, y - _fontCached.Metrics.Height(text), 400, 400),
                _currentColor);
        }

        public static void FillOval(int p0, int p1, int p2, int p3)
        {
            //throw new NotImplementedException();
        }

        public static void FillRoundRect(int x, int y, int wid, int hei, int arcWid, int arcHei)
        {
            D2D.FillRoundedRectangle(new RoundedRectangle()
            {
                Rect = new RectangleF(x, y, wid, hei),
                RadiusX = arcWid,
                RadiusY = arcHei,
            }, _currentColor);
        }

        public static void DrawRoundRect(int x, int y, int wid, int hei, int arcWid, int arcHei)
        {
            D2D.DrawRoundedRectangle(new RoundedRectangle()
            {
                Rect = new RectangleF(x, y, wid, hei),
                RadiusX = arcWid,
                RadiusY = arcHei,
            }, _currentColor);
        }

        public static void DrawRect(int x1, int y1, int width, int height)
        {
            D2D.DrawRectangle(new RectangleF(x1, y1, width, height), _currentColor);
        }

        public static void DrawImage(Image bggo, int p1, int i429, int p3, int i, object o)
        {
            ////throw new NotImplementedException();
        }

        public static void DrawImage(Image image, int x, int y, int wid, int hei)
        {
            if (image == null)
            {
                return;
            }

            D2D.DrawBitmap(image, new RectangleF(x, y, wid, hei), 1.0f,
                BitmapInterpolationMode.NearestNeighbor);
        }
    }
}