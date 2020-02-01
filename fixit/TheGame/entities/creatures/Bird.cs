using System;
using fixit.TheGame.statemachine;
using fixit.TheGame.statemachine.characterstates.bird;
using SkiaSharp;
using Xamarin.Forms;

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

            g.DrawBitmap(state.getImage(directionX), new SKPoint((int)getX(), (int)getY()));

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
                    setY(util.Random.value((int)Building.getBuilding().getBotBounds().Top,(int) Building.getBuilding().getTopBounds().Top));
                }
                directionX = -1;
            }

        }


        

        override
    public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), 30, 20);
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
