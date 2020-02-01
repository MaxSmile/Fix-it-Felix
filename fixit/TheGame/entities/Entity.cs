using System;
using System.Collections.Generic;
using fixit.TheGame.physics;
using fixit.TheGame.statemachine;
using SkiaSharp;
using Xamarin.Forms;

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

        public abstract void draw(SKCanvas g);
        public abstract void tick();//List<Entity> objects

        // Limites
        public abstract Rectangle getBounds();
        public abstract Rectangle getTopBounds();
        public abstract Rectangle getLeftBounds();
        public abstract Rectangle getRightBounds();
        public abstract Rectangle getBotBounds();

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
