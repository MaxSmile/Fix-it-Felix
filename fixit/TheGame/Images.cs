using System;
using fixit.TheGame.graphics;

namespace fixit.TheGame
{
    public class Images
    {
    private static Images _instance = null;
    public static Images Instance
    {
        get
        {
            if (_instance == null) _instance = new Images();
            return _instance;
        }
    }
    

    // FELIX'S PATHS
    String[] felixMovingLeftPaths = {
        "fixit.TheGame.images.felix.moving.movingLeft.0.png",
        "fixit.TheGame.images.felix.moving.movingLeft.1.png",
        "fixit.TheGame.images.felix.moving.movingLeft.2.png",
        "fixit.TheGame.images.felix.moving.movingLeft.3.png",
    };


    String[] felixMovingRightPaths = {
        "fixit.TheGame.images.felix.moving.movingRight.0.png",
        "fixit.TheGame.images.felix.moving.movingRight.1.png",
        "fixit.TheGame.images.felix.moving.movingRight.2.png",
        "fixit.TheGame.images.felix.moving.movingRight.3.png",
    };


    String[] felixFixingLeftPaths = {
        "fixit.TheGame.images.felix.fixing.fixingLeft.0.png",
        "fixit.TheGame.images.felix.fixing.fixingLeft.1.png",
    };

    String[] felixFixingRightPaths = {
        "fixit.TheGame.images.felix.fixing.fixingRight.0.png",
        "fixit.TheGame.images.felix.fixing.fixingRight.1.png",
    };


    String[] felixNormalRightPaths = {
        "fixit.TheGame.images.felix.normal.normalRight.0.png",
    };


    String[] felixNormalLeftPaths = {
        "fixit.TheGame.images.felix.normal.normalLeft.0.png",
    };


    String[] felixFallingPaths = {
        "fixit.TheGame.images.felix.falling.0.png",
        "fixit.TheGame.images.felix.falling.1.png",
    };

    String[] felixWinPaths = {
        "fixit.TheGame.images.felix.win.0.png",
        "fixit.TheGame.images.felix.win.1.png",
        "fixit.TheGame.images.felix.win.2.png",
        "fixit.TheGame.images.felix.win.3.png",
        "fixit.TheGame.images.felix.win.4.png",
        "fixit.TheGame.images.felix.win.5.png"
    };


    // RALPH'S ANIMATIONS
    String[] ralphDemolishing = {
        "fixit.TheGame.images.ralph.demolishing.0.png",
        "fixit.TheGame.images.ralph.demolishing.1.png"
    };


    String[] ralphClimbingPath = {
        "fixit.TheGame.images.ralph.climbing.0.png",
        "fixit.TheGame.images.ralph.climbing.1.png"
    };


    String[] ralphMovePath = {
        "fixit.TheGame.images.ralph.Moving.0.png",
        "fixit.TheGame.images.ralph.Moving.1.png"
    };

    // IMAGES PATHS
    String[] birdLeftPaths = {
		"fixit.TheGame.images.entities.bird.birdLeft.0.png",
		"fixit.TheGame.images.entities.bird.birdLeft.1.png"
	};
	
	
	String[] birdRightPaths = {
		"fixit.TheGame.images.entities.bird.birdRight.0.png",
		"fixit.TheGame.images.entities.bird.birdRight.1.png"
	};
	
	
	String[] brickPaths = {
		"fixit.TheGame.images.entities.brick.0.png",
		"fixit.TheGame.images.entities.brick.1.png"
	};
	
	String[] nicelanderPaths = {
		"fixit.TheGame.images.entities.nicelander.0.png",
		"fixit.TheGame.images.entities.nicelander.1.png"
	};
	
	String[] cakePaths= {
		"fixit.TheGame.images.entities.cake.0.png",
		"fixit.TheGame.images.entities.cake.1.png"
	};

	
	//	Ralph Animations
	private Animation ralphClimbing;
    private Animation ralphDemolition;
    private Animation ralphMove;


    //Felix Animations
    private Animation felixMoveLeft;
    private Animation felixMoveRight;

    private Animation felixNormalRight;
    private Animation felixNormalLeft;

    private Animation felixFixingRight;
    private Animation felixFixingLeft;

    private Animation felixFalling;

    private Animation felixWin;

    //OBJECTS
    private Sprite flowerPot;
	private Sprite roof;
	private Sprite twoPanels; 
	private Animation brick;
	private Animation birdLeft;
	private Animation birdRight;
	private Animation nicelander;
	private Animation cake;
	private Sprite life;
	private Sprite bush;
	private Sprite cloud;
	private Sprite building;
	private Sprite menu;
	private Sprite config;
	private Sprite buildingRoof;
	
	//WINDOWS & PARTS
	private Sprite[] glasses;
    private Sprite[] doubleDoor;
    private Sprite[] semicircular;
    private Sprite[] door;

