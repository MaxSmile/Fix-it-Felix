using System;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class GameManager : GameState
    {
        public GameManager()
        {
        }

        public void draw(SKCanvas c)
        {
            throw new NotImplementedException();
        }

        public void tick()
        {
            throw new NotImplementedException();
        }

        private static GameManager _instance = null;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameManager();
                return _instance;
            }
        }
    }
}
