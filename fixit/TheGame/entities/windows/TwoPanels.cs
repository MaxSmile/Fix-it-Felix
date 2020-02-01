using System;
using fixit.TheGame.entities.windows.parts;
using fixit.TheGame.graphics;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.windows
{
    public class TwoPanels : Window
    {
        private Sprite window;

        private  int BOT_DISP_Y = 20;

        private Glass topGlass;
        private Glass botGlass;

        private int topGlassState;
        private int botGlassState;

        private Sprite roof;
        private Sprite flowerPot;

        public TwoPanels(float x, float y, bool hasObstacle):base(x,y)
        {
            
            window = Images.Instance.getTwoPanels();


            strokesRequired = util.Random.value(0, 4);
            //		strokesRequired = 1;

            initObstacle(hasObstacle);

            width = 38;
            height = 60;

            topGlass = new Glass();
            botGlass = new Glass();

            topGlassState = 1;
            botGlassState = 1;

            roof = Images.Instance.getRoof();
            flowerPot = Images.Instance.getFlowerPot();
        }


        private void initObstacle(bool hasObstacle)
        {
            if (hasObstacle)
            {
                if (util.Random.boolValue(3))
                {
                    hasFlowerPot = true;
                }
                else
                    hasRoof = true;
            }
        }



        override
    public void draw(SKCanvas g)
        {

            g.DrawBitmap(window.getImage(), new SKPoint((int)getX(), (int)getY()));

            g.DrawBitmap(topGlass.getGlass(topGlassState).getImage(),
                new SKPoint((int)getX() + topGlass.getDispX(topGlassState),
                (int)getY() + topGlass.getDispY(topGlassState)));


            g.DrawBitmap(botGlass.getGlass(botGlassState).getImage(),
                    new SKPoint((int)getX() + botGlass.getDispX(botGlassState),
                    (int)getY() + botGlass.getDispY(botGlassState) + BOT_DISP_Y));

            if (hasFlowerPot)
            {
                g.DrawBitmap(flowerPot.getImage(), new SKPoint((int)getX() + 5, (int)getY() + 43));
            }

            if (hasRoof)
            {
                g.DrawBitmap(roof.getImage(), new SKPoint((int)getX() - 1, (int)getY() - 11));
            }

            //g.setColor(Color.GREEN);
            //		g.draw(getBounds());
            //		g.draw(getBotBounds());
            //		g.draw(getTopBounds());
        }


        override
    public void tick()
        {

            switch (strokesRequired)
            {
                case 0:
                    topGlassState = 1;
                    botGlassState = 1;
                    break;
                case 1:
                    topGlassState = 1;
                    botGlassState = 5;
                    break;
                case 2:
                    topGlassState = 1;
                    botGlassState = 0;
                    break;
                case 3:
                    topGlassState = 4;
                    botGlassState = 0;
                    break;
                case 4:
                    topGlassState = 0;
                    botGlassState = 0;
                    break;
                default:
                    break;
            }
        }



        override
    public Rectangle getTopBounds()
        {
            return new Rectangle((int)getX(), (int)getY() - 10, 36, 6);
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
            return new Rectangle((int)getX(), (int)getY() + 52, 40, 5);
        }

  

        override
    public Rectangle getBounds()
        {
            return new Rectangle((int)getX(), (int)getY(), width, height);
        }

    }
}
