using System;
using System.Collections.Generic;
using System.Reflection;
using SkiaSharp;

namespace fixit.TheGame.graphics
{
    public class Animation
    {
        private List<Sprite> sprites;
        private int actualFrame;
        private int framesAmount;

        private void init()
        {
            sprites = new List<Sprite>();
            actualFrame = 0;
        }

        public Animation()
        {
            init();
        }


        public Animation(String[] paths)
        {
            init();
            addFrames(paths);
        }

        public Animation(List<Sprite> sprites)
        {
            this.sprites = sprites;
        }

        private void addFrames(String[] paths)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                addFrame(new Sprite(ResourceLoader.Instance.LoadImage(paths[i])));
            }
        }

        

        public void addFrame(Sprite frame)
        {
            sprites.Add(frame);
            framesAmount++;
        }



        public int getIndexAnimation()
        {
            return actualFrame;
        }


        public SKBitmap getActualFrame()
        {
            return sprites[actualFrame].getImage();
        }


        public SKBitmap getFrame(int i)
        {
            return sprites[i].getImage();
        }


        public void tick()
        {
            if (actualFrame == framesAmount - 1)
                actualFrame = -1;
            actualFrame++;
        }


        public List<Sprite> getAnimation()
        {
            return sprites;
        }


        public Sprite getIanimation(int i)
        {
            return sprites[i];
        }

        public void setAnimation(List<Sprite> sprites)
        {
            this.sprites = sprites;
        }

        public int getFramesAmount()
        {
            return framesAmount;
        }
    }
}
