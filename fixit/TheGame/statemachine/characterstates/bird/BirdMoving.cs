using System;
namespace fixit.TheGame.statemachine.characterstates.bird
{
    public class BirdMoving:State
    {
        private static BirdMoving moving = new BirdMoving();


        private BirdMoving()
        {
            animUpdate = 700;
        }

        public static BirdMoving getMoving()
        {
            return moving;
        }


        
    public override SkiaSharp.SKBitmap getImage(int dir)
        {
            if (dir == -1)
            {
                animation = Images.Instance.getLeftBird();
            }
            else
                animation = Images.Instance.getRightBird();
            return animation.getActualFrame();
        }
    }
}
