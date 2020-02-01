using System;
using fixit.TheGame.graphics;

namespace fixit.TheGame.statemachine
{
    public abstract class State
    {
        
        protected String[] paths;
        protected int animationTickCounter = 0;
        protected int animUpdate;
        protected Animation animation;

        public abstract SkiaSharp.SKBitmap getImage(int dir);

        public void update()
        {
            animationTickCounter++;
            if (animationTickCounter % animUpdate == 0)
            {
                animation.tick();
                animationTickCounter = 0;
            }
        }
    }
}
