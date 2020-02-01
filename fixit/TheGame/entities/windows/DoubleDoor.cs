using System;
using fixit.TheGame.graphics;
using SkiaSharp;

namespace fixit.TheGame.entities.windows
{
    public class DoubleDoor : Window
    {

        private Sprite[] img;
        private int doors;


        public DoubleDoor(float x, float y):base(x, y)
        {
            

            img = Images.Instance.getDoubleDoor();

            width = img[0].getWidth();
            height = img[0].getHeight();

            doors = util.Random.value(0, 3);

        }




        override
    public void draw(SKCanvas g)
        {
            g.DrawBitmap(img[doors].getImage(), new SKPoint((int)getX(), (int)getY()));
            
        }

        override
    public void tick()
        {

        }

        override
    public SKRect getTopBounds()
        {
            return new SKRect((int)getX(), (int)getY() - 10, 36, 6);
        }

        override
    public SKRect getLeftBounds()
        {
            if (doors == 0 || doors == 3)
            {
                return new SKRect(0, 0, 0, 0);
            }
            return new SKRect((int)getX(), (int)getY() + 6, 4, 44);
        }

        override
    public SKRect getRightBounds()
        {
            if (doors == 0 || doors == 2)
            {
                return new SKRect(0, 0, 0, 0);
            }
            return new SKRect((int)getX() + 32, (int)getY() + 6, 4, 44);
        }

        override
    public SKRect getBotBounds()
        {
            return new SKRect((int)getX(), (int)getY() + 49, 40, 5);
        }

        override
    public SKRect getBounds()
        {
            return new SKRect((int)getX(), (int)getY(), width, height);
        }

    }
}
