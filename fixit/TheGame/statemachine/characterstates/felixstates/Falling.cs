using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class Falling:State
    {
        private static Falling falling = new Falling();

        private Falling()
        {
            animation = Images.Instance.getFelixFalling();
            animUpdate = 300;
        }

        public static State getFalling()
        {
            return falling;
        }

        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
