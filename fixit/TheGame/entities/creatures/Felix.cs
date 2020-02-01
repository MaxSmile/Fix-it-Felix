using System;
using System.Collections.Generic;
using fixit.TheGame.entities.windows;
using fixit.TheGame.input;
using fixit.TheGame.statemachine.characterstates.felixstates;
using SkiaSharp;
using Xamarin.Forms;

namespace fixit.TheGame.entities.creatures
{
    public class Felix : Creature
    {
        /*
	 * Different states:
	 * 		Normal.getNormal() 	 
	 * 		Moving.getMoving()
	 * 		Fixing.getFixing()
	 * 		Jumping.getJumping()
	 * 		Immune.getImmune()
	 */

        private float JUMP_SPEED = -10f;
        private float MAX_JUMP = -80;//   la velocidad de salto es negativa y la gravedad positiva

        private float VEL = 3f;

        private long IMMUNE_DEATH = 2000;
        private long IMMUNE_CAKE = 7000;

        private long immuneDuration;

        private long movDelay = DateTime.Now.Ticks;
        private long delay = DateTime.Now.Ticks;
        private long inmTime;
        private float max_jump = 0;

        private float death_x;
        private float death_y;

        private bool dying;

        private bool onObstacle;
        private bool onGround;
        private bool falling;

        private bool isImmune;

        private int life;


        public Felix(float x, float y):base(x,y)
        {
            

            life = 3;
            state = Normal.getNormal();

            onObstacle = false;
            onGround = false;
            falling = false;
            isImmune = false;

            directionX = 1;
            id = ID.Felix;

            width = 20;
            height = 50;

            Handler.add(this);
        }



        public override void tick()
        {

            if (!dying)
            {
                stopFalling();
                //checkImmune();
                //checkButtons(ent, beforeTime);
                //collision(ent, beforeTime);
            }
            else
            {
                setY(getY() + 3f);
                if (Building.getBuilding().getActualSector().getBotBounds().Top + 100 < getY())
                {
                    dying = false;
                    reset(death_x, death_y);
                }
            }

            checkStates();

        }



        private void checkButtons(List<Entity> ent, long beforeTime)
        {
            setDx(getInputX(ent));
            setX(getX() + getDx());

            setDy(getInputY(ent, beforeTime));
            setY(getY() + getDy());
        }


        private void checkImmune(long beforeTime)
        {
            if (isImmune)
            {
                if (beforeTime - inmTime > immuneDuration)
                {
                    isImmune = false;
                }

            }
        }

        private void checkStates()
        {

            if (dying)
            {
                state = Falling.getFalling();
            }

            if (KeyBoard.fix && onGround && !dying)
            {
                state = Fixing.getFixing();
            }

            if (isImmune && !KeyBoard.fix && !dying)
            {
                state = Immune.getImmune();
            }

            if (getDx() == 0 && getDy() == 0 && !KeyBoard.fix && !isImmune && !dying)
            {
                state = Normal.getNormal();
            }


            if ((getDx() != 0 || getDy() != 0) && !isImmune)
            {
                state = Moving.getMoving();
            }
        }


        private void collision(List<Entity> ent, long beforeTime)
        {
            buildingCollision();
            windowCollision(beforeTime);

            for (int i = 0; i < ent.Count; i++)
            {
                Entity e = ent[i];
                ralphCollision(e);
                brickCollision(e, beforeTime);
                birdCollision(e, beforeTime);
                cakeCollision(e, beforeTime);
            }
        }



        private void windowCollision(long beforeTime)
        {
            Window[] windows = Building.getBuilding().getActualWindows();
            for (int i = 0; i < windows.Length; i++)
            {
                Window w = windows[i];

                // 300 ms entre cada golpe de delay para coordinarlo con el arreglo
                if (w.getBounds().Contains(getBounds()) && KeyBoard.fix && beforeTime - movDelay > 300)
                {
                    movDelay = DateTime.Now.Ticks;
                    w.removeNicelander();
                    w.getFixed();
                }

                if (getBotBounds().IntersectsWith(w.getBotBounds()) && !w.hasFlowerPot)
                {
                    onGround = true;
                    onObstacle = false;
                }

                doubleDoorsCollision(w);
                obstacleCollision(w);
            }
        }


        private void obstacleCollision(Window w)
        {

            if (getTopBounds().IntersectsWith(w.getTopBounds()) && w.hasRoof)
            {
                setY(w.getY() + 2);
            }

            if (getBotBounds().IntersectsWith(w.getTopBounds()) && w.hasRoof)
            {
                onGround = true;
                onObstacle = true;
            }

            if (getBotBounds().IntersectsWith(w.getBotBounds()) && w.hasFlowerPot)
            {

                onGround = true;
                onObstacle = true;
            }
        }


        private void doubleDoorsCollision(Window w)
        {
            if (getLeftBounds().IntersectsWith(w.getLeftBounds()))
            {
                setX(w.getX() - 6);
            }

            if (getRightBounds().IntersectsWith(w.getLeftBounds()))
            {
                setX(w.getX() - 19);
            }

            if (getLeftBounds().IntersectsWith(w.getRightBounds()))
            {
                setX(w.getX() + 27);
            }

            if (getRightBounds().IntersectsWith(w.getRightBounds()))
            {
                setX(w.getX() + 12);
            }

            if (getBotBounds().IntersectsWith(w.getRightBounds()) || getBotBounds().IntersectsWith(w.getLeftBounds()))
            {
                onObstacle = true;
                onGround = true;
            }
        }



