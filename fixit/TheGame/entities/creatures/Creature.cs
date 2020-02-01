using System;
using fixit.TheGame.physics;

namespace fixit.TheGame.entities.creatures
{
    public abstract class Creature : Entity
    {
        private Displacement displacement;

        protected int directionX;
        protected int directionY;

        protected float vel;


        public Creature(float x, float y):base(x,y)
        {
            displacement = new Displacement();
        }

        // Setters y getters
        public float getDx()
        {
            return displacement.getDx();
        }

        public float getDy()
        {
            return displacement.getDy();
        }

        public void setDx(float dx)
        {
            displacement.setDx(dx);
        }

        public void setDy(float dy)
        {
            displacement.setDy(dy);
        }

        public int getDirectionX()
        {
            return directionX;
        }

        public void setDirectionX(int directionX)
        {
            this.directionX = directionX;
        }

        public int getDirectionY()
        {
            return directionY;
        }

        public void setDirectionY(int directionY)
        {
            this.directionY = directionY;
        }

        public void setVelocity(float vel)
        {
            this.vel = vel;
        }

        public float getVel()
        {
            return vel;
        }

    }
}
