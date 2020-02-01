using System;
using SkiaSharp;

namespace fixit.TheGame.sectorstates
{
    public interface GameState
    {
        void draw(SKCanvas c);

        void tick();
    }
}