        private void brickCollision(Entity e, long beforeTime)
        {
            
            if (e.GetType() == typeof(Brick)) {
                if (getTopBounds().IntersectsWith(e.getBounds()) && !isImmune)
                {
                    setY(getY());
                    savePosition(e);
                    decLife(beforeTime);
                    Handler.remove(e);
                    setImmune(IMMUNE_DEATH);
                }
            }
        }

        private void birdCollision(Entity e, long beforeTime)
        {
            if (e.GetType() == typeof(Bird)) {
                if (getAllBounds().IntersectsWith(e.getBounds()) && !isImmune)
                {
                    setY(getY());
                    savePosition(e);
                    decLife(beforeTime);
                    Handler.remove(e);
                    setImmune(IMMUNE_DEATH);
                }
            }
        }



        private void ralphCollision(Entity e)
        {
            if (e.GetType() == typeof(Ralph))
			if (getTopBounds().IntersectsWith(e.getBounds()))
            {
                setY(e.getY() + 82);
                max_jump = MAX_JUMP;
            }
        }


        private void cakeCollision(Entity e, long beforeTime)
        {
            if (e.getID() == ID.Cake)
            {
                if (getAllBounds().IntersectsWith(e.getBounds()))
                {
                    setImmune(IMMUNE_CAKE);
                    Handler.remove(e);
                }
            }
        }


        private void setImmune(long immuneTime)
        {
            inmTime = DateTime.Now.Ticks;
            isImmune = true;
            immuneDuration = immuneTime;
        }


        private void savePosition(Entity e)
        {
            death_x = e.getX() - 10;
            death_y = e.getY() - 10;
        }


        private void buildingCollision()
        {

            Building b = Building.getBuilding();


            if (getLeftBounds().IntersectsWith(b.getLeftBounds()))
            {
                setX(Building.getBuilding().getX() + 9);
            }


            if (getRightBounds().IntersectsWith(b.getRightBounds()))
            {
                setX(b.getX() + 279);
            }


            if (getBotBounds().IntersectsWith(b.getTopBounds()) && b.isChangingSector())
            {
                Building.getBuilding().changeSector();
                onGround = true;
                isImmune = false;
            }


            if (getBotBounds().IntersectsWith(b.getBotBounds()))
            {
                onGround = true;
            }
            else
                onGround = false;

        }




        private float getInputX(List<Entity> ent)
        {

            // Mover derecha
            if (KeyBoard.right && !KeyBoard.fix)
            {
                directionX = 1;
                return VEL;
            }

            // Mover izquierda
            if (KeyBoard.left && !KeyBoard.fix)
            {
                directionX = -1;
                return -VEL;
            }

            return 0;
        }



        private float getInputY(List<Entity> ent, long beforeTime)
        {

            // Mover arriba
            if (KeyBoard.up && !falling && max_jump > MAX_JUMP && beforeTime - movDelay > 150)
            {
                directionY = -1;
                max_jump += JUMP_SPEED;

                return JUMP_SPEED;
            }

            // Mover abajo
            if (KeyBoard.down && onGround && !onObstacle && getY() < 503 && beforeTime - movDelay > 100
                    && !getBotBounds().IntersectsWith(Building.getBuilding().getBotBounds()))
            {

                movDelay = DateTime.Now.Ticks;
                directionY = 1;

                return Constant.GRAVITY;
            }

            if (!onGround)
            {
                movDelay = DateTime.Now.Ticks;
                falling = true;
                onObstacle = false;
                return Constant.GRAVITY;
            }

            return 0;
        }



        private void stopFalling()
        {
            if (onGround && falling)
            {
                falling = false;
                max_jump = 0;
            }
        }



        private void decLife(long beforeTime)
        {
            dying = true;
            if (!isImmune)
            {
                if (beforeTime - delay > 20)
                {
                    delay = DateTime.Now.Ticks;
                    life--;
                    if (life > 0)
                        Score.getScore().loseHP();

                }
            }
        }



        override
        public void draw(SKCanvas g)
        {
            state.update();
            g.DrawBitmap(state.getImage(directionX), new SKPoint((int)getX(), (int)getY()));
        }



        public int getLife()
        {
            return life;
        }


        // limites
        override
        public Rectangle getTopBounds()
        {
            return new Rectangle((int)getX() + 12, (int)getY(), 15, 3);
        }


        override
        public Rectangle getLeftBounds()
        {
            return new Rectangle((int)getX() + 7, (int)getY() + 6, 3, 39);
        }


        override
        public Rectangle getRightBounds()
        {
            return new Rectangle((int)getX() + 15, (int)getY() + 6, 3, 39);
        }


        override
        public Rectangle getBotBounds()
        {
            if (directionX == -1)
            {
                return new Rectangle((int)getX() + 12, (int)getY() + 52, 12, 2);
            }
            return new Rectangle((int)getX() + 6, (int)getY() + 52, 12, 2);
        }


        public Rectangle getAllBounds()
        {
            if (directionX == -1)
            {
                return new Rectangle((int)getX() + 10, (int)getY(), width, height);
            }
            return new Rectangle((int)getX(), (int)getY(), width, height);
        }


        override
        public Rectangle getBounds()
        {
            if (directionX == -1)
            {
                return new Rectangle((int)getX() + 6, (int)getY() + 30, 7, 7);
            }
            return new Rectangle((int)getX() + 26, (int)getY() + 30, 7, 7);
        }


        public void resetAll(float x, float y)
        {
            setXY(x, y);
            life = 3;
            isImmune = false;
            dying = false;
        }


        public void reset(float x, float y)
        {
            setXY(x, y);
        }

    }
}
