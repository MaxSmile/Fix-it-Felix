using System;
namespace fixit.TheGame.statemachine.characterstates.ralphstates
{
    public class Climbing:State
    {
        private static Climbing climb = new Climbing();


        private Climbing()
        {
            animation = Images.Instance.getClimbing();
            animUpdate = 600;
        }

        public static Climbing getClimbing()
        {
            return climb;
        }

        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
