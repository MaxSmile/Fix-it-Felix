using System;
using fixit.TheGame.graphics;
using SkiaSharp;

namespace fixit.TheGame.entities.creatures
{
    public class Brick: Creature
    {
        private Animation brick;

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
    public SKRect getBounds()
        {
            return new SKRect((int)getX(), (int)getY(), 18, 12);
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
