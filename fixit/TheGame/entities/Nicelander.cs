using System;
using fixit.TheGame.statemachine.characterstates.nicelander;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities
{
    public class Nicelander:Entity
    {
        private long actionsDelay;
        private bool leaveCake;
        private Cake cake;

        public Nicelander(float x, float y):base(x,y)
        {
            
            leaveCake = true;
            state = NicelanderAnimation.getNicelander();
            actionsDelay = DateTime.Now.Ticks;
            Handler.add(this);
        }


        override
    public void draw(SKCanvas g)
        {
            state.update();
            g.DrawBitmap(state.getImage(0), new SKPoint((int)getX(), (int)getY()));
        }


        override
    public void tick()
        {
            // TODO: wrong timing!
            if (0 - actionsDelay > 1150)
            {
                if (leaveCake)
                {
                    cake = new Cake((int)getX(), (int)getY());
                    leaveCake = false;
                    Handler.remove(this);
                }
            }
        }


        override
    public Rectangle getBounds()
        {
            return new Rectangle(0, 0, 0, 0);
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
            return new Rectangle(0, 0, 0, 0);
        }

    }
}
