﻿using System;
using fixit.TheGame.entities.windows;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.sectorstates.sectorstates
{
    public class SecondSector : Sector
    {
        private int MAX_DOUBLE_DOOR = 3;
        private int doubleDoorCounter;

        public SecondSector()
        {
            windows = new Window[15];

            initWindows();
            countBrokenWindows();
        }


        private void initWindows()
        {
            int posX = 283;
            int posY = 250;
            int i = 0;
            for (int y = 0; y < ROW; y++)
            {
                for (int x = 0; x < COL; x++)
                {
                    if (obsCounter < MAX_OBSTACLES)
                        setWithObstacles(posX, posY, i);
                    else
                    {
                        setWithoutObstacles(posX, posY, i);
                    }
                    posX += 49;
                    i++;
                }
                posX = 283;
                posY -= 74;
            }
        }


        private void setWithObstacles(int posX, int posY, int i)
        {
            if (util.Random.boolValue(5) && doubleDoorCounter < MAX_DOUBLE_DOOR)
            {
                bool hasObstacle = util.Random.boolValue(6);
                if (hasObstacle)
                    obsCounter++;
                windows[i] = new DoubleDoor(posX, posY);
                doubleDoorCounter++;
            }
            else
            {
                bool hasObstacle = util.Random.boolValue(5);
                if (hasObstacle)
                    obsCounter++;
                windows[i] = new TwoPanels(posX, posY, hasObstacle);
            }
        }

        private void setWithoutObstacles(int posX, int posY, int i)
        {
            if (util.Random.boolValue(5) && doubleDoorCounter < MAX_DOUBLE_DOOR)
            {
                windows[i] = new DoubleDoor(posX, posY);
                doubleDoorCounter++;
            }
            else
            {
                windows[i] = new TwoPanels(posX, posY, false);
            }
        }




        private void countBrokenWindows()
        {
            for (int i = 0; i < windows.Length; i++)
            {
                Window w = windows[i];
                if (w.isBroken())
                {
                    brokenWindows.Add(w);
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
            return true;
        }

        override
    public bool hasNicelanders()
        {
            return true;
        }


        override
    public Rectangle getBotBounds()
        {
            return new Rectangle(POS_X + 18, POS_Y + 778, 278, 8);
        }

        override
    public Rectangle getTopBounds()
        {
            return new Rectangle(POS_X + 18, POS_Y + 540, 278, 8);
        }


    }
}
