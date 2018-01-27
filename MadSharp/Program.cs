using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Cum;
using MadGame;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DirectInput;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using D2D = SharpDX.Direct2D1;
using Bitmap = SharpDX.Direct2D1.Bitmap;
using SharpDX.Samples;
using SysGfx = System.Drawing;

namespace MadGame
{
    /// <summary>
    /// This sample demonstrates how to load a Direct2D1 bitmap from a file.
    /// This method will be part of a future version of SharpDX API.
    /// </summary>
    public class Program : Direct2D1DemoApp
    {
        private const int FrameDelay = (int) (1000 / 21.3f);

        public GameSparker GameSparker { get; set; }

        protected override void Initialize(DemoConfiguration demoConfiguration)
        {
            base.Initialize(demoConfiguration);
            Directory.SetCurrentDirectory(@".\GameData");
            //_bitmap = LoadFromFile(RenderTarget2D, "sharpdx.png");
            G.D2D = RenderTarget2D;
            G.Factory = Factory2D;
            G.FactoryDW = FactoryDWrite;
            RenderTarget2D.AntialiasMode = D2D.AntialiasMode.Aliased;
//            F51.run();
        }

        protected override Form CreateForm(DemoConfiguration config)
        {
            var form = base.CreateForm(config);
            form.MouseDown += MouseDown;
            form.MouseDown += MouseUp;
            return form;
        }

        public void SetupAndRun()
        {
            Run(new DemoConfiguration("Mad.cs", 800, 450));
        }

        protected override void Draw(DemoTime time)
        {
            var tickStart = CurrentTimeMillis();
            
            base.Draw(time);

            // Draw the TextLayout
            //RenderTarget2D.DrawBitmap(_bitmap, 1.0f, Direct2D1.BitmapInterpolationMode.Linear);

            if (GameSparker == null)
            {
                GameSparker = GameSparker.Create();
            }

            GameSparker.GameTick();

            var delay = FrameDelay - (int)(CurrentTimeMillis() - tickStart);
            if (delay > 0)
            {
                Console.WriteLine(delay);
                Thread.Sleep(delay);
            }

            //RenderTarget2D.FillEllipse(new D2D.Ellipse(new Vector2(250, 525), 100, 100), new D2D.SolidColorBrush(RenderTarget2D, new RawColor4(0,1,0,1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long CurrentTimeMillis()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        protected override void KeyDown(KeyEventArgs args)
        {
            const bool isDown = true;
            HandleKeyPress(args, isDown);
        }

        protected override void KeyUp(KeyEventArgs args)
        {
            const bool isDown = false;
            HandleKeyPress(args, isDown);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            GameSparker.MouseReleased(e.X, e.Y);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            GameSparker.MousePressed(e.X, e.Y);
        }

        private void HandleKeyPress(KeyEventArgs args, bool isDown)
        {
            if (isDown)
            {
                GameSparker.KeyPressed(args.KeyCode);
            }
            else
            {
                GameSparker.KeyReleased(args.KeyCode);
            }
        }

        [STAThread]
        private static void Main(string[] args)
        {
            var program = new Program();
            program.SetupAndRun();
        }
    }
}