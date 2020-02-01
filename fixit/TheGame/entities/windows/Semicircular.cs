using System;
using fixit.TheGame.graphics;
using SkiaSharp;

namespace fixit.TheGame.entities.windows
{
    public class Semicircular : Window
    {
        private Sprite[] images;
        new int state;

        public Semicircular(float x, float y): base(x, y)
        {
            

            images = Images.Instance.getSemicircular();

            strokesRequired = util.Random.value(0, 16);
            initWindow();


            width = images[0].getWidth();
            height = images[0].getHeight();
        }


        private void initWindow()
        {
            if (strokesRequired > 12)
            {
                state = 4;
            }
            else if (strokesRequired <= 12 && strokesRequired > 8)
            {
                state = 3;
            }
            else if (strokesRequired <= 8 && strokesRequired > 4)
            {
                state = 2;
            }
            else if (strokesRequired <= 4 && strokesRequired > 0)
            {
                state = 1;
            }
            else if (strokesRequired == 0)
            {
                state = 0;
            }
        }



        override
    public void tick()
        {
            initWindow();
        }


        override
    public void draw(SKCanvas g)
        {
            g.DrawBitmap(images[state].getImage(), new SKPoint((int)getX(), (int)getY()));
            //		g.draw(getBotBounds());
            //		g.draw(getBounds());
        }


        override
    public SKRect getTopBounds()
        {
            return new SKRect(0, 0, 0, 0);
        }

        override
    public SKRect getLeftBounds()
        {
            return new SKRect(0, 0, 0, 0);
        }

        override
    public SKRect getRightBounds()
        {
            return new SKRect(0, 0, 0, 0);
        }

        override
    public SKRect getBotBounds()
        {
            return new SKRect((int)getX(), (int)getY() + 51, 70, 5);
        }

      

        override
    public SKRect getBounds()
        {
            return new SKRect((int)getX() + 5, (int)getY(), width - 11, height);
        }

        override
    public void getFixed()
        {
            if (isBroken())
            {
                strokesRequired--;
            }
        }
    }
}
