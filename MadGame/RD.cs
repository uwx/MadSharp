using System;
using System.Collections.Generic;
using System.Diagnostics;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TriangleNet;
using TriangleNet.Geometry;
using Triangulator.Geometry;
using Point = TriangleNet.Geometry.Point;

namespace MadGame
{
    public class StandardBasicEffect : BasicEffect
    {
        public StandardBasicEffect(GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
            this.VertexColorEnabled = true;
            this.Projection = Matrix.CreateOrthographicOffCenter(
                0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
        }

        public StandardBasicEffect(BasicEffect effect)
            : base(effect) { }

        public BasicEffect Clone()
        {
            return new StandardBasicEffect(this);
        }
    }
    
    public static class G
    {
        public static Texture2D Pixel = new Texture2D(Game1.InternalDevice, 1, 1);
        private static Brush _currentColor = Brush.Red;
        
        public static void DrawLine(Vector2 start, Vector2 end)
        {
            var edge = end - start;
            // calculate angle to rotate line
            var angle = (float)Math.Atan2(edge.Y, edge.X);

            Game1.SpriteBatch.Draw(Pixel,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Red, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }

        public static void SetColor(Color c)
        {
            _currentColor = new SolidColorBrush(c);
        }

        public static void SetColor(Brush c)
        {
            _currentColor = c;
        }

        public static void FillPolygon(int[] x, int[] y, int n)
        {
            if (n < 3) return;
            
            var avertices = new List<Triangulator.Geometry.Point>();
            
            //Add vertices ...
            for (var i = 0; i < n; i++)
            {
                avertices.Add(new Triangulator.Geometry.Point(x[i], y[i]));
            }
            
            //Do triangulation
            var tris = Triangulator.Delauney.Triangulate(avertices);

            if (tris.Count == 0)
            {
                Debug.WriteLine($"Empty for {string.Join(" ", x)} {string.Join(" ", y)}");
                return;
            }
            
            var vertices = new VertexPositionColor[tris.Count * 3];
            var ai = 0;
            foreach (var tri in tris)
            {
                vertices[ai].Position = ToVector3(x[tri.p1], y[tri.p1]);
                vertices[ai+1].Position = ToVector3(x[tri.p2], y[tri.p2]);
                vertices[ai+2].Position = ToVector3(x[tri.p3], y[tri.p3]);
                vertices[ai].Color = _currentColor.Color;
                vertices[ai+1].Color = _currentColor.Color;
                vertices[ai+2].Color = _currentColor.Color;
                ai += 3;
            }
            
            Game1.GameFX.CurrentTechnique.Passes[0].Apply();
            Game1.InternalDevice.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList, vertices, 0, tris.Count);


            //Game1.InternalDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vert, 0, vert.Length, ind, 0, ind.Length / 3);
        }
        
        private static Vector3 ToVector3(int x, int y)
        {
            return new Vector3(x / 400F - 1, y / 240F - 1, 0);
        }

        public static Texture2D ColorToTexture(GraphicsDevice device, Color color, int width, int height)
        {
            Texture2D texture = new Texture2D(device, 1, 1);
            texture.SetData(new[] { color });

            return texture;
        }

        public static void DrawPolygon(int[] ai5, int[] ai6, int i)
        {
            //throw new NotImplementedException();
            // TODO
        }
    }
}