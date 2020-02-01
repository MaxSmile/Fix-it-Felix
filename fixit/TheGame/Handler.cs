using System;
using System.Collections.Generic;
using fixit.TheGame.entities;
using fixit.TheGame.entities.creatures;
using SkiaSharp;

namespace fixit.TheGame
{
    public class Handler
    {
        public static List<Entity> objects;
        private Entity tempObject;

        private Building building;


        public Handler()
        {
            objects = new List<Entity>();
            this.building = Building.getBuilding();
        }



        public static void add(Entity obj)
        {
            objects.Add(obj);
        }



        public static void remove(Entity obj)
        {
             objects.Remove(obj);
        }


        public static void addBrick(float x, float y)
        {
            int actualSector = Building.getBuilding().getIndexActualSector();
            Brick brick = new Brick((int)x, (int)y, actualSector);
        }


        public static void removeAll()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Entity e = objects[i];
                if (e.GetType() == typeof (Brick) || e.GetType() == typeof(Bird)) {
                    objects.Remove(e);
                }
            }
        }

        public void tick()
        {
            building.tick();
            for (int i = 0; i < objects.Count; i++)
            {
                tempObject = objects[i];
                tempObject.tick();
            }
        }



    public void draw(SKCanvas g)
    {
        building.draw(g);
        for (int i = 0; i < objects.Count; i++)
        {
            tempObject = objects[i];
            tempObject.draw(g);
        }
    }

    public Building getBuilding()
    {
        return building;
    }
}
}
