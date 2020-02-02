using System;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class PauseMenu : GameState
    {
        public PauseMenu()
        {
        }

        void GameState.draw(SKCanvas c)
        {
            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Orange,
                TextSize = 80
            };

            c.DrawText("PAUSED", Constant.WIDTH / 2 - 200, Constant.HEIGHT / 2 + 40, textPaint);
        }

        void GameState.tick()
        {
            
        }
    }
}
