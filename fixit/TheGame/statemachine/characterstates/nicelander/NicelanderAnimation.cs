using System;
using fixit.TheGame.graphics;

namespace fixit.TheGame.statemachine.characterstates.nicelander
{
    public class NicelanderAnimation:State
    {
        private String[] nicelanderPaths = {
        "fixit.TheGame.images.entities.nicelander.0.png",
        "fixit.TheGame.images.entities.nicelander.1.png"
    };
	
	private static NicelanderAnimation nicelander = new NicelanderAnimation();

        private NicelanderAnimation()
        {
            animUpdate = 1200;
            animation = new Animation(nicelanderPaths);
        }

        public static NicelanderAnimation getNicelander()
        {
            return nicelander;
        }

        override
    public SkiaSharp.SKBitmap getImage(int dir)
        {
            return animation.getActualFrame();
        }
    }
}
