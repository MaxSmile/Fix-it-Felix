using System;
namespace fixit.TheGame.statemachine.characterstates.ralphstates
{
    public class Demolishing:State
    {
        private static Demolishing demolishing = new Demolishing();

        private Demolishing()
        {
            animation = Images.Instance.getRalphDemolition();
            animUpdate = 300;
        }

        public static Demolishing getDemolishing()
        {
            return demolishing;
        }

        override
        public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
