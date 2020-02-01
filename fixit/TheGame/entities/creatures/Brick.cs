using System;
using fixit.TheGame.graphics;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.creatures
{
    public class Brick: Creature
    {
        private fixit.TheGame.graphics.Animation brick;

        private int actualSector;

        public Brick(float x, float y, int actualSector):base(x,y)
        {

            brick = Images.Instance.getBrick();

            vel = Level.getLevel().getBrickVel();


            this.actualSector = actualSector;
            id = ID.Brick;

            Handler.add(this);
        }

    

        override
        public void draw(SKCanvas g)
        {
            brick.tick();
            g.DrawBitmap(brick.getActualFrame(), new SkiaSharp.SKPoint((int)getX(), (int)getY()));
        }

        override
        public void tick()
        {

            Building b = Building.getBuilding();

            setY(getY() + vel);

            if (getY() > b.getSector(actualSector).getBotBounds().Top + 100)
            {
                Handler.remove(this);
            }
        }


        override
        public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), 18, 12);
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
