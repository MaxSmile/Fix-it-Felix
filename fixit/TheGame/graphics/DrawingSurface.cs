using System;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.graphics
{
    public class DrawingSurface
    {
        public DrawingSurface()
        {
        }

        internal void tick()
        {
            
        }

        internal void draw(GameStatus gameStatus, SKCanvas canvas)
        {
            gameStatus.draw(canvas);
            HUD.getHud().draw(canvas);
        }
    }
}
