using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace MainGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //BossStuff--------------------------------------------------------
         Animation Attack1Boss;
         Animation Attack1BossVar1;
         Animation Attack1BossVar2;
         Animation Attack2Boss;
         Animation Attack2BossVar1;
         Animation Attack3Boss;
         Animation Attack3BossVar1;
         Animation Walk1Boss;
         Animation Walk2Boss;
         Animation Walk3Boss;
         Animation Idle1Boss;
         Animation Idle2Boss;
         Animation Idle3Boss;
         Animation Recoil1Boss;
         Animation Recoil2Boss;
         Animation Recoil3Boss;
         Animation deathBoss;
         Animation powerUp1;
         Animation powerUp2;

         int generateCounter = 0;
         int fightStages = 0;
         int enemyKillCount = 0;
         int enemyGroup = 0;

        

        //-----------------------------------------------------------------


         

         bool recraft = false;
        bool jumpUp = false;
        //cheats
        String cheatCode = "";
        bool cheatKeyDown = false;
        int cheatTimer = 0;
        bool cheatSong = false;

        bool viaMenu = false;
        public SpriteFont loadingFont;
        int loadingTimer = 0;
        double totalLoadingTime = 100;
        bool isLoadingScreen = true; //Make false to switch off initial loading screen

        bool mainMenu = true; //true for default to Main Menu
        bool levelSelect = false;
        bool optionsSelect = false;
        bool pauseOptionsSelect = false;
        bool checkKeyUp = true;
        int currentMenuLevel = 0;
        int mainMenuOptionsUpDown = 0;

        bool savedGame = false;

        Animation idlingAnimationMainMenu;

        Animation Stars;

        float defaultVolume = 1.0f;
        float effectsVolume = 1.0f;


        bool[] levelUnlocked;
        String[] levelScores = new String[5];

        Texture2D[] scoreImages = new Texture2D[6];
        List<Texture2D> levelMenuTextures;
        Texture2D levelLockedScreen;

        int mainMenuRow = 1;

        bool skip = false;
        //EnemyHUD
        Enemy enemyHud1;
        Enemy enemyHud2;
        Texture2D oneEnemyHUD;
        Texture2D twoEnemyHUD;
        Texture2D blankHealthBar;
        Texture2D enemyHealthBar;
        Texture2D gymLoadingScreen;
        Texture2D classLoadingScreen;
        Texture2D loadingProgress;
        Texture2D loadingScreenTexture;

        Texture2D mainMenuSettingsTexture;
        Texture2D mainMenuOptionsSelectorTexture;
        Texture2D mainMenuFullScreenTexture;
        Texture2D mainMenuWindowedTexture;
        Texture2D mainMenuVolumeSliderMusicTexture;
        Texture2D mainMenuVolumeSliderEffectsTexture;
        Texture2D pauseMenuOptionScreen;
        Texture2D pauseMenuOptionsSelectorTexture;

        private tutText tutText;
        private bool[] tutInstructions = new bool[8];

        bool drawBrawlDown = false;
        bool drawBrawlAnimation = false;
        float drawBrawlAlpha = 1.0f;
        int drawBrawlCount = 0;
        int fadeInCount = 0;
        bool fadedIn = false;

        Texture2D[] enemyThumbs;

        //level Obastacles


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MultiBackground gameBG;
        Random rnd;
        Random r;

        Player player;
        EnemyList enemies;

        bool idDoneMoving = true;

        private IntelligenceProjectile intelligenceProjectile;
        SpriteFont dropItemFont;

        bool isEscUp = true;
        bool isArrowUp = true;
        bool isEnterUp = true;
        private bool paused = false;
        private bool crafting = false;
        Cue level0Sound;
        Cue level1Sound;
        Cue level2Sound;
        Cue level3Sound;
        Cue menuMusic;
        Cue craftMusic;
        Cue goWest;
        Cue bossFightSound;
        Cue creditsMusic;

        Texture2D levelPaused;
        Animation arrowAnimation;

        Texture2D[] teslaObstacle;
        Texture2D PlainTeslaCoil;
        Texture2D PlainTeslaTop;

        //Main Menu
        Texture2D baseMainMenu;
        Texture2D playHover;
        Texture2D optionsHover;
        Texture2D helpHover;
        Texture2D exitHover;

        //HUD stuff
        HUD hud;
        Texture2D hudTexture;
        Texture2D emptyHealthBar;
        Texture2D fullHealthBar;
        Texture2D healthBarLeft;
        Texture2D healthBarRight;
        Texture2D itemExists;
        Texture2D otherDefault;
        Texture2D weaponDefault;

        Texture2D bookMenu;
        Texture2D baseballMenu;
        Texture2D calculatorMenu;
        Texture2D plateMenu;
        Texture2D bossFightMenu;

        Texture2D[] progressScreens = new Texture2D[5]; //5 levels, each has own name

        //--------------

        Texture2D strengthTexture;
        Texture2D agilityTexture;
        Texture2D intelligenceTexture;

        Texture2D objectTexture1;
        Texture2D objectTexture2;
        Texture2D objectTexture3;
        Texture2D objectTexture4;
        Texture2D tutObjectTexture1;
        Texture2D tutObjectTexture2;
        Texture2D tutObjectTexture3;
        Texture2D tutObjectTexture4;
        Texture2D labObjectTexture1;
        Texture2D labObjectTexture2;
        Texture2D labObjectTexture3;
        Texture2D labObjectTexture4;
        Texture2D cafObjectTexture1;
        Texture2D cafObjectTexture2;
        Texture2D cafObjectTexture3;
        Texture2D cafObjectTexture4;
        Texture2D bossFightObjectTexture1;
        Texture2D bossFightObjectTexture2;
        Texture2D bossFightObjectTexture3;
        Texture2D bossFightObjectTexture4;

        Texture2D trees1;
        Texture2D trees2;
        Texture2D bossTrees1;
        Texture2D bossTrees2;
        Texture2D gymParalax1;
        Texture2D gymParalax2;

        Texture2D bgTexture;
        Texture2D bgTexture2;
        Texture2D tutTexture1;
        Texture2D tutTexture2;
        Texture2D level2BG1;
        Texture2D level2BG2;
        Texture2D level3BG1;
        Texture2D level3BG2;
        Texture2D bossFightBG;

        Texture2D scienceLoading;
        Texture2D cafLoading;
        Texture2D bossLoading;

        Texture2D idleArrow;

        Texture2D levelCompleteAPlus;
        Texture2D levelCompleteA;
        Texture2D levelCompleteB;
        Texture2D levelCompleteC;
        Texture2D levelCompleteD;
        Texture2D levelFailed;

        int bgPos = 0;

        public bool levelEndSuccess = false;

        private int drawSplash = 0; // 0 - No Splash; 1 - Level Complete; 2 - Level Failed

        private int scrollingPoint;
        List<ThrowObjects> throwObjects;

        BasicParticleSystem particleSystem;
        BasicParticleSystem particleSystem2;
        TimeSpan totalTimeSpan = new TimeSpan();

        float mapPosition;
        bool[] fights;

        private AudioEngine audioEngine;
        private WaveBank waveBank;
        private SoundBank soundBank;

        EnemyHandler enemyHandler;
        VirtualScreen virtualScreen;

        Texture2D[] strengthTextures;
        Texture2D[] agilityTextures;
        Texture2D[] intelligenceTextures;
        Texture2D[] punchingBagTextures;

        public int level = 0;   // 0 - Tut, 1 - Level 1 etc...
        private int menuOption = 1; //1 - Play; 2 - Options; 3 - Main Menu

        Texture2D menuOption1;
        Texture2D menuOption2;
        Texture2D menuOption3;

        //Crafting Menu
        DropItems item1 = null;
        DropItems item2 = null;
        int row = 0;    //4 Rows
        int col = 0;    //6 Cols
        Texture2D emptyCrafting;
        Texture2D emptyCrafting2;
        Texture2D emptyCraftingItem;
        Texture2D selectedBlank;
        Texture2D craftBtnHover;
        Texture2D UNcraftBtnHover;
        Texture2D doneBtnHover;
        Texture2D itemTotalHolder;
        Texture2D selectedItemHolder;
        Weapon craftedWeapon = null;
        bool weaponScreenDraw = false;
        bool validCraftingRecipe = false;
        bool bothCraftingSlotsFull = false;
        int selectedWeaponColCrafting = 0;
        Texture2D invalidCombo;
        int tutCraftScreen = 0; //Which tut screen to display [-1 - none]
        Texture2D[] craftingTutScreens;

        DropItems[,] craftingInventory = new DropItems[3, 4];

        Texture2D[] f;
        Texture2D[] w;

        Texture2D finalBrawlTexture;
        Animation finalBrawlAnimation;

        ContentManager tutManager;
        ContentManager defaultManager;
        ContentManager level1Manager;
        ContentManager level2Manager;
        ContentManager level3Manager;
        ContentManager bossFightManager;
        IServiceProvider s;

        //MainMenu
        Animation downMenu;
        Animation upMenu;
        Animation jumpDownMenu;
        Animation jumpUpMenu;
        Animation mainMenuToDraw;

        Animation selectorDownMenu;
        Animation selectorUpMenu;
        Animation selectorJumpDownMenu;
        Animation selectorJumpUpMenu;
        Animation selectorMenuToDraw;

        bool helpScreen = false;

        Texture2D helpScreenTexture;


        public Game1()
        {
            r = new Random();
            rnd = new Random();
            scrollingPoint = 700;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            tutManager = new ContentManager(this.Services, "Content1");
            defaultManager = new ContentManager(this.Services, "Content");
            level1Manager = new ContentManager(this.Services, "level1");
            level2Manager = new ContentManager(this.Services, "level2");
            level3Manager = new ContentManager(this.Services, "level3");
            bossFightManager = new ContentManager(this.Services, "bossFight");


            fights = new bool[10];

            for (int i = 0; i < fights.Length; i++)
            {
                fights[i] = false;
            }
        }

        protected override void Initialize()
        {
            BGExtras.shine = new Animation(new Vector2(0, 0));

            //BGExtras.credits = new Credits(soundBank);

            //main menu animaiton
            idlingAnimationMainMenu = new Animation(new Vector2(120, 270));

            levelMenuTextures = new List<Texture2D>();
            levelUnlocked = new bool[5];
            levelUnlocked[0] = true;
            levelUnlocked[1] = false;
            levelUnlocked[2] = false;
            levelUnlocked[3] = false;
            levelUnlocked[4] = false;

            for (int i = 0; i < 5; i++)
                levelScores[i] = "X";   //X - Not played yet

            loadPreviousLevelProgress();    //Check for previous saves

            Stars = new Animation(new Vector2(0, 0));



            finalBrawlAnimation = new Animation(new Vector2(0f, 0f));
            enemyThumbs = new Texture2D[2];
            gameBG = new MultiBackground(graphics);

            for (int x = 0; x < tutInstructions.Length; x++)
                tutInstructions[x] = false;

            Vector2 arrowPosition = new Vector2(1290, -13);
            arrowAnimation = new Animation(arrowPosition);

            enemies = new EnemyList();
            throwObjects = new List<ThrowObjects>();

            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.ApplyChanges();

            virtualScreen = new VirtualScreen(1440, 900, GraphicsDevice);
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            Window.AllowUserResizing = true;

            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            virtualScreen.PhysicalResolutionChanged();
        }

        private void loadAudioContent()
        {
            audioEngine = new AudioEngine("Content/Music/Win/Music.xgs");
            waveBank = new WaveBank(audioEngine, "Content/Music/Win/Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, "Content/Music/Win/Sound Bank.xsb");
        }

        protected void loadTut()
        {
            unloadAll();
            tutTexture1 = tutManager.Load<Texture2D>("Gym Part 1");
            tutTexture2 = tutManager.Load<Texture2D>("Gym Part 2");

            gymParalax1 = tutManager.Load<Texture2D>("Gym paralax 1");
            gymParalax2 = tutManager.Load<Texture2D>("Gym paralax 2");
            gymLoadingScreen = tutManager.Load<Texture2D>("GymLoading");
        }

        protected void unloadAll()
        {
            row = 0;    //Reset for the next craft
            col = 0;

            tutManager.Unload();
            level1Manager.Unload();
            level2Manager.Unload();
            level3Manager.Unload();
            bossFightManager.Unload();

            tutManager = new ContentManager(this.Services, "Content1");
            defaultManager = new ContentManager(this.Services, "Content");
            level1Manager = new ContentManager(this.Services, "level1");
            level2Manager = new ContentManager(this.Services, "level2");
            level3Manager = new ContentManager(this.Services, "level3");
            bossFightManager = new ContentManager(this.Services, "bossFight");

        }

        protected void loadLevel1()
        {
            unloadAll();

            classLoadingScreen = level1Manager.Load<Texture2D>("ClassLoading");
            bgTexture = level1Manager.Load<Texture2D>("BG");
            bgTexture2 = level1Manager.Load<Texture2D>("BG2");
        }

        protected void loadLevel2()
        {
            unloadAll();
            scienceLoading = level2Manager.Load<Texture2D>("LabLoading");
            level2BG1 = level2Manager.Load<Texture2D>("Science Lab1");
            level2BG2 = level2Manager.Load<Texture2D>("Science Lab2");
        }

        protected void loadLevel3()
        {
            unloadAll();
            cafLoading = level3Manager.Load<Texture2D>("CafeteriaLoading");
            level3BG1 = level3Manager.Load<Texture2D>("Cafeteria1");
            level3BG2 = level3Manager.Load<Texture2D>("Cafeteria2");
        }

        protected void loadBossFight()
        {
            unloadAll();
            bossLoading = bossFightManager.Load<Texture2D>("CatheralOfSavageryLoading");//should load from boss fight load
            bossFightBG = bossFightManager.Load<Texture2D>("Final Level"); 
        }

        protected override void LoadContent()
        {

            loadAudioContent();

            BGExtras.w = this.Window.ClientBounds.Width * 2;    //Used for snow
            BGExtras.h = this.Window.ClientBounds.Height;
            BGExtras.snowFlakes = Content.Load<Texture2D>("Snowflake");
            BGExtras.rainDrops = Content.Load<Texture2D>("RainDrop");
            BGExtras.lightning = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 10; i++)
            {
                BGExtras.lightning.AddCell(defaultManager.Load<Texture2D>("Lightning"+i));
            }

            //Credits Stuff
            BGExtras.credits = new Credits(soundBank);
            BGExtras.credits.blankBlack = defaultManager.Load<Texture2D>("blankBlack");
            BGExtras.credits.allImages = new Texture2D[8];
            BGExtras.credits.allImages[0] = defaultManager.Load<Texture2D>("credits1");
            BGExtras.credits.allImages[1] = defaultManager.Load<Texture2D>("credits2");
            BGExtras.credits.allImages[2] = defaultManager.Load<Texture2D>("credits3");
            BGExtras.credits.allImages[3] = defaultManager.Load<Texture2D>("credits4");
            BGExtras.credits.allImages[4] = defaultManager.Load<Texture2D>("credits5");
            BGExtras.credits.allImages[5] = defaultManager.Load<Texture2D>("credits6");
            BGExtras.credits.allImages[7] = defaultManager.Load<Texture2D>("credits7");
            BGExtras.credits.allImages[6] = defaultManager.Load<Texture2D>("credits8");



            scoreImages[0] = defaultManager.Load<Texture2D>("LevelScoreA+");
            scoreImages[1] = defaultManager.Load<Texture2D>("LevelScoreA");
            scoreImages[2] = defaultManager.Load<Texture2D>("LevelScoreB");
            scoreImages[3] = defaultManager.Load<Texture2D>("LevelScoreC");
            scoreImages[4] = defaultManager.Load<Texture2D>("LevelScoreD");
            scoreImages[5] = defaultManager.Load<Texture2D>("LevelScoreF");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            particleSystem = new BasicParticleSystem(defaultManager.Load<Texture2D>("blood"));
            particleSystem2 = new BasicParticleSystem(defaultManager.Load<Texture2D>("blood2"));

            loadingProgress = defaultManager.Load<Texture2D>("loadingProgress");

            //HUD
            hudTexture = defaultManager.Load<Texture2D>("Base HUD");
            emptyHealthBar = defaultManager.Load<Texture2D>("Health Empty");
            fullHealthBar = defaultManager.Load<Texture2D>("Health Full");
            healthBarLeft = defaultManager.Load<Texture2D>("Health Bar left");
            healthBarRight = defaultManager.Load<Texture2D>("Health Bar Right");
            itemExists = defaultManager.Load<Texture2D>("Slot Highlight");

            otherDefault = defaultManager.Load<Texture2D>("otherDefault");
            weaponDefault = defaultManager.Load<Texture2D>("Fist");

            bookMenu = defaultManager.Load<Texture2D>("bookMenu");
            baseballMenu = defaultManager.Load<Texture2D>("baseballMenu");
            calculatorMenu = defaultManager.Load<Texture2D>("calculatorMenu");
            plateMenu = defaultManager.Load<Texture2D>("plateMenu");
            bossFightMenu = defaultManager.Load<Texture2D>("SpikeBallMenu");

            //EnemyHUD
            oneEnemyHUD = defaultManager.Load<Texture2D>("OneEnemyHealth");
            twoEnemyHUD = defaultManager.Load<Texture2D>("TwoEnemyHealth");
            enemyHealthBar = defaultManager.Load<Texture2D>("EnemyHealthBar");
            blankHealthBar = defaultManager.Load<Texture2D>("EnemyHealthBarBlank");

            //ProgressHUD
            progressScreens[0] = defaultManager.Load<Texture2D>("Level0Progress");
            progressScreens[1] = defaultManager.Load<Texture2D>("Level1Progress");
            progressScreens[2] = defaultManager.Load<Texture2D>("Level2Progress");
            progressScreens[3] = defaultManager.Load<Texture2D>("Level3Progress");
            progressScreens[4] = defaultManager.Load<Texture2D>("Level0Progress");

            //EvilJP_HUD
            BGExtras.hud1 = defaultManager.Load<Texture2D>("bossHUD1");
            BGExtras.hud2 = defaultManager.Load<Texture2D>("bossHUD2");
            BGExtras.hud3 = defaultManager.Load<Texture2D>("bossHUD3");
            BGExtras.blueHP = defaultManager.Load<Texture2D>("blueHealth");
            BGExtras.purpleHP = defaultManager.Load<Texture2D>("purpleHealth");
            BGExtras.redHP = defaultManager.Load<Texture2D>("redHealth");
            BGExtras.emptyJPHealth = defaultManager.Load<Texture2D>("blankJPHealth");

            //trees
            trees1 = defaultManager.Load<Texture2D>("treesBGBottom");
            trees2 = defaultManager.Load<Texture2D>("treesBGTop");
            bossTrees1 = defaultManager.Load<Texture2D>("treesBGBottomBoss");
            bossTrees2 = defaultManager.Load<Texture2D>("treesBGTopBoss");

            //Tuturoial
            tutText = new tutText(GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("Command 1"));

            //Level 1
            if (level == 0)
            {
                loadTut();
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(gymParalax1, 1, 200.0f);
                gameBG.AddLayer(gymParalax2, 1, 200.0f);
                gameBG.AddLayer(gymParalax1, 1, 200.0f);

                gameBG.AddLayer(tutTexture1, 0, 200.0f);
                gameBG.AddLayer(tutTexture2, 0, 200.0f);
                gameBG.AddLayer(tutTexture1, 0, 200.0f);   //Not in use currently

                gameBG.tutLevel = true;
                gameBG.lastLevel = false;

            }
            else if (level == 1)
            {

                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);

                gameBG.AddLayer(bgTexture, 0, 200.0f);
                gameBG.AddLayer(bgTexture2, 0, 200.0f);
                gameBG.AddLayer(bgTexture, 0, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 2)
            {

                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);

                gameBG.AddLayer(level2BG1, 0, 200.0f);
                gameBG.AddLayer(level2BG2, 0, 200.0f);
                gameBG.AddLayer(level2BG1, 0, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 3)
            {

                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);

                gameBG.AddLayer(level3BG1, 0, 200.0f);
                gameBG.AddLayer(level3BG2, 0, 200.0f);
                gameBG.AddLayer(level3BG1, 0, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 4)
            {

                gameBG.AddLayer(bossTrees1, 2, 200.0f);
                gameBG.AddLayer(bossTrees1, 2, 200.0f);
                gameBG.AddLayer(bossTrees1, 2, 200.0f);

                gameBG.AddLayer(bossTrees2, 1, 200.0f);
                gameBG.AddLayer(bossTrees2, 1, 200.0f);
                gameBG.AddLayer(bossTrees2, 1, 200.0f);

                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.lastLevel = true;
            }


            


            //LOADING OF ANIMATION TEXTURES

            for (int i = 1; i < 1490; i++)  //Credits Screen
            {
                String zeros = "";
                if (i < 10)
                    zeros = "000";
                else if (i < 100)
                    zeros = "00";
                else if (i < 1000)
                    zeros = "0";
                //credits.AddCell(defaultManager.Load<Texture2D>("End Text" + zeros + i));
            }
            

            for (int i = 1; i <= 6; i++)
                arrowAnimation.AddCell(defaultManager.Load<Texture2D>("Arrow" + i));

            Texture2D playerWalk1 = defaultManager.Load<Texture2D>("Walk 1");
            Texture2D playerWalk2 = defaultManager.Load<Texture2D>("Walk 2");
            Texture2D playerWalk3 = defaultManager.Load<Texture2D>("Walk 3");
            Texture2D playerWalk4 = defaultManager.Load<Texture2D>("Walk 4");
            Texture2D playerWalk5 = defaultManager.Load<Texture2D>("Walk 5");
            Texture2D playerWalk6 = defaultManager.Load<Texture2D>("Walk 6");
            Texture2D playerWalk7 = defaultManager.Load<Texture2D>("Walk 7");
            Texture2D playerWalk8 = defaultManager.Load<Texture2D>("Walk 8");
            player = new Player(graphics.GraphicsDevice, new Vector2(400f, 400.0f), new Vector2(playerWalk1.Width / 2, playerWalk1.Height / 2), enemies, scrollingPoint, throwObjects, particleSystem, particleSystem2, soundBank);
            player.AddCell(playerWalk1);
            player.AddCell(playerWalk2);
            player.AddCell(playerWalk3);
            player.AddCell(playerWalk4);
            player.AddCell(playerWalk5);
            player.AddCell(playerWalk6);
            player.AddCell(playerWalk7);
            player.AddCell(playerWalk8);

            Texture2D playerIdle1 = defaultManager.Load<Texture2D>("Idle 1");
            Texture2D playerIdle2 = defaultManager.Load<Texture2D>("Idle 2");
            Texture2D playerIdle3 = defaultManager.Load<Texture2D>("Idle 3");
            Texture2D playerIdle4 = defaultManager.Load<Texture2D>("Idle 4");
            Texture2D playerIdle5 = defaultManager.Load<Texture2D>("Idle 5");
            Texture2D playerIdle6 = defaultManager.Load<Texture2D>("Idle 6");
            Texture2D playerIdle7 = defaultManager.Load<Texture2D>("Idle 7");
            Texture2D playerIdle8 = defaultManager.Load<Texture2D>("Idle 8");

            player.AddIdleCell(playerIdle1);
            player.AddIdleCell(playerIdle2);
            player.AddIdleCell(playerIdle3);
            player.AddIdleCell(playerIdle4);
            player.AddIdleCell(playerIdle5);
            player.AddIdleCell(playerIdle6);
            player.AddIdleCell(playerIdle7);
            player.AddIdleCell(playerIdle8);

            Texture2D playerAttack1 = defaultManager.Load<Texture2D>("Punch 1");
            Texture2D playerAttack2 = defaultManager.Load<Texture2D>("Punch 2");
            Texture2D playerAttack3 = defaultManager.Load<Texture2D>("Punch 3");
            Texture2D playerAttack4 = defaultManager.Load<Texture2D>("Punch 4");
            Texture2D playerAttack5 = defaultManager.Load<Texture2D>("Punch 5");

            player.AddAttackCell(playerAttack1);
            player.AddAttackCell(playerAttack2);
            player.AddAttackCell(playerAttack3);
            player.AddAttackCell(playerAttack4);
            player.AddAttackCell(playerAttack5);

            for (int i = 1; i < 6; i++)
            {
                player.AddAttackVariation2Cell(defaultManager.Load<Texture2D>("Punch 2 " + i));
            }

            for (int i = 1; i < 6; i++)
            {
                player.AddAttackVariation3Cell(defaultManager.Load<Texture2D>("Kick " + i));
            }

            Texture2D playerRecoil1 = defaultManager.Load<Texture2D>("Recoil 1");
            Texture2D playerRecoil2 = defaultManager.Load<Texture2D>("Recoil 2");
            Texture2D playerRecoil3 = defaultManager.Load<Texture2D>("Recoil 3");

            player.AddRecoilCell(playerRecoil1);
            player.AddRecoilCell(playerRecoil2);
            player.AddRecoilCell(playerRecoil3);

            player.passArrow(arrowAnimation);




            //Strength Textures
            strengthTextures = new Texture2D[8];
            for (int i = 0; i < 8; i++)
            {
                strengthTextures[i] = defaultManager.Load<Texture2D>("Jock Walk " + (i + 1));
            }

            //Agility Textures
            agilityTextures = new Texture2D[8];
            for (int i = 0; i < 8; i++)
            {
                agilityTextures[i] = defaultManager.Load<Texture2D>("Ninja Walk " + (i + 1));
            }

            //Intelligence Textures
            intelligenceTextures = new Texture2D[8];
            for (int i = 0; i < 8; i++)
            {
                intelligenceTextures[i] = defaultManager.Load<Texture2D>("Red Walk " + (i + 1));
            }

            punchingBagTextures = new Texture2D[1];
            punchingBagTextures[0] = defaultManager.Load<Texture2D>("Punching Bag 1");


            strengthTexture = defaultManager.Load<Texture2D>("Red Walk 1");
            agilityTexture = defaultManager.Load<Texture2D>("Ninja Walk 1");
            intelligenceTexture = defaultManager.Load<Texture2D>("Blue Walk 1");

            hud = new HUD(graphics, hudTexture, emptyHealthBar, fullHealthBar, healthBarLeft, healthBarRight, itemExists, player);
            hud.LoadSprite("otherDefault", otherDefault);
            hud.LoadSprite("weaponDefault", weaponDefault);

            hud.LoadSprite("bookMenu", bookMenu);
            hud.LoadSprite("baseballMenu", baseballMenu);
            hud.LoadSprite("calculatorMenu", calculatorMenu);
            hud.LoadSprite("plateMenu", plateMenu);

            hud.LoadLevelProgress(progressScreens[0], defaultManager.Load<Texture2D>("LevelProgress"), defaultManager.Load<Texture2D>("jpsFace"), defaultManager.Load<Texture2D>("progressBG"));

            levelCompleteAPlus = defaultManager.Load<Texture2D>("LevelCompleteA+");
            levelCompleteA = defaultManager.Load<Texture2D>("LevelCompleteA");
            levelCompleteB = defaultManager.Load<Texture2D>("LevelCompleteB");
            levelCompleteC = defaultManager.Load<Texture2D>("LevelCompleteC");
            levelCompleteD = defaultManager.Load<Texture2D>("LevelCompleteD");
            levelFailed = defaultManager.Load<Texture2D>("LevelFailed");
            levelPaused = defaultManager.Load<Texture2D>("pauseMenu");

            menuOption1 = defaultManager.Load<Texture2D>("menuOption1");
            menuOption2 = defaultManager.Load<Texture2D>("menuOption2");
            menuOption3 = defaultManager.Load<Texture2D>("menuOption3");


            level0Sound = soundBank.GetCue("SuperMegaUltra");
            level1Sound = soundBank.GetCue("level1");
            level2Sound = soundBank.GetCue("PixelPuncher");
            level3Sound = soundBank.GetCue("The Next Level");
            bossFightSound = soundBank.GetCue("Boss Fight");
            menuMusic = soundBank.GetCue("8bit");
            craftMusic = soundBank.GetCue("Cubish");
            goWest = soundBank.GetCue("West");
            creditsMusic = soundBank.GetCue("Credits");
            //menuMusic.Play();

            objectTexture1 = defaultManager.Load<Texture2D>("Book 1");
            objectTexture2 = defaultManager.Load<Texture2D>("Book 2");
            objectTexture3 = defaultManager.Load<Texture2D>("Book 3");
            objectTexture4 = defaultManager.Load<Texture2D>("Book 4");
            tutObjectTexture1 = defaultManager.Load<Texture2D>("Baseball1");
            tutObjectTexture2 = defaultManager.Load<Texture2D>("Baseball2");
            tutObjectTexture3 = defaultManager.Load<Texture2D>("Baseball3");
            tutObjectTexture4 = defaultManager.Load<Texture2D>("Baseball4");
            labObjectTexture1 = defaultManager.Load<Texture2D>("Calculator1");
            labObjectTexture2 = defaultManager.Load<Texture2D>("Calculator2");
            labObjectTexture3 = defaultManager.Load<Texture2D>("Calculator3");
            labObjectTexture4 = defaultManager.Load<Texture2D>("Calculator4");
            cafObjectTexture1 = defaultManager.Load<Texture2D>("pl1");
            cafObjectTexture2 = defaultManager.Load<Texture2D>("pl2");
            cafObjectTexture3 = defaultManager.Load<Texture2D>("pl3");
            cafObjectTexture4 = defaultManager.Load<Texture2D>("pl4");
            bossFightObjectTexture1 = defaultManager.Load<Texture2D>("SpikeBall1");
            bossFightObjectTexture2 = defaultManager.Load<Texture2D>("SpikeBall2");
            bossFightObjectTexture3 = defaultManager.Load<Texture2D>("SpikeBall3");
            bossFightObjectTexture4 = defaultManager.Load<Texture2D>("SpikeBall4");


            //All Loot Items
            dropItemFont = defaultManager.Load<SpriteFont>("DropItemFont");
            loadingFont = defaultManager.Load<SpriteFont>("Visitor");

            DropItems[] allItems = new DropItems[15];
            allItems[0] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("dropItem1Large"), defaultManager.Load<Texture2D>("dropItem1Large"), "Red Square");
            allItems[1] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("dropItem2Large"), defaultManager.Load<Texture2D>("dropItem2Large"), "Blue Star");
            allItems[2] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("dropItem3Large"), defaultManager.Load<Texture2D>("dropItem3Large"), "Green Circle");
            allItems[3] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("nailsLarge"), defaultManager.Load<Texture2D>("nailsLarge"), "Deadly Nails");
            allItems[4] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("baseballBatLarge"), defaultManager.Load<Texture2D>("baseballBatLarge"), "Baseball Bat");
            allItems[5] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("CactusLarge"), defaultManager.Load<Texture2D>("CactusLarge"), "Cactus");
            allItems[6] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("CarBatteryLarge"), defaultManager.Load<Texture2D>("CarBatteryLarge"), "Car Battery");
            allItems[7] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("ChemicalFlaskLarge"), defaultManager.Load<Texture2D>("ChemicalFlaskLarge"), "Chemical Flask");
            allItems[8] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("fluorescentLarge"), defaultManager.Load<Texture2D>("fluorescentLarge"), "Fluorescent Tube");
            allItems[9] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("GlovesLarge"), defaultManager.Load<Texture2D>("GlovesLarge"), "Gloves");
            allItems[10] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("HockeyStickLarge"), defaultManager.Load<Texture2D>("HockeyStickLarge"), "Hockey Stick");
            allItems[11] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("KnifeLarge"), defaultManager.Load<Texture2D>("KnifeLarge"), "Knife");
            allItems[12] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("MouseLarge"), defaultManager.Load<Texture2D>("MouseLarge"), "Mouse");
            allItems[13] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("Nokia3310Large"), defaultManager.Load<Texture2D>("Nokia3310Large"), "Nokia 331O");
            allItems[14] = new DropItems(graphics.GraphicsDevice, new Vector2(0, 0), defaultManager.Load<Texture2D>("yoyoLarge"), defaultManager.Load<Texture2D>("yoyoLarge"), "YoYo");

            for (int i = 0; i < allItems.Length; i++)
                allItems[i].DropItemFont = dropItemFont;

            enemyHandler = new EnemyHandler(strengthTextures, agilityTextures, intelligenceTextures, punchingBagTextures, allItems, graphics.GraphicsDevice, player, particleSystem, particleSystem2);

            //BossFighhtTextures------------------------------------------------------------------------------


            deathBoss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 130; i++)
                deathBoss.AddCell(defaultManager.Load<Texture2D>("Boss Death " + i));

            Idle1Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Idle1Boss.AddCell(defaultManager.Load<Texture2D>("Boss Idle " + i));


            Recoil1Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                Recoil1Boss.AddCell(defaultManager.Load<Texture2D>("Boss Recoil " + i));


            Walk1Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Walk1Boss.AddCell(defaultManager.Load<Texture2D>("Boss Walk " + i));


            Attack1Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack1Boss.AddCell(defaultManager.Load<Texture2D>("Boss Punch " + i));

            Attack1BossVar1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack1BossVar1.AddCell(defaultManager.Load<Texture2D>("Boss Kick " + i));

            Attack1BossVar2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack1BossVar2.AddCell(defaultManager.Load<Texture2D>("Boss Punch 2 " + i));



            Idle2Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Idle2Boss.AddCell(defaultManager.Load<Texture2D>("Radioactive Boss Idle " + i));


            Recoil2Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                Recoil2Boss.AddCell(defaultManager.Load<Texture2D>("Radioactive Boss Recoil " + i));


            Walk2Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Walk2Boss.AddCell(defaultManager.Load<Texture2D>("Radioactive Boss Walk " + i));


            Attack2Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack2Boss.AddCell(defaultManager.Load<Texture2D>("Radioactive Boss Punch " + i));

            Attack2BossVar1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack2BossVar1.AddCell(defaultManager.Load<Texture2D>("Radioactive Boss Punch 2 " + i));

            Idle3Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Idle3Boss.AddCell(defaultManager.Load<Texture2D>("LightSaber Boss Idle " + i));


            Recoil3Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                Recoil3Boss.AddCell(defaultManager.Load<Texture2D>("LightSaber Boss Recoil " + i));


            Walk3Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                Walk3Boss.AddCell(defaultManager.Load<Texture2D>("LightSaber Boss Walk " + i));


            Attack3Boss = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack3Boss.AddCell(defaultManager.Load<Texture2D>("Boss Lighsaber Attack " + i));

            Attack3BossVar1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                Attack3BossVar1.AddCell(defaultManager.Load<Texture2D>("Boss Lightsaber Attack 2 " + i));

            
            powerUp1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 23; i++)
                powerUp1.AddCell(defaultManager.Load<Texture2D>("First Powerup " + i));

            powerUp2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 23; i++)
                powerUp2.AddCell(defaultManager.Load<Texture2D>("Second Powerup " + i));

            Texture2D[] bossFightTextures = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                bossFightTextures[i - 1] = (defaultManager.Load<Texture2D>("LightSaber Boss Walk " + i));


            enemyHandler.Attack1Boss = Attack1Boss;
            enemyHandler.Attack1BossVar1 = Attack1BossVar1;
            enemyHandler.Attack1BossVar2 = Attack1BossVar2;
            enemyHandler.Attack2Boss = Attack2Boss;
            enemyHandler.Attack2BossVar1 = Attack2BossVar1;
            enemyHandler.Attack3Boss = Attack3Boss;
            enemyHandler.Attack3BossVar1 = Attack3BossVar1;
            enemyHandler.Walk1Boss = Walk1Boss;
            enemyHandler.Walk2Boss = Walk2Boss;
            enemyHandler.Walk3Boss = Walk3Boss;
            enemyHandler.Idle1Boss = Idle1Boss;
            enemyHandler.Idle2Boss = Idle2Boss;
            enemyHandler.Idle3Boss = Idle3Boss;
            enemyHandler.Recoil1Boss = Recoil1Boss;
            enemyHandler.Recoil2Boss = Recoil2Boss;
            enemyHandler.Recoil3Boss = Recoil3Boss;
            enemyHandler.deathBoss = deathBoss;
            enemyHandler.powerUp1 = powerUp1;
            enemyHandler.powerUp2 = powerUp2;
            enemyHandler.setBossTextures(bossFightTextures);
            //-------------------------------------------------------------------------------------------------

            enemyHandler.addStrengthThumbnail(defaultManager.Load<Texture2D>("JockThumb"));
            enemyHandler.addIntelligenceThumbnail(defaultManager.Load<Texture2D>("IntelligenceThumb"));
            enemyHandler.addAgilityThumbnail(defaultManager.Load<Texture2D>("AgilityThumb"));
            enemyHandler.addPunchingBagThumbnail(defaultManager.Load<Texture2D>("PunchingBagThumb"));
            enemyHandler.addBossThumbnail(defaultManager.Load<Texture2D>("PunchingBagThumb"));

            //VARIATION - Black Jock
            enemyHandler.addStrengthThumbnailVariation(defaultManager.Load<Texture2D>("BlackJockThumb"));
            Texture2D[] arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("Black Jock Walk " + (i + 1));
            enemyHandler.addStrengthTextureVariation(arr);
            arr = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Black Jock Attack " + i);
            enemyHandler.setAttackStrengthTexturesVariation(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Black Jock Recoil " + i);
            enemyHandler.setRecoilStrengthTexturesVariation(arr);
            arr = new Texture2D[36];
            for (int i = 2; i < 38; i++)
                arr[i - 2] = defaultManager.Load<Texture2D>("Black Jock Death " + i);
            enemyHandler.setDeathStrengthTexturesVariation(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Black Jock Idle " + i);
            enemyHandler.setIdleStrengthTexturesVariation(arr);

            //VARIATION - Green Jock
            enemyHandler.addStrengthThumbnailVariation2(defaultManager.Load<Texture2D>("GreenJockThumb"));
            arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("Green Jock Walk " + (i + 1));
            enemyHandler.addStrengthTextureVariation2(arr);
            arr = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Jock Attack " + i);
            enemyHandler.setAttackStrengthTexturesVariation2(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Jock Recoil " + i);
            enemyHandler.setRecoilStrengthTexturesVariation2(arr);
            arr = new Texture2D[36];
            for (int i = 2; i < 38; i++)
                arr[i - 2] = defaultManager.Load<Texture2D>("Green Jock Death " + i);
            enemyHandler.setDeathStrengthTexturesVariation2(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Jock Idle " + i);
            enemyHandler.setIdleStrengthTexturesVariation2(arr);

            //VARIATION - Blue Intelligence
            enemyHandler.addIntelligenceThumbnailVariation(defaultManager.Load<Texture2D>("BlueIntelligenceThumb"));
            arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("Blue Walk " + (i + 1));
            enemyHandler.addIntelligenceTextureVariation(arr);
            arr = new Texture2D[6];
            for (int i = 1; i < 7; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Blue Intelligence Attack " + i);
            enemyHandler.setAttackIntelligenceTexturesVariation(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Blue Intelligence Recoil " + i);
            enemyHandler.setRecoilIntelligenceTexturesVariation(arr);
            arr = new Texture2D[15];
            for (int i = 1; i < 16; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Blue Intelligence Death " + i);
            enemyHandler.setDeathIntelligenceTexturesVariation(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Blue Intelligence Idle " + i);
            enemyHandler.setIdleIntelligenceTexturesVariation(arr);

            //VARIATION - Green Intelligence
            enemyHandler.addIntelligenceThumbnailVariation2(defaultManager.Load<Texture2D>("GreenIntelligenceThumb"));
            arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("Green Walk " + (i + 1));
            enemyHandler.addIntelligenceTextureVariation2(arr);
            arr = new Texture2D[6];
            for (int i = 1; i < 7; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Intelligence Attack " + i);
            enemyHandler.setAttackIntelligenceTexturesVariation2(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Intelligence Recoil " + i);
            enemyHandler.setRecoilIntelligenceTexturesVariation2(arr);
            arr = new Texture2D[15];
            for (int i = 1; i < 16; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Intelligence Death " + i);
            enemyHandler.setDeathIntelligenceTexturesVariation2(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Intelligence Idle " + i);
            enemyHandler.setIdleIntelligenceTexturesVariation2(arr);

            //VARIATION - White Ninja
            enemyHandler.addAgilityThumbnailVariation(defaultManager.Load<Texture2D>("WhiteAgilityThumb"));
            arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("White Ninja Walk " + (i + 1));
            enemyHandler.addAgilityTextureVariation(arr);
            arr = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("White Ninja Attack " + i);
            enemyHandler.setAttackAgilityTexturesVariation(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("White Ninja Recoil " + i);
            enemyHandler.setRecoilAgilityTexturesVariation(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("White Ninja Death " + i);
            enemyHandler.setDeathAgilityTexturesVariation(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("White Ninja Idle " + i);
            enemyHandler.setIdleAgilityTexturesVariation(arr);

            //VARIATION - Green Ninja
            enemyHandler.addAgilityThumbnailVariation2(defaultManager.Load<Texture2D>("GreenAgilityThumb"));
            arr = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                arr[i] = defaultManager.Load<Texture2D>("Green Ninja Walk " + (i + 1));
            enemyHandler.addAgilityTextureVariation2(arr);
            arr = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Ninja Attack " + i);
            enemyHandler.setAttackAgilityTexturesVariation2(arr);
            arr = new Texture2D[3];
            for (int i = 1; i < 4; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Ninja Recoil " + i);
            enemyHandler.setRecoilAgilityTexturesVariation2(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Ninja Death " + i);
            enemyHandler.setDeathAgilityTexturesVariation2(arr);
            arr = new Texture2D[8];
            for (int i = 1; i < 9; i++)
                arr[i - 1] = defaultManager.Load<Texture2D>("Green Ninja Idle " + i);
            enemyHandler.setIdleAgilityTexturesVariation2(arr);

            Recipe.allItems = allItems;

            for (int i = 1; i < 11; i++)
            {
                enemyHandler.addProjectileCell0R(defaultManager.Load<Texture2D>("0_Blast " + i));  //Add the zero texture (right)
            }

            for (int i = 1; i < 11; i++)
            {
                enemyHandler.addProjectileCell1R(defaultManager.Load<Texture2D>("1_Blast " + i));  //Add the one texture   (left)
            }

            for (int i = 1; i < 11; i++)
            {
                enemyHandler.addProjectileCell0L(defaultManager.Load<Texture2D>("0_Blast reverse " + i));  //Add the zero texture (left)
            }

            for (int i = 1; i < 11; i++)
            {
                enemyHandler.addProjectileCell1L(defaultManager.Load<Texture2D>("1_Blast reverse " + i));  //Add the one texture   (right)
            }

            //Recoil Textures
            Texture2D[] intelligenceRecoil = new Texture2D[3];
            for (int i = 1; i < 4; i++)
            {
                intelligenceRecoil[i - 1] = defaultManager.Load<Texture2D>("Intelligence Recoil " + i);
            }
            enemyHandler.setRecoilIntelligenceTextures(intelligenceRecoil);

            Texture2D[] strengthRecoil = new Texture2D[3];
            for (int i = 1; i < 4; i++)
            {
                strengthRecoil[i - 1] = defaultManager.Load<Texture2D>("Jock Recoil " + i);
            }
            enemyHandler.setRecoilStrengthTextures(strengthRecoil);


            Texture2D[] agilityRecoil = new Texture2D[3];
            for (int i = 1; i < 4; i++)
            {
                agilityRecoil[i - 1] = defaultManager.Load<Texture2D>("Ninja Recoil " + i);
            }
            enemyHandler.setRecoilAgilityTextures(agilityRecoil);

            Texture2D[] punchingBagRecoil = new Texture2D[10];
            for (int i = 1; i < 10; i++)
            {
                punchingBagRecoil[i - 1] = defaultManager.Load<Texture2D>("Punching Bag " + i);
            }
            punchingBagRecoil[9] = defaultManager.Load<Texture2D>("Punching Bag 1");
            enemyHandler.setRecoilPunchingBagTextures(punchingBagRecoil);

            Texture2D[] punchingBagRecoilReverse = new Texture2D[10];
            for (int i = 1; i < 10; i++)
            {
                punchingBagRecoilReverse[i - 1] = defaultManager.Load<Texture2D>("Punching Bag Reverse " + i);
            }
            punchingBagRecoilReverse[9] = defaultManager.Load<Texture2D>("Punching Bag Reverse 1");
            enemyHandler.setRecoilPunchingBagReverseTextures(punchingBagRecoilReverse);

            Texture2D[] punchingBagDeath = new Texture2D[15];
            for (int i = 1; i < 16; i++)
            {
                punchingBagDeath[i - 1] = defaultManager.Load<Texture2D>("Punching Death " + i);
            }
            enemyHandler.setDeathPunchingBagTextures(punchingBagDeath);

            Texture2D[] strengthAttack = new Texture2D[5];
            for (int i = 1; i < 6; i++)
            {
                strengthAttack[i - 1] = defaultManager.Load<Texture2D>("Jock Attack " + i);
            }

            enemyHandler.setAttackStrengthTextures(strengthAttack);


            Texture2D[] agilityAttack = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                agilityAttack[i - 1] = defaultManager.Load<Texture2D>("Ninja Attack " + i);

            enemyHandler.setAttackAgilityTextures(agilityAttack);


            Texture2D[] intelligenceDeath = new Texture2D[15];
            for (int i = 1; i < 15; i++)
            {
                intelligenceDeath[i - 1] = defaultManager.Load<Texture2D>("Intelligence Death " + i);
            }
            intelligenceDeath[14] = defaultManager.Load<Texture2D>("Intelligence Death 15");
            enemyHandler.setDeathIntelligenceTextures(intelligenceDeath);

            Texture2D[] strenthDeath = new Texture2D[36];
            for (int i = 2; i < 38; i++)
            {
                strenthDeath[i - 2] = defaultManager.Load<Texture2D>("Jock Death " + i);
            }
            enemyHandler.setDeathStrengthTextures(strenthDeath);

            Texture2D[] agilityDeath = new Texture2D[8];
            for (int i = 1; i < 9; i++)
            {
                agilityDeath[i - 1] = defaultManager.Load<Texture2D>("Ninja Death " + i);
            }

            enemyHandler.setDeathAgilityTextures(agilityDeath);

            //Idle Textures
            Texture2D[] intelligenceIdle = new Texture2D[8];
            for (int i = 1; i < 9; i++)
            {
                intelligenceIdle[i - 1] = defaultManager.Load<Texture2D>("Intelligence Idle " + i);
            }
            enemyHandler.setIdleIntelligenceTextures(intelligenceIdle);

            Texture2D[] strengthIdle = new Texture2D[8];
            for (int i = 1; i < 9; i++)
            {
                strengthIdle[i - 1] = defaultManager.Load<Texture2D>("Jock Idle " + i);
            }
            enemyHandler.setIdleStrengthTextures(strengthIdle);

            Texture2D[] agilityIdle = new Texture2D[8];
            for (int i = 1; i < 9; i++)
            {
                agilityIdle[i - 1] = defaultManager.Load<Texture2D>("Ninja Idle " + i);
            }
            enemyHandler.setIdleAgilityTextures(agilityIdle);

            Texture2D[] intelligenceAttack = new Texture2D[14];
            intelligenceAttack[0] = defaultManager.Load<Texture2D>("Intelligence Attack 1");
            intelligenceAttack[1] = defaultManager.Load<Texture2D>("Intelligence Attack 1");
            intelligenceAttack[2] = defaultManager.Load<Texture2D>("Intelligence Attack 2");
            intelligenceAttack[3] = defaultManager.Load<Texture2D>("Intelligence Attack 3");
            intelligenceAttack[4] = defaultManager.Load<Texture2D>("Intelligence Attack 2");
            intelligenceAttack[5] = defaultManager.Load<Texture2D>("Intelligence Attack 3");
            intelligenceAttack[6] = defaultManager.Load<Texture2D>("Intelligence Attack 2");
            intelligenceAttack[7] = defaultManager.Load<Texture2D>("Intelligence Attack 3");
            intelligenceAttack[8] = defaultManager.Load<Texture2D>("Intelligence Attack 4");
            intelligenceAttack[9] = defaultManager.Load<Texture2D>("Intelligence Attack 5");
            intelligenceAttack[10] = defaultManager.Load<Texture2D>("Intelligence Attack 5");
            intelligenceAttack[11] = defaultManager.Load<Texture2D>("Intelligence Attack 6");
            intelligenceAttack[12] = defaultManager.Load<Texture2D>("Intelligence Attack 6");
            intelligenceAttack[13] = defaultManager.Load<Texture2D>("Intelligence Attack 6");

            enemyHandler.setAttackIntelligenceTextures(intelligenceAttack);
            //arrowAnimation.LoopAll(0.6f);


            //Load Tesla coil textures
            teslaObstacle = new Texture2D[3];
            for (int i = 1; i < 4; i++)
            {
                teslaObstacle[i - 1] = defaultManager.Load<Texture2D>("teslaCoilShock" + i);
            }
            PlainTeslaCoil = defaultManager.Load<Texture2D>("teslaCoilBottom");
            PlainTeslaTop = defaultManager.Load<Texture2D>("teslaCoilTop");

            //Crafting Loads
            emptyCrafting = defaultManager.Load<Texture2D>("EmptyCrafting");
            emptyCrafting2 = defaultManager.Load<Texture2D>("CraftingMenu2");
            emptyCraftingItem = defaultManager.Load<Texture2D>("EmptyCraftingItem");
            selectedBlank = defaultManager.Load<Texture2D>("EmptyItem");
            UNcraftBtnHover = defaultManager.Load<Texture2D>("unCraftBtn");
            craftBtnHover = defaultManager.Load<Texture2D>("craftHover");
            doneBtnHover = defaultManager.Load<Texture2D>("doneHover");
            selectedItemHolder = defaultManager.Load<Texture2D>("selectedItemHolder");
            itemTotalHolder = defaultManager.Load<Texture2D>("itemTotalHolder");
            invalidCombo = defaultManager.Load<Texture2D>("InvalidCombo");

            enemyHandler.DropItemFont = dropItemFont;

            for (int i = 1; i < 8; i++)
            {
                tutText.addTextFramePt1(defaultManager.Load<Texture2D>("Command " + i));
                tutText.addTextFramePt2(defaultManager.Load<Texture2D>("Command " + i + " b"));
            }

            craftingTutScreens = new Texture2D[5];
            for (int i = 1; i < 6; i++)
                craftingTutScreens[i - 1] = defaultManager.Load<Texture2D>("craftTut" + i);



            //Shine!
            for (int i = 1; i < 15; i++)
            {
                BGExtras.shine.AddCell(defaultManager.Load<Texture2D>("Shine " + i));
            }


            //Main Menu Load ---------------------------------------------
            baseMainMenu = defaultManager.Load<Texture2D>("MainMenu");
            //playHover = defaultManager.Load<Texture2D>("MainMenuPlayHover");
            //optionsHover = defaultManager.Load<Texture2D>("MainMenuOptionsHover");
            //helpHover = defaultManager.Load<Texture2D>("MainMenuHelpHover");
            //exitHover = defaultManager.Load<Texture2D>("MainMenuExitHover");

            playHover = defaultManager.Load<Texture2D>("MainMenuSelector");
            optionsHover = defaultManager.Load<Texture2D>("MainMenuSelector");
            helpHover = defaultManager.Load<Texture2D>("MainMenuSelector");
            exitHover = defaultManager.Load<Texture2D>("MainMenuSelector");

            for (int i = 1; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            for (int i = 1; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            for (int i = 1; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 1"));
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 2"));
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 3"));
            for (int i = 4; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            for (int i = 1; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            for (int i = 1; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 1"));
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 2"));
            idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("Blink 3"));
            for (int i = 4; i < 9; i++)
            {
                idlingAnimationMainMenu.AddCell(defaultManager.Load<Texture2D>("IdleMain " + i));
            }

            mainMenuSettingsTexture = defaultManager.Load<Texture2D>("MainMenuSettings");
            mainMenuOptionsSelectorTexture = defaultManager.Load<Texture2D>("OptionsSelector");
            mainMenuFullScreenTexture = defaultManager.Load<Texture2D>("screenModeFullscreen");
            mainMenuWindowedTexture = defaultManager.Load<Texture2D>("screenModeWindowed");
            mainMenuVolumeSliderMusicTexture = defaultManager.Load<Texture2D>("Slider");
            mainMenuVolumeSliderEffectsTexture = defaultManager.Load<Texture2D>("Slider");
            pauseMenuOptionScreen = defaultManager.Load<Texture2D>("pauseMenuOptionsScreen");
            pauseMenuOptionsSelectorTexture = defaultManager.Load<Texture2D>("OptionsSelectorSmall");

            levelMenuTextures.Add(defaultManager.Load<Texture2D>("GymOfPainMenu"));
            levelMenuTextures.Add(defaultManager.Load<Texture2D>("ClassOfDespairMenu"));
            levelMenuTextures.Add(defaultManager.Load<Texture2D>("LabOfBrutalityMenu"));
            levelMenuTextures.Add(defaultManager.Load<Texture2D>("CafeteriaOfCarnageMenu"));
            levelMenuTextures.Add(defaultManager.Load<Texture2D>("CathedralOfSavageryMenu"));//should be bossFight
            levelLockedScreen = defaultManager.Load<Texture2D>("LevelLocked");

            //Recipes
            Recipe.silCanada = defaultManager.Load<Texture2D>("silCanada");
            Recipe.mainCanada = defaultManager.Load<Texture2D>("mainCanada");
            Recipe.iconCanada = defaultManager.Load<Texture2D>("iconCanada");

            Recipe.silNailBat = defaultManager.Load<Texture2D>("silNailBat");
            Recipe.mainNailBat = defaultManager.Load<Texture2D>("mainNailBat");
            Recipe.iconNailBat = defaultManager.Load<Texture2D>("Nailbat");
            Recipe.infoNailBat = defaultManager.Load<Texture2D>("NailbatInfo");

            Recipe.silCactus = defaultManager.Load<Texture2D>("silCactusBat");
            Recipe.mainCactus = defaultManager.Load<Texture2D>("mainCactusBat");
            Recipe.iconCactus = defaultManager.Load<Texture2D>("CactusBat");
            Recipe.infoCactus = defaultManager.Load<Texture2D>("CactusBatInfo");

            Recipe.silYoYo = defaultManager.Load<Texture2D>("silKnifeYoyo");
            Recipe.mainYoYo = defaultManager.Load<Texture2D>("mainKnifeYoyo");
            Recipe.iconYoYo = defaultManager.Load<Texture2D>("KnifeYoyo");
            Recipe.infoYoYo = defaultManager.Load<Texture2D>("KnifeYoyoInfo");

            Recipe.silBearHands = defaultManager.Load<Texture2D>("silBearHands");
            Recipe.mainBearHands = defaultManager.Load<Texture2D>("mainBearHands");
            Recipe.iconBearHands = defaultManager.Load<Texture2D>("BearHands");
            Recipe.infoBearHands = defaultManager.Load<Texture2D>("BearHandsInfo");

            Recipe.silLightSaber = defaultManager.Load<Texture2D>("silLightSaber");
            Recipe.mainLightSaber = defaultManager.Load<Texture2D>("mainLightSaber");
            Recipe.iconLightSaber = defaultManager.Load<Texture2D>("LightSaber");
            Recipe.infoLightSaber = defaultManager.Load<Texture2D>("LightSaberInfo");

            Recipe.silRadio = defaultManager.Load<Texture2D>("silRadioactiveGloves");
            Recipe.mainRadio = defaultManager.Load<Texture2D>("mainRadioactiveGloves");
            Recipe.iconRadio = defaultManager.Load<Texture2D>("RadioactiveGloves");
            Recipe.infoRadio = defaultManager.Load<Texture2D>("RadioActiveGlovesInfo");

            Recipe.silNokia = defaultManager.Load<Texture2D>("sil3310OnAStick");
            Recipe.mainNokia = defaultManager.Load<Texture2D>("main3310OnAStick");
            Recipe.iconNokia = defaultManager.Load<Texture2D>("3310OnAStick");
            Recipe.infoNokia = defaultManager.Load<Texture2D>("3310OnAStickInfo");

            Recipe.silLightSaber = defaultManager.Load<Texture2D>("silLightSaber");
            Recipe.mainLightSaber = defaultManager.Load<Texture2D>("mainLightSaber");
            Recipe.iconLightSaber = defaultManager.Load<Texture2D>("LightSaber");
            Recipe.infoLightSaber = defaultManager.Load<Texture2D>("LightSaberInfo");

            Recipe.silRadio = defaultManager.Load<Texture2D>("silRadioactiveGloves");
            Recipe.mainRadio = defaultManager.Load<Texture2D>("mainRadioactiveGloves");
            Recipe.iconRadio = defaultManager.Load<Texture2D>("RadioactiveGloves");
            Recipe.infoRadio = defaultManager.Load<Texture2D>("RadioActiveGlovesInfo");

            Recipe.silAcidMouse = defaultManager.Load<Texture2D>("silAcidMouse");
            Recipe.mainAcidMouse = defaultManager.Load<Texture2D>("mainAcidMouse");
            Recipe.iconAcidMouse = defaultManager.Load<Texture2D>("AcidMouse");
            Recipe.infoAcidMouse = defaultManager.Load<Texture2D>("AcidMouseInfo");

            Recipe.silHockey = defaultManager.Load<Texture2D>("silElectricHockeyStick");
            Recipe.mainHockey = defaultManager.Load<Texture2D>("mainElectricHockeyStick");
            Recipe.iconHockey = defaultManager.Load<Texture2D>("ElectricHockeyStick");
            Recipe.infoHockey = defaultManager.Load<Texture2D>("ElectricHockeyStickInfo");


            //nail bat animations
            Animation nailBatIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                nailBatIdleTmp.AddCell(defaultManager.Load<Texture2D>("Nailbat Idle " + i));
            Recipe.nailBatIdle = nailBatIdleTmp;

            Animation nailBatRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                nailBatRecoilTmp.AddCell(defaultManager.Load<Texture2D>("Nailbat Recoil " + i));
            Recipe.nailBatRecoil = nailBatRecoilTmp;

            Animation nailBatWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                nailBatWalkTmp.AddCell(defaultManager.Load<Texture2D>("Nailbat Walk " + i));
            Recipe.nailBatWalkAnimation = nailBatWalkTmp;

            Animation nailBatAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nailBatAttack1.AddCell(defaultManager.Load<Texture2D>("Nailbat Attack " + i));
            Recipe.nailBatAttack.Add(nailBatAttack1);

            Animation nailBatAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nailBatAttack2.AddCell(defaultManager.Load<Texture2D>("Nailbat Attack 2 " + i));
            Recipe.nailBatAttack.Add(nailBatAttack2);

            Animation nailBatThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nailBatThrow.AddCell(defaultManager.Load<Texture2D>("Nailbat Throw " + i));
            Recipe.nailBatThrowAnimation = nailBatThrow;

            //cactus bat animations
            Animation cactusBatIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                cactusBatIdleTmp.AddCell(defaultManager.Load<Texture2D>("CactusBat Idle " + i));
            Recipe.cactusBatIdle = cactusBatIdleTmp;

            Animation cactusBatRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                cactusBatRecoilTmp.AddCell(defaultManager.Load<Texture2D>("CactusBat Recoil " + i));
            Recipe.cactusBatRecoil = cactusBatRecoilTmp;

            Animation cactusBatWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                cactusBatWalkTmp.AddCell(defaultManager.Load<Texture2D>("CactusBat Walk " + i));
            Recipe.cactusBatWalkAnimation = cactusBatWalkTmp;

            Animation cactusBatAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                cactusBatAttack1.AddCell(defaultManager.Load<Texture2D>("CactusBat Attack " + i));
            Recipe.cactusBatAttack.Add(cactusBatAttack1);

            Animation cactusBatAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                cactusBatAttack2.AddCell(defaultManager.Load<Texture2D>("CactusBat Attack 2 " + i));
            Recipe.cactusBatAttack.Add(cactusBatAttack2);

            Animation cactusBatThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                cactusBatThrow.AddCell(defaultManager.Load<Texture2D>("CactusBat Throw " + i));
            Recipe.cactusBatThrowAnimation = cactusBatThrow;


            ////Bearhand animations ROAR!
            Animation bearHandsIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                bearHandsIdleTmp.AddCell(defaultManager.Load<Texture2D>("BearHands Idle " + i));
            Recipe.bearHandsIdle = bearHandsIdleTmp;

            Animation bearHandsRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                bearHandsRecoilTmp.AddCell(defaultManager.Load<Texture2D>("BearHands Recoil " + i));
            Recipe.bearHandsRecoil = bearHandsRecoilTmp;

            Animation bearHandsWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                bearHandsWalkTmp.AddCell(defaultManager.Load<Texture2D>("BearHands Walk " + i));
            Recipe.bearHandsWalkAnimation = bearHandsWalkTmp;

            Animation bearHandsAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                bearHandsAttack1.AddCell(defaultManager.Load<Texture2D>("BearHands Punch " + i));
            Recipe.bearHandsAttack.Add(bearHandsAttack1);

            Animation bearHandsAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                bearHandsAttack2.AddCell(defaultManager.Load<Texture2D>("BearHands Punch 2 " + i));
            Recipe.bearHandsAttack.Add(bearHandsAttack2);

            Animation bearHandsThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                bearHandsThrow.AddCell(defaultManager.Load<Texture2D>("BearHands Punch " + i));
            Recipe.bearHandsThrowAnimation = bearHandsThrow;

            //Knife yoyo animations
            Animation knifeYoyoIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                knifeYoyoIdleTmp.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Idle " + i));
            Recipe.knifeYoyoIdle = knifeYoyoIdleTmp;

            Animation knifeYoyoRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                knifeYoyoRecoilTmp.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Recoil " + i));
            Recipe.knifeYoyoRecoil = knifeYoyoRecoilTmp;

            Animation knifeYoyoWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                knifeYoyoWalkTmp.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Walk " + i));
            Recipe.knifeYoyoWalkAnimation = knifeYoyoWalkTmp;

            Animation knifeYoyoAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                knifeYoyoAttack1.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Attack " + i));
            Recipe.knifeYoyoAttack.Add(knifeYoyoAttack1);

            Animation knifeYoyoAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                knifeYoyoAttack2.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Attack 2 " + i));
            Recipe.knifeYoyoAttack.Add(knifeYoyoAttack2);

            Animation knifeYoyoThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                knifeYoyoThrow.AddCell(defaultManager.Load<Texture2D>("KnifeYoyo Throw " + i));
            Recipe.knifeYoyoThrowAnimation = knifeYoyoThrow;

            //acidMOuse animations
            Animation acidMouseIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                acidMouseIdleTmp.AddCell(defaultManager.Load<Texture2D>("AcidMouse Idle " + i));
            Recipe.acidMouseIdle = acidMouseIdleTmp;

            Animation acidMouseRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                acidMouseRecoilTmp.AddCell(defaultManager.Load<Texture2D>("AcidMouse Recoil " + i));
            Recipe.acidMouseRecoil = acidMouseRecoilTmp;

            Animation acidMouseWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                acidMouseWalkTmp.AddCell(defaultManager.Load<Texture2D>("AcidMouse Walk " + i));
            Recipe.acidMouseWalkAnimation = acidMouseWalkTmp;

            Animation acidMouseAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                acidMouseAttack1.AddCell(defaultManager.Load<Texture2D>("AcidMouse Attack " + i));
            Recipe.acidMouseAttack.Add(acidMouseAttack1);

            Animation acidMouseAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                acidMouseAttack2.AddCell(defaultManager.Load<Texture2D>("AcidMouse Attack 2 " + i));
            Recipe.acidMouseAttack.Add(acidMouseAttack2);

            Animation acidMouseThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                acidMouseThrow.AddCell(defaultManager.Load<Texture2D>("AcidMouse Throw " + i));
            Recipe.acidMouseThrowAnimation = acidMouseThrow;

            //readioactive gloves animations (I feel it in my bones...)

            Animation radioactiveIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                radioactiveIdleTmp.AddCell(defaultManager.Load<Texture2D>("Radioactive Idle " + i));
            Recipe.radioactiveIdle = radioactiveIdleTmp;

            Animation radioactiveRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                radioactiveRecoilTmp.AddCell(defaultManager.Load<Texture2D>("Radioactive Recoil " + i));
            Recipe.radioactiveRecoil = radioactiveRecoilTmp;

            Animation radioactiveWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                radioactiveWalkTmp.AddCell(defaultManager.Load<Texture2D>("Radioactive Walk " + i));
            Recipe.radioactiveWalkAnimation = radioactiveWalkTmp;

            Animation radioactiveAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                radioactiveAttack1.AddCell(defaultManager.Load<Texture2D>("Radioactive Punch " + i));
            Recipe.radioactiveAttack.Add(radioactiveAttack1);

            Animation radioactiveAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                radioactiveAttack2.AddCell(defaultManager.Load<Texture2D>("Radioactive Punch 2 " + i));
            Recipe.radioactiveAttack.Add(radioactiveAttack2);

            Animation radioactiveThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                radioactiveThrow.AddCell(defaultManager.Load<Texture2D>("Radioactive Punch " + i));
            Recipe.radioactiveThrowAnimation = radioactiveThrow;

            //nokia animations
            Animation nokiaIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                nokiaIdleTmp.AddCell(defaultManager.Load<Texture2D>("3310 Idle " + i));
            Recipe.nokiaIdle = nokiaIdleTmp;

            Animation nokiaRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                nokiaRecoilTmp.AddCell(defaultManager.Load<Texture2D>("3310 Recoil " + i));
            Recipe.nokiaRecoil = nokiaRecoilTmp;

            Animation nokiaWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                nokiaWalkTmp.AddCell(defaultManager.Load<Texture2D>("3310 Walk " + i));
            Recipe.nokiaWalkAnimation = nokiaWalkTmp;

            Animation nokiaAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nokiaAttack1.AddCell(defaultManager.Load<Texture2D>("3310 Attack " + i));
            Recipe.nokiaAttack.Add(nokiaAttack1);

            Animation nokiaAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nokiaAttack2.AddCell(defaultManager.Load<Texture2D>("3310 Attack 2 " + i));
            Recipe.nokiaAttack.Add(nokiaAttack2);

            Animation nokiaThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                nokiaThrow.AddCell(defaultManager.Load<Texture2D>("3310 Throw " + i));
            Recipe.nokiaThrowAnimation = nokiaThrow;

            //hockey stick animations
            Animation hockeyIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                hockeyIdleTmp.AddCell(defaultManager.Load<Texture2D>("HockeyStick Idle " + i));
            Recipe.hockeyIdle = hockeyIdleTmp;

            Animation hockeyRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                hockeyRecoilTmp.AddCell(defaultManager.Load<Texture2D>("HockeyStick Recoil " + i));
            Recipe.hockeyRecoil = hockeyRecoilTmp;

            Animation hockeyWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                hockeyWalkTmp.AddCell(defaultManager.Load<Texture2D>("HockeyStick Walk" + i));
            Recipe.hockeyWalkAnimation = hockeyWalkTmp;

            Animation hockeyAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                hockeyAttack1.AddCell(defaultManager.Load<Texture2D>("HockeyStick Attack 1 " + i));
            Recipe.hockeyAttack.Add(hockeyAttack1);

            Animation hockeyAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                hockeyAttack2.AddCell(defaultManager.Load<Texture2D>("HockeyStick Attack 2 " + i));
            Recipe.hockeyAttack.Add(hockeyAttack2);

            Animation hockeyThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                hockeyThrow.AddCell(defaultManager.Load<Texture2D>("HockeyStick Throw " + i));
            Recipe.hockeyThrowAnimation = hockeyThrow;

            //lightsaber (Use the force JP)

            Animation lightsaberIdleTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                lightsaberIdleTmp.AddCell(defaultManager.Load<Texture2D>("Lightsaber Idle " + i));
            Recipe.lightsaberIdle = lightsaberIdleTmp;

            Animation lightsaberRecoilTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 4; i++)
                lightsaberRecoilTmp.AddCell(defaultManager.Load<Texture2D>("Lightsaber Recoil " + i));
            Recipe.lightsaberRecoil = lightsaberRecoilTmp;

            Animation lightsaberWalkTmp = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 9; i++)
                lightsaberWalkTmp.AddCell(defaultManager.Load<Texture2D>("Lightsaber Walk " + i));
            Recipe.lightsaberWalkAnimation = lightsaberWalkTmp;

            Animation lightsaberAttack1 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                lightsaberAttack1.AddCell(defaultManager.Load<Texture2D>("Lightsaber Attack 1 " + i));
            Recipe.lightsaberAttack.Add(lightsaberAttack1);

            Animation lightsaberAttack2 = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                lightsaberAttack2.AddCell(defaultManager.Load<Texture2D>("Lightsaber Attack 2 " + i));
            Recipe.lightsaberAttack.Add(lightsaberAttack2);

            Animation lightsaberThrow = new Animation(new Vector2(100, 100));
            for (int i = 1; i < 6; i++)
                lightsaberThrow.AddCell(defaultManager.Load<Texture2D>("Lightsaber Throw " + i));
            Recipe.lightsaberThrowAnimation = lightsaberThrow;


            //Blood Splashes!
            Texture2D[] floorTextures = new Texture2D[12];
            for (int i = 1; i < 4; i++)
                floorTextures[i - 1] = defaultManager.Load<Texture2D>("Floor Splash " + i);
            for (int i = 1; i < 10; i++)
                floorTextures[(i - 1) + 3] = defaultManager.Load<Texture2D>("Both Splash " + i);
            Texture2D[] wallTextures = new Texture2D[16];
            for (int i = 1; i < 8; i++)
                wallTextures[i - 1] = defaultManager.Load<Texture2D>("Wall Splash " + i);
            for (int i = 1; i < 10; i++)
                wallTextures[i - 1 + 7] = defaultManager.Load<Texture2D>("Both Splash " + i);
            f = floorTextures;
            w = wallTextures;
            BGExtras.allBloodSplashes = new BloodSpashes(floorTextures, wallTextures);
            BGExtras.spinningGlobe = new Animation(new Vector2(3566, 320));
            for (int i = 1; i < 10; i++)
            {
                BGExtras.spinningGlobe.AddCell(defaultManager.Load<Texture2D>("Globe " + i));
            }

            BGExtras.flashingMac = new Animation(new Vector2(2470, 301));
            for (int i = 1; i < 18; i++)
            {
                BGExtras.flashingMac.AddCell(defaultManager.Load<Texture2D>("Mac" + i));
            }

            BGExtras.bunsenBurner = new Animation(new Vector2(3710, 135));
            for (int i = 1; i < 12; i++)
            {
                BGExtras.bunsenBurner.AddCell(defaultManager.Load<Texture2D>("Fire " + i));
            }

            BGExtras.floatingBrain = new Animation(new Vector2(2450, 280));
            for (int i = 1; i < 46; i++)
            {
                BGExtras.floatingBrain.AddCell(defaultManager.Load<Texture2D>("Brain" + i));
            }

            BGExtras.torches = new Animation(new Vector2(2450, 280));
            for (int i = 1; i < 7; i++)
            {
                BGExtras.torches.AddCell(defaultManager.Load<Texture2D>("torch" + i));
            }

            BGExtras.torches2 = new Animation(new Vector2(2450, 280));
            for (int i = 1; i < 7; i++)
            {
                BGExtras.torches2.AddCell(defaultManager.Load<Texture2D>("torch" + i));
            }

            for (int i = 1; i < 25; i++)
            {
                finalBrawlAnimation.AddCell(defaultManager.Load<Texture2D>("Final Brawl" + i));
            }
            finalBrawlTexture = defaultManager.Load<Texture2D>("FinalBrawl");

            for (int i = 1; i < 35; i++)
                Stars.AddCell(defaultManager.Load<Texture2D>("Stars" + i));

            BGExtras.stars = Stars;

            downMenu = new Animation(new Vector2(430, 288));
            for (int i = 1; i < 8; i++)
                downMenu.AddCell(defaultManager.Load<Texture2D>("Down" + i));
            upMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                upMenu.AddCell(defaultManager.Load<Texture2D>("Up" + i));
            jumpDownMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                jumpDownMenu.AddCell(defaultManager.Load<Texture2D>("JumpDown" + i));
            jumpUpMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                jumpUpMenu.AddCell(defaultManager.Load<Texture2D>("JumpUp" + i));

            mainMenuToDraw = downMenu;


            selectorDownMenu = new Animation(new Vector2(91, 228));
            for (int i = 1; i < 8; i++)
                selectorDownMenu.AddCell(defaultManager.Load<Texture2D>("SelectorDown" + i));

            selectorUpMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                selectorUpMenu.AddCell(defaultManager.Load<Texture2D>("SelectorUp" + i));

            selectorJumpDownMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                selectorJumpDownMenu.AddCell(defaultManager.Load<Texture2D>("SelectorJumpDown" + i));

            selectorJumpUpMenu = new Animation(new Vector2(0, 0));
            for (int i = 1; i < 8; i++)
                selectorJumpUpMenu.AddCell(defaultManager.Load<Texture2D>("SelectorJumpUp" + i));


            selectorMenuToDraw = selectorDownMenu;

            helpScreenTexture = defaultManager.Load<Texture2D>("help");

            loadPreviousSaves();

        }

        public void loadPreviousLevelProgress()
        {
            string line;
            System.IO.StreamReader file1 = new System.IO.StreamReader("save/SavedProgress.txt");
            while ((line = file1.ReadLine()) != null)
            {
                if (line.Contains("L0,"))
                {
                    string[] arr = line.Split(',');
                    if (arr[1].Contains('X'))
                        levelUnlocked[0] = true;
                    else
                    {
                        levelScores[0] = arr[1];
                        levelUnlocked[0] = true;
                        levelUnlocked[1] = true;
                    }
                }
                else if (line.Contains("L1,"))
                {
                    string[] arr = line.Split(',');
                    if (arr[1].Contains('X')){
                        //levelUnlocked[1] = false;
                    }else
                    {
                        levelScores[1] = arr[1]; 
                        levelUnlocked[1] = true;
                        levelUnlocked[2] = true;
                    }
                }
                else if (line.Contains("L2,"))
                {
                    string[] arr = line.Split(',');
                    if (arr[1].Contains('X')){
                        //levelUnlocked[2] = false;
                    }else
                    {
                        levelScores[2] = arr[1];
                        levelUnlocked[2] = true;
                        levelUnlocked[3] = true;
                    }
                }
                else if (line.Contains("L3,"))
                {
                    string[] arr = line.Split(',');
                    if (arr[1].Contains('X')){
                     //   levelUnlocked[3] = false;
                    }else
                    {
                        levelScores[3] = arr[1];
                        levelUnlocked[3] = true;
                        levelUnlocked[4] = true;
                    }
                }
                else if (line.Contains("L4,"))
                {
                    string[] arr = line.Split(',');
                    if (arr[1].Contains('X')){
                     //   levelUnlocked[4] = false;
                    }else
                    {
                        levelScores[4] = arr[1];
                        levelUnlocked[4] = true;
                    }
                }
            }
        }

        public void loadPreviousSaves()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("save/SavedGame.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length != 0)
                {
                    //------------------------------WEAPONS------------------------------------
                    if (line.Contains("Nail Bat"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[3], Recipe.allItems[4]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Cactus Bat"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[5], Recipe.allItems[9]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Knife YoYo"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[11], Recipe.allItems[14]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Bear Hands"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[11], Recipe.allItems[9]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Light Saber"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[8], Recipe.allItems[6]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Acid Mouse"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[7], Recipe.allItems[12]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Radio Active Hands"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[7], Recipe.allItems[9]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("Electric Hokey Stick"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[6], Recipe.allItems[10]);
                        player.addWeapon(tmp);
                    }
                    else if (line.Contains("331O on a Stick"))
                    {
                        Weapon tmp = Recipe.checkRecipe(Recipe.allItems[10], Recipe.allItems[13]);
                        player.addWeapon(tmp);
                    }//------------------------------ITEMS--------------------------------------
                    else
                    {
                        if (line.Contains("Deadly Nails,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[3]);
                        }
                        else if (line.Contains("Baseball Bat,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[4]);
                        }
                        else if (line.Contains("Cactus,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[5]);
                        }
                        else if (line.Contains("Gloves,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[9]);
                        }
                        else if (line.Contains("Knife,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[11]);
                        }
                        else if (line.Contains("YoYo,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[14]);
                        }
                        else if (line.Contains("Car Battery,"))
                        {

                            InventoryHolder.inventory.Add(Recipe.allItems[6]);
                        }
                        else if (line.Contains("Fluorescent Tube,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[8]);
                        }
                        else if (line.Contains("Mouse,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[12]);
                        }
                        else if (line.Contains("Chemical Flask,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[7]);
                        }
                        else if (line.Contains("Hockey Stick,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[10]);
                        }
                        else if (line.Contains("Nokia 331O,"))
                        {
                            InventoryHolder.inventory.Add(Recipe.allItems[13]);
                        }
                    }
                }
            }

            for (int i = 0; i < InventoryHolder.inventory.Count; i++)
            {
                InventoryHolder.inventory[i].pickedUp = true;
            }
        }

        public void saveGame()
        {
            try
            {
                String saved = "";
                for (int i = 0; i < player.getWeapons().Count; i++)
                { //Save weapons
                    saved += player.getWeapons()[i].name += "\r\n";
                }

                for (int i = 0; i < InventoryHolder.inventory.Count; i++)
                {
                    for (int x = 0; x < InventoryHolder.inventory[i].amount; x++)
                        saved += InventoryHolder.inventory[i].name + ",\r\n";
                }
                System.IO.File.WriteAllText(@"save/SavedGame.txt", saved);

                //Level Progress
                saved = "";
                for (int i = 0; i < levelScores.Length; i++)
                    saved += ("L" + i + "," + levelScores[i] + "\r\n");
                System.IO.File.WriteAllText(@"save/SavedProgress.txt", saved);
            }
            catch (Exception e)
            {
                Console.WriteLine("Matthews text file thingy broke!");
            }
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public void giveAllItems()
        {
            for (int i = 3; i < Recipe.allItems.Length; i++)
            {
                InventoryHolder.inventory.Add(Recipe.allItems[i]);
            }

            for (int i = 0; i < InventoryHolder.inventory.Count; i++)
            {
                InventoryHolder.inventory[i].pickedUp = true;
            }

            if (player.weaponInventory.Count == 0)  //Give Nailbat as default
            {
                player.weaponInventory.Add(Recipe.checkRecipe(Recipe.allItems[3], Recipe.allItems[4]));

            }
        }

        public void checkCheatCode()
        {
            cheatTimer++;

            if (cheatCode.Contains("ITEM"))
            {
                Console.WriteLine("itemcheatActivated");
                giveAllItems();
                cheatCode = "";
                soundBank.PlayCue("Pickup");  
            }

            if (cheatCode.Contains("HEAL"))
            {
                Console.WriteLine("healCheatActivated");
                cheatCode = "";
                player.hitpoints = 100;
                soundBank.PlayCue("Pickup");  
            }

            if (cheatCode.Contains("WEST"))
            {
                Console.WriteLine("Go West");
                cheatCode = "";
                cheatSong = true;
                soundBank.PlayCue("Pickup");  
            }

            if (cheatCode.Contains("EAST"))
            {
                Console.WriteLine("Stop West");
                cheatCode = "";
                cheatSong = false;
                soundBank.PlayCue("Pickup");  
            }

            if (cheatCode.Contains("RESET"))
            {
                Console.WriteLine("Reset save");
                cheatCode = "";
                //code to reset save file
                String reset = "";
                System.IO.File.WriteAllText(@"save/SavedGame.txt", reset);
                System.IO.File.WriteAllText(@"save/SavedProgress.txt", reset);
                InventoryHolder.inventory = new List<DropItems>();
                InventoryHolder.tmpInventory = new List<DropItems>();
                craftingInventory = new DropItems[3, 4];
                tutCraftScreen = 0;
                player.weapon = player.fists;
                player.specialWeapon = null;
                recraft = false;
                crafting = false;
                count = 0;
                isEnterUp = true;
                player.weaponInventory = new List<Weapon>();
                for (int i = 1; i < levelUnlocked.Length; i++)
                {
                    levelUnlocked[i] = false;
                }
                for (int i = 0; i < levelScores.Length; i++)
                {
                    levelScores[i] = "X";
                }
                mainMenu = true;
                unloadAll();
                player.switchEquipedWeapon();
                soundBank.PlayCue("Pickup");  
                
            }

            if (cheatCode.Length > 100)
            {
                cheatCode = "";
            }
        }

        public void cheatCodes()
        {

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.S) && keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down) && keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right) && keyState.IsKeyUp(Keys.Enter)
                 && keyState.IsKeyUp(Keys.Escape) && keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.Q) && keyState.IsKeyUp(Keys.I) && keyState.IsKeyUp(Keys.T) && keyState.IsKeyUp(Keys.E) && keyState.IsKeyUp(Keys.M)
                 && keyState.IsKeyUp(Keys.H) && keyState.IsKeyUp(Keys.L) && keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.R))
            {
                cheatKeyDown = false;
            }

            if (keyState.IsKeyDown(Keys.I) && !cheatKeyDown)
            {
                cheatCode += "I";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.T) && !cheatKeyDown)
            {
                cheatCode += "T";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.E) && !cheatKeyDown)
            {
                cheatCode += "E";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.M) && !cheatKeyDown)
            {
                cheatCode += "M";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.H) && !cheatKeyDown)
            {
                cheatCode += "H";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.A) && !cheatKeyDown)
            {
                cheatCode += "A";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.L) && !cheatKeyDown)
            {
                cheatCode += "L";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.Q) && !cheatKeyDown)
            {
                cheatCode += "Q";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.S) && !cheatKeyDown)
            {
                cheatCode += "S";
                cheatKeyDown = true;
            }
            if (keyState.IsKeyDown(Keys.W) && !cheatKeyDown)
            {
                cheatCode += "W";
                cheatKeyDown = true;
            }

            if (keyState.IsKeyDown(Keys.R) && !cheatKeyDown)
            {
                cheatCode += "R";
                cheatKeyDown = true;
            }

            checkCheatCode();

        }

        protected override void Update(GameTime gameTime)
        {
            virtualScreen.Update();
            audioEngine.Update();

            if (BGExtras.credits.currentSection >= 13)
            {

                saveGame();
                BGExtras.credits.reset();
                BGExtras.credits.currentSection = 0;
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i).type.Equals("evilJP"))
                    {
                        enemies.getAtIndex(i).enemyDeathAnimation.currentCell = 0;
                    }
                }
                mainMenu = true;
                unloadAll();
            }
            if (BGExtras.credits.isPlaying)
            {
                if (bossFightSound.IsPlaying)
                    bossFightSound.Stop(AudioStopOptions.Immediate);
            }
            
            if (mainMenu)
            {
                idlingAnimationMainMenu.Update(gameTime);

                if (!idlingAnimationMainMenu.playing)
                {
                    idlingAnimationMainMenu.LoopAll(6.0f);
                }

                if (goWest.IsPlaying)
                {
                    goWest.Stop(AudioStopOptions.Immediate);
                }


                if (BGExtras.credits.music != null && BGExtras.credits.music.IsPlaying)
                {
                    BGExtras.credits.music.Stop(AudioStopOptions.Immediate);
                    BGExtras.credits.musicPlaying = false;
                }

                if (level2Sound.IsPlaying)
                    level2Sound.Stop(AudioStopOptions.Immediate);

                if (level0Sound.IsPlaying)
                    level0Sound.Stop(AudioStopOptions.Immediate);

                if (level1Sound.IsPlaying)
                    level1Sound.Stop(AudioStopOptions.Immediate);

                if (level3Sound.IsPlaying)
                    level3Sound.Stop(AudioStopOptions.Immediate);

                if (bossFightSound.IsPlaying)
                    bossFightSound.Stop(AudioStopOptions.Immediate);

                if (!menuMusic.IsPlaying)
                {
                    menuMusic = soundBank.GetCue("8bit");
                    menuMusic.Play();
                }

                if (craftMusic.IsPlaying)
                    craftMusic.Stop(AudioStopOptions.Immediate);

                mainMenuUpdate(gameTime);
            }
            else
            {
                hud.Update(gameTime);
                cheatCodes();
                //sound update
                if (BGExtras.credits.isPlaying)
                {
                    KeyboardState keys = Keyboard.GetState();

                    if (keys.IsKeyDown(Keys.Escape))
                    {
                        BGExtras.credits.currentSection = 0;
                        BGExtras.credits.reset();
                        mainMenu = true;
                        unloadAll();
                        BGExtras.credits.isPlaying = false;
                        
                        for (int i = 0; i < enemies.getSize(); i++)
                        {
                            if (enemies.getAtIndex(i).type.Equals("evilJP"))
                            {
                                enemies.getAtIndex(i).enemyDeathAnimation.currentCell = 0;
                            }
                        }
                    }
                    BGExtras.credits.Update(gameTime);
                }
                else if (cheatSong && !crafting)
                {

                    if (bossFightSound.IsPlaying)
                        bossFightSound.Stop(AudioStopOptions.Immediate);

                    if (level2Sound.IsPlaying)
                        level2Sound.Stop(AudioStopOptions.Immediate);

                    if (level0Sound.IsPlaying)
                        level0Sound.Stop(AudioStopOptions.Immediate);

                    if (level1Sound.IsPlaying)
                        level1Sound.Stop(AudioStopOptions.Immediate);

                    if (menuMusic.IsPlaying)
                    {
                        menuMusic.Stop(AudioStopOptions.Immediate);
                    }

                    if (!goWest.IsPlaying)
                    {
                        goWest = soundBank.GetCue("West");
                        goWest.Play();
                    }

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level3Sound.IsPlaying)
                        level3Sound.Stop(AudioStopOptions.Immediate);
                }
                else if (level == 0 && !crafting)
                {
                    if (bossFightSound.IsPlaying)
                        bossFightSound.Stop(AudioStopOptions.Immediate);

                    if (goWest.IsPlaying)
                    {
                        goWest.Stop(AudioStopOptions.Immediate);
                    }

                    if (menuMusic.IsPlaying)
                    {
                        menuMusic.Stop(AudioStopOptions.Immediate);
                    }

                    if (!level0Sound.IsPlaying)
                    {
                        level0Sound = soundBank.GetCue("SuperMegaUltra");
                        level0Sound.Play();
                    }

                    if (level1Sound.IsPlaying)
                        level1Sound.Stop(AudioStopOptions.Immediate);

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level2Sound.IsPlaying)
                        level2Sound.Stop(AudioStopOptions.Immediate);

                    if (level3Sound.IsPlaying)
                        level3Sound.Stop(AudioStopOptions.Immediate);
                }
                else if (level == 1 && !crafting)
                {
                    if (bossFightSound.IsPlaying)
                        bossFightSound.Stop(AudioStopOptions.Immediate);

                    if (goWest.IsPlaying)
                    {
                        goWest.Stop(AudioStopOptions.Immediate);
                    }

                    if (menuMusic.IsPlaying)
                        menuMusic.Stop(AudioStopOptions.Immediate);

                    if (level0Sound.IsPlaying)
                        level0Sound.Stop(AudioStopOptions.Immediate);

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level2Sound.IsPlaying)
                        level2Sound.Stop(AudioStopOptions.Immediate);

                    if (level3Sound.IsPlaying)
                        level3Sound.Stop(AudioStopOptions.Immediate);

                    if (!level1Sound.IsPlaying)
                    {
                        level1Sound = soundBank.GetCue("level1");
                        level1Sound.Play();
                    }
                }

                else if (level == 2 && !crafting)
                {
                    if (bossFightSound.IsPlaying)
                        bossFightSound.Stop(AudioStopOptions.Immediate);

                    if (goWest.IsPlaying)
                    {
                        goWest.Stop(AudioStopOptions.Immediate);
                    }

                    if (menuMusic.IsPlaying)
                        menuMusic.Stop(AudioStopOptions.Immediate);

                    if (level0Sound.IsPlaying)
                        level0Sound.Stop(AudioStopOptions.Immediate);

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level1Sound.IsPlaying)
                        level1Sound.Stop(AudioStopOptions.Immediate);

                    if (level3Sound.IsPlaying)
                        level3Sound.Stop(AudioStopOptions.Immediate);

                    if (!level2Sound.IsPlaying)
                    {
                        level2Sound = soundBank.GetCue("PixelPuncher");
                        level2Sound.Play();
                    }
                }
                else if (level == 3 && !crafting)
                {
                    if (bossFightSound.IsPlaying)
                        bossFightSound.Stop(AudioStopOptions.Immediate);

                    if (goWest.IsPlaying)
                    {
                        goWest.Stop(AudioStopOptions.Immediate);
                    }

                    if (menuMusic.IsPlaying)
                        menuMusic.Stop(AudioStopOptions.Immediate);

                    if (level0Sound.IsPlaying)
                        level0Sound.Stop(AudioStopOptions.Immediate);

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level1Sound.IsPlaying)
                        level1Sound.Stop(AudioStopOptions.Immediate);

                    if (level2Sound.IsPlaying)
                        level2Sound.Stop(AudioStopOptions.Immediate);

                    if (!level3Sound.IsPlaying)
                    {
                        level3Sound = soundBank.GetCue("The Next Level");
                        level3Sound.Play();
                    }
                }
                else if (level == 4 && !crafting)
                {
                    if (level3Sound.IsPlaying)
                        level3Sound.Stop(AudioStopOptions.Immediate);

                    if (goWest.IsPlaying)
                    {
                        goWest.Stop(AudioStopOptions.Immediate);
                    }

                    if (menuMusic.IsPlaying)
                        menuMusic.Stop(AudioStopOptions.Immediate);

                    if (level0Sound.IsPlaying)
                        level0Sound.Stop(AudioStopOptions.Immediate);

                    if (craftMusic.IsPlaying)
                        craftMusic.Stop(AudioStopOptions.Immediate);

                    if (level1Sound.IsPlaying)
                        level1Sound.Stop(AudioStopOptions.Immediate);

                    if (level2Sound.IsPlaying)
                        level2Sound.Stop(AudioStopOptions.Immediate);

                    if (!bossFightSound.IsPlaying)
                    {
                        bossFightSound = soundBank.GetCue("Boss Fight");
                        bossFightSound.Play();
                    }
                }

                if (isLoadingScreen)
                {
                    //Console.WriteLine("loadingTimerMain: " + loadingTimer);
                    if (!(loadingTimer >= totalLoadingTime))
                        loadingTimer++;

                    KeyboardState keyState = Keyboard.GetState();


                    if (keyState.IsKeyDown(Keys.Enter) && loadingTimer >= totalLoadingTime)
                    {
                        isLoadingScreen = false;
                        loadingTimer = 0;
                    }
                    player.isLoadingScreen = isLoadingScreen;
                }
                else
                {

                    if (!paused)
                    {
                        switch (level)
                        {
                            case 0:
                                {
                                    tutUpdate(gameTime);
                                    player.fists.damage = 30;
                                } break;
                            case 1:
                                {
                                    level1Update(gameTime);
                                    player.fists.damage = 35;
                                } break;
                            case 2:
                                {
                                    level2Update(gameTime);
                                    player.fists.damage = 40;
                                    if (BGExtras.teslaCoil != null)
                                        BGExtras.teslaCoil.Update(gameTime);
                                } break;
                            case 3:
                                {
                                    player.fists.damage = 50;
                                    level3Update(gameTime);
                                    if (BGExtras.teslaCoil != null)
                                        BGExtras.teslaCoil.Update(gameTime);
                                }break;
                            case 4:
                                {
                                    player.fists.damage = 60;
                                    bossFightUpdate(gameTime);
                                } break;
                        }
                        //arrowAnimation.Update(gameTime);

                    }
                    if (crafting)
                    {
                        craftingMenuUpdate();
                        if (bossFightSound.IsPlaying)
                            bossFightSound.Stop(AudioStopOptions.Immediate);

                        if (goWest.IsPlaying)
                        {
                            goWest.Stop(AudioStopOptions.Immediate);
                        }

                        if (menuMusic.IsPlaying)
                            menuMusic.Stop(AudioStopOptions.Immediate);

                        if (level0Sound.IsPlaying)
                            level0Sound.Stop(AudioStopOptions.Immediate);

                        if (level1Sound.IsPlaying)
                            level1Sound.Stop(AudioStopOptions.Immediate);

                        if (level2Sound.IsPlaying)
                            level2Sound.Stop(AudioStopOptions.Immediate);

                        if (level3Sound.IsPlaying)
                            level3Sound.Stop(AudioStopOptions.Immediate);

                        if (!craftMusic.IsPlaying)
                        {
                            craftMusic = soundBank.GetCue("Cubish");
                            craftMusic.Play();
                        }
                    }
                    else
                        menuUpdate();

                }
            }
            base.Update(gameTime);

        }

        public void pauseGame()
        {
            //TODO: Pause all animations
            spriteBatch.Begin();

            if (pauseOptionsSelect)
            {
                spriteBatch.Draw(pauseMenuOptionScreen, new Vector2(0, 0), Color.White);

                if (mainMenuOptionsUpDown == 0)
                    spriteBatch.Draw(pauseMenuOptionsSelectorTexture, new Vector2(386, 238), Color.White);
                if (mainMenuOptionsUpDown == 1)
                    spriteBatch.Draw(pauseMenuOptionsSelectorTexture, new Vector2(386, 400), Color.White);
                if (mainMenuOptionsUpDown == 2)
                    spriteBatch.Draw(pauseMenuOptionsSelectorTexture, new Vector2(386, 570), Color.White);

                if (!graphics.IsFullScreen)
                    spriteBatch.Draw(mainMenuWindowedTexture, new Vector2(530, 320), Color.White);
                else
                    spriteBatch.Draw(mainMenuFullScreenTexture, new Vector2(495, 320), Color.White);

                float tmpEffects = effectsVolume / 2.0f;
                float tmpMusic = defaultVolume / 2.0f;

                tmpEffects *= 427;
                tmpMusic *= 427;

                tmpEffects += 492;
                tmpMusic += 492;

                spriteBatch.Draw(mainMenuVolumeSliderMusicTexture, new Vector2(tmpMusic, 462), Color.White);
                spriteBatch.Draw(mainMenuVolumeSliderEffectsTexture, new Vector2(tmpEffects, 636), Color.White);

            }
            else
            {
                spriteBatch.Draw(levelPaused, new Vector2(0, 0), Color.White);
                switch (menuOption)
                {
                    case 1: spriteBatch.Draw(menuOption1, new Vector2(366, 206), Color.White); break;
                    case 2: spriteBatch.Draw(menuOption2, new Vector2(366, 383), Color.White); break;
                    case 3: spriteBatch.Draw(menuOption3, new Vector2(366, 555), Color.White); break;
                }
            }
            spriteBatch.End();
        }

        public void menuUpdate()
        {
            KeyboardState keyState = Keyboard.GetState();


            if (paused)
            {
                if (keyState.IsKeyUp(Keys.Enter) && keyState.IsKeyUp(Keys.Escape))
                    checkKeyUp = true;

                if (keyState.IsKeyDown(Keys.Enter) && checkKeyUp && !pauseOptionsSelect)
                {
                    checkKeyUp = false;
                    if (menuOption == 1)
                    {
                        paused = false;
                    }

                    if (menuOption == 2)
                    {
                        pauseOptionsSelect = true;
                    }

                    if (menuOption == 3)
                    {
                        mainMenuRow = 1;
                        mainMenu = true;
                        unloadAll();
                    }
                }

                if (keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down) && keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right))
                    isArrowUp = true;

                if (keyState.IsKeyDown(Keys.Down) && isArrowUp && !pauseOptionsSelect)
                {
                    isArrowUp = false;
                    if (menuOption == 1)
                        menuOption = 2;
                    else if (menuOption == 2)
                        menuOption = 3;
                    else if (menuOption == 3)
                        menuOption = 1;
                }
                else if (keyState.IsKeyDown(Keys.Up) && isArrowUp && !pauseOptionsSelect)
                {
                    isArrowUp = false;
                    if (menuOption == 1)
                        menuOption = 3;
                    else if (menuOption == 2)
                        menuOption = 1;
                    else if (menuOption == 3)
                        menuOption = 2;
                }

            }

            if (keyState.IsKeyDown(Keys.Escape) && isEscUp && !pauseOptionsSelect)
            {
                isEscUp = false;
                if (paused)
                    paused = false;
                else
                    paused = true;
            }

            if (paused)
            {

                if (pauseOptionsSelect)
                {
                    if (keyState.IsKeyDown(Keys.Enter) && checkKeyUp && mainMenuOptionsUpDown == 0)
                    {
                        checkKeyUp = false;

                        if (graphics.IsFullScreen)
                            graphics.IsFullScreen = false;
                        else
                            graphics.IsFullScreen = true;
                        graphics.ApplyChanges();

                    }
                    else if (keyState.IsKeyDown(Keys.Down) && isArrowUp)
                    {
                        isArrowUp = false;
                        if (mainMenuOptionsUpDown == 0)
                            mainMenuOptionsUpDown = 1;
                        else if (mainMenuOptionsUpDown == 1)
                            mainMenuOptionsUpDown = 2;
                        else if (mainMenuOptionsUpDown == 2)
                            mainMenuOptionsUpDown = 0;

                        //Console.WriteLine("OptionsRow:" + mainMenuOptionsUpDown);
                    }
                    else if (keyState.IsKeyDown(Keys.Up) && isArrowUp)
                    {
                        isArrowUp = false;
                        if (mainMenuOptionsUpDown == 0)
                            mainMenuOptionsUpDown = 2;
                        else if (mainMenuOptionsUpDown == 1)
                            mainMenuOptionsUpDown = 0;
                        else if (mainMenuOptionsUpDown == 2)
                            mainMenuOptionsUpDown = 1;

                       // Console.WriteLine("OptionsRow:" + mainMenuOptionsUpDown);
                    }
                    else if ((keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left)) && isArrowUp && mainMenuOptionsUpDown == 0)
                    {
                        isArrowUp = false;

                        if (graphics.IsFullScreen)
                            graphics.IsFullScreen = false;
                        else
                            graphics.IsFullScreen = true;
                        graphics.ApplyChanges();

                    }
                    else if (keyState.IsKeyDown(Keys.Right) && mainMenuOptionsUpDown == 1 && isArrowUp)
                    {
                        isArrowUp = false;
                        Console.WriteLine("VolumeChange:" + defaultVolume);
                        defaultVolume = MathHelper.Clamp(defaultVolume + 0.1f, 0.0f, 2.0f);
                        audioEngine.GetCategory("Music").SetVolume(defaultVolume);

                    }
                    else if (keyState.IsKeyDown(Keys.Left) && mainMenuOptionsUpDown == 1 && isArrowUp)
                    {
                        isArrowUp = false;
                        Console.WriteLine("VolumeChange:" + defaultVolume);
                        defaultVolume = MathHelper.Clamp(defaultVolume - 0.1f, 0.0f, 2.0f);
                        audioEngine.GetCategory("Music").SetVolume(defaultVolume);

                    }
                    else if (keyState.IsKeyDown(Keys.Right) && mainMenuOptionsUpDown == 2 && isArrowUp)
                    {
                        isArrowUp = false;
                        Console.WriteLine("SoundEffects:" + effectsVolume);
                        effectsVolume = MathHelper.Clamp(effectsVolume + 0.1f, 0.0f, 2.0f);
                        audioEngine.GetCategory("SoundEffects").SetVolume(effectsVolume);

                        soundBank.PlayCue("Pickup");
                    }
                    else if (keyState.IsKeyDown(Keys.Left) && mainMenuOptionsUpDown == 2 && isArrowUp)
                    {
                        isArrowUp = false;
                        Console.WriteLine("SoundEffects:" + effectsVolume);
                        effectsVolume = MathHelper.Clamp(effectsVolume - 0.1f, 0.0f, 2.0f);
                        audioEngine.GetCategory("SoundEffects").SetVolume(effectsVolume);

                        soundBank.PlayCue("Pickup");
                    }

                    if (keyState.IsKeyDown(Keys.Escape) && checkKeyUp && isEscUp)
                    {
                        isEscUp = false;
                        checkKeyUp = false;
                        pauseOptionsSelect = false;
                    }
                }
            }

            //Pausing game
            if (keyState.IsKeyUp(Keys.Escape))
                isEscUp = true;


        }

        public void restartGame()
        {
            enemies.removeAll();
            if (level == 0)
            {
                tutText.levelCompleted = false;
                tutText.textNumber = 0;
                tutText.nextNumber = 0;
                tutText.position.X = 0;
                tutText.started = false;
                tutText.startedDraw = false;
                tutText.position2.X = 4096;
                fadeInCount = 0;
                fadedIn = false;
                for (int x = 0; x < tutInstructions.Length; x++)
                    tutInstructions[x] = false;
            }
            else if (level == 1)
            {
                BGExtras.spinningGlobe.someBounds.X = 3566;
                BGExtras.spinningGlobe.position = new Vector2(3566, 320);
                BGExtras.flashingMac.position = new Vector2(2470, 301);
            }
            else if (level == 2)
            {
                BGExtras.bunsenBurner.someBounds.X = 3710;
                BGExtras.bunsenBurner.position = new Vector2(3710, 135);
                BGExtras.floatingBrain.position = new Vector2(2450, 280);
                if (BGExtras.teslaCoil != null)
                    BGExtras.teslaCoil.position = new Vector2(3400f, 350.0f);
            }
            else if (level == 4)
            {
                BGExtras.teslaCoil = null;
                generateCounter = 0;
                fightStages = 0;
            }

            drawSplash = 0;

            drawBrawlAnimation = false;
            drawBrawlDown = false;
            drawBrawlAlpha = 1.0f;
            drawBrawlCount = 0;

            BGExtras.allBloodSplashes = new BloodSpashes(f, w);
            //arrowAnimation.LoopAll(0.6f);
            drawSplash = 0;
            crafting = false;
            player.position.X = 400;
            player.position.Y = 400;
            player.playerDied = false;
            player.levelComplete = false;
            player.hitpoints = 100;
            player.inventoryObject = null;
            player.throwInventory = false;
            player.recoilBackward = false;
            player.recoilForward = false;
            player.left = false;

            gameBG = null;
            gameBG = new MultiBackground(graphics);



            //clear tmpInventory
            InventoryHolder.tmpInventory = new List<DropItems>();


            //clear throw objects
            throwObjects = new List<ThrowObjects>();
            player.throwObjects = this.throwObjects;

            if (level == 0)
            {
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 1"), 1, 200.0f);
                gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 2"), 1, 200.0f);
                gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 1"), 1, 200.0f);

                gameBG.AddLayer(tutTexture1, 0, 200.0f);
                gameBG.AddLayer(tutTexture2, 0, 200.0f);
                gameBG.AddLayer(tutTexture1, 0, 200.0f);   //Not in use currently

                //gameBG.SetLayerAlpha(0, 0f);

                gameBG.tutLevel = true;
                gameBG.lastLevel = false;

            }
            else if (level == 1)
            {
                loadLevel1();

                gameBG.AddLayer(trees1, 2.0f, 200.0f);
                gameBG.AddLayer(trees1, 2.0f, 200.0f);
                gameBG.AddLayer(trees1, 2.0f, 200.0f);

                gameBG.AddLayer(trees2, 1.0f, 200.0f);
                gameBG.AddLayer(trees2, 1.0f, 200.0f);
                gameBG.AddLayer(trees2, 1.0f, 200.0f);

                gameBG.AddLayer(bgTexture, 0.0f, 200.0f);
                gameBG.AddLayer(bgTexture2, 0.0f, 200.0f);
                gameBG.AddLayer(bgTexture, 0.0f, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 2)
            {
                loadLevel2();
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);

                gameBG.AddLayer(level2BG1, 0, 200.0f);
                gameBG.AddLayer(level2BG2, 0, 200.0f);
                gameBG.AddLayer(level2BG1, 0, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 3)
            {
                loadLevel3();
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);
                gameBG.AddLayer(trees1, 2, 200.0f);

                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);
                gameBG.AddLayer(trees2, 1, 200.0f);

                gameBG.AddLayer(level3BG1, 0, 200.0f);
                gameBG.AddLayer(level3BG2, 0, 200.0f);
                gameBG.AddLayer(level3BG1, 0, 200.0f);
                gameBG.lastLevel = false;
            }
            else if (level == 4)
            {
                loadBossFight();
                gameBG.AddLayer(bossTrees1, 2, 200.0f);
                gameBG.AddLayer(bossTrees1, 2, 200.0f);
                gameBG.AddLayer(bossTrees1, 2, 200.0f);

                gameBG.AddLayer(bossTrees2, 1, 200.0f);
                gameBG.AddLayer(bossTrees2, 1, 200.0f);
                gameBG.AddLayer(bossTrees2, 1, 200.0f);

                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.AddLayer(bossFightBG, 0, 200.0f);
                gameBG.lastLevel = true;
            }

            mapPosition = 0;

            for (int i = 0; i < fights.Length; i++)
                fights[i] = false;

            
        }

        public void MoveScreen()
        {

        }

        private void shakeScreen(int x)
        {
            gameBG.shake(x);
            player.position.X += x;
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null)
                    enemies.getAtIndex(i).position.X += x;
            }

            if (tutText != null && level == 0)
            {
                tutText.position.X += x;
                tutText.position2.X += x;
            }

            for (int i = 0; i < throwObjects.Count; i++)
            {
                throwObjects.ElementAt(i).position.X += x;
                throwObjects.ElementAt(i).textPosition.X += x;
                throwObjects.ElementAt(i).textPosition2.X += x;
            }

            for (int i = 0; i < BGExtras.allBloodSplashes.floorSplashList.Count; i++)
            {
                BGExtras.allBloodSplashes.floorSplashList[i].position.X += x;
            }

            for (int i = 0; i < BGExtras.allBloodSplashes.wallSplashList.Count; i++)
            {
                BGExtras.allBloodSplashes.wallSplashList[i].position.X += x;
            }

            if (level == 1)
            {
                BGExtras.spinningGlobe.someBounds.X += x;
                BGExtras.spinningGlobe.position.X += x;
                BGExtras.flashingMac.position.X += x;
            }
            else if (level == 2)
            {
                BGExtras.bunsenBurner.someBounds.X += x;
                BGExtras.bunsenBurner.position.X += x;
                BGExtras.floatingBrain.position.X += x;
            }

            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
            {
                InventoryHolder.tmpInventory[i].position.X += x;
            }
            if (BGExtras.teslaCoil != null)
                BGExtras.teslaCoil.position.X += x;

        }

        public void adjustScreenAfterFight()
        {
            if (enemies.isAllDead()) //if (enemies.getSize() == 0)
            {
                if (player.getPosition().X > 710 && level != 0)
                {
                    gameBG.newMoveDistance = 13;
                    //player.scrolling = true;
                    gameBG.setMoveRate(500f);
                    gameBG.SetMoveRightLeft();
                    gameBG.StartMoving();
                    player.position.X -= 13;

                    //move enemies off screen
                    for (int i = 0; i < enemies.getSize(); i++)
                    {
                        if (enemies.getAtIndex(i) != null)
                        {
                            enemies.getAtIndex(i).position.X -= 13;
                            if (enemies.getAtIndex(i).projectile != null)
                            {
                                enemies.getAtIndex(i).projectile.position.X -= 13;
                            }
                        }
                    }

                    if (tutText != null && level == 0)
                    {
                        tutText.position.X -= 13;
                        tutText.position2.X -= 13;
                    }

                    for (int i = 0; i < throwObjects.Count; i++)
                    {
                        throwObjects.ElementAt(i).position.X -= 13;
                        throwObjects.ElementAt(i).textPosition.X -= 13;
                        throwObjects.ElementAt(i).textPosition2.X -= 13;
                    }

                    for (int i = 0; i < BGExtras.allBloodSplashes.floorSplashList.Count; i++)
                    {
                        BGExtras.allBloodSplashes.floorSplashList[i].position.X -= 13;
                    }

                    for (int i = 0; i < BGExtras.allBloodSplashes.wallSplashList.Count; i++)
                    {
                        BGExtras.allBloodSplashes.wallSplashList[i].position.X -= 13;
                    }

                    if (level == 1)
                    {
                        BGExtras.spinningGlobe.someBounds.X -= 13;
                        BGExtras.spinningGlobe.position.X -= 13;
                        BGExtras.flashingMac.position.X -= 13;
                    }
                    else if (level == 2)
                    {
                        BGExtras.bunsenBurner.someBounds.X -= 13;
                        BGExtras.bunsenBurner.position.X -= 13;
                        BGExtras.floatingBrain.position.X -= 13;
                    }

                    for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                    {
                        InventoryHolder.tmpInventory[i].position.X -= 13;
                    }
                    if (BGExtras.teslaCoil != null)
                        BGExtras.teslaCoil.position.X -= 13;
                }
                else
                {
                    //player.scrolling = false;
                    gameBG.setMoveRate(200f);
                    gameBG.Stop();

                    if (player.getPosition().X >= 700 && !player.isIdlePlayer() && !player.isAttackingPlayer() && idDoneMoving) //Move the player [walking]
                    {

                        if (enemies.isAllDead())//if (enemies.getSize() == 0)
                        {
                            //if (level == 0 && InventoryHolder.allPickedUp())
                            //{
                            gameBG.newMoveDistance = player.getForwardSpeed() / 2;
                            //Scroll The Screen
                            gameBG.SetMoveRightLeft();
                            gameBG.StartMoving();

                            mapPosition = -gameBG.getLayerList()[0].position.X;

                            if (tutText != null && level == 0)
                            {
                                tutText.position.X -= player.getForwardSpeed() / 2;
                                tutText.position2.X -= player.getForwardSpeed() / 2;
                            }

                            for (int i = 0; i < enemies.getSize(); i++)
                            {
                                if (enemies.getAtIndex(i) != null)
                                    enemies.getAtIndex(i).position.X -= player.getForwardSpeed() / 2;
                            }


                            for (int i = 0; i < throwObjects.Count; i++)
                            {
                                throwObjects.ElementAt(i).position.X -= player.getForwardSpeed() / 2;
                                throwObjects.ElementAt(i).textPosition.X -= player.getForwardSpeed() / 2;
                                throwObjects.ElementAt(i).textPosition2.X -= player.getForwardSpeed() / 2;
                            }

                            for (int i = 0; i < BGExtras.allBloodSplashes.floorSplashList.Count; i++)
                            {
                                BGExtras.allBloodSplashes.floorSplashList[i].position.X -= player.getForwardSpeed() / 2;
                            }

                            for (int i = 0; i < BGExtras.allBloodSplashes.wallSplashList.Count; i++)
                            {
                                BGExtras.allBloodSplashes.wallSplashList[i].position.X -= player.getForwardSpeed() / 2;
                            }

                            if (level == 1)
                            {
                                BGExtras.spinningGlobe.someBounds.X -= (int)player.getForwardSpeed() / 2;
                                BGExtras.spinningGlobe.position.X -= player.getForwardSpeed() / 2;
                                BGExtras.flashingMac.position.X -= player.getForwardSpeed() / 2;
                            }
                            else if (level == 2)
                            {
                                BGExtras.bunsenBurner.someBounds.X -= (int)player.getForwardSpeed() / 2;
                                BGExtras.bunsenBurner.position.X -= player.getForwardSpeed() / 2;
                                BGExtras.floatingBrain.position.X -= player.getForwardSpeed() / 2;
                            }

                            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                            {
                                InventoryHolder.tmpInventory[i].position.X -= player.getForwardSpeed() / 2;
                            }
                            if (BGExtras.teslaCoil != null)
                                BGExtras.teslaCoil.position.X -= player.getForwardSpeed() / 2; ;

                            //else
                            //{
                            //   player.scrollingPoint = 1400 - 160;
                            //}
                        }
                    }
                    else if (player.getPosition().X < 700)
                    {

                        gameBG.Stop();
                        for (int i = 0; i < enemies.getSize(); i++)
                        {
                            if (enemies.getAtIndex(i) != null)
                                enemies.getAtIndex(i).setScrollSpeed(0);
                        }
                    }
                }
            }
            else
            {
                //player.scrolling = false;
                gameBG.setMoveRate(200f);
                gameBG.Stop();
            }





        }

        public void addBook(float x, float y)
        {
            float tmpY = y;
            float tmpX = x;
            if (level == 0)
            {
                ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), tutObjectTexture1, "throwable1");
                objectTmp.DropItemFont = dropItemFont;
                throwObjects.Add(objectTmp);
                objectTmp.addCell(tutObjectTexture1);
                objectTmp.addCell(tutObjectTexture2);
                objectTmp.addCell(tutObjectTexture3);
                objectTmp.addCell(tutObjectTexture4);
                objectTmp.displayName = "Baseball";
                hud.LoadSprite("Baseball", baseballMenu);

            }
            else if (level == 1)
            {
                ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), objectTexture1, "throwable1");
                objectTmp.DropItemFont = dropItemFont;
                throwObjects.Add(objectTmp);
                objectTmp.addCell(objectTexture1);
                objectTmp.addCell(objectTexture2);
                objectTmp.addCell(objectTexture3);
                objectTmp.addCell(objectTexture4);
                objectTmp.displayName = "Textbook";
                hud.LoadSprite("throwable1", bookMenu);
            }
            else if (level == 2)
            {
                ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), labObjectTexture1, "throwable1");
                objectTmp.DropItemFont = dropItemFont;

                objectTmp.addCell(labObjectTexture1);
                objectTmp.addCell(labObjectTexture2);
                objectTmp.addCell(labObjectTexture3);
                objectTmp.addCell(labObjectTexture4);
                throwObjects.Add(objectTmp);
                objectTmp.displayName = "Calculator";
                hud.LoadSprite("throwable1", calculatorMenu);
            }
            else if (level == 3)
            {
                ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), plateMenu, "throwable1");
                objectTmp.DropItemFont = dropItemFont;
                throwObjects.Add(objectTmp);
                objectTmp.addCell(cafObjectTexture1);
                objectTmp.addCell(cafObjectTexture2);
                objectTmp.addCell(cafObjectTexture3);
                objectTmp.addCell(cafObjectTexture4);
                objectTmp.displayName = "Plate";
                hud.LoadSprite("throwable1", plateMenu);
            }
            else if (level == 4)
            {
                ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), bossFightMenu, "throwable1");
                objectTmp.DropItemFont = dropItemFont;
                throwObjects.Add(objectTmp);
                objectTmp.addCell(bossFightObjectTexture1);
                objectTmp.addCell(bossFightObjectTexture2);
                objectTmp.addCell(bossFightObjectTexture3);
                objectTmp.addCell(bossFightObjectTexture4);
                objectTmp.displayName = "Barbarian Ball";
                hud.LoadSprite("throwable1", bossFightMenu);
            }

        }

        public void addRandomBook()
        {
            int tmp = r.Next(800);
            float tmpY = ((float)r.Next(260) + 520);
            float tmpX = ((float)r.Next(1220) + 100);

            if (tmp == 200 && !player.levelComplete && !player.playerDied)
            {
                if (level == 0)
                {
                    ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), tutObjectTexture1, "throwable1");
                    objectTmp.DropItemFont = dropItemFont;
                    throwObjects.Add(objectTmp);
                    objectTmp.addCell(tutObjectTexture1);
                    objectTmp.addCell(tutObjectTexture2);
                    objectTmp.addCell(tutObjectTexture3);
                    objectTmp.addCell(tutObjectTexture4);
                    objectTmp.displayName = "Baseball";
                }
                else if (level == 1)
                {
                    ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), objectTexture1, "throwable1");
                    objectTmp.DropItemFont = dropItemFont;
                    throwObjects.Add(objectTmp);
                    objectTmp.addCell(objectTexture1);
                    objectTmp.addCell(objectTexture2);
                    objectTmp.addCell(objectTexture3);
                    objectTmp.addCell(objectTexture4);
                    objectTmp.displayName = "Textbook";
                }
                else if (level == 2)
                {
                    ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), objectTexture1, "throwable1");
                    objectTmp.DropItemFont = dropItemFont;
                    throwObjects.Add(objectTmp);
                    objectTmp.addCell(labObjectTexture1);
                    objectTmp.addCell(labObjectTexture2);
                    objectTmp.addCell(labObjectTexture3);
                    objectTmp.addCell(labObjectTexture4);
                    objectTmp.displayName = "Calculator";

                }
                else if (level == 3)
                {
                    ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), objectTexture1, "throwable1");
                    objectTmp.DropItemFont = dropItemFont;
                    throwObjects.Add(objectTmp);
                    objectTmp.addCell(objectTexture1);
                    objectTmp.addCell(objectTexture2);
                    objectTmp.addCell(objectTexture3);
                    objectTmp.addCell(objectTexture4);
                    objectTmp.displayName = "Textbook";
                    hud.LoadSprite("throwable1", bookMenu);
                }
                else if (level == 4)
                {
                    ThrowObjects objectTmp = new ThrowObjects(graphics.GraphicsDevice, new Vector2(tmpX, tmpY), objectTexture1, "throwable1");
                    objectTmp.DropItemFont = dropItemFont;
                    throwObjects.Add(objectTmp);
                    objectTmp.addCell(tutObjectTexture1);
                    objectTmp.addCell(tutObjectTexture2);
                    objectTmp.addCell(tutObjectTexture3);
                    objectTmp.addCell(tutObjectTexture4);
                    objectTmp.displayName = "Bassball";
                    hud.LoadSprite("throwable1", bookMenu);
                }
            }
        }

        public void levelEnded()
        {
            // drawSplash = 1;

            player.levelComplete = true;

            player.isIdle = true;
            enemies.removeNull();
            double grade = player.getHitpoints();
            String levelGrade = "";

            if (grade == 100)
            {
                levelGrade = "A+";
                drawSplash = 1;
            }
            else if (grade > 70)
            {
                levelGrade = "A";
                drawSplash = 2;
            }
            else if (grade > 50)
            {
                levelGrade = "B";
                drawSplash = 3;
            }
            else if (grade > 25)
            {
                levelGrade = "C";
                drawSplash = 4;
            }
            else
            {
                levelGrade = "D";
                drawSplash = 5;
            }

            if (newScoreIsBetter(levelGrade, levelScores[level]))
                levelScores[level] = levelGrade;

            if (level == 0)
            {
                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    InventoryHolder.tmpInventory[i].pickedUp = true;
                }
            }
        }

        public void bossFightEnded()
        {
            // drawSplash = 1;

            player.levelComplete = true;

            player.isIdle = true;
            enemies.removeNull();
            double grade = player.getHitpoints();
            String levelGrade = "";

            if (grade == 100)
            {
                levelGrade = "A+";
                //drawSplash = 1;
            }
            else if (grade > 70)
            {
                levelGrade = "A";
                //drawSplash = 2;
            }
            else if (grade > 50)
            {
                levelGrade = "B";
                //drawSplash = 3;
            }
            else if (grade > 25)
            {
                levelGrade = "C";
                //drawSplash = 4;
            }
            else
            {
                levelGrade = "D";
                //drawSplash = 5;
            }

            if (newScoreIsBetter(levelGrade, levelScores[level]))
                levelScores[level] = levelGrade;

            if (level == 0)
            {
                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    InventoryHolder.tmpInventory[i].pickedUp = true;
                }
            }
        }

        private bool newScoreIsBetter(String newScore, String oldScore)
        {
            if (oldScore == "X")
                return true;
            if (newScore == "A+")
                return true;
            if (newScore == oldScore)
                return false;
            else
            {
                if (newScore == "A")
                {
                    if (oldScore == "B" || oldScore == "C" || oldScore == "D" || oldScore == "F")
                        return true;
                    else
                        return false;
                }
                if (newScore == "B")
                {
                    if (oldScore == "C" || oldScore == "D" || oldScore == "F")
                        return true;
                    else
                        return false;
                }
                if (newScore == "C")
                {
                    if (oldScore == "D" || oldScore == "F")
                        return true;
                    else
                        return false;
                }
                if (newScore == "D")
                {

                    if (oldScore == "F")
                        return true;
                    else
                        return false;
                }    
            }
            return false;
        }

        public void removeNull()
        {
            for (int x = 0; x < enemies.getSize(); x++)
            {
                if (enemies.getAtIndex(x) != null && enemies.getAtIndex(x).dying && enemies.getAtIndex(x).position.X <= -300)
                {
                    enemies.enemies[x] = null;
                }
            }
        }

        public void checkPlayerDead()
        {
            if (player.getHitpoints() <= 0)
            {
                drawSplash = 6;
                levelScores[level] = "F";
                if (level == 0)
                    tutText.levelCompleted = true;

                player.playerDied = true;
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null)
                        enemies.getAtIndex(i).playerDied = true;
                }
            }
        }

        public void gotoLevel(int level)
        {
            BGExtras.teslaCoil = null;

            this.level = level;
            if (level == 0)
                loadTut();
            if (level == 1)
                loadLevel1();
            if (level == 2)
                loadLevel2();
            if (level == 3)
                loadLevel3();
            if (level == 4)
                loadBossFight();


            if (((level != 1 || level != 2 || level != 3 || level != 4) && player.weaponInventory.Count == 0) || level == 0)
            {
                isLoadingScreen = true;
                restartGame();
            }
            else
            {
                isLoadingScreen = false;
                restartGame();
                gotoCrafting();
            }
        }

        public void levelJump(int level)
        {
            BGExtras.teslaCoil = null;
            this.level = level;
            if (player.weaponInventory.Count == 0)
            {
                //Console.WriteLine("place11111111111111111111111");
                tutCraftScreen = -1;
                restartGame();
            }
            else
            {
                //Console.WriteLine("place222222222222222222222222");
                skip = true;
                tutCraftScreen = -1;
                player.levelComplete = true;
                player.isIdle = true;
                drawSplash = 0;
                crafting = true;
                int rowCount = 0;
                int colCount = 0;
                Console.WriteLine("InventorySizeHere:" + InventoryHolder.inventory.Count);
                for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                {
                    InventoryHolder.inventory[x].pickedUp = true;
                }


                //adding everything to inventory permenantly
                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    InventoryHolder.inventory.Add(InventoryHolder.tmpInventory[i]);
                }

                Console.WriteLine("InventorySizeHere1:" + InventoryHolder.inventory.Count);

                //clear tmpInventory
                InventoryHolder.tmpInventory = new List<DropItems>();

                Console.WriteLine("InventorySizeHere2:" + InventoryHolder.inventory.Count);

                List<DropItems> tmp1 = new List<DropItems>();


                for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                {
                    if (InventoryHolder.inventory[x].pickedUp)
                    {
                        tmp1.Add(InventoryHolder.inventory[x]);
                    }
                }

                Console.WriteLine("InventorySizeHere3:" + InventoryHolder.inventory.Count);
                InventoryHolder.inventory = tmp1;

                Console.WriteLine("InventorySizeHere4:" + InventoryHolder.inventory.Count);

                if (InventoryHolder.inventory.Count > 0)
                {
                    List<DropItems> tmp = new List<DropItems>();
                    tmp.Add(InventoryHolder.inventory[0]);
                    for (int x = 1; x < InventoryHolder.inventory.Count; x++)
                    {
                        bool found = false;

                        for (int y = 0; y < tmp.Count; y++)
                        {


                            if (InventoryHolder.inventory[x].name.Equals(tmp[y].name))
                            {
                                found = true;
                                tmp[y].amount++;
                                break;
                            }
                        }
                        if (!found)
                            tmp.Add(InventoryHolder.inventory[x]);
                    }

                    Console.WriteLine("InventorySizeHere5:" + InventoryHolder.inventory.Count);
                    InventoryHolder.inventory = tmp;

                    Console.WriteLine("InventorySizeHere6:" + InventoryHolder.inventory.Count);

                    //get everything ready for crafting
                    for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                    {
                        //Console.WriteLine(x);
                        Console.WriteLine("Item: " + InventoryHolder.inventory[x].amount);
                        craftingInventory[rowCount, colCount] = InventoryHolder.inventory[x];
                        colCount++;
                        if (colCount >= 4)
                        {
                            colCount = 0;
                            rowCount++;
                        }

                        if (rowCount >= 3)
                        {
                            break;
                        }
                    }

                }

                throwObjects = new List<ThrowObjects>();
                player.throwObjects = this.throwObjects;
                gameBG = new MultiBackground(graphics);

                if (level == 0)
                {
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);

                    gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 1"), 1, 200.0f);
                    gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 2"), 1, 200.0f);
                    gameBG.AddLayer(tutManager.Load<Texture2D>("Gym paralax 1"), 1, 200.0f);

                    gameBG.AddLayer(tutTexture1, 0, 200.0f);
                    gameBG.AddLayer(tutTexture2, 0, 200.0f);
                    gameBG.AddLayer(tutTexture1, 0, 200.0f);   //Not in use currently

                    //gameBG.SetLayerAlpha(0, 0f);

                    gameBG.tutLevel = true;
                    gameBG.lastLevel = false;
                }
                else if (level == 1)
                {
                    loadLevel1();

                    gameBG.AddLayer(trees1, 2.0f, 200.0f);
                    gameBG.AddLayer(trees1, 2.0f, 200.0f);
                    gameBG.AddLayer(trees1, 2.0f, 200.0f);

                    gameBG.AddLayer(trees2, 1.0f, 200.0f);
                    gameBG.AddLayer(trees2, 1.0f, 200.0f);
                    gameBG.AddLayer(trees2, 1.0f, 200.0f);

                    gameBG.AddLayer(bgTexture, 0.0f, 200.0f);
                    gameBG.AddLayer(bgTexture2, 0.0f, 200.0f);
                    gameBG.AddLayer(bgTexture, 0.0f, 200.0f);
                    gameBG.lastLevel = false;
                }
                else if (level == 2)
                {
                    loadLevel2();
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);

                    gameBG.AddLayer(trees2, 1, 200.0f);
                    gameBG.AddLayer(trees2, 1, 200.0f);
                    gameBG.AddLayer(trees2, 1, 200.0f);

                    gameBG.AddLayer(level2BG1, 0, 200.0f);
                    gameBG.AddLayer(level2BG2, 0, 200.0f);
                    gameBG.AddLayer(level2BG1, 0, 200.0f);
                    gameBG.lastLevel = false;
                }
                else if (level == 3)
                {
                    loadLevel3();
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);
                    gameBG.AddLayer(trees1, 2, 200.0f);

                    gameBG.AddLayer(trees2, 1, 200.0f);
                    gameBG.AddLayer(trees2, 1, 200.0f);
                    gameBG.AddLayer(trees2, 1, 200.0f);

                    gameBG.AddLayer(level3BG1, 0, 200.0f);
                    gameBG.AddLayer(level3BG2, 0, 200.0f);
                    gameBG.AddLayer(level3BG1, 0, 200.0f);
                    gameBG.lastLevel = false;
                }
                else if (level == 4)
                {
                    loadBossFight();
                    gameBG.AddLayer(bossTrees1, 2, 200.0f);
                    gameBG.AddLayer(bossTrees1, 2, 200.0f);
                    gameBG.AddLayer(bossTrees1, 2, 200.0f);

                    gameBG.AddLayer(bossTrees2, 1, 200.0f);
                    gameBG.AddLayer(bossTrees2, 1, 200.0f);
                    gameBG.AddLayer(bossTrees2, 1, 200.0f);

                    gameBG.AddLayer(bossFightBG, 0, 200.0f);
                    gameBG.AddLayer(bossFightBG, 0, 200.0f);
                    gameBG.AddLayer(bossFightBG, 0, 200.0f);
                    gameBG.lastLevel = true;
                }
            }
        }

        public void addItems()
        {

        }

        public void gotoCrafting()
        {
            if (level == 1)
            {
                BGExtras.spinningGlobe.someBounds.X = 3566;
                BGExtras.spinningGlobe.position = new Vector2(3566, 320);
                BGExtras.flashingMac.position = new Vector2(2470, 301);
            }
            else if (level == 2)
            {
                BGExtras.bunsenBurner.position = new Vector2(3566, 320);
                BGExtras.bunsenBurner.someBounds.X = 3566;
                BGExtras.floatingBrain.position = new Vector2(4510, 135);
                if (BGExtras.teslaCoil != null)
                    BGExtras.teslaCoil.position = new Vector2(3400f, 350.0f);

            }



            drawSplash = 0;
            crafting = true;
            int rowCount = 0;
            int colCount = 0;


            //clear tmpInventory
            InventoryHolder.tmpInventory = new List<DropItems>();
            for (int x = 0; x < InventoryHolder.inventory.Count; x++)
            {
                InventoryHolder.inventory[x].pickedUp = true;
            }


            List<DropItems> tmp1 = new List<DropItems>();
            for (int x = 0; x < InventoryHolder.inventory.Count; x++)
            {
                if (InventoryHolder.inventory[x].pickedUp)
                {
                    tmp1.Add(InventoryHolder.inventory[x]);
                }
            }

            InventoryHolder.inventory = tmp1;

            if (InventoryHolder.inventory.Count > 0)
            {
                List<DropItems> tmp = new List<DropItems>();
                tmp.Add(InventoryHolder.inventory[0]);
                for (int x = 1; x < InventoryHolder.inventory.Count; x++)
                {
                    bool found = false;
                    for (int y = 0; y < tmp.Count; y++)
                    {
                        if (InventoryHolder.inventory[x].name.Equals(tmp[y].name))
                        {
                            found = true;
                            tmp[y].amount++;
                            break;
                        }
                    }
                    if (!found)
                        tmp.Add(InventoryHolder.inventory[x]);
                }
                InventoryHolder.inventory = tmp;

                //get everything ready for crafting
                for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                {
                    //Console.WriteLine(x);
                    Console.WriteLine("Item: " + InventoryHolder.inventory[x].amount);
                    craftingInventory[rowCount, colCount] = InventoryHolder.inventory[x];
                    colCount++;
                    if (colCount >= 4)
                    {
                        colCount = 0;
                        rowCount++;
                    }

                    if (rowCount >= 3)
                    {
                        break;
                    }
                }

            }
        }

        public void restartPress(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.R) && !crafting)
            {
                
                BGExtras.teslaCoil = null;
                restartGame();
            }
            if (keyState.IsKeyDown(Keys.C) && drawSplash == 6 && !crafting && level != 0)
            {
                if (level == 4)
                {
                    BGExtras.teslaCoil = null;
                    generateCounter = 0;
                    fightStages = 0;
                }
                recraft = true;
                gotoCrafting();
            }

            if (keyState.IsKeyDown(Keys.Enter) && drawSplash != 6 && !crafting && player.levelComplete)
            {
                drawSplash = 0;
                crafting = true;
                int rowCount = 0;
                int colCount = 0;
                for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                {
                    InventoryHolder.inventory[x].pickedUp = true;
                }

                //adding everything to inventory permenantly
                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    InventoryHolder.inventory.Add(InventoryHolder.tmpInventory[i]);
                }

                //clear tmpInventory
                InventoryHolder.tmpInventory = new List<DropItems>();

                List<DropItems> tmp1 = new List<DropItems>();
                for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                {
                    if (InventoryHolder.inventory[x].pickedUp)
                    {
                        tmp1.Add(InventoryHolder.inventory[x]);
                    }
                }
                InventoryHolder.inventory = tmp1;

                if (InventoryHolder.inventory.Count > 0)
                {
                    List<DropItems> tmp = new List<DropItems>();
                    tmp.Add(InventoryHolder.inventory[0]);
                    for (int x = 1; x < InventoryHolder.inventory.Count; x++)
                    {
                        bool found = false;
                        for (int y = 0; y < tmp.Count; y++)
                        {
                            if (InventoryHolder.inventory[x].name.Equals(tmp[y].name))
                            {
                                found = true;
                                tmp[y].amount++;
                                break;
                            }
                        }
                        if (!found)
                            tmp.Add(InventoryHolder.inventory[x]);
                    }
                    InventoryHolder.inventory = tmp;

                    //get everything ready for crafting
                    for (int x = 0; x < InventoryHolder.inventory.Count; x++)
                    {
                        //Console.WriteLine(x);
                        Console.WriteLine("Item: " + InventoryHolder.inventory[x].amount);
                        craftingInventory[rowCount, colCount] = InventoryHolder.inventory[x];
                        colCount++;
                        if (colCount >= 4)
                        {
                            colCount = 0;
                            rowCount++;
                        }

                        if (rowCount >= 3)
                        {
                            break;
                        }
                    }

                }
            }
        }

        ////////////////
        int shakeCounter = 0;
        int shakeCounter2 = 5;
        bool shake = false;
        public void checkShake()
        {
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).type == "Strength")
                {
                    if (enemies.getAtIndex(i).dyingCounter == 65)
                        shake = true;

                    if (shake)
                    {
                        if (shakeCounter < 5)
                        {
                            shakeScreen(4);
                            shakeCounter++;
                        }
                        else if (shakeCounter > 0 && shakeCounter2 > 0)
                        {
                            shakeScreen(-4);
                            shakeCounter2--;
                        }
                        else if (shakeCounter2 == 0)
                        {
                            shake = false;
                            shakeCounter = 0;
                            shakeCounter2 = 5;
                        }
                    }
                }
            }

        }

        int count = 0; //So that 'Enter' doesn't trigger selection in crafting menu immediatley
        bool usability = false;
        int autoRemove = 1;
        public void craftingMenuUpdate()
        {
            KeyboardState keyState = Keyboard.GetState();
            
            if (keyState.IsKeyDown(Keys.Escape))
            {
                crafting = false;
                mainMenu = true;
                unloadAll();
            }
            if (count < 50)
                count++;

            if (!savedGame) //Save the inventory
            {
                savedGame = true;
                saveGame();
            }

            if (player.weaponInventory.Count > 0 || craftingInventory[0, 2] != null)    //Determine wether tut or not
            {
                if (tutCraftScreen == 2 || tutCraftScreen == 3 || tutCraftScreen == 4 || tutCraftScreen == 5)
                {
                }
                else
                {
                    tutCraftScreen = -1;
                }
            }


            if (tutCraftScreen == 0 && !keyState.IsKeyDown(Keys.Enter) && !keyState.IsKeyDown(Keys.A))    //First craft screen can't move around
                return;
            else if ((tutCraftScreen == 1 && row == 0 && col == 1 && keyState.IsKeyDown(Keys.Right)) || (tutCraftScreen == 1 && row == 0 && col == 0 && keyState.IsKeyDown(Keys.Left)) || (tutCraftScreen == 1 && keyState.IsKeyDown(Keys.Up)) || (tutCraftScreen == 1 && keyState.IsKeyDown(Keys.Down))) //Screen 2 constraints
                return;
            else if (tutCraftScreen == 2)
            {
                if ((col == 5 && keyState.IsKeyDown(Keys.Right)) || (col == 4 && keyState.IsKeyDown(Keys.Left)))
                    return;
                if (row > 1 && (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left)))
                    return;
                if ((row == 0 || row == 1) && keyState.IsKeyDown(Keys.Enter))
                    return;
            }

            if (tutCraftScreen == 1 && item1 != null && item2 != null)
            {
                row = 3;
                col = 4;
                ++tutCraftScreen;
                return;
            }
            else if (tutCraftScreen == 2 && player.getWeapons().Count > 0)
            {
                row = 3;
                col = 0;
                ++tutCraftScreen;
            }
            else if (tutCraftScreen == 3)
            {
                if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left))
                    return;
            }
            else if (tutCraftScreen == 4)
            {
                row = 3;
                col = 4;
                if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left))
                    return;
            }

            ///------Normal Checks

            if (keyState.IsKeyUp(Keys.Enter) && !keyState.IsKeyDown(Keys.A))
                isEnterUp = true;

            if (weaponScreenDraw && col < 4 && row != 3)
                weaponScreenDraw = false;

            //ENTER IS PRESSED
            if ((keyState.IsKeyDown(Keys.Enter) || keyState.IsKeyDown(Keys.A)) && isEnterUp && count >= 50)//select items to craft
            {
                isEnterUp = false;
                if (weaponScreenDraw && row == 2 && (col == 4 || col == 5))
                {
                    //craftedWeapon
                    if (Recipe.uncraftItems(player.getWeapons()[selectedWeaponColCrafting]) != null)
                    {
                        Console.WriteLine("NailBat uncraft basic");
                        DropItems[] tmpList;
                        tmpList = Recipe.uncraftItems(player.getWeapons()[selectedWeaponColCrafting]);

                        bool tmpFound = false;
                        bool tmpFound2 = false;
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (craftingInventory[x, y] != null && craftingInventory[x, y].name.Equals(tmpList[0].name))
                                {
                                    tmpFound = true;
                                    Console.WriteLine("NailBat uncraft1");
                                    craftingInventory[x, y].amount++;
                                    if (craftingInventory[x, y].displayInInventory == false)
                                    {
                                        craftingInventory[x, y].displayInInventory = true;
                                    }
                                    break;
                                }
                            }
                        }

                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (craftingInventory[x, y] != null && craftingInventory[x, y].name.Equals(tmpList[1].name))
                                {
                                    tmpFound2 = true;
                                    Console.WriteLine("NailBat uncraft2");
                                    craftingInventory[x, y].amount++;
                                    if (craftingInventory[x, y].displayInInventory == false)
                                    {
                                        craftingInventory[x, y].displayInInventory = true;
                                    }
                                    break;
                                }
                            }
                        }

                        if (!tmpFound)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                for (int y = 0; y < 4; y++)
                                {
                                    if (craftingInventory[x, y] == null && !tmpFound)
                                    {
                                        tmpFound = true;
                                        craftingInventory[x, y] = tmpList[0];
                                        craftingInventory[x, y].displayInInventory = true;
                                        craftingInventory[x, y].amount = 1;
                                        break;
                                    }
                                }
                            }
                        }

                        if (!tmpFound2)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                for (int y = 0; y < 4; y++)
                                {
                                    if (craftingInventory[x, y] == null && !tmpFound2)
                                    {
                                        tmpFound2 = true;
                                        craftingInventory[x, y] = tmpList[1];
                                        craftingInventory[x, y].displayInInventory = true;
                                        craftingInventory[x, y].amount = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        craftedWeapon = null;
                        weaponScreenDraw = false;
                        player.weaponInventory.RemoveAt(selectedWeaponColCrafting);

                    }
                }


                //TUT CHECKS
                Console.WriteLine("Crafting check here");
                if (tutCraftScreen == 0)
                {
                    ++tutCraftScreen;
                    return;
                }

                if (tutCraftScreen == 3)
                {
                    ++tutCraftScreen;
                }

                if (col < 4 && row < 3)
                {
                    if (craftingInventory[row, col] != null && craftingInventory[row, col].displayInInventory == true)    //Crafting slot is not empty
                    {
                        if (item1 == null)//check if slot 1 is open
                        {
                            item1 = new DropItems(craftingInventory[row, col]);
                            craftingInventory[row, col].amount--;
                            if (craftingInventory[row, col].amount < 1)
                                craftingInventory[row, col].displayInInventory = false;
                            autoRemove = 2;
                        }
                        else if (item2 == null)//check if slot 2 is open
                        {
                            item2 = new DropItems(craftingInventory[row, col]);
                            craftingInventory[row, col].amount--;
                            if (craftingInventory[row, col].amount < 1)
                                craftingInventory[row, col].displayInInventory = false;
                            autoRemove = 1;
                            //row = 3; col = 4;

                        }
                        else //automatically remove one item and add the new one
                        {
                            if (autoRemove == 1)
                            {
                                for (int x = 0; x < 3; x++)
                                {
                                    for (int y = 0; y < 4; y++)
                                    {
                                        if (item1 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item1.name))
                                        {
                                            craftingInventory[x, y].amount++;
                                            craftingInventory[x, y].displayInInventory = true;
                                            item1 = null;
                                            break;
                                        }
                                    }
                                }

                                item1 = new DropItems(craftingInventory[row, col]);
                                craftingInventory[row, col].amount--;
                                if (craftingInventory[row, col].amount < 1)
                                    craftingInventory[row, col].displayInInventory = false;
                                usability = false;
                                autoRemove = 2;
                            }
                            else if (autoRemove == 2)
                            {
                                for (int x = 0; x < 3; x++)
                                {
                                    for (int y = 0; y < 4; y++)
                                    {
                                        if (item2 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item2.name))
                                        {
                                            craftingInventory[x, y].amount++;
                                            craftingInventory[x, y].displayInInventory = true;
                                            item2 = null;
                                            break;
                                        }
                                    }
                                }

                                item2 = new DropItems(craftingInventory[row, col]);
                                craftingInventory[row, col].amount--;
                                if (craftingInventory[row, col].amount < 1)
                                    craftingInventory[row, col].displayInInventory = false;

                                usability = false;
                                autoRemove = 1;
                            }
                        }
                        //else slots are full
                    }
                }
                else if (col == 4 && (row == 0 || row == 1))
                {
                    if (item1 != null)  //Move item 1 back to inventory
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (item1 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item1.name))
                                {
                                    craftingInventory[x, y].amount++;
                                    craftingInventory[x, y].displayInInventory = true;
                                    item1 = null;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (col == 5 && (row == 0 || row == 1))
                {
                    if (item2 != null)  //Move item 2 back to inventory
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (item2 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item2.name))
                                {
                                    craftingInventory[x, y].amount++;
                                    craftingInventory[x, y].displayInInventory = true;
                                    item2 = null;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((row == 2 || row == 3) && (col == 4 || col == 5) && (item1 != null && item2 != null))
                {
                    if (craftedWeapon != null && player.addWeapon(craftedWeapon))   //CRAFT
                    {
                        item2 = null;
                        item1 = null;
                        col = player.weaponInventory.Count-1;
                        row = 3;
                    }
                }

                if (row == 3 && col > 3 && weaponScreenDraw)
                {
                    saveGame();
                    savedGame = false;
                    tutCraftScreen = -1;
                    //donePressed
                    
                    int tmpLevelPrev = level;
                    if (!skip && !viaMenu && !recraft)
                    {
                        if (level == 3)
                            level = 4;
                        if (level == 2)
                            level = 3;
                        if (level == 1)
                            level = 2;
                        else if (level == 0)
                            level = 1;
                    }

                    if (tmpLevelPrev == 0)
                    {
                        level = 1;
                    }
                    viaMenu = false;
                    skip = false;
                    recraft = false;
                    
                    restartGame();
                    player.specialWeapon = player.getWeapons()[selectedWeaponColCrafting];
                    player.weapon = player.specialWeapon;
                    player.playerAnimation = player.weapon.walkAnimation;
                    player.playerIdleAnimation = player.weapon.idelAnimation;
                    player.playerRecoilAnimation = player.weapon.recoilAnimation;
                    player.specialAttackAnimations = player.weapon.attackAnimations;
                    player.weaponBounds = player.weapon.weaponBounds;


                    InventoryHolder.inventory = new List<DropItems>();

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            if (craftingInventory[x, y] != null && (craftingInventory[x, y].displayInInventory == true || craftingInventory[x, y].amount > 0))
                            {
                                InventoryHolder.inventory.Add(craftingInventory[x, y]);
                            }

                            /* if (craftingInventory[x, y] != null && (craftingInventory[x, y].displayInInventory == false || craftingInventory[x, y].amount == 0))
                             {
                               
                                 Console.WriteLine("Found it3");
                                 craftingInventory[x, y] = null;
                             }*/
                        }
                    }

                    //activate loading screen
                    isLoadingScreen = true;

                }

                if ((row == 3 && col < 4) && (col < player.getWeapons().Count))
                {
                    //Get rid of half-crafted stuff
                    if (item1 != null)  //Move item 1 back to inventory
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (item1 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item1.name))
                                {
                                    craftingInventory[x, y].amount++;
                                    craftingInventory[x, y].displayInInventory = true;
                                    item1 = null;
                                    break;
                                }
                            }
                        }
                    }

                    if (item2 != null)  //Move item 2 back to inventory
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (item2 != null && craftingInventory[x, y] != null && (craftingInventory[x, y].name == item2.name))
                                {
                                    craftingInventory[x, y].amount++;
                                    craftingInventory[x, y].displayInInventory = true;
                                    item2 = null;
                                    break;
                                }
                            }
                        }
                    }
                    bothCraftingSlotsFull = false;
                    selectedWeaponColCrafting = col;
                    weaponScreenDraw = true;
                    row = 3; col = 4;
                }
                else
                    weaponScreenDraw = false;
            }

            //check if both item slots are full
            if (item1 != null && item2 != null)
            {
                //check if recipe exists 
                Weapon tmp = Recipe.checkRecipe(item1, item2);
                craftedWeapon = tmp;
                bothCraftingSlotsFull = true;
                if (tmp != null)
                {
                    //valid recipe
                    validCraftingRecipe = true;
                    if (!usability)
                    {
                        usability = true;
                        row = 3; col = 4;
                    }
                }
                else
                {
                    //invalid recipe
                    validCraftingRecipe = false;
                }
            }
            else
            {
                usability = false ;
                bothCraftingSlotsFull = false;
            }

           


            //Navigating, moving around
            if (keyState.IsKeyUp(Keys.Down) && keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Right) && keyState.IsKeyUp(Keys.Left))
                isArrowUp = true;
            if (keyState.IsKeyDown(Keys.Down) && isArrowUp)
            {
                isArrowUp = false;
                switch (row)
                {
                    case 0:
                        {
                            if (col > 3)
                                row = 2;
                            else
                                row = 1;
                        } break;
                    case 1: row = 2; break;
                    case 2:
                        {
                            if (weaponScreenDraw && col > 3)
                            {
                                row = 3;
                                col = 4;
                            }
                            else
                                if (col > 3)
                                    row = 0;
                                else
                                    row = 3;
                        } break;
                    case 3: if (weaponScreenDraw && col > 3)
                        {
                            row = 2;
                            col = 4;
                        }
                        else
                            row = 0;
                        break;
                }
            }
            else if (keyState.IsKeyDown(Keys.Up) && isArrowUp)
            {
                isArrowUp = false;
                switch (row)
                {
                    case 0: row = 3; break;
                    case 1:
                        {
                            if (col > 3)
                                row = 3;
                            else
                                row = 0;
                        } break;
                    case 2: if (weaponScreenDraw && col > 3)
                        {
                            row = 3;
                            col = 4;
                        }
                        else
                            row = 1;
                        break;
                    case 3:
                        {
                            if (weaponScreenDraw && col > 3)
                            {
                                row = 2;
                                col = 4;
                            }
                            else
                                if (col > 3)
                                    row = 1;
                                else
                                    row = 2;
                        } break;
                }
            }

            if (keyState.IsKeyDown(Keys.Right) && isArrowUp)
            {
                isArrowUp = false;
                switch (col)
                {
                    case 0: col = 1; break;
                    case 1: col = 2; break;
                    case 2: col = 3; break;
                    case 3: col = 4; break;
                    case 4:
                        {
                            if (row == 2 || row == 3)
                                col = 0;
                            else
                                col = 5;
                        } break;
                    case 5: col = 0; break;
                }
            }
            else if (keyState.IsKeyDown(Keys.Left) && isArrowUp)
            {
                isArrowUp = false;
                switch (col)
                {
                    case 0: col = 5; break;
                    case 1: col = 0; break;
                    case 2: col = 1; break;
                    case 3: col = 2; break;
                    case 4: col = 3; break;
                    case 5:
                        {
                            if (row == 2 || row == 3)
                                col = 3;
                            else
                                col = 4;
                        } break;
                }
            }
        }

        public void genericUpdates(GameTime gameTime)
        {

            hud.setProgressAmount(mapPosition);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyUp(Keys.D2) && keyState.IsKeyUp(Keys.D1) && keyState.IsKeyUp(Keys.D0) && keyState.IsKeyUp(Keys.D4) && keyState.IsKeyUp(Keys.D5))
            {
                jumpUp = false;
            }
            
            //Press 1 to skip to level 1
            if (keyState.IsKeyDown(Keys.D5) && keyState.IsKeyDown(Keys.L) && keyState.IsKeyDown(Keys.RightControl) && !jumpUp)
            {

                jumpUp = true;
                levelJump(4);
            }
            else if (keyState.IsKeyDown(Keys.D4) && keyState.IsKeyDown(Keys.L) && keyState.IsKeyDown(Keys.RightControl) && !jumpUp)
            {
                
                jumpUp = true;
                levelJump(3);
            }
            else if (keyState.IsKeyDown(Keys.D2) && keyState.IsKeyDown(Keys.L) && keyState.IsKeyDown(Keys.RightControl) && !jumpUp)
            {
                jumpUp = true;
                levelJump(2);
            }
            else if (keyState.IsKeyDown(Keys.D1) && keyState.IsKeyDown(Keys.L) && keyState.IsKeyDown(Keys.RightControl) && !jumpUp)
            {

                //restartGame();
                jumpUp = true;
                levelJump(1);
            }
            else if (keyState.IsKeyDown(Keys.D0) && keyState.IsKeyDown(Keys.L) && keyState.IsKeyDown(Keys.RightControl) && !jumpUp)
            {
                loadTut();
                //restartGame();
                jumpUp = true;
                levelJump(0);
            }

            finalBrawlAnimation.Update(gameTime);
            gameBG.Update(gameTime);
            BGExtras.allBloodSplashes.Update(gameTime);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            for (int i = 0; i < throwObjects.Count; i++)
            {
                throwObjects.ElementAt(i).Update(gameTime);
                if (throwObjects[i].alpha2 < 1.0f)
                {
                    throwObjects[i].alpha2 += 0.05f;
                }
            }

            enemyHud1 = null;
            double tmpMax = -1;
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null)
                {
                    if (enemies.getAtIndex(i).hudCount > tmpMax && enemies.getAtIndex(i).drawThumbNail && !enemies.getAtIndex(i).type.Equals("evilJP"))
                    {
                        tmpMax = enemies.getAtIndex(i).hudCount;
                        enemyHud1 = enemies.getAtIndex(i);
                    }
                }
            }

            enemyHud2 = null;
            tmpMax = -1;
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null)
                {
                    if (enemies.getAtIndex(i).hudCount > tmpMax && enemies.getAtIndex(i) != enemyHud1 && enemies.getAtIndex(i).drawThumbNail && !enemies.getAtIndex(i).type.Equals("evilJP"))
                    {
                        tmpMax = enemies.getAtIndex(i).hudCount;
                        enemyHud2 = enemies.getAtIndex(i);
                    }
                }
            }



            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
            {
                InventoryHolder.tmpInventory[i].Update(gameTime);
            }

            // TODO: Add your update logic here
            player.Update(gameTime);

            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null)
                    enemies.getAtIndex(i).Update(gameTime);
            }

            particleSystem.Update(totalTimeSpan, gameTime.ElapsedGameTime);
            particleSystem2.Update(totalTimeSpan, gameTime.ElapsedGameTime);
        }

        public void universalDraw()
        {
            spriteBatch.Begin();


            BGExtras.allBloodSplashes.Draw(spriteBatch);

            if (enemies.isAllDead())
            {
                // arrowAnimation.Draw(spriteBatch);
            }

            //not picked up yet
            for (int i = 0; i < throwObjects.Count; i++)
            {
                if (!throwObjects[i].pickedUp)
                    throwObjects[i].Draw(spriteBatch);
            }

            

            if (enemies.getSize() == 0)
                player.Draw(spriteBatch);
            else
            {
                int playerZIndex = enemies.orderEnemiesByPlacement(player.getPosition().Y);
                if (playerZIndex == enemies.getSize())
                    player.Draw(spriteBatch);
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).dead && enemies.getAtIndex(i).speed != 0 && !enemies.getAtIndex(i).type.Equals("evilJP"))
                        enemies.getAtIndex(i).Draw(spriteBatch);
                }


                //Draw Boss On top
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).dead && enemies.getAtIndex(i).speed != 0 && enemies.getAtIndex(i).type.Equals("evilJP"))
                        enemies.getAtIndex(i).Draw(spriteBatch);
                }


                //draw loot above dead enemies
                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    if (!InventoryHolder.tmpInventory[i].pickedUp)
                        InventoryHolder.tmpInventory[i].Draw(spriteBatch);
                }

                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).dying && (!enemies.getAtIndex(i).dead) && !enemies.getAtIndex(i).type.Equals("evilJP"))
                        enemies.getAtIndex(i).Draw(spriteBatch);
                }

                //Draw Boss On top
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).dying && (!enemies.getAtIndex(i).dead) && enemies.getAtIndex(i).type.Equals("evilJP"))
                        enemies.getAtIndex(i).Draw(spriteBatch);
                }
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (playerZIndex == i)
                    {
                        player.Draw(spriteBatch);
                        if (!enemies.getAtIndex(i).dying || enemies.getAtIndex(i).speed == 0)
                            enemies.getAtIndex(i).Draw(spriteBatch);
                    }
                    else if (enemies.getAtIndex(i) != null && (!enemies.getAtIndex(i).dying || enemies.getAtIndex(i).speed == 0))
                        enemies.getAtIndex(i).Draw(spriteBatch);
                }
                if (playerZIndex == enemies.getSize())
                    player.Draw(spriteBatch);
            }

            //picked up
            for (int i = 0; i < throwObjects.Count; i++)
            {
                if (throwObjects[i].pickedUp)
                    throwObjects[i].Draw(spriteBatch);
            }

            if (BGExtras.teslaCoil != null && (level == 2 || level == 4 || level == 3))
                BGExtras.teslaCoil.Draw(spriteBatch);

            //particle system
            particleSystem.Draw(spriteBatch);
            particleSystem2.Draw(spriteBatch);

            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
            {
                if (InventoryHolder.tmpInventory[i].pickedUp)
                    InventoryHolder.tmpInventory[i].Draw(spriteBatch);
            }


            //Draw Enemy HUD
            if (enemyHud2 != null && enemyHud1 != null && enemyHud1.drawThumbNail && enemyHud2.drawThumbNail)
            {
                spriteBatch.Draw(twoEnemyHUD, new Vector2(0, 0), Color.White);

                spriteBatch.Draw(enemyHud1.thumbnail, new Vector2(1112, 35), Color.White);

                int width = (int)((enemyHud1.getHitpoints() / enemyHud1.getMaxHitPoints()) * 141);
                Rectangle drawHere = new Rectangle(1099, 168, width, 12);
                spriteBatch.Draw(blankHealthBar, new Vector2(1099, 168), Color.White);
                spriteBatch.Draw(enemyHealthBar, drawHere, Color.White);

                spriteBatch.Draw(enemyHud2.thumbnail, new Vector2(1288, 35), Color.White);
                width = (int)((enemyHud2.getHitpoints() / enemyHud2.getMaxHitPoints()) * 141);
                drawHere = new Rectangle(1275, 168, width, 12);
                spriteBatch.Draw(blankHealthBar, new Vector2(1275, 168), Color.White);
                spriteBatch.Draw(enemyHealthBar, drawHere, Color.White);
            }
            else if ((enemyHud2 == null || (enemyHud2 != null && !enemyHud2.drawThumbNail)) && (enemyHud1 != null && enemyHud1.drawThumbNail))
            {
                spriteBatch.Draw(oneEnemyHUD, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(enemyHud1.thumbnail, new Vector2(1288, 35), Color.White);
                int width = (int)((enemyHud1.getHitpoints() / enemyHud1.getMaxHitPoints()) * 141);
                Rectangle drawHere = new Rectangle(1275, 168, width, 12);
                spriteBatch.Draw(blankHealthBar, new Vector2(1275, 168), Color.White);
                spriteBatch.Draw(enemyHealthBar, drawHere, Color.White);
            }


            spriteBatch.End();
            hud.Draw();

            spriteBatch.Begin();
            if (!crafting)
                switch (drawSplash)
                {
                    case 1: spriteBatch.Draw(levelCompleteAPlus, new Vector2(0, 0), Color.White); break;
                    case 2: spriteBatch.Draw(levelCompleteA, new Vector2(0, 0), Color.White); break;
                    case 3: spriteBatch.Draw(levelCompleteB, new Vector2(0, 0), Color.White); break;
                    case 4: spriteBatch.Draw(levelCompleteC, new Vector2(0, 0), Color.White); break;
                    case 5: spriteBatch.Draw(levelCompleteD, new Vector2(0, 0), Color.White); break;
                    case 6: spriteBatch.Draw(levelFailed, new Vector2(0, 0), Color.White); break;
                }

            if (drawBrawlAlpha > 0 && (drawBrawlDown))
            {
                Color myColor = Color.White * drawBrawlAlpha;
                finalBrawlAnimation.Draw(spriteBatch, drawBrawlAlpha);
            }

            spriteBatch.End();
        }

        public void craftingMenuDraw()
        {
            spriteBatch.Begin();
            if (!weaponScreenDraw)
                spriteBatch.Draw(emptyCrafting, new Vector2(0, 0), Color.White);    //Draw the default screen
            else
            {
                spriteBatch.Draw(emptyCrafting2, new Vector2(0, 0), Color.White);    //Draw the weapon-specific screen
                Rectangle drawHere = new Rectangle(992, 190, 175, 175);
                spriteBatch.Draw(player.getWeapons()[selectedWeaponColCrafting].icon, drawHere, Color.White);
                drawHere = new Rectangle(855, 390, 472, 187);
                if (level != 0)
                    spriteBatch.Draw(player.getWeapons()[selectedWeaponColCrafting].info, drawHere, Color.White);   //Draw the info screen
            }

            if (bothCraftingSlotsFull)
            {
                if (validCraftingRecipe)
                    spriteBatch.Draw(craftedWeapon.silhouette, new Vector2(999, 434), Color.White);
                else
                    spriteBatch.Draw(invalidCombo, new Vector2(999, 434), Color.White);
            }

            if (row == 0)
            {
                switch (col)
                {
                    case 0: spriteBatch.Draw(selectedBlank, new Vector2(62, 124), Color.White); break;
                    case 1: spriteBatch.Draw(selectedBlank, new Vector2(217, 124), Color.White); break;
                    case 2: spriteBatch.Draw(selectedBlank, new Vector2(375, 124), Color.White); break;
                    case 3: spriteBatch.Draw(selectedBlank, new Vector2(532, 124), Color.White); break;
                    case 4: if (!weaponScreenDraw) spriteBatch.Draw(emptyCraftingItem, new Vector2(842, 148), Color.White); break; //Crafting Item 1
                    case 5: if (!weaponScreenDraw) spriteBatch.Draw(emptyCraftingItem, new Vector2(1124, 148), Color.White); break; //Crafting Item 1
                }
            }
            else if (row == 1)
            {
                switch (col)
                {
                    case 0: spriteBatch.Draw(selectedBlank, new Vector2(62, 280), Color.White); break;
                    case 1: spriteBatch.Draw(selectedBlank, new Vector2(217, 280), Color.White); break;
                    case 2: spriteBatch.Draw(selectedBlank, new Vector2(375, 280), Color.White); break;
                    case 3: spriteBatch.Draw(selectedBlank, new Vector2(532, 280), Color.White); break;
                    case 4: if (!weaponScreenDraw) spriteBatch.Draw(emptyCraftingItem, new Vector2(842, 148), Color.White); break; //Crafting Item 1
                    case 5: if (!weaponScreenDraw) spriteBatch.Draw(emptyCraftingItem, new Vector2(1124, 148), Color.White); break; //Crafting Item 1
                }
            }
            else if (row == 2)
            {
                switch (col)
                {
                    case 0: spriteBatch.Draw(selectedBlank, new Vector2(62, 434), Color.White); break;
                    case 1: spriteBatch.Draw(selectedBlank, new Vector2(217, 434), Color.White); break;
                    case 2: spriteBatch.Draw(selectedBlank, new Vector2(375, 434), Color.White); break;
                    case 3: spriteBatch.Draw(selectedBlank, new Vector2(532, 434), Color.White); break;
                    case 4: if (!weaponScreenDraw) spriteBatch.Draw(craftBtnHover, new Vector2(879, 680), Color.White); else spriteBatch.Draw(UNcraftBtnHover, new Vector2(892, 602), Color.White); break;
                    case 5: if (!weaponScreenDraw) spriteBatch.Draw(craftBtnHover, new Vector2(879, 680), Color.White); else spriteBatch.Draw(UNcraftBtnHover, new Vector2(892, 602), Color.White); break;
                }
            }
            else if (row == 3)
            {
                switch (col)
                {
                    case 0: spriteBatch.Draw(selectedBlank, new Vector2(62, 718), Color.White); break;
                    case 1: spriteBatch.Draw(selectedBlank, new Vector2(217, 718), Color.White); break;
                    case 2: spriteBatch.Draw(selectedBlank, new Vector2(375, 718), Color.White); break;
                    case 3: spriteBatch.Draw(selectedBlank, new Vector2(532, 718), Color.White); break;
                    case 4: if (!weaponScreenDraw) spriteBatch.Draw(craftBtnHover, new Vector2(879, 680), Color.White); else spriteBatch.Draw(doneBtnHover, new Vector2(892, 728), Color.White); break;
                    case 5: if (!weaponScreenDraw) spriteBatch.Draw(craftBtnHover, new Vector2(879, 680), Color.White); else spriteBatch.Draw(doneBtnHover, new Vector2(892, 728), Color.White); break;
                }
            }

            int validItems = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (craftingInventory[x, y] != null)
                        validItems++;
                }
            }

            DropItems[] tmp = new DropItems[validItems];
            int tmpCounter = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (craftingInventory[x, y] != null)
                        tmp[tmpCounter++] = craftingInventory[x, y];
                }
            }

            for (int x = 0; x < tmpCounter; x++)
            {
                for (int y = x; y < tmpCounter; y++)
                {
                    if (tmp[y].displayInInventory && !tmp[x].displayInInventory)
                    {
                        DropItems tmpDrop = new DropItems(tmp[x]);
                        tmp[x] = new DropItems(tmp[y]);
                        tmp[y] = new DropItems(tmpDrop);
                    }
                }
            }

            int rowCount1 = 0;
            int colCount1 = 0;
            for (int x = 0; x < tmpCounter; x++)
            {
                craftingInventory[rowCount1, colCount1] = new DropItems(tmp[x]);
                colCount1++;
                if (colCount1 >= 4)
                {
                    colCount1 = 0;
                    rowCount1++;
                }
                if (rowCount1 >= 3)
                    break;
            }

            if (item1 != null)
            {
                Rectangle drawHere = new Rectangle(845, 150, 174, 174);
                spriteBatch.Draw(item1.craftingMenuSprite, drawHere, Color.White);
            }
            if (item2 != null)
            {
                Rectangle drawHere = new Rectangle(1125, 150, 174, 174);
                spriteBatch.Draw(item2.craftingMenuSprite, drawHere, Color.White);
            }

            //DRAW WEAPONS
            for (int i = 0; i < player.getWeapons().Count; i++)
            {
                if (player.getWeapons()[i] == null)
                {
                    //spriteBatch.End();
                    //return;
                }

                switch (i)
                {
                    case 0:
                        {
                            Rectangle drawHere = new Rectangle(79, 734, 122, 122);
                            if (player.getWeapons()[i] != null)
                                spriteBatch.Draw(player.getWeapons()[i].icon, drawHere, Color.White);
                        } break;
                    case 1:
                        {
                            Rectangle drawHere = new Rectangle(235, 734, 122, 122);
                            if (player.getWeapons()[i] != null)
                                spriteBatch.Draw(player.getWeapons()[i].icon, drawHere, Color.White);
                        } break;//233,722 break;
                    case 2:
                        {
                            Rectangle drawHere = new Rectangle(392, 734, 122, 122);
                            if (player.getWeapons()[i] != null)
                                spriteBatch.Draw(player.getWeapons()[i].icon, drawHere, Color.White);
                        } break;//390,722 break;
                    case 3:
                        {
                            Rectangle drawHere = new Rectangle(550, 734, 122, 122);
                            if (player.getWeapons()[i] != null)
                                spriteBatch.Draw(player.getWeapons()[i].icon, drawHere, Color.White);
                        } break;//548,722 break;
                }
            }


            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (craftingInventory[x, y] != null && craftingInventory[x, y].displayInInventory)
                    {
                        if (x == 0)
                        {
                            switch (y)
                            {
                                case 0:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(62, 124), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(62, 124), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(186, 245), Color.White);
                                    } break;
                                case 1:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(217, 124), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(217, 124), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(217 + 124, 245), Color.White);
                                    } break;
                                case 2:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(375, 124), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(375, 124), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(375 + 124, 245), Color.White);
                                    } break;
                                case 3:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(532, 124), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(532, 124), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(532 + 124, 245), Color.White);
                                    } break;
                            }
                        }
                        else if (x == 1)
                        {
                            switch (y)
                            {
                                case 0:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(62, 280), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(62, 280), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(62 + 124, 404), Color.White);
                                    } break;
                                case 1:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(217, 280), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(217, 280), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(217 + 124, 404), Color.White);
                                    } break;
                                case 2:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(375, 280), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(375, 280), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(375 + 124, 404), Color.White);
                                    } break;
                                case 3:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(532, 280), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(532, 280), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(532 + 124, 404), Color.White);
                                    } break;
                            }
                        }
                        else if (x == 2)
                        {
                            switch (y)
                            {
                                case 0:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(62, 434), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(62, 434), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(62 + 126, 556), Color.White);
                                    } break;
                                case 1:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(217, 434), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(217, 434), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(217 + 126, 556), Color.White);
                                    } break;
                                case 2:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(375, 434), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(375, 434), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(375 + 126, 556), Color.White);
                                    } break;
                                case 3:
                                    {
                                        spriteBatch.Draw(craftingInventory[x, y].craftingMenuSprite, new Vector2(532, 434), Color.White);
                                        spriteBatch.Draw(itemTotalHolder, new Vector2(532, 434), Color.White);
                                        spriteBatch.DrawString(craftingInventory[x, y].DropItemFont, ("" + craftingInventory[x, y].amount), new Vector2(532 + 126, 556), Color.White);
                                    } break;
                            }
                        }
                    }
                    //else
                    //Console.Write("0\t");
                }
                //Console.WriteLine();
            } //Console.WriteLine();

            if (row < 3 && col < 4 && craftingInventory[row, col] != null && craftingInventory[row, col].displayInInventory)
            {
                if (row == 0)
                {
                    switch (col)
                    {
                        case 0: spriteBatch.Draw(selectedItemHolder, new Vector2(62, 124), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(186, 245), Color.White); break;
                        case 1: spriteBatch.Draw(selectedItemHolder, new Vector2(217, 124), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(217 + 124, 245), Color.White); break;
                        case 2: spriteBatch.Draw(selectedItemHolder, new Vector2(375, 124), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(375 + 124, 245), Color.White); break;
                        case 3: spriteBatch.Draw(selectedItemHolder, new Vector2(532, 124), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(532 + 124, 245), Color.White); break;
                    }
                }
                else if (row == 1)
                {
                    switch (col)
                    {
                        case 0: spriteBatch.Draw(selectedItemHolder, new Vector2(62, 280), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(62 + 124, 404), Color.White); break;
                        case 1: spriteBatch.Draw(selectedItemHolder, new Vector2(217, 280), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(217 + 124, 404), Color.White); break;
                        case 2: spriteBatch.Draw(selectedItemHolder, new Vector2(375, 280), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(375 + 124, 404), Color.White); break;
                        case 3: spriteBatch.Draw(selectedItemHolder, new Vector2(532, 280), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(532 + 124, 404), Color.White); break;
                    }
                }
                else if (row == 2)
                {
                    switch (col)
                    {
                        case 0: spriteBatch.Draw(selectedItemHolder, new Vector2(62, 434), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(62 + 126, 556), Color.White); break;
                        case 1: spriteBatch.Draw(selectedItemHolder, new Vector2(217, 434), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(217 + 126, 556), Color.White); break;
                        case 2: spriteBatch.Draw(selectedItemHolder, new Vector2(375, 434), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(375 + 126, 556), Color.White); break;
                        case 3: spriteBatch.Draw(selectedItemHolder, new Vector2(532, 434), Color.White); spriteBatch.DrawString(craftingInventory[row, col].DropItemFont, ("" + craftingInventory[row, col].amount), new Vector2(532 + 126, 556), Color.White); break;
                    }
                }
            }


            if (tutCraftScreen >= 0 && tutCraftScreen < 6)
            {   //Tutorial for crafting
                spriteBatch.Draw(craftingTutScreens[tutCraftScreen], new Vector2(0, 0), Color.White);
            }

            spriteBatch.End();
        }

        public void mainMenuUpdate(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (mainMenuToDraw != null)
                mainMenuToDraw.Update(gameTime);

            if (selectorMenuToDraw != null)
            {

                selectorMenuToDraw.Update(gameTime);
            }

            if (keyState.IsKeyDown(Keys.Escape) && checkKeyUp && levelSelect)
                levelSelect = false;

            if (keyState.IsKeyDown(Keys.Escape) && checkKeyUp && optionsSelect)
                optionsSelect = false;

            if (keyState.IsKeyDown(Keys.Escape) && checkKeyUp && helpScreen)
                helpScreen = false;

            if (keyState.IsKeyUp(Keys.Enter))
                checkKeyUp = true;


            if (keyState.IsKeyDown(Keys.Enter) && checkKeyUp && !optionsSelect && !helpScreen)
            {
                if (mainMenuRow == 3 && !levelSelect && !optionsSelect && !helpScreen)
                {
                    helpScreen = true;
                }
                else
                    if (mainMenuRow == 4 && !levelSelect && !optionsSelect)
                    {
                        Exit();
                    }
                    else if (mainMenuRow == 1 && !levelSelect && !optionsSelect)
                    {
                        levelSelect = true;
                    }
                    else if (mainMenuRow == 2 && !levelSelect && !optionsSelect)
                    {
                        optionsSelect = true;
                    }
                    else if (levelSelect)
                    {
                        if (levelUnlocked[currentMenuLevel])
                        {
                            levelSelect = false;
                            mainMenu = false;
                            paused = false;
                            if (level != 0)
                                viaMenu = true;
                            if (currentMenuLevel != 0)
                            {
                                isLoadingScreen = false;
                                levelJump(currentMenuLevel);
                            }
                            else
                                gotoLevel(currentMenuLevel);
                        }
                    }
                checkKeyUp = false;

            }


            if (keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down) && keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right))
                isArrowUp = true;

            if (!levelSelect && !optionsSelect && !helpScreen)
            {
                if (keyState.IsKeyDown(Keys.Down) && isArrowUp)
                {
                    //down
                    isArrowUp = false;
                    if (mainMenuRow == 1)
                    {
                        mainMenuRow = 2;
                        mainMenuToDraw = downMenu;
                        mainMenuToDraw.position = new Vector2(430, 288);
                        mainMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuRow == 2)
                    {
                        mainMenuRow = 3;
                        mainMenuToDraw = downMenu;
                        mainMenuToDraw.position = new Vector2(430, 399);
                        mainMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuRow == 3)
                    {
                        mainMenuRow = 4;
                        mainMenuToDraw = downMenu;
                        mainMenuToDraw.position = new Vector2(430, 510);
                        mainMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuRow == 4)
                    {
                        mainMenuToDraw = jumpUpMenu;
                        mainMenuToDraw.position = new Vector2(430, 288);
                        mainMenuToDraw.PlayAll(0.1f);
                        mainMenuRow = 1;
                    }

                    Console.WriteLine("MenuRow:" + mainMenuRow);
                }
                else if (keyState.IsKeyDown(Keys.Up) && isArrowUp)
                {
                    //up
                    isArrowUp = false;
                    if (mainMenuRow == 1)
                    {
                        mainMenuRow = 4;
                        mainMenuToDraw = jumpDownMenu;
                        mainMenuToDraw.position = new Vector2(430, 288);
                        mainMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuRow == 2)
                    {
                        mainMenuRow = 1;
                        mainMenuToDraw = upMenu;
                        mainMenuToDraw.position = new Vector2(430, 288);
                        mainMenuToDraw.PlayAll(0.1f);

                    }
                    else if (mainMenuRow == 3)
                    {
                        mainMenuRow = 2;
                        mainMenuToDraw = upMenu;
                        mainMenuToDraw.position = new Vector2(430, 399);
                        mainMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuRow == 4)
                    {
                        mainMenuRow = 3;
                        mainMenuToDraw = upMenu;
                        mainMenuToDraw.position = new Vector2(430, 510);
                        mainMenuToDraw.PlayAll(0.1f);
                    }

                    Console.WriteLine("MenuRow:" + mainMenuRow);
                }
            }
            else if (levelSelect)
            {
                if (keyState.IsKeyDown(Keys.Right) && isArrowUp)
                {
                    isArrowUp = false;
                    if (currentMenuLevel == 0)
                        currentMenuLevel = 1;
                    else if (currentMenuLevel == 1)
                        currentMenuLevel = 2;
                    else if (currentMenuLevel == 2)
                        currentMenuLevel = 3;
                    else if (currentMenuLevel == 3)
                        currentMenuLevel = 4;
                    else if (currentMenuLevel == 4)
                        currentMenuLevel = 0;


                    Console.WriteLine("MenuLevel: " + currentMenuLevel);
                }
                else if (keyState.IsKeyDown(Keys.Left) && isArrowUp)
                {
                    isArrowUp = false;
                    if (currentMenuLevel == 0)
                        currentMenuLevel = 4;
                    else if (currentMenuLevel == 1)
                        currentMenuLevel = 0;
                    else if (currentMenuLevel == 2)
                        currentMenuLevel = 1;
                    else if (currentMenuLevel == 3)
                        currentMenuLevel = 2;
                    else if (currentMenuLevel == 4)
                        currentMenuLevel = 3;
                    Console.WriteLine("MenuLevel: " + currentMenuLevel);
                }

            }
            else if (optionsSelect)
            {
                if (keyState.IsKeyDown(Keys.Enter) && checkKeyUp && mainMenuOptionsUpDown == 0)
                {
                    checkKeyUp = false;

                    if (graphics.IsFullScreen)
                        graphics.IsFullScreen = false;
                    else
                        graphics.IsFullScreen = true;
                    graphics.ApplyChanges();

                }
                else if (keyState.IsKeyDown(Keys.Down) && isArrowUp)
                {
                    isArrowUp = false;
                    if (mainMenuOptionsUpDown == 0)
                    {
                        mainMenuOptionsUpDown = 1;
                        selectorMenuToDraw = selectorDownMenu;
                        selectorMenuToDraw.position = new Vector2(91, 228);
                        selectorMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuOptionsUpDown == 1)
                    {
                        mainMenuOptionsUpDown = 2;
                        selectorMenuToDraw = selectorDownMenu;
                        selectorMenuToDraw.position = new Vector2(91, 404);
                        selectorMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuOptionsUpDown == 2)
                    {
                        mainMenuOptionsUpDown = 0;
                        selectorMenuToDraw = selectorJumpUpMenu;
                        selectorMenuToDraw.position = new Vector2(91, 228);
                        selectorMenuToDraw.PlayAll(0.1f);

                    }

                    Console.WriteLine("OptionsRow:" + mainMenuOptionsUpDown);
                }
                else if (keyState.IsKeyDown(Keys.Up) && isArrowUp)
                {
                    isArrowUp = false;
                    if (mainMenuOptionsUpDown == 0)
                    {
                        mainMenuOptionsUpDown = 2;
                        selectorMenuToDraw = selectorJumpDownMenu;
                        selectorMenuToDraw.position = new Vector2(91, 242);
                        selectorMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuOptionsUpDown == 1)
                    {
                        mainMenuOptionsUpDown = 0;
                        selectorMenuToDraw = selectorUpMenu;
                        selectorMenuToDraw.position = new Vector2(91, 228);
                        selectorMenuToDraw.PlayAll(0.1f);
                    }
                    else if (mainMenuOptionsUpDown == 2)
                    {
                        mainMenuOptionsUpDown = 1;
                        selectorMenuToDraw = selectorUpMenu;
                        selectorMenuToDraw.position = new Vector2(91, 404);
                        selectorMenuToDraw.PlayAll(0.1f);
                    }

                    Console.WriteLine("OptionsRow:" + mainMenuOptionsUpDown);
                }
                else if ((keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left)) && isArrowUp && mainMenuOptionsUpDown == 0)
                {
                    isArrowUp = false;

                    if (graphics.IsFullScreen)
                        graphics.IsFullScreen = false;
                    else
                        graphics.IsFullScreen = true;
                    graphics.ApplyChanges();

                }
                else if (keyState.IsKeyDown(Keys.Right) && mainMenuOptionsUpDown == 1 && isArrowUp)
                {
                    isArrowUp = false;
                    Console.WriteLine("VolumeChange:" + defaultVolume);
                    defaultVolume = MathHelper.Clamp(defaultVolume + 0.1f, 0.0f, 2.0f);
                    audioEngine.GetCategory("Music").SetVolume(defaultVolume);

                }
                else if (keyState.IsKeyDown(Keys.Left) && mainMenuOptionsUpDown == 1 && isArrowUp)
                {
                    isArrowUp = false;
                    Console.WriteLine("VolumeChange:" + defaultVolume);
                    defaultVolume = MathHelper.Clamp(defaultVolume - 0.1f, 0.0f, 2.0f);
                    audioEngine.GetCategory("Music").SetVolume(defaultVolume);

                }
                else if (keyState.IsKeyDown(Keys.Right) && mainMenuOptionsUpDown == 2 && isArrowUp)
                {
                    isArrowUp = false;
                    Console.WriteLine("SoundEffects:" + effectsVolume);
                    effectsVolume = MathHelper.Clamp(effectsVolume + 0.1f, 0.0f, 2.0f);
                    audioEngine.GetCategory("SoundEffects").SetVolume(effectsVolume);

                    soundBank.PlayCue("Pickup");
                }
                else if (keyState.IsKeyDown(Keys.Left) && mainMenuOptionsUpDown == 2 && isArrowUp)
                {
                    isArrowUp = false;
                    Console.WriteLine("SoundEffects:" + effectsVolume);
                    effectsVolume = MathHelper.Clamp(effectsVolume - 0.1f, 0.0f, 2.0f);
                    audioEngine.GetCategory("SoundEffects").SetVolume(effectsVolume);

                    soundBank.PlayCue("Pickup");
                }


            }
            else if (helpScreen)
            {

            }


        }

        public void mainMenuDraw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (mainMenu)
            {
                if (optionsSelect)
                {

                    spriteBatch.Draw(mainMenuSettingsTexture, new Vector2(0, 0), Color.White);


                    /*if (mainMenuOptionsUpDown == 0)
                        spriteBatch.Draw(mainMenuOptionsSelectorTexture, new Vector2(151,268 ), Color.White);
                    if (mainMenuOptionsUpDown == 1)
                         spriteBatch.Draw(mainMenuOptionsSelectorTexture, new Vector2(151,450 ), Color.White);   
                    if (mainMenuOptionsUpDown == 2)
                        spriteBatch.Draw(mainMenuOptionsSelectorTexture, new Vector2(151, 600), Color.White);*/

                    if (!graphics.IsFullScreen)
                        spriteBatch.Draw(mainMenuWindowedTexture, new Vector2(745, 316), Color.White);
                    else
                        spriteBatch.Draw(mainMenuFullScreenTexture, new Vector2(745, 316), Color.White);

                    float tmpEffects = effectsVolume / 2.0f;
                    float tmpMusic = defaultVolume / 2.0f;

                    tmpEffects *= 427;
                    tmpMusic *= 427;

                    tmpEffects += 747;
                    tmpMusic += 747;

                    spriteBatch.Draw(mainMenuVolumeSliderMusicTexture, new Vector2(tmpMusic, 476), Color.White);
                    spriteBatch.Draw(mainMenuVolumeSliderEffectsTexture, new Vector2(tmpEffects, 646), Color.White);

                    if (selectorMenuToDraw != null)
                    {
                        selectorMenuToDraw.Draw(spriteBatch);
                    }
                }
                else if (levelSelect)
                {
                    if (levelUnlocked[currentMenuLevel])
                    {
                        spriteBatch.Draw(levelMenuTextures[currentMenuLevel], new Vector2(0, 0), Color.White);
                        
                        if (levelScores[currentMenuLevel] != "X")
                        {
                            switch (levelScores[currentMenuLevel])
                            {
                                case "A+": spriteBatch.Draw(scoreImages[0], new Vector2(0, 0), Color.White); break;
                                case "A": spriteBatch.Draw(scoreImages[1], new Vector2(0, 0), Color.White); break;
                                case "B": spriteBatch.Draw(scoreImages[2], new Vector2(0, 0), Color.White); break;
                                case "C": spriteBatch.Draw(scoreImages[3], new Vector2(0, 0), Color.White); break;
                                case "D": spriteBatch.Draw(scoreImages[4], new Vector2(0, 0), Color.White); break;
                                case "F": spriteBatch.Draw(scoreImages[5], new Vector2(0, 0), Color.White); break;
                            }

                        }
                    }
                    else
                    {
                        spriteBatch.Draw(levelMenuTextures[currentMenuLevel], new Vector2(0, 0), Color.White);
                        spriteBatch.Draw(levelLockedScreen, new Vector2(424, 308), Color.White);

                    }
                }
                else if (helpScreen)
                {
                    spriteBatch.Draw(helpScreenTexture, new Vector2(0, 0), Color.White);

                }
                else
                {
                    spriteBatch.Draw(baseMainMenu, new Vector2(0, 0), Color.White);
                    if (mainMenuToDraw != null)
                        mainMenuToDraw.Draw(spriteBatch);
                    /*if (mainMenuRow == 1)
                        spriteBatch.Draw(playHover, new Vector2(789, 357), Color.White);
                    else if (mainMenuRow == 2)
                        spriteBatch.Draw(optionsHover, new Vector2(789, 467), Color.White);
                    else if (mainMenuRow == 3)
                        spriteBatch.Draw(helpHover, new Vector2(789, 577), Color.White);
                    else if (mainMenuRow == 4)
                        spriteBatch.Draw(exitHover, new Vector2(789, 687), Color.White);*/

                    //idlingAnimationMainMenu.Draw(spriteBatch);
                }
            }

            spriteBatch.End();
        }

        protected override void Draw(GameTime gameTime)
        {
            virtualScreen.BeginCapture();

            if (mainMenu)
            {
                mainMenuDraw(gameTime);
            }
            else
            {
                
                switch (level)
                {
                    case 0: loadingScreenTexture = gymLoadingScreen;
                        tutDraw(gameTime); break;
                    case 1: loadingScreenTexture = classLoadingScreen;
                        level1Draw(gameTime); break;
                    case 2: loadingScreenTexture = scienceLoading;
                        level2Draw(gameTime); break;
                    case 3: loadingScreenTexture = cafLoading;
                        level3Draw(gameTime); break;
                    case 4: loadingScreenTexture = bossLoading;
                        bossFightDraw(gameTime); break;

                }
                if (paused)
                    pauseGame();
                else if (crafting)
                {
                    craftingMenuDraw();
                }
                drawLoadingScreen();

                if (BGExtras.credits.isPlaying)
                {
                    spriteBatch.Begin();
                    BGExtras.credits.Draw(spriteBatch);
                    spriteBatch.End();
                }
            }
            virtualScreen.EndCapture();

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            virtualScreen.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void removeLoot()
        {
            //remove off screen loot
            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
            {
                if (!InventoryHolder.tmpInventory[i].pickedUp && InventoryHolder.tmpInventory[i].position.X < -200 && level != 0)
                {
                    InventoryHolder.tmpInventory.RemoveAt(i);
                }
            }
        }

        //Seperate level functions
        public void tutUpdate(GameTime gameTime)
        {
            hud.SetProgressScreen(this.progressScreens[0]);
            checkShake();

            hud.setTotalAmount(2000);

            if (fadeInCount == 50 && !fadedIn)
            {
                tutText.setText(1);
                fadedIn = true;
            }
            else
            {
                fadeInCount++;
            }

            //throwing test
            if (!tutInstructions[0] && mapPosition >= 100 && mapPosition <= 150)
            {
                tutInstructions[0] = true;
                tutText.setText(2);
            }

            if (fights[1] == false && mapPosition >= 500 && mapPosition <= 940)
            {
                fights[1] = true;
                tutText.setText(3);
                enemies.Add(enemyHandler.generatePunchingBag(1450, 400, false, 1.0));
            }



            if (enemies.getAtIndex(0) != null && enemies.getAtIndex(0).hitCount >= 2 && !tutInstructions[1])
            {
                tutInstructions[1] = true;
                tutText.setText(4);
            }

            if (enemies.getAtIndex(0) != null && enemies.getAtIndex(0).dying && !tutInstructions[2] && mapPosition < 2000)
            {
                tutInstructions[2] = true;
                tutText.setText(2);
            }

            if (fights[3] == false && mapPosition >= 1000 && mapPosition <= 1040)
            {
                fights[3] = true;
                addBook(1320, 400);
                addBook(1400, 600);
                addBook(1550, 750);
                tutText.setText(5);
                enemies.Add(enemyHandler.generatePunchingBag(1800, 400, false, 1.0));
            }

            if (player.throwingObject && !tutInstructions[3] && mapPosition < 2000)
            {
                tutInstructions[3] = true;
                tutText.setText(4);
            }

            if (enemies.getAtIndex(1) != null && enemies.getAtIndex(1).dying && !tutInstructions[4])
            {
                tutInstructions[4] = true;
                tutText.setText(2);
            }

            if (fights[2] == false && mapPosition >= 2000 && mapPosition <= 2340)
            {
                fights[2] = true;
                tutText.setText(6);
                enemies.Add(enemyHandler.generateAgilityEnemy(1600, 400, true, 3, 0.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(-200, 400, false, 0.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-200, 400, true, 4, 0.0));
                //enemies.Add(enemyHandler.generateIntelligenceEnemy(-200, 400));
                //enemies.Add(enemyHandler.generateStrengthEnemy(-200, 400));
                // enemies.Add(enemyHandler.generateIntelligenceEnemy(1600, 500));

                addBook(1100, 750);
            }

            displayFinalBrawl(fights[2]);

            //level completed
            if (fights[2] == true && enemies.isAllDead())
            {

                levelUnlocked[1] = true;
                tutText.setText(7);
                bool allPickedUp = true;

                for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
                {
                    if (!InventoryHolder.tmpInventory[i].pickedUp)
                    {
                        allPickedUp = false;
                        break;
                    }
                }

                if (allPickedUp || mapPosition >= 2200)
                {
                    tutText.levelCompleted = true;
                    viaMenu = false;
                    levelEnded();
                }
            }

            removeLoot();

            removeNull();


            //you dead man
            checkPlayerDead();

            KeyboardState keyState = Keyboard.GetState();

            //restarting da game
            restartPress(keyState);


            adjustScreenAfterFight();

            genericUpdates(gameTime);

            tutText.update(gameTime);
            //addObjects
            // addRandomBook();

            //particle system
            totalTimeSpan += gameTime.ElapsedGameTime;
        }

        public void level1Update(GameTime gameTime)
        {
            hud.SetProgressScreen(this.progressScreens[1]);
            hud.setTotalAmount(1350);
            checkShake();
            if (!BGExtras.spinningGlobe.playing)
                BGExtras.spinningGlobe.LoopAll(1.0f);

            if (!BGExtras.flashingMac.playing)
                BGExtras.flashingMac.LoopAll(2.0f);



            //MoveScreen();
            if (fights[0] == false && mapPosition >= 150 && mapPosition <= 170)
            {
                fights[0] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(-200, 400, false, 6, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, true, 5, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-500, 400, false, 7, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(1800, 400, false, 8, 1.0));
                addBook(400, 600);
            }


            if (fights[1] == false && mapPosition >= 350 && mapPosition <= 370)
            {
                fights[1] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(1500, 400, true, 9, 1.0));

            }

            if (fights[2] == false && mapPosition >= 550 && mapPosition <= 570)
            {
                fights[2] = true;
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 9, 1.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(1800, 400, false, 10, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(2500, 400, true, 11, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-1500, 400, false, 12, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 13, 1.0));
                addBook(500, 700);
            }

            if (fights[3] == false && mapPosition >= 750 && mapPosition <= 770)
            {
                fights[3] = true;
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, true, 14, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(2000, 400, false, 11, 1.0));
            }

            if (fights[4] == false && mapPosition >= 950 && mapPosition <= 970)
            {
                fights[4] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(-500, 400, false, 5, 1.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(1800, 400, false, 6, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2500, 400, false, 7, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-1500, 400, false, 8, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(1800, 400, true, 9, 1.0));
                addBook(450, 660);
            }

            if (fights[5] == false && mapPosition >= 1150 && mapPosition <= 1170)
            {
                fights[5] = true;

                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(-400, 400, false, 11, 1.0));
            }

            if (fights[6] == false && mapPosition >= 1350 && mapPosition <= 1370)
            {
                fights[6] = true;

                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-800, 400, false, 14, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 12, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-200, 400, false, 13, 1.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1900, 400, false, 14, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(-1200, 400, false, 1.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2500, 400, false, 1.0));


                addBook(450, 660);
            }

            displayFinalBrawl(fights[6]);

            //level completed
            if (fights[6] == true && enemies.isAllDead())
            {
                levelUnlocked[2] = true;
                viaMenu = false;
                levelEnded();
            }
            removeLoot();
            removeNull();
            checkPlayerDead();

            KeyboardState keyState = Keyboard.GetState();

            //restarting da game
            restartPress(keyState);



            adjustScreenAfterFight();

            genericUpdates(gameTime);

            BGExtras.spinningGlobe.Update(gameTime);
            BGExtras.flashingMac.Update(gameTime);

            //addObjects
            // addRandomBook();
            totalTimeSpan += gameTime.ElapsedGameTime;
        }

        public void level2Update(GameTime gameTime)
        {
            hud.SetProgressScreen(this.progressScreens[2]);
            hud.setTotalAmount(1350);
            if (BGExtras.teslaCoil == null)
            {
                BGExtras.teslaCoil = new TeslaObstacle(graphics.GraphicsDevice, new Vector2(3650f, 350.0f), teslaObstacle, player, enemies, PlainTeslaCoil);
                BGExtras.teslaCoil.soundbank = this.soundBank;
                BGExtras.teslaCoil.addAnimationCells(teslaObstacle);
                BGExtras.teslaCoil.playAnimation();
            }

            checkShake();
            if (!BGExtras.bunsenBurner.playing)
            {
                BGExtras.bunsenBurner.LoopAll(1.0f);

            }

            if (!BGExtras.floatingBrain.playing)
            {
                BGExtras.floatingBrain.LoopAll(1.0f);
            }

            if (!BGExtras.flashingMac.playing)
                BGExtras.flashingMac.LoopAll(2.0f);

            //MoveScreen();
            if (fights[0] == false && mapPosition >= 150 && mapPosition <= 170)
            {
                fights[0] = true;

                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-200, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, true,7, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(2600, 400, false, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 2.0));
                addBook(450, 660);
                addBook(700, 700);

            }


            if (fights[1] == false && mapPosition >= 350 && mapPosition <= 370)
            {
                fights[1] = true;
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1450, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(-200, 400, true, 6, 2.0));

            }

            if (fights[2] == false && mapPosition >= 550 && mapPosition <= 570)
            {
                fights[2] = true;
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(1800, 400, true, 10, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 5, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-1500, 400, false, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(2800, 400, false, 2.0));
                addBook(450, 660);
                addBook(700, 700);
            }

            if (fights[3] == false && mapPosition >= 750 && mapPosition <= 770)
            {
                fights[3] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-500, 400, true, 12,2.0));

            }

            if (fights[4] == false && mapPosition >= 950 && mapPosition <= 970)
            {
                fights[4] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(-500, 400, false, 5, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-800, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(2500, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-1200, 400, false, 11, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(2800, 400, false, 2.0));
                addBook(450, 660);
            }

            if (fights[5] == false && mapPosition >= 1150 && mapPosition <= 1170)
            {
                fights[5] = true;

                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-400, 400, true, 13, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-400, 400, false, 11, 2.0));
            }

            if (fights[6] == false && mapPosition >= 1350 && mapPosition <= 1370)
            {
                fights[6] = true;
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-1800, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(3500, 400, false, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-800, 400, false, 14, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 12, 2.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-200, 400, false, 13, 2.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(1800, 400, false, 14, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(-1200, 400, false, 2.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2500, 400, false, 2.0));

                addBook(700, 700);
                addBook(450, 660);
            }

            displayFinalBrawl(fights[6]);

            //level completed
            if (fights[6] == true && enemies.isAllDead())
            {
                levelUnlocked[3] = true;
                viaMenu = false;
                levelEnded();
            }
            removeLoot();
            removeNull();
            checkPlayerDead();

            KeyboardState keyState = Keyboard.GetState();

            //restarting da game
            restartPress(keyState);

            adjustScreenAfterFight();

            genericUpdates(gameTime);

            BGExtras.bunsenBurner.Update(gameTime);
            BGExtras.floatingBrain.Update(gameTime);
            BGExtras.spinningGlobe.Update(gameTime);
            BGExtras.flashingMac.Update(gameTime);
            

            //addObjects
            // addRandomBook();
            totalTimeSpan += gameTime.ElapsedGameTime;
        }

        public void level3Update(GameTime gameTime)
        {
            hud.SetProgressScreen(this.progressScreens[3]);
            hud.setTotalAmount(1350);

            //if (BGExtras.teslaCoil == null)
            //{

            //    BGExtras.teslaCoil = new TeslaObstacle(graphics.GraphicsDevice, new Vector2(3100f, 350.0f), teslaObstacle, player, enemies, PlainTeslaCoil);
            //    BGExtras.teslaCoil.addAnimationCells(teslaObstacle);
            //    BGExtras.teslaCoil.playAnimation();
           // }

            checkShake();
           /* if (!BGExtras.bunsenBurner.playing)
            {
                BGExtras.bunsenBurner.LoopAll(1.0f);

            }

            if (!BGExtras.floatingBrain.playing)
            {
                BGExtras.floatingBrain.LoopAll(1.0f);
            }

            if (!BGExtras.flashingMac.playing)
                BGExtras.flashingMac.LoopAll(2.0f);
            * 
            */

            //MoveScreen();
            if (fights[0] == false && mapPosition >= 150 && mapPosition <= 170)
            {
                fights[0] = true;

                enemies.Add(enemyHandler.generateAgilityEnemy(-200, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-500, 400, true, 8, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(2200, 400, false, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 3.0));
                addBook(450, 660);
                addBook(700, 700);

            }


            if (fights[1] == false && mapPosition >= 350 && mapPosition <= 370)
            {
                fights[1] = true;
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1450, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-200, 400, false, 14, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 3.0));
            }

            if (fights[2] == false && mapPosition >= 550 && mapPosition <= 570)
            {
                fights[2] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(-500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(1800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, true, 8, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(1900, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(2200, 400, true, 8, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(2800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(2400, 400, false, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 3.0));
                addBook(450, 660);
                addBook(700, 700);
            }

            if (fights[3] == false && mapPosition >= 750 && mapPosition <= 770)
            {
                fights[3] = true;
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-500, 400, true,6, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(2200, 400, false, 3.0));
            }

            if (fights[4] == false && mapPosition >= 950 && mapPosition <= 970)
            {
                fights[4] = true;
                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 5, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-1200, 400, true, 6, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 3.0));
                addBook(450, 660);
            }

            if (fights[5] == false && mapPosition >= 1150 && mapPosition <= 1170)
            {
                fights[5] = true;

                enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-400, 400, false, 11, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(3500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation(-800, 400, false, 14, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-1800, 400, false, 3.0));
            }

            if (fights[6] == false && mapPosition >= 1350 && mapPosition <= 1370)
            {
                fights[6] = true;
                enemies.Add(enemyHandler.generateIntelligenceEnemy(-1800, 400, false, 3.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(3500, 400, false, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-800, 400, false, 14, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 12, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-200, 400, false, 13, 3.0));
                enemies.Add(enemyHandler.generateAgilityEnemy(1800, 400, false, 14, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation(-500, 400, false, 13, 3.0));
                enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 3.0));

                addBook(700, 700);
                addBook(450, 660);
            }

            displayFinalBrawl(fights[6]);

            //level completed
            if (fights[6] == true && enemies.isAllDead())
            {
                levelUnlocked[4] = true;
                viaMenu = false;
                levelEnded();
            }
            removeLoot();
            removeNull();
            checkPlayerDead();

            KeyboardState keyState = Keyboard.GetState();

            //restarting da game
            restartPress(keyState);

            adjustScreenAfterFight();

            genericUpdates(gameTime);

            //BGExtras.bunsenBurner.Update(gameTime);
            //BGExtras.floatingBrain.Update(gameTime);
            //BGExtras.spinningGlobe.Update(gameTime);
            //BGExtras.flashingMac.Update(gameTime);

            //addObjects
            // addRandomBook();
            totalTimeSpan += gameTime.ElapsedGameTime;
        }

        public void generateRandomGroupOfEnemies()
        {
            int random = RandomClass.r.Next(5);
            Console.WriteLine("Generated enemies");
            switch (random)
            {
                case 0:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemyVariation(-200, 400, false, 6, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 5, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-500, 400, false, 7, 3.0));
                        enemies.Add(enemyHandler.generateStrengthEnemy(1800, 400, false, 8, 3.0));
                        break;
                    }
                case 1:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateAgilityEnemyVariation(1800, 400, false, 10, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 5, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-1500, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateAgilityEnemy(2800, 400, false, 3.0));
                        break;
                    }
                case 2:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(-400, 400, false, 13, 3.0));
                        enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-400, 400, false, 11, 3.0));
                        break;
                    }
                case 3:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 5, 3.0));
                        enemies.Add(enemyHandler.generateStrengthEnemyVariation2(-800, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(-1200, 400, false, 11, 3.0));
                        enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2800, 400, false, 3.0));
                        break;
                    }
                case 4:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 3.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(-400, 400, false, 11, 3.0));
                        break;
                    } 
                       
            }
        }

        public void generateSpecificGroupOfEnemies(int num)
        {
            
            Console.WriteLine("Generated enemies");
            switch (num)
            {
                case 0:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemyVariation(-200, 400, false, 6, 4.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(2500, 400, false, 5, 4.0));
                        enemies.Add(enemyHandler.generateAgilityEnemyVariation2(1800, 400, false, 8, 4.0));
                        break;
                    }
                case 1:
                    {

                        enemies.Add(enemyHandler.generateStrengthEnemyVariation(1800, 400, false, 10, 4.0));
                        enemies.Add(enemyHandler.generateStrengthEnemyVariation2(1800, 400, false, 4.0));
                        enemies.Add(enemyHandler.generateAgilityEnemy(2800, 400, false, 4.0));
                        break;
                    }
                case 2:
                    {
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 4.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-400, 400, false, 13, 4.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemy(-400, 400, false, 11, 4.0));
                        break;
                    }
                case 3:
                    {
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation2(-500, 400, false, 5, 4.0));
                        enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 4.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(2800, 400, false, 4.0));
                        break;
                    }
                case 4:
                    {
                        enemies.Add(enemyHandler.generateStrengthEnemy(-800, 400, false, 4.0));
                        enemies.Add(enemyHandler.generateAgilityEnemy(-500, 400, false, 10, 4.0));
                        enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-400, 400, false, 11, 4.0));
                        break;
                    }

            }
        }

        public int countEnemiesStillAlive()
        {
            int tmpCounter = 0;
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (!enemies.getAtIndex(i).dead && !enemies.getAtIndex(i).dying)
                {
                    tmpCounter++;
                }
            }
            return tmpCounter;
        }

        public void bossFightUpdate(GameTime gameTime)
        {
            generateCounter++;

            //if (BGExtras.teslaCoil == null)
            //{
               // BGExtras.teslaCoil = new TeslaObstacle(graphics.GraphicsDevice, new Vector2(350f, 350.0f), teslaObstacle, player, enemies, PlainTeslaCoil);
                //BGExtras.teslaCoil.addAnimationCells(teslaObstacle);
                //BGExtras.teslaCoil.playAnimation();
           // }

            if (!BGExtras.torches.playing)
            {
                BGExtras.torches.position = (new Vector2(375, 250));
                BGExtras.torches2.position = (new Vector2(975, 250));
                BGExtras.torches.LoopAll(1.0f);
                BGExtras.torches2.LoopAll(1.0f);
                BGExtras.torches.Update(gameTime);
                BGExtras.torches2.Update(gameTime);
            }

            if (generateCounter >= 200 && countEnemiesStillAlive()<3 && !enemies.isAllDead())//periodically generate enemies
            {
                generateCounter = 0;
                generateSpecificGroupOfEnemies(enemyGroup);
                enemyGroup++;
                if (enemyGroup >= 5)
                    enemyGroup = 0;

                addBook(450, 660);
                addBook(700, 700);
            }
            
            if (fightStages == 0)
            {
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if ( enemies.getAtIndex(i) != null && enemies.getAtIndex(i).type.Equals("evilJP") && enemies.getAtIndex(i).getHitpoints() <= 4000)
                    {
                        Console.WriteLine("stage1");
                        enemies.getAtIndex(i).setStage(1);
                        fightStages = 1;
                        //generateCounter = 0;
                        if (countEnemiesStillAlive() < 4)
                        {
                            
                            generateSpecificGroupOfEnemies(enemyGroup);
                            enemyGroup++;
                            if (enemyGroup >= 5)
                                enemyGroup = 0;
                        }
                    }
                }
            }
            else if (fightStages == 1)
            {
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).type.Equals("evilJP") && enemies.getAtIndex(i).getHitpoints() <= 2000)
                    {
                        Console.WriteLine("stage2");
                        enemies.getAtIndex(i).setStage(2);
                        fightStages = 2;
                        //generateCounter = 0;
                        if (countEnemiesStillAlive() < 4)
                        {

                            generateSpecificGroupOfEnemies(enemyGroup);
                            enemyGroup++;
                            if (enemyGroup >= 5)
                                enemyGroup = 0;
                        }
                    }
                }
            }

            bool killThemAll = false;
            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).type.Equals("evilJP") && enemies.getAtIndex(i).getHitpoints() <= 0)
                {
                    killThemAll = true;
                }
            }

            if (killThemAll && !enemies.isAllDead())
            {
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && !enemies.getAtIndex(i).type.Equals("evilJP") && !enemies.getAtIndex(i).dead && !enemies.getAtIndex(i).dying)
                    {
                        
                        enemies.getAtIndex(i).die(enemies.enemies,i);
                    }
                }
            }

            hud.SetProgressScreen(null);
            hud.setTotalAmount(1350);

            //checkShake();

            if (fights[0] == false && generateCounter>20)
            {
                fights[0] = true;

                enemies.Add(enemyHandler.generateEvilJP(-200, 400, false, 4.0));
                enemies.Add(enemyHandler.generateAgilityEnemyVariation2(-500, 400, false, 4.0));
                enemies.Add(enemyHandler.generateIntelligenceEnemyVariation(-500, 400, false, 4.0));
                enemies.Add(enemyHandler.generateStrengthEnemyVariation2(2200, 400, false, 4.0));
                
                addBook(450, 660);
                addBook(700, 700);

            }

            displayFinalBrawl(true);

            

            //level completed
            if (fights[0] == true && enemies.isAllDead())
            {
                
                viaMenu = false;
                bossFightEnded();
                //levelEnded();
            }
            removeLoot();
            removeNull();
            checkPlayerDead();

            KeyboardState keyState = Keyboard.GetState();

            //restarting da game
            restartPress(keyState);

            //adjustScreenAfterFight();

            genericUpdates(gameTime);
            

            totalTimeSpan += gameTime.ElapsedGameTime;
        }

        public void drawLoadingScreen()
        {
            if (isLoadingScreen)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(loadingScreenTexture, new Vector2(0, 0), Color.White);
                int width = (int)((loadingTimer / totalLoadingTime) * 917);

                Rectangle drawHere = new Rectangle(262, 745, width, 56);

                spriteBatch.Draw(loadingProgress, drawHere, Color.White);
                int tmpPercentage = (int)((width / 917.0) * 100);

                if (tmpPercentage < 100)
                    spriteBatch.DrawString(loadingFont, tmpPercentage + "%", new Vector2(688, 750), Color.Black);
                else
                {
                    spriteBatch.DrawString(loadingFont, "Press Enter to continue", new Vector2(368, 750), Color.Black);
                }
                spriteBatch.End();
            }
        }

        public void tutDraw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            if (isLoadingScreen)
            {

            }
            else
            {
                gameBG.Draw();
                universalDraw();
                spriteBatch.Begin();
                tutText.Draw(spriteBatch);
                spriteBatch.End();
            }

        }

        public void level1Draw(GameTime gameTime)
        {
            if (isLoadingScreen)
            {

            }
            else
            {
                GraphicsDevice.Clear(Color.White);
                gameBG.Draw();
                spriteBatch.Begin();
                BGExtras.spinningGlobe.Draw(spriteBatch);
                BGExtras.flashingMac.Draw(spriteBatch);
                spriteBatch.End();
                universalDraw();
            }
        }

        public void level2Draw(GameTime gameTime)
        {
            if (isLoadingScreen)
            {

            }
            else
            {

                GraphicsDevice.Clear(Color.White);
                gameBG.Draw();


                spriteBatch.Begin();
                BGExtras.bunsenBurner.Draw(spriteBatch);
                BGExtras.floatingBrain.Draw(spriteBatch);
                //BGExtras.spinningGlobe.Draw(spriteBatch);
                //BGExtras.flashingMac.Draw(spriteBatch);
                if (BGExtras.teslaCoil != null)
                    spriteBatch.Draw(PlainTeslaTop, BGExtras.teslaCoil.position, Color.White);
                spriteBatch.End();

                universalDraw();

            }
        }

        public void level3Draw(GameTime gameTime)
        {
            if (isLoadingScreen)
            {

            }
            else
            {

                GraphicsDevice.Clear(Color.White);
                gameBG.Draw();


                spriteBatch.Begin();
                //BGExtras.bunsenBurner.Draw(spriteBatch);
                //BGExtras.floatingBrain.Draw(spriteBatch);
                //BGExtras.spinningGlobe.Draw(spriteBatch);
                //BGExtras.flashingMac.Draw(spriteBatch);
                 //if (BGExtras.teslaCoil != null)
                 //   spriteBatch.Draw(PlainTeslaTop, BGExtras.teslaCoil.position, Color.White);
                spriteBatch.End();

                universalDraw();

            }
        }

        public void bossFightDraw(GameTime gameTime)
        {
            if (isLoadingScreen)
            {

            }
            else
            {
                GraphicsDevice.Clear(Color.White);
                gameBG.Draw();

                
                spriteBatch.Begin();
                BGExtras.torches.Draw(spriteBatch);
                BGExtras.torches2.Draw(spriteBatch);
                 if (BGExtras.teslaCoil != null)
                    spriteBatch.Draw(PlainTeslaTop, BGExtras.teslaCoil.position, Color.White);
                spriteBatch.End();

                universalDraw();

            }
        }

        public void drawEnemyThumb(GameTime gameTime)
        {

        }

        public void displayFinalBrawl(bool value)
        {
            if (value)
            {
                if (!drawBrawlAnimation)
                {
                    finalBrawlAnimation.PlayAll(0.8f);
                    drawBrawlAnimation = true;
                    drawBrawlDown = true;
                }

                if (drawBrawlDown)
                {
                    drawBrawlCount++;
                    if (drawBrawlCount > 50)
                        drawBrawlAlpha -= 0.02f;

                    if (drawBrawlAlpha <= 0)
                    {

                        drawBrawlDown = false;
                    }
                }
            }
        }
    }
}
