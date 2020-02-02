using System;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.graphics;
using fixit.TheGame.sectorstates;
using fixit.TheGame.statemachine.gamestate;
using SkiaSharp;

namespace fixit.TheGame
{
    public class HUD
    {
        private Sprite lifeImage;
        private int lifeAmount;
        private util.Timer clock;

        private static HUD hud = new HUD();

        private HUD()
        {
            clock = new util.Timer(180000);
            lifeImage = Images.Instance.getLife();
        }



        public static HUD getHud()
        {
            return hud;
        }

        public void draw(SKCanvas canvas)
        {
            var paint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Yellow,
                TextSize = 20
            };

            //canvas.DrawRect(new SKRect(0,26,30,50),paint);
            //canvas.DrawRect(new SKRect(100, 26, 130, 50), paint);
            

            paint.Color = SKColors.Red;
            canvas.DrawText(GameStatus.actualState.GetType().Name, 60, 80, paint);


            //paint.Color = SKColors.White;
            //canvas.DrawText("" + Score.getScore().getActualScore(), 120, 80, paint);

            clock.draw(canvas);

            drawLife(canvas);
        }


        private void drawLife(SKCanvas canvas)
        {
            int lifePosX = 0;
            for (int i = 0; i < lifeAmount; i++)
            {
                canvas.DrawBitmap(lifeImage.getImage(), new SKPoint(Constant.WIDTH - 50 - lifePosX, 0));
                lifePosX += lifeImage.getWidth() + 5;
            }
        }



        public void reset()
        {
            clock.reset();
        }

        public void tick()
        {
            lifeAmount = GameManager.Instance.GetFelix().getLife();
            clock.tick();
        }
    }
}
