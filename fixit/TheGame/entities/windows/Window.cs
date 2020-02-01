using System;
namespace fixit.TheGame.entities.windows
{
    public abstract class Window : Entity
    {
        protected int strokesRequired;

        public bool hasFlowerPot;
        public bool hasRoof;

        protected Nicelander nicelander;

        public Window(float x, float y) : base(x, y)
        {

            nicelander = null;
        }

        public int getStrokesRequired()
        {
            return strokesRequired;
        }

        public void getFixed()
        {
            if (isBroken())
            {
                strokesRequired--;
            }
        }


        public bool isBroken()
        {
            return strokesRequired > 0;
        }






        public void setNicelander(Nicelander nicelander)
        {
            this.nicelander = nicelander;
        }


        public void removeNicelander()
        {
            if (nicelander != null)
            {
                Handler.remove(nicelander);
            }
        }
    }
}
