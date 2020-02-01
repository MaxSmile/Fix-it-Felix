using System;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.entities.windows;
using fixit.TheGame.graphics;
using fixit.TheGame.sectorstates.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.entities
{
    public class Building : Entity
    {
        private  static int BUILDING_WIDTH = 315;
        private  static int BUILDING_HEIGHT = 1065;

        public  static int POS_X = Constant.WIDTH / 2 - BUILDING_WIDTH / 2;
        public  static int POS_Y = Constant.HEIGHT - BUILDING_HEIGHT + 10;

        private bool globalMovement = false;

        private Nicelander nicelander;
        private bool spawnNicelander;
        private long nicelanderDelay;

        private bool birdInit;
        private Bird bird;


        private static Building building = new Building();

        private Sprite sprite;

        private Sector[] sectors;
        private int actualSector;
        private int previousSector;


        private Building():base(POS_X, POS_Y)
        {
            
            sprite = Images.Instance.getBuilding();
            id = ID.Building;

            birdInit = true;
            spawnNicelander = false;

            sectors = new Sector[Constant.SECTORS];

            initSectors();
            initActualSectors();
        }


        public void initSectors()
        {
            sectors[0] = new FirstSector();
            sectors[1] = new SecondSector();
            sectors[2] = new ThirdSector();
            sectors[3] = new FourthSector();
        }


        public void initActualSectors()
        {
            actualSector = 0;
            previousSector = 0;
        }

        public static Building getBuilding()
        {
            return building;
        }


        override public void tick()
        {
            sectors[actualSector].tick();
            if (isChangingSector()) globalMovement = true;
            generateBird();
            generateNicelander();
        }


        private void generateBird()
        {
            if (getActualSector().hasBirds())
            {
                if (birdInit)
                {
                    float altitude = util.Random.value((int)getBotBounds().Top - 50, (int)getTopBounds().Top + 50);
                    bird = new Bird(0, altitude, true);
                    birdInit = false;
                }

                if (isChangingSector())
                {
                    Handler.remove(bird);
                    birdInit = true;
                }
            }
        }


        private void generateNicelander()
        {
            Window[] windows = getActualWindows();
            Window w;
            if (spawnNicelander)
            {
                for (int i = 0; i < windows.Length; i++)
                {
                    w = windows[i];
                    initNicePosition(w);
                    if (!spawnNicelander) break;
                }
            }
        }


        private void initNicePosition(Window w)
        {
            if (getActualSector().hasNicelanders())
            {
                if (w.getStrokesRequired() >= 2 && w.getStrokesRequired() <= 4 && w.getID() != ID.DoubleDoor)
                {
                    if (util.Random.boolValue(5))
                    {
                        nicelander = new Nicelander(w.getX() + 8, w.getY() + 30);
                        w.setNicelander(nicelander);
                        spawnNicelander = false;
                    }// boolValue
                }// strokesRequired
            }// actualSector
        }// void

        public override void draw(SKCanvas g)
        {
            g.DrawBitmap(sprite.getImage(), new SKPoint(POS_X, POS_Y));

            // TODO: show hit box
            //g.setColor(Color.GREEN);
            //if (GameManager.showHitBox)
            //{
            //    g.draw(getLeftBounds());
            //    g.draw(getRightBounds());
            //    g.draw(getBotBounds());
            //    g.draw(getTopBounds());
            //}

            for(int i=0;i<sectors.Length;i++)
            {
                sectors[i].draw(g);
            }
            
        }


        public void changeSector()
        {
            previousSector = actualSector;
            actualSector++;
            spawnNicelander = true;
            nicelanderDelay = DateTime.Now.Ticks;
            Score.getScore().nextSector();
        }

        public void stopGM()
        {
            globalMovement = false;
        }


        public bool getGM()
        {
            return globalMovement;
        }


        public Window[] getActualWindows()
        {
            return sectors[actualSector].getWindows();
        }

        public Window[] getPreviousWindows()
        {
            return sectors[previousSector].getWindows();
        }


        public override SKRect getBounds()
        {
            return new SKRect(0,0,0,0);
        }


        override
    public SKRect getTopBounds()
        {
            return sectors[actualSector].getTopBounds();
        }


        override
    public SKRect getLeftBounds()
        {
            return new SKRect(POS_X + 11, POS_Y, 3, 1000);
        }


        override
    public SKRect getRightBounds()
        {
            return new SKRect(POS_X + 298, POS_Y, 3, 1000);
        }


        override
    public SKRect getBotBounds()
        {
            return sectors[actualSector].getBotBounds();
        }


        public String getName()
        {
            return "Building";
        }


        public bool isChangingSector()
        {
            return sectors[actualSector].changeSector();
        }


        public int getIndexActualSector()
        {
            return actualSector;
        }

        public Sector getActualSector()
        {
            return sectors[actualSector];
        }

        public Sector getSector(int i)
        {
            return sectors[i];
        }

        public bool canChangeLevel()
        {
            return isChangingSector() && actualSector == 3;
        }

        public void resetBuilding()
        {
            initSectors();
            actualSector = 0;
            previousSector = 0;
            stopGM();
        }
    }
}
