﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using fixit.TheGame.graphics;
using fixit.TheGame.sectorstates;
using fixit.TheGame.statemachine.gamestate;
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

        public Action<int> OnNeedToSartScorePage = null;

        

        public void startGame(Action readyToInvalidateSurface)
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
                        readyToInvalidateSurface?.Invoke();
                    });
                    await Task.Delay(25);
                }
            });
        }

        public void resetGame()
        {
            GameManager.Instance.resetGameManager();
            drawingSurface = new DrawingSurface();
            gameStatus = new GameStatus();
        }

    
        internal void OnDraw(SKCanvas canvas)
        {
            draw(canvas);

        }

        private void tick()
        {

            gameStatus.tick();
            drawingSurface.tick();
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
