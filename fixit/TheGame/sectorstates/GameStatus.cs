using System;
using fixit.TheGame.statemachine.gamestate;
using SkiaSharp;

namespace fixit.TheGame.sectorstates
{
    public class GameStatus : GameState
    {
        public static GameState[] states;
        public static GameState actualState;

        public enum GAME_STATES { MENU,GAME,PAUSE,SCORE,RULES,WIN };

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
            actualState = states[(int)GAME_STATES.MENU];
        }

        

        public static void changeState(GAME_STATES i)
        {
            actualState = states[(int)i];
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
