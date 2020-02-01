using System;
using fixit.TheGame.statemachine.gamestate;
using SkiaSharp;

namespace fixit.TheGame.sectorstates
{
    public class GameStatus : GameState
    {
        public static GameState[] states;
        public static GameState actualState;


        public GameStatus()
        {
            initState();
            initActualState();
        }


        private void initState()
        {
            states = new GameState[Constant.STATES];
            states[0] = new PrincipalMenu();
            states[1] = GameManager.Instance;
            states[2] = new PauseMenu();
            states[3] = new ScoreMenu();
            states[4] = new GameRules();
            states[5] = new Win();
        }


        private void initActualState()
        {
            actualState = states[0];
        }


        public static void changeState(int i)
        {
            actualState = states[i];
        }


        public void tick()
        {
            actualState.tick();
        }


        public void draw(SKCanvas canvas)
        {
            actualState.draw(canvas);
        }


        public GameState getActualState()
        {
            return actualState;
        }

    }
}
