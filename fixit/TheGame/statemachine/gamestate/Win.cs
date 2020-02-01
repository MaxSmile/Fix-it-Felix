using System;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.graphics;
using fixit.TheGame.sectorstates;
using fixit.TheGame.statemachine.characterstates.felixstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class Win : GameState
    {
        private State felixAnim = FelixWin.getFelixWin();

        private static long timing;
        private Sprite buildingRoof;

        private Cloud[] clouds;

        public Win()
        {
            buildingRoof = Images.Instance.getBuildingRoof();
            clouds = new Cloud[3];
            initClouds();
        }

        private void initClouds()
        {
            clouds[0] = new Cloud(40, 500);
            clouds[1] = new Cloud(300, 350);
            clouds[2] = new Cloud(600, 670);
        }

        
        public void draw(SKCanvas g)
        {

            drawClouds(g);



            felixAnim.update();
            //g.drawRect(0, 0, 800, 600);
            g.DrawBitmap(felixAnim.getImage(0), new SKPoint(Constant.WIDTH / 2, Constant.HEIGHT / 2 + 78));
            g.DrawBitmap(buildingRoof.getImage(),
                new SKPoint(Constant.WIDTH / 2 - buildingRoof.getWidth() / 2, Constant.HEIGHT - 186));

            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Wheat,
                TextSize = 80
            };

            g.DrawText("Level " + (Level.getLevel().getActualLevel() - 1) + " Completed", 90, 200, textPaint);
            
        }

        private void drawClouds(SKCanvas g)
        {
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].draw(g);
            }
        }

        
        public void tick()
        {

            long beforeTime = 0;
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].tick();
            }

            if (beforeTime - timing > 5000)
            {
                GameStatus.changeState(1);
            }

        }

        public static void setTiming(long time)
        {
            timing = time;
        }

    }
}
