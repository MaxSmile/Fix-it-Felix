using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class FelixWin:State
    {
        private static FelixWin felixWin = new FelixWin();

        private FelixWin()
        {
            animation = Images.Instance.getFelixWin();
            animUpdate = 800;
        }


        public static FelixWin getFelixWin()
        {
            return felixWin;
        }


        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
