using System;
using fixit.TheGame.entities;
using fixit.TheGame.input;
using fixit.TheGame.sectorstates;
using fixit.TheGame.statemachine.gamestate;
using SkiaSharp;

namespace fixit.TheGame.graphics
{
    public class DrawingSurface
    {
        //private MouseInput mouse;
        private static bool prevGM = false;
        private static int floor;

        public DrawingSurface()
        {
            //mouse = new MouseInput();
            //addKeyListener(inputKeys);
            //addMouseListener(mouse);
            //setFocusable(true);
            //setIgnoreRepaint(true);
            //requestFocus();
            floor = 237;
        }


        // esto se va a usar para cuando cambie de sector asi translada la imagen al segundo sector
        // como el juego de disney lo comentado dentro era solo para hacer debug si ejecutas esa linea
        // la camara se va a mover hasta la punta del edificio

        public void tick()
        {

            if (GameStatus.actualState.GetType() == typeof(GameManager)){
                HUD.getHud().tick();
            }


            if (GameStatus.actualState.GetType() == typeof(GameManager))
            {
                if (Building.getBuilding().getGM())
                {
                    // TODO: building grow logic?
                    //if (cam.getY() < floor)
                    //{
                    //    cam.tick();
                    //    prevGM = true;
                    //}
                    //else
                    //{
                    //    Building.getBuilding().stopGM();
                    //}
                }
                else
                {
                    if (prevGM)
                    {
                        floor = floor + 203;
                        prevGM = false;
                    }
                }
            }
        }

        public static void resetSurface()
        {
            prevGM = false;
            floor = 237;
        }

        internal void draw(GameStatus gameStatus, SKCanvas canvas)
        {
            gameStatus.draw(canvas);
            HUD.getHud().draw(canvas);
        }
    }
}
