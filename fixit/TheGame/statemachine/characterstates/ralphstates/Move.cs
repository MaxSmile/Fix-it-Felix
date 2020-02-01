using System;
namespace fixit.TheGame.statemachine.characterstates.ralphstates
{
    public class Move:State
    {
        private static Move move = new Move();


        private Move()
        {
            animation = Images.Instance.getRalphMove();
            animUpdate = 300;
        }

        public static Move getMove()
        {
            return move;
        }

        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }

    }
}
