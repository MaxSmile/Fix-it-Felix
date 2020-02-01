using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using fixit.TheGame.graphics;
using fixit.TheGame.sectorstates;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame
{
    public class Game
    {
        public static bool inGame;

        public long gameStartTime;
        private DrawingSurface drawingSurface;
        private GameStatus gameStatus;


        private static Game _instance = null;

        private Game()
        {
            inGame = true;
            drawingSurface = new DrawingSurface();
            gameStatus = new GameStatus();
        }


        public static Game Instance
        {
            get
            {
                if (_instance == null) _instance = new Game();
                return _instance;
            }
        }

        
        public void startGame(Action ready)
        {
            Score.getScore().readFromFile();
            gameStartTime = DateTime.Now.Ticks;
            Task.Run(async()=> {
                while (inGame)
                {
                    await Task.Yield();
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        tick();
                        ready?.Invoke();
                    });
                    await Task.Delay(25);
                }
            });
        }


    
        internal void OnDraw(SKCanvas canvas)
        {
            draw(canvas);
            //canvas.DrawBitmap(Images.Instance.getRoof().getImage(), new SKPoint(20,40));
        }

        private void tick()
        {
            gameStatus.getActualState();
            if (!Score.getScore().askName())
            {
                gameStatus.tick();
                drawingSurface.tick();
            }
        }


        // game status is sent because you know what to draw at the indicated time, example if pulse pauses
        // the game status will draw a black screen with a string that says pause
        // (it is necessary to indicate in the code that when I press escape the game status will change to pause mode), if I put game manager as status
        // draw the corresponding objects when you are playing felix, birds, ralph, etc.

        private void draw(SKCanvas canvas)
        {
            drawingSurface.draw(gameStatus,canvas);
        }


        public static void quitGame()
        {
            inGame = false;
        }

        
    }
}
