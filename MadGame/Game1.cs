using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MadGame
{
    public class Game1 : Game
    {
        internal static Game1 Game { get; private set; }
        internal static GraphicsDeviceManager Graphics;
        internal static SpriteBatch SpriteBatch;
        internal static GraphicsDevice InternalDevice { get; private set; }
        internal static DrawBatch DrawBatch;
        internal static F51 F51;

        internal static Effect GameFX { get; private set; }

        public Game1()
        {
            Game = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            F51 = new F51();
            F51.run();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            DrawBatch = new DrawBatch(GraphicsDevice);
            InternalDevice = GraphicsDevice;
            
            //var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("ProjectNameSpace.Assets.Content.effects.mgfxo");
            //var reader = new BinaryReader(s);
            //GameFX = new Effect(GraphicsDevice, reader.ReadBytes((int)reader.BaseStream.Length));
            GameFX = new StandardBasicEffect(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            SpriteBatch.Begin();
            DrawBatch.Begin();
            
            // Draw a fancy purple rectangle.  
            SpriteBatch.Draw(G.Pixel, new Rectangle(0, 0, 300, 300), Color.Purple);

            //GameFX.CurrentTechnique = GameFX.Techniques["Pretransformed"];
            
            F51.wtrue();
            
//            {
//                var basicEffect = new BasicEffect(device)
//                {
//                    //Texture = G.Pixel,
//                    TextureEnabled = false
//                };
//
//                var vert = new VertexPositionColor[4];
//                vert[0].Position = new Vector3(0, 0, 0);
//                vert[1].Position = new Vector3(100, 0, 0);
//                vert[2].Position = new Vector3(0, 100, 0);
//                vert[3].Position = new Vector3(100, 100, 0);
//
//                vert[0].Color = Color.Aquamarine;
//                vert[1].Color = Color.Aquamarine;
//                vert[2].Color = Color.Aquamarine;
//                vert[3].Color = Color.Aquamarine;
//
//                var ind = new short[6];
//                ind[0] = 0;
//                ind[1] = 2;
//                ind[2] = 1;
//                ind[3] = 1;
//                ind[4] = 2;
//                ind[5] = 3;
//            }
            
            DrawBatch.End();
            SpriteBatch.End();
            
            base.Draw(gameTime);
            
        }
    }
}