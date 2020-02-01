using System;
using fixit.TheGame.graphics;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.windows
{
    public class Door:Window
    {
        private Sprite[] images;
        private new int state;

        public Door(float x, float y):base(x, y)
        {
            images = Images.Instance.getDoor();
            strokesRequired = util.Random.value(0, 16);
            initWindows();

            width = images[0].getWidth() - 20;
            height = images[0].getHeight() - 41;
        }


        private void initWindows()
        {
            if (strokesRequired > 12)
            {
                state = 4;
            }
            else
                if (strokesRequired <= 12 && strokesRequired > 8)
            {
                state = 3;
            }
            else
                    if (strokesRequired <= 8 && strokesRequired > 4)
            {
                state = 2;
            }
            else
                        if (strokesRequired <= 4 && strokesRequired > 0)
            {
                state = 1;
            }
            else
                            if (strokesRequired == 0)
            {
                state = 0;
            }
        }


        override
    public void draw(SKCanvas g)
        {
            g.DrawBitmap(images[state].getImage(), new SKPoint((int)getX(), (int)getY()));
        }


        override
    public void tick()
        {
            initWindows();
        }


        override
    public Rectangle getTopBounds()
        {
            return new Rectangle(0, 0, 0, 0);
        }


        override
    public Rectangle getLeftBounds()
        {
            return new Rectangle(0, 0, 0, 0);
        }


        override
    public Rectangle getRightBounds()
        {
            return new Rectangle(0, 0, 0, 0);
        }


        override
    public Rectangle getBotBounds()
        {
            return new Rectangle((int)getX(), (int)getY() + 95, 60, 4);
        }



        override
    public Rectangle getBounds()
        {
            return new Rectangle((int)getX() + 10, (int)getY() + 40, width, height);
        }



    }
}
