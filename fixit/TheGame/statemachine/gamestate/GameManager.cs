using System;
using fixit.TheGame.entities;
using fixit.TheGame.entities.creatures;
using fixit.TheGame.graphics;
using fixit.TheGame.input;
using fixit.TheGame.sectorstates;
using SkiaSharp;

namespace fixit.TheGame.statemachine.gamestate
{
    public class GameManager : GameState
    {
        public static bool showHitBox;

        private Handler handler;

        private Building b;

        private Felix felix;
        private Ralph ralph;

        private Sprite bush;

        private long timing;

        private static bool chooseLevel;

        private Cloud cloud;
        private Cloud cloud1;


        private static GameManager _instance = null;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameManager();
                return _instance;
            }
        }


        

        private GameManager()
        {
            handler = new Handler();

            b = Building.getBuilding();

            cloud = new Cloud(0, 300);
            cloud1 = new Cloud(150, 200);

            felix = new Felix(Constant.WIDTH / 2, Constant.HEIGHT - 100);

            HUD.getHud().setFelix(felix);

            chooseLevel = false;

            ralph = new Ralph(300, 240);

            bush = Images.Instance.getBush();

        }



        
        public void tick()
        {
            long time = 0;
            if (b.canChangeLevel())
            {
                Win.setTiming(time);
                GameStatus.changeState(5);
            }


            if (b.canChangeLevel())
            {
                nextLevel();
            }



            if (felix.getLife() == 0)
            {
                Score.getScore().saveScore();
                GameStatus.changeState(3);
                felix.resetAll(Constant.WIDTH / 2, Constant.HEIGHT - 100);
            }


            handler.tick();



            if (KeyBoard.pause)
            {
                GameStatus.changeState(2);
            }

        }


        public void draw(SKCanvas g)
        {
            drawBushes(g);
            handler.draw(g);
        }


        private void drawBushes(SKCanvas g)
        {
            int bushPosX = 0;
            for (int i = 0; i < 33; i++)
            {
                g.DrawBitmap(bush.getImage(), 0 + bushPosX, Constant.HEIGHT - 45, null);
                bushPosX += bush.getWidth();
            }
        }


        public static int getLevel()
        {
            return Level.getLevel().getActualLevel();
        }


        public void resetGameManager()
        {
            b.resetBuilding();
            if (!chooseLevel)
            {
                Level.getLevel().resetGame();
            }

            ralph.reset(300, 240);
            felix.resetAll(Constant.WIDTH / 2, Constant.HEIGHT - 100);
            HUD.getHud().setFelix(felix);
            DrawingSurface.resetSurface();
            Handler.removeAll();
        }


        public void nextLevel()
        {
            b.resetBuilding();
            ralph.reset(300, 240);
            felix.resetAll(Constant.WIDTH / 2, Constant.HEIGHT - 100);
            DrawingSurface.resetSurface();
            Level.getLevel().levelUp();
            ralph.setVelocity(Level.getLevel().getRalphVel());
            ralph.setBrickTime(Level.getLevel().getRalphTime());
            HUD.getHud().reset();
            Handler.removeAll();
        }


        public static void setChoose(bool choose)
        {
            chooseLevel = choose;
        }
    }
}
