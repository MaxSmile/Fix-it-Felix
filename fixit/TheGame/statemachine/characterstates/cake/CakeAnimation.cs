using System;
namespace fixit.TheGame.statemachine.characterstates.cake
{
    public class CakeAnimation : State
    {
        private static CakeAnimation cake = new CakeAnimation();

        private CakeAnimation()
        {
            animation = Images.Instance.getCake();
            animUpdate = 700;
        }

        public static CakeAnimation getCake()
        {
            return cake;
        }
        
        public override SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
