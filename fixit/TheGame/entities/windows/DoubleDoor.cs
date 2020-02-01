using System;
using fixit.TheGame.graphics;
using SkiaSharp;
using Xamarin.Forms;

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
    public Rectangle getTopBounds()
        {
            return new Rectangle((int)getX(), (int)getY() - 10, 36, 6);
        }

        override
    public Rectangle getLeftBounds()
        {
            if (doors == 0 || doors == 3)
            {
                return new Rectangle(0, 0, 0, 0);
            }
            return new Rectangle((int)getX(), (int)getY() + 6, 4, 44);
        }

        override
    public Rectangle getRightBounds()
        {
            if (doors == 0 || doors == 2)
            {
                return new Rectangle(0, 0, 0, 0);
            }
            return new Rectangle((int)getX() + 32, (int)getY() + 6, 4, 44);
        }

        override
    public Rectangle getBotBounds()
        {
            return new Rectangle((int)getX(), (int)getY() + 49, 40, 5);
        }

        override
    public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), width, height);
        }

    }
}
