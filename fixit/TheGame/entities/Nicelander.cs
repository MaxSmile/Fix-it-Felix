using System;
using SkiaSharp;

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
            g.DrawBitmap(state.getImage(0), SKPoint((int)getX(), (int)getY()));
        }


        override
    public void tick()
        {
            if (beforeTime - actionsDelay > 1150)
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
    public SKRect getBounds()
        {
            return new SKRect(0, 0, 0, 0);
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
            return new SKRect(0, 0, 0, 0);
        }

    }
}
