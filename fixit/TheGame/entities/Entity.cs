using System;
using System.Collections.Generic;
using fixit.TheGame.physics;
using fixit.TheGame.statemachine;
using SkiaSharp;

namespace fixit.TheGame.entities
{
    public abstract class Entity
    {
        protected int width;
        protected int height;

        protected State state;

        protected ID id;

        private Position position;

        public Entity(float x, float y)
        {
            position = new Position(x, y);
        }

        public abstract void draw(SKCanvas g, long time);
        public abstract void tick(List<Entity> objects, long beforeTime);

        // Limites
        public abstract SKRect getBounds();
        public abstract SKRect getTopBounds();
        public abstract SKRect getLeftBounds();
        public abstract SKRect getRightBounds();
        public abstract SKRect getBotBounds();

        // Getters and setters
        public int getWidth()
        {
            return width;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public float getX()
        {
            return position.getX();
        }

        public void setX(float x)
        {
            position.setX(x);
        }

        public float getY()
        {
            return position.getY();
        }

        public void setY(float y)
        {
            position.setY(y);
        }

        public ID getID()
        {
            return id;
        }




        public void setXY(float x, float y)
        {
            setX(x);
            setY(y);
        }
    }
}
