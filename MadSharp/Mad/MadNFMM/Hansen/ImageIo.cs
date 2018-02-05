using System;
using MadGame;
using SharpDXMad;

namespace Cum
{
    internal static class ImageIo
    {
        public static Image Read(File file)
        {
            return new Image(G.D2D, Images.LoadFromFile(G.D2D, file.Path));
        }

        public static void GrabPixels(Image image, int[] flexpix)
        {
            throw new NotImplementedException();
            /*
            
                PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 800, 450, flexpix, 0, 800);
                try {
                    pixelgrabber.grabPixels();
                } catch (InterruptedException ignored) {

                }*/
        }

        public static Image Read(byte[] file)
        {
            return new Image(G.D2D, Images.LoadFromFile(G.D2D, file));
        }
    }
}