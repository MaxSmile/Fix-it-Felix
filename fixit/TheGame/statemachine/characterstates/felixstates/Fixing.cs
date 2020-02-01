using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class Fixing:State
    {
        private static Fixing fixing = new Fixing();

        private Fixing()
        {
            animUpdate = 300;
        }

        public static Fixing getFixing()
        {
            return fixing;
        }


        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            if (dir == -1)
            {
                animation = Images.Instance.getFelixFixingLeft();
            }
            else
                animation = Images.Instance.getFelixFixingRight();
            return animation.getActualFrame();
        }
    }
}