    public Images()
    {

        // Ralph's Animations

        ralphDemolition = new Animation(ralphDemolishing);

        ralphClimbing = new Animation(ralphClimbingPath);

        ralphMove = new Animation(ralphMovePath);

        // Felix's Animations

        felixMoveLeft = new Animation(felixMovingLeftPaths);
        felixMoveRight = new Animation(felixMovingRightPaths);

        felixNormalRight = new Animation(felixNormalRightPaths);
        felixNormalLeft = new Animation(felixNormalLeftPaths);

        felixFixingLeft = new Animation(felixFixingLeftPaths);
        felixFixingRight = new Animation(felixFixingRightPaths);

        felixFalling = new Animation(felixFallingPaths);

        felixWin = new Animation(felixWinPaths);

        // OBJECTS
        flowerPot = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.window.obstacles.flowerpot.png"));

        roof = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.window.obstacles.roof.png"));

        twoPanels = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.window.0.png"));

        life = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.life.png"));

        bush = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.bush.png"));

        buildingRoof = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.sprites_sin_fondo.png"));


        cloud = new Sprite(ResourceLoader.Instance.
                    LoadImage("fixit.TheGame.images.entities.cloud.0.png"));

        building = new Sprite(ResourceLoader.Instance.LoadImage("fixit.TheGame.images.building.0.png"));

        brick = new Animation(brickPaths);

        birdLeft = new Animation(birdLeftPaths);
        birdRight = new Animation(birdRightPaths);

        nicelander = new Animation(nicelanderPaths);

        cake = new Animation(cakePaths);

        menu = new Sprite(ResourceLoader.Instance.
            LoadImage("fixit.TheGame.images.initial_menu.png"));

        config = new Sprite(ResourceLoader.Instance.
            LoadImage("fixit.TheGame.images.config.png"));

        // WINDOWS & PARTS
        initGlasses();
        initDoubleDoor();
        initSemicircular();
        initDoor();
    }


        private void initGlasses()
        {
            glasses = new Sprite[7];
            for (int i = 0; i < glasses.Length; i++)
            {
                glasses[i] = new Sprite(ResourceLoader.Instance.LoadImage("fixit.TheGame.images.window.glasses." + i + ".png"));
            }
        }



        private void initDoubleDoor()
        {
            doubleDoor = new Sprite[4];
            for (int i = 0; i < doubleDoor.Length; i++)
            {
                doubleDoor[i] = new Sprite(ResourceLoader.Instance.LoadImage("fixit.TheGame.images.window.doubledoor." + i + ".png"));
            }
        }

        private void initSemicircular()
        {
            semicircular = new Sprite[5];
            for (int i = 0; i < semicircular.Length; i++)
            {
                semicircular[i] = new Sprite(ResourceLoader.Instance.
                            LoadImage("fixit.TheGame.images.window.semicircular.bigwindow." + i + ".png"));
            }
        }

        private void initDoor()
        {
            door = new Sprite[5];
            for (int i = 0; i < door.Length; i++)
            {
                door[i] = new Sprite(ResourceLoader.Instance.
                            LoadImage("fixit.TheGame.images.window.semicircular.door." + i + ".png"));
            }
        }

        public Animation getBrick()
        {
            return brick;
        }


        // RALPH'S ANIMATION
        public Animation getClimbing()
        {
            return ralphClimbing;
        }

        public Animation getRalphDemolition()
        {
            return ralphDemolition;
        }

        public Animation getRalphMove()
        {
            return ralphMove;
        }

        // FELIX'S ANIMATION
        public Animation getFelixMoveLeft()
        {
            return felixMoveLeft;
        }

        public Animation getFelixMoveRight()
        {
            return felixMoveRight;
        }

        public Animation getFelixNormalLeft()
        {
            return felixNormalLeft;
        }

        public Animation getFelixNormalRight()
        {
            return felixNormalRight;
        }

        public Animation getFelixFixingLeft()
        {
            return felixFixingLeft;
        }

        public Animation getFelixFixingRight()
        {
            return felixFixingRight;
        }


        public Animation getFelixFalling()
        {
            return felixFalling;
        }






        // OBJECTS
        public Sprite getBuildingRoof()
        {
            return buildingRoof;
        }


        public Sprite getFlowerPot()
        {
            return flowerPot;
        }


        public Sprite getRoof()
        {
            return roof;
        }


        public Animation getLeftBird()
        {
            return birdLeft;
        }


        public Animation getRightBird()
        {
            return birdRight;
        }


        public Animation getNicelander()
        {
            return nicelander;
        }


        public Animation getCake()
        {
            return cake;
        }

        public Sprite getTwoPanels()
        {
            return twoPanels;
        }


        public Sprite getBush()
        {
            return bush;
        }


        public Sprite getCloud()
        {
            return cloud;
        }


        public Sprite getBuilding()
        {
            return building;
        }


        public Sprite getLife()
        {
            return life;
        }


        public Sprite getMenu()
        {
            return menu;
        }

        public Sprite getConfig()
        {
            return config;
        }

        // WINDOWS & PARTS
        public Sprite getGlass(int i)
        {
            return glasses[i];
        }


        public Sprite[] getDoubleDoor()
        {
            return doubleDoor;
        }


        public Sprite[] getSemicircular()
        {
            return semicircular;
        }


        public Sprite[] getDoor()
        {
            return door;
        }



        public Animation getFelixWin()
        {
            return felixWin;
        }

    }
}
