using System;
using fixit.TheGame.entities.windows;
using SkiaSharp;

namespace fixit.TheGame.sectorstates.sectorstates
{
    public class FirstSector : Sector
    {
        public FirstSector()
        {
            windows = new Window[15];
            initWindows();
            countBrokenWindows();
        }


        private void initWindows()
        {
            // diferencia x = 49
            // diferencia y = -74
            int posX = 283;
            int posY = 488;
            int i = 0;
            for (int y = 0; y < ROW; y++)
            {
                for (int x = 0; x < COL; x++)
                {
                    if ((posX != 381 && posY != 488) || (posX != 381 && posY != 417) || posY == 340)
                    {
                        windows[i] = new TwoPanels(posX, posY, false);
                    }

                    if (posY == 488 && posX == 381)
                    {
                        windows[i] = new Door(369, 468);
                    }

                    if (posY == 414 && posX == 381)
                    {
                        windows[i] = new Semicircular(369, 413);
                    }

                    i++;
                    posX += 49;
                }
                posX = 283;
                posY -= 74;
            }
        }


        private void countBrokenWindows()
        {
            for (int i = 0; i < windows.length; i++)
            {
                Window w = windows[i];
                if (w.isBroken())
                {
                    brokenWindows.add(w);
                }
            }
        }


        override
    public void tick()
        {
            for (int i = 0; i < windows.Length; i++)
            {
                Window w = windows[i];
                w.tick();
                if (!w.isBroken())
                {
                    if (brokenWindows.Contains(w))
                    {
                        Score.getScore().fixWindow();
                    }
                    brokenWindows.Remove(w);
                }
            }
        }


        override
    public void draw(SKCanvas g)
        {
            for (int i = 0; i < windows.Length; i++)
            {
                windows[i].draw(g);
            }
        }


        override
    public bool hasBirds()
        {
            return false;
        }


        override
    public bool hasNicelanders()
        {
            return false;
        }


        override
    public SKRect getBotBounds()
        {
            return new SKRect(POS_X + 18, Constant.HEIGHT - 44, 278, 6);
        }

        override
    public SKRect getTopBounds()
        {
            return new SKRect(POS_X + 18, POS_Y + 778, 278, 6);
        }
    }
}
