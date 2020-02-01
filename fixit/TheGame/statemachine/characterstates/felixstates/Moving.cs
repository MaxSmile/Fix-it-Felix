using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class Moving:State
    {
        private static Moving moving = new Moving();



        private Moving()
        {
            animation = Images.Instance.getFelixMoveRight();
            animUpdate = 200;
        }

        public static Moving getMoving()
        {
            return moving;
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
