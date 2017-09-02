using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
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
        private const int FrameDelay = (int)(1000 / 21f);
        
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        
        public GameSparker GameSparker { get; set; }
        
        protected override void Initialize(DemoConfiguration demoConfiguration)
        {
            base.Initialize(demoConfiguration);
            Directory.SetCurrentDirectory(@"C:\Users\Rafael\Documents\GitHub\MadGame\GameData");
            //_bitmap = LoadFromFile(RenderTarget2D, "sharpdx.png");
            G.D2D = RenderTarget2D;
            G.Factory = Factory2D;
            G.FactoryDW = FactoryDWrite;
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
            Stopwatch.Reset();
            
            base.Draw(time);

            // Draw the TextLayout
            //RenderTarget2D.DrawBitmap(_bitmap, 1.0f, Direct2D1.BitmapInterpolationMode.Linear);
            
            if (GameSparker == null)
            {
                GameSparker = GameSparker.create();
            }
            
            GameSparker.gameTick();

            var delay = FrameDelay - (int)Stopwatch.ElapsedMilliseconds;
            if (delay > 0)
            {
                Thread.Sleep(delay);
            }

            //RenderTarget2D.FillEllipse(new D2D.Ellipse(new Vector2(250, 525), 100, 100), new D2D.SolidColorBrush(RenderTarget2D, new RawColor4(0,1,0,1)));
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
            GameSparker.mouseReleased(e.X, e.Y);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            GameSparker.mousePressed(e.X, e.Y);
        }

        private void HandleKeyPress(KeyEventArgs args, bool isDown)
        {
            if (isDown)
            {
                GameSparker.keyPressed(args.KeyCode);
            }
            else
            {
                GameSparker.keyReleased(args.KeyCode);
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