using System;
using SkiaSharp;

namespace fixit.TheGame.graphics
{
    public class Sprite
    {
        private SKBitmap image;

        public Sprite(SKBitmap image)
        {
            this.image = image;
        }

        public SKBitmap getImage()
        {
            return image;
        }


        public int getWidth()
        {
            return image.Width;
        }

        public int getHeight()
        {
            return image.Height;
        }
    }
}
