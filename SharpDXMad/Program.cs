using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using MadGame;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using D2D = SharpDX.Direct2D1;
using Bitmap = SharpDX.Direct2D1.Bitmap;
using SharpDX.Samples;
using SysGfx = System.Drawing;

namespace SharpDXMad
{
    /// <summary>
    /// This sample demonstrates how to load a Direct2D1 bitmap from a file.
    /// This method will be part of a future version of SharpDX API.
    /// </summary>
    public class Program : Direct2D1DemoApp
    {
        private const int FrameDelay = (int)(1000 / 21f);
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        private Bitmap _bitmap;

        protected override void Initialize(DemoConfiguration demoConfiguration)
        {
            base.Initialize(demoConfiguration);
            //_bitmap = LoadFromFile(RenderTarget2D, "sharpdx.png");
            G.D2D = RenderTarget2D;
            G.Factory = Factory2D;
            F51 = new F51();
            F51.run();
        }

        public F51 F51 { get; set; }

        protected override void Draw(DemoTime time)
        {
            Stopwatch.Reset();
            
            base.Draw(time);

            // Draw the TextLayout
            //RenderTarget2D.DrawBitmap(_bitmap, 1.0f, Direct2D1.BitmapInterpolationMode.Linear);
            
            F51.wtrue();

            var delay = FrameDelay - (int)Stopwatch.ElapsedMilliseconds;
            if (delay > 0)
            {
                Thread.Sleep(delay);
            }

            //RenderTarget2D.FillEllipse(new D2D.Ellipse(new Vector2(250, 525), 100, 100), new D2D.SolidColorBrush(RenderTarget2D, new RawColor4(0,1,0,1)));
        }

        [STAThread]
        private static void Main(string[] args)
        {
            var program = new Program();
            program.Run(new DemoConfiguration("SharpDX Bitmap Demo"));
        }
}
}