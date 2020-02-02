using System;
using fixit.TheGame.entities;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.graphics;
using fixit.TheGame.input;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class PrincipalMenu : GameState
    {
        private Cloud[] cloud = new Cloud[2];
        private Building building;


        public PrincipalMenu()
        {
            cloud[0] = new Cloud(Constant.WIDTH / 2, 300);
            cloud[1] = new Cloud(0, 150);

            building = Building.getBuilding();
        }

        void GameState.draw(SKCanvas c)
        {
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].draw(c);
            }

            building.draw(c);
            // DRAWING TEXT

            // create the paint for the text
            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Orange,
                TextSize = 80
            };

            c.DrawText("Tap anykey", Constant.WIDTH/2-200, Constant.HEIGHT/2+40, textPaint);
            c.DrawText("to Start", Constant.WIDTH / 2 - 80, Constant.HEIGHT / 2 + 160, textPaint);
        }

        void GameState.tick()
        {
            for(int i=0;i<cloud.Length;i++)
            {
                cloud[i].tick();
            }

            if(KeyBoard.ifAny())
            {
                KeyBoard.consume();
                GameStatus.changeState(GameStatus.GAME_STATES.GAME);
            }
        }
    }
}
