using System;
using fixit.TheGame.statemachine.characterstates.ralphstates;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.creatures
{
    public class Ralph: Creature
    {
        private float CLIMBING = 3.0f;

        private long DELAY_PER_BRICK = 5000;

        private int floor;

        private long time = DateTime.Now.Ticks;

        private long brickTime;

        private bool prevGM;

        public Ralph(float x, float y):base(x,y)
        {
            id = ID.Ralph;
            state = Move.getMove();

            vel = Level.getLevel().getRalphVel();

            brickTime = Level.getLevel().getRalphTime();

            setDx(vel);
            prevGM = false;

            width = 93;
            height = 84;

            floor = 0;

            Handler.add(this);
        }


        override
        public void draw(SKCanvas g)
        {

            state.update();
            g.DrawBitmap(state.getImage(0), new SKPoint((int)getX(), (int)getY() + 10));

        }


        override
        public void tick()
        {
            long elapsedTime = 0;
            if (elapsedTime - time > 1500 || Building.getBuilding().isChangingSector())
            {
                if (Building.getBuilding().getGM())
                {
                    climbing(floor);
                    prevGM = true;
                    if (getY() == floor - 1)
                        moving(elapsedTime);
                }
                else
                {
                    moving(elapsedTime);
                    if (prevGM)
                    {
                        floor = floor - 238;
                        prevGM = false;
                    }
                }
            }
        }


        private void climbing(int floor)
        {
            state = Climbing.getClimbing();
            setDy(-CLIMBING);
            if (getY() > floor)
            {
                setY(getY() + getDy());
            }
        }

        private void moving(long elapsedTime)
        {

            state = Move.getMove();

            setX(getX() + getDx());

            if (getBounds().IntersectsWith(Building.getBuilding().getLeftBounds()))
            {
                setDx(vel);
            }
            else
                if (getBounds().IntersectsWith(Building.getBuilding().getRightBounds()))
                setDx(-vel);



            if (elapsedTime - time > brickTime)
            {

                time = DateTime.Now.Ticks;
                state = Demolishing.getDemolishing();
                throwBrick();
            }

        }



        private void throwBrick()
        {
            Handler.addBrick(getX() + 25, getY() + 70);
            Handler.addBrick(getX() + 50, getY() + 70);
        }


        override
        public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), width, height);
        }


        override
        public Rectangle getTopBounds()
        {
            return Rectangle.Zero;
        }


        override
        public Rectangle getLeftBounds()
        {
            return Rectangle.Zero;
        }


        override
        public Rectangle getRightBounds()
        {
            return Rectangle.Zero;
        }


        override
        public Rectangle getBotBounds()
        {
            return Rectangle.Zero;
        }


        public void reset(float x, float y)
        {
            floor = 0;
            prevGM = false;
            setXY(x, y);
            vel = Level.getLevel().getRalphVel();
            brickTime = Level.getLevel().getRalphTime();

        }


        public void setBrickTime(long time)
        {
            brickTime = time;
        }
    }
}
