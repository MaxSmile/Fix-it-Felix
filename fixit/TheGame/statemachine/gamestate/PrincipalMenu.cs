using System;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class PrincipalMenu : GameState
    {
        private Cloud[] cloud = new Cloud[2];

        public PrincipalMenu()
        {
            cloud[0] = new Cloud(Constant.WIDTH / 2, 300);
            cloud[1] = new Cloud(0, 150);
        }

        void GameState.draw(SKCanvas c)
        {
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].draw(c);
            }
        }

        void GameState.tick()
        {
            for(int i=0;i<cloud.Length;i++)
            {
                cloud[i].tick();
            }
        }
    }
}
