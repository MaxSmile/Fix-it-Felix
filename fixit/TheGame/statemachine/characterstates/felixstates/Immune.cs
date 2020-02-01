using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class Immune:State
    {
        private static Immune inmmune = new Immune();

        private Immune()
        {
            animation = Images.Instance.getFelixMoveRight();
            animUpdate = 2;
        }

        public static Immune getImmune()
        {
            return inmmune;
        }


        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            if (dir == -1)
            {
                animation = Images.Instance.getFelixMoveLeft();
            }
            else
                animation = Images.Instance.getFelixMoveRight();
            return animation.getActualFrame();
        }
    }
}
