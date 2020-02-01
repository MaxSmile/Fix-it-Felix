using System;
using System.Collections.Generic;
using fixit.TheGame.graphics;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.creatures
{
    public class Cloud : Creature
    {
        private Sprite sprite;

        public Cloud(float x, float y):base(x,y)
        {
            setDx(2f);

            sprite = Images.Instance.getCloud();
        }

        override
        public void tick()
        {
            if (getX() > Constant.WIDTH + sprite.getWidth())
            {
                reset();
            }
            setX(getX() + getDx());
            setY(getY() + getDy());
        }


        private void reset()
        {
            setX(-sprite.getWidth());
        }

        override
        public void draw(SKCanvas g)
        {
            g.DrawBitmap(sprite.getImage(), new SKPoint((int)getX(), (int)getY()));
        }

        public override Rectangle getBounds()
        {
            return Rectangle.Zero;
        }

        public override Rectangle getTopBounds()
        {
            return Rectangle.Zero;
        }

        public override Rectangle getLeftBounds()
        {
            return Rectangle.Zero;
        }

        public override Rectangle getRightBounds()
        {
            return Rectangle.Zero;
        }

        public override Rectangle getBotBounds()
        {
            return Rectangle.Zero;
        }
    }
}
