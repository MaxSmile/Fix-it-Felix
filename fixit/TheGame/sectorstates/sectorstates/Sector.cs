using System;
using System.Collections.Generic;
using fixit.TheGame.entities;
using fixit.TheGame.entities.windows;
using SkiaSharp;

namespace fixit.TheGame.sectorstates.sectorstates
{
    public abstract class Sector
    {
        protected int COL = 5;
        protected int ROW = 3;

        protected static int POS_X = Building.POS_X;
        protected static int POS_Y = Building.POS_Y;

        protected int MAX_OBSTACLES = 3;
        protected int obsCounter;

        protected Window[] windows;
        protected List<Window> brokenWindows;

        public Sector()
        {
            brokenWindows = new List<Window>();
            obsCounter = 0;
        }

        public abstract void tick();
        public abstract void draw(SkiaSharp.SKCanvas g);

        public abstract  bool hasBirds();
        public abstract  bool hasNicelanders();

        public abstract  SKRect getTopBounds();
        public abstract  SKRect getBotBounds();

        public Window[] getWindows()
        {
            return windows;
        }

        public int brokenWinsAmount()
        {
            return brokenWindows.Count;
        }

        public  bool changeSector()
        {
            return brokenWindows.Count <= 0;
        }
    }
}
