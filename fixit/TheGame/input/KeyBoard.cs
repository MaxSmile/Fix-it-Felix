using System;
namespace fixit.TheGame.input
{
    public class KeyBoard
    {
        public static bool up;
        public static bool down;
        public static bool right;
        public static bool left;
        public static bool pause;
        public static bool fix;
        public static bool hitBox;

        public static void consume()
        {
            up = false;
            down = false;
            right = false;
            left = false;
            pause = false;
            fix = false;
            hitBox = false;
        }

        public static bool ifAny()
        {
            return up||down||right||left||pause||fix||hitBox;
        }

    }
}
