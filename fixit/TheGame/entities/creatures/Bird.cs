using System;
using fixit.TheGame.statemachine;
using SkiaSharp;

namespace fixit.TheGame.entities.creatures
{
    public class Bird:Creature
    {
        
        private bool side;

        public Bird(float x, float y, bool side):base(x,y)
        {
           

            vel = Level.getLevel().getBirdVel();
            id = ID.Bird;

            this.side = side;
            changeSide();

            state = BirdMoving.getMoving();

            Handler.add(this);
        }

        private void changeSide()
        {


            if (side)
            {
                setX(0 - 30);
                directionX = 1;
            }
            else
            {
                setX(Constant.WIDTH);
                directionX = -1;
            }
        }


    


        
    public override void draw(SKCanvas g)
        {
            state.update();

            g.DrawBitmap(state.getImage(directionX), SKPoint((int)getX(), (int)getY()));

        }


        
    public override void tick()
        {

            //		System.out.println("Bird: " + vel);
            setX(getX() + getDx());
            if (side)
            {
                setDx(vel);
                if (getX() > Constant.WIDTH + 20) side = !side;
                directionX = 1;
            }
            else
            {
                setDx(-vel);
                if (getX() < 0 - 20)
                {
                    side = !side;
                    setY(util.Random.value(Building.getBuilding().getBotBounds().y, Building.getBuilding().getTopBounds().y));
                }
                directionX = -1;
            }

        }


        public void setVelocity(float vel) { }

        override
    public SKRect getBounds()
        {
            return new SKRect((int)getX(), (int)getY(), 30, 20);
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
