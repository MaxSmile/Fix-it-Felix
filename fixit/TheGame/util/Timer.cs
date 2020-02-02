using System;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.util
{
    public class Timer
    {
       
        private long ms;
        private int second;
        private int minute;

        public Timer(long initTime)
        {
            ms = initTime;
            minute = ((int)(ms / 1000)) / 60;
            second = ((int)(ms / 1000)) % 60;
        }

        public void tick()
        {
            countDown();
            if (second == 0 && minute == 0)
            {
                GameStatus.changeState(GameStatus.GAME_STATES.SCORE);
                Score.getScore().saveScore();
                reset();
            }

        }

        private void countDown()
        {
            if (DateTime.Now.Ticks - ms > 1000)
            {
                second--;
                ms = DateTime.Now.Ticks;
                if (second == -1)
                {
                    minute--;
                    second = 59;
                }
            }
        }

        public void reset()
        {
            this.ms = 180000;
            minute = ((int)(ms / 1000)) / 60;
            second = ((int)(ms / 1000)) % 60;
        }


        public void draw(SKCanvas g)
        {
            var paint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.White,
                TextSize = 30
            };
            g.DrawText(minute + ":" + second, new SKPoint(Constant.WIDTH / 2 - 20, 23),paint);
        }
    }
}
