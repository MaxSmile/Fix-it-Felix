using System;
namespace fixit.TheGame.statemachine.characterstates.felixstates
{
    public class Normal : State
    {
        private static Normal normal = new Normal();

 


        private Normal()
        {
            animation = Images.Instance.getFelixNormalRight();
            animUpdate = 1;
        }

        public static Normal getNormal()
        {
            return normal;
        }

        override
    public SkiaSharp.SKBitmap getImage(int dir)
        {
            if (dir == -1)
            {
                animation = Images.Instance.getFelixNormalLeft();
            }
            else
                animation = Images.Instance.getFelixNormalRight();
            return animation.getActualFrame();
        }
    }
}
