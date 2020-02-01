using System;
using fixit.TheGame.statemachine.characterstates.cake;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities
{
    public class Cake : Entity
    {
        private long cakeTime;

        public Cake(float x, float y):base(x, y)
        {
            id = ID.Cake;
            Handler.add(this);
            cakeTime = DateTime.Now.Ticks;
            state = CakeAnimation.getCake();
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
            // TODO: return to this logic. Its wrong!
            if (0 - cakeTime > 5000)
            {
                Handler.remove(this);
            }
        }

        override
    public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), 20, 20);
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
