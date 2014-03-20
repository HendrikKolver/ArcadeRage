using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MainGame
{
    class Player
    {
        public bool isLoadingScreen = false;
        public double enemyHudCounter = 0;
        public Animation arrowAnimation = null;
        public bool scrolling = false;
        //LevelComplete
        public bool levelComplete = false;
        public bool playerDied = false;



        //throwObjects
        public bool throwInventory = false;
        public ThrowObjects inventoryObject;
        public bool throwingObject = false;
        public List<ThrowObjects> throwObjects;
        private bool leftThrow = false;
        private int throwCounter;

        //enemies
        private EnemyList enemies;
        private int hitCounter;
        private int hitSpeed;
        private Boolean attacking = false;
        public bool recoilForward = false;
        public bool recoilBackward = false;
        private int recoilCounter;
        public int scrollingPoint;
        private bool aSpamming = false;
        private bool qSpamming;
        private bool punching = false;
        private bool touchingEnemy = false;
        private bool registerHit = false;
        private int splashTmp = 0;

        //colission detection
        private Rectangle playerBounds;
        private Rectangle playerPickupBounds;
        public Rectangle playerProjectileBounds;
        public Rectangle weaponBounds;
        public bool lookingLeft = false;

        //ganeral stats
        public double hitpoints;
        public Weapon weapon;
        public Weapon specialWeapon;
        public Weapon fists;
        public List<Weapon> weaponInventory;

        //movement and textures
        public Vector2 position;

        private Animation playerAttackAnimation;
        private Animation playerAttack2Animation;
        private Animation playerAttack3Animation;
        public List<Animation> specialAttackAnimations;

        public Animation playerRecoilAnimation;
        public Animation playerIdleAnimation;
        public Animation playerAnimation;

        private Animation playerRecoilAnimationBasic;
        private Animation playerIdleAnimationBasic;
        private Animation playerAnimationBasic;
        private Vector2 spriteOrigin;
        private int windowWidth, windowHeight;
        public bool isIdle = true;
        public bool left = false;
        private float forwardSpeed;
        private float topSpeed;
        private float WalkAnimationSpeed;
        private Boolean action = false;


        //jumping
        private Boolean jumping = false;
        private float initialY = 0;
        private float topY = 0;
        private Boolean topReached = false;
        private float jumpMomentum = 15;
        private double jumpGravityEffect = 0.55;
        private float jumpHeight = 200;

        GraphicsDevice device;
        BasicParticleSystem particleSystem;
        BasicParticleSystem particleSystem2;

        SoundBank soundBank;

        private int idleCounter;
        private int attackToPlay = 0;

        public Player(GraphicsDevice device, Vector2 position, Vector2 origin, EnemyList enemies, int scrollingPoint_, List<ThrowObjects> throwObjects, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2, SoundBank soundBank)
        {
            this.idleCounter = 0;
            throwCounter = 0;

            this.device = device;

            this.soundBank = soundBank;

            this.particleSystem = particleSystem;
            this.particleSystem2 = particleSystem2;
            this.throwObjects = throwObjects;
            scrollingPoint = scrollingPoint_;   //Amount of pixels until screen will scroll
            recoilCounter = 0;
            // The position that is passed in is now set to the position above
            this.position = position;
            // Create the animation, this method is in Animation.cs
            playerAnimation = new Animation(position);
            playerIdleAnimation = new Animation(position);
            playerAttackAnimation = new Animation(position);
            playerAttack2Animation = new Animation(position);
            playerAttack3Animation = new Animation(position);
            playerRecoilAnimation = new Animation(position);

            playerAnimationBasic = new Animation(position);
            playerIdleAnimationBasic = new Animation(position);
            playerRecoilAnimationBasic = new Animation(position);

            // Setup origin
            spriteOrigin.X = origin.X;
            spriteOrigin.Y = origin.Y;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            origin.X *= 2;
            origin.Y *= 2;
            playerProjectileBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 50, 50);
            playerBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 220, 50);
            //playerBounds.X+=170;
            //playerPickupBounds = new Rectangle((int)(position.X - origin.X), (int)(position.Y - origin.Y), (int)origin.X/2, (int)origin.Y);
            playerPickupBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 110, 220);
            // Console.WriteLine("originX: " + origin.X);
            // Console.WriteLine("originY: " + origin.Y);

            this.enemies = enemies;
            hitpoints = 100;

            fists = new Weapon();
            weapon = fists;
            specialWeapon = null;
            weaponInventory = new List<Weapon>();
            weaponBounds = weapon.weaponBounds;

            hitSpeed = 20;
            hitCounter = 0;
            forwardSpeed = 10.0f;
            topSpeed = forwardSpeed / 2;
            WalkAnimationSpeed = (float)0.7;
        }

        public List<Weapon> getWeapons()
        {
            return weaponInventory;
        }

        public void setWeapon(int i)
        {
            specialWeapon = weaponInventory[i];
        }

        public bool addWeapon(Weapon w)
        {
            if (weaponInventory.Count < 4)
            {
                weaponInventory.Add(w);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddCell(Texture2D cellPicture)
        {
            playerAnimation.AddCell(cellPicture);
            playerAnimationBasic.AddCell(cellPicture);
        }

        public void AddIdleCell(Texture2D cellPicture)
        {
            playerIdleAnimation.AddCell(cellPicture);
            playerIdleAnimationBasic.AddCell(cellPicture);
        }

        public void AddAttackCell(Texture2D cellPicture)
        {
            playerAttackAnimation.AddCell(cellPicture);
        }

        public void AddAttackVariation2Cell(Texture2D cellPicture)
        {
            playerAttack2Animation.AddCell(cellPicture);
        }

        public void AddAttackVariation3Cell(Texture2D cellPicture)
        {
            playerAttack3Animation.AddCell(cellPicture);
        }


        public void AddRecoilCell(Texture2D cellPicture)
        {
            playerRecoilAnimation.AddCell(cellPicture);
            playerRecoilAnimationBasic.AddCell(cellPicture);
        }

        public void passArrow(Animation arrow)
        {
            arrowAnimation = arrow;
        }

        public void Draw(SpriteBatch batch)
        {
            if (recoilForward || recoilBackward)
            {
                playerRecoilAnimation.SetPosition(position);
                playerRecoilAnimation.Draw(batch);
            }
            else if (attacking)
            {
                if (weapon != specialWeapon)
                {
                    if (attackToPlay == 0)  //Attack Variations
                    {
                        playerAttackAnimation.SetPosition(position);
                        playerAttackAnimation.Draw(batch);
                    }
                    else if (attackToPlay == 1)
                    {
                        playerAttack2Animation.SetPosition(position);
                        playerAttack2Animation.Draw(batch);
                    }
                    else
                    {
                        playerAttack3Animation.SetPosition(position);
                        playerAttack3Animation.Draw(batch);
                    }
                }
                else
                {
                    if (throwingObject)
                    {

                        if (weapon.throwAnimation != null)
                        {
                            weapon.throwAnimation.SetPosition(position);
                            weapon.throwAnimation.Draw(batch);
                        }
                        else
                        {
                            playerAttackAnimation.SetPosition(position);
                            playerAttackAnimation.Draw(batch);
                        }
                    }
                    else
                    {
                        specialAttackAnimations[attackToPlay].SetPosition(new Vector2(position.X + weapon.attackpositionAdjustment.X, position.Y + weapon.attackpositionAdjustment.Y));
                        specialAttackAnimations[attackToPlay].Draw(batch);
                    }
                }
            }
            else if (!isIdle)
            {
                if (weapon == specialWeapon && weapon.name.Contains("Electric Hokey Stick"))
                {
                    playerAnimation.SetPosition(new Vector2(position.X,position.Y-40));
                }
                else
                {
                    playerAnimation.SetPosition(position);
                }
                playerAnimation.Draw(batch);
            }
            else
            {
                playerIdleAnimation.SetPosition(position);
                playerIdleAnimation.Draw(batch);
            }

            /*if (this.idleCounter >= 300)
            {
                this.arrowAnimation.Draw(batch);
            }*/
        }

        public void Update(GameTime gameTime)
        {
            if (this.idleCounter >= 300)
            {
                this.arrowAnimation.LoopAll(0.5f);
                this.arrowAnimation.Update(gameTime);
            }

            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).getBounds().Intersects(playerBounds))
                {
                    touchingEnemy = true;
                }
                else
                {
                    touchingEnemy = false;
                }
            }

            KeyboardState keyState = Keyboard.GetState();
            //object pickup
            for (int i = 0; i < InventoryHolder.tmpInventory.Count; i++)
            {
                if (InventoryHolder.tmpInventory.ElementAt(i) != null && InventoryHolder.tmpInventory.ElementAt(i).getBounds().Intersects(playerPickupBounds) && !InventoryHolder.tmpInventory.ElementAt(i).pickedUp)
                {
                    InventoryHolder.tmpInventory.ElementAt(i).pickedUp = true;
                    // InventoryHolder.inventory.ElementAt(i).position.X = -100;
                }
            }


            for (int i = 0; i < throwObjects.Count; i++)
            {
                if (throwObjects.ElementAt(i) != null && throwObjects.ElementAt(i).getBounds().Intersects(playerPickupBounds) && !throwInventory && !throwingObject)
                {
                    soundBank.PlayCue("Pickup");
                    throwInventory = true;
                    inventoryObject = throwObjects.ElementAt(i);
                    inventoryObject.pickedUp = true;
                    inventoryObject.position.X = -100;
                }
            }

            if (!levelComplete && !playerDied && !isLoadingScreen)
            {
                if (keyState.IsKeyDown(Keys.S) && throwInventory)
                {
                    throwInventory = false;
                    throwingObject = true;
                    inventoryObject.position.X = (int)(position.X + 150);
                    inventoryObject.position.Y = (int)(position.Y + 120);
                    inventoryObject.objectBounds.Y = (int)(position.Y + 200);
                    leftThrow = left;
                    attack();

                }

                //movement
                if (recoilForward)
                {
                    recoilCounter++;
                    position.X -= 4;
                    if (recoilCounter == 24)
                    {
                        recoilCounter = 0;
                        recoilForward = false;
                    }
                }
                else if (recoilBackward)
                {
                    recoilCounter++;
                    position.X += 4;
                    if (recoilCounter == 24)
                    {
                        recoilCounter = 0;
                        recoilBackward = false;
                    }
                }
                else if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Left))// && !scrolling)
                {
                    diagonalUpLeft();
                }
                else if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Right))// && !scrolling)
                {
                    diagonalUpRight();
                }
                else if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Left))// && !scrolling)
                {
                    diagonalDownLeft();
                }
                else if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Right))// && !scrolling)
                {
                    diagonalDownRight();
                }
                else if (keyState.IsKeyDown(Keys.Left))// && !scrolling)
                {
                    Forward();
                }
                else if (keyState.IsKeyDown(Keys.Right))// && !scrolling)
                {
                    Backward();
                }
                else if (keyState.IsKeyDown(Keys.Up))
                {
                    Up();
                }
                else if (keyState.IsKeyDown(Keys.Down))
                {
                    Down();
                }
                else
                {
                    idle();
                }

                //Switch weapon key listener
                if (keyState.IsKeyDown(Keys.Q) && !recoilBackward && !recoilForward && !aSpamming && !qSpamming && !punching)
                {
                    qSpamming = true;
                    switchEquipedWeapon();
                }

                if (keyState.IsKeyUp(Keys.Q) && qSpamming)
                {
                    qSpamming = false;
                }

                if (keyState.IsKeyDown(Keys.Space) && !jumping && position.Y >= 600)
                {
                    jumping = true;
                    initialY = position.Y;
                    topY = (position.Y - jumpHeight);

                }

                if (keyState.IsKeyDown(Keys.A) && !recoilBackward && !recoilForward && !aSpamming && !punching && !attacking)
                {
                    aSpamming = true;
                    attacking = true;
                    punching = true;
                    attack();
                }

                if (keyState.IsKeyUp(Keys.A) && aSpamming)
                {
                    aSpamming = false;
                }
            }


            if (attacking)
            {
                hitCounter++;
                if (hitCounter == hitSpeed - weapon.soundContactDelay)
                {
                    registerHit = true;
                }
                else if (hitCounter >= hitSpeed)
                {
                    hitCounter = 0;
                    attacking = false;
                    punching = false;
                }
            }

            if (registerHit)
            {

                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).getBounds().Intersects(weaponBounds))
                    {
                        if (splashTmp >= weapon.splashCount)
                        {

                            break;
                        }
                        splashTmp++;

                        dealDamage(enemies.getAtIndex(i));
                        //Console.WriteLine("enemy Hitpoints: " + enemies.getAtIndex(i).getHitpoints());

                        if (enemies.getAtIndex(i).getHitpoints() <= 0)
                        {
                            enemies.enemies[i].dropItems();
                            killEnemy(i);

                        }

                        //registerHit = false;

                        //break to only attack one enemy
                        //break;
                    }
                    else
                    {

                        //registerHit = false;
                    }
                }
                registerHit = false;
                splashTmp = 0;

            }

            //stay on screen
            if (position.Y < 330) position.Y = 330.0f;
            if (position.Y > windowHeight - 280) position.Y = windowHeight - 280;
            if (position.X < 0 - 130) position.X = 0.0f - 130;
            if (position.X > windowWidth - 160) position.X = windowWidth - 160;

            playerBounds.X = (int)(position.X);
            playerBounds.X += 135;
            playerBounds.Y = (int)(position.Y);
            playerBounds.Y += 195;
            weaponBounds.X = (int)(position.X);
            weaponBounds.X += weapon.weaponXAdjustment;
            weaponBounds.Y = (int)(position.Y);
            weaponBounds.Y += weapon.weaponYAdjustment;
            playerPickupBounds.X = (int)(position.X);
            playerPickupBounds.X += 200;
            playerPickupBounds.Y = (int)(position.Y);
            playerPickupBounds.Y += 40;
            playerProjectileBounds.X = (int)(position.X);
            playerProjectileBounds.X += 60;
            playerProjectileBounds.Y = (int)(position.Y);
            playerProjectileBounds.Y += 195;


            if (throwingObject)
            {
                throwCounter++;
            }

            if (throwingObject && throwCounter >= 9)
            {
                throwing();

            }

            playerAnimation.Update(gameTime);
            playerIdleAnimation.Update(gameTime);
            playerRecoilAnimation.Update(gameTime);
            if (weapon != specialWeapon)
            {
                playerAttackAnimation.Update(gameTime);
                playerAttack2Animation.Update(gameTime);
                playerAttack3Animation.Update(gameTime);
            }
            else
            {
                for (int i = 0; i < specialAttackAnimations.Count; i++)
                {

                    specialAttackAnimations[i].Update(gameTime);
                }

                playerAttackAnimation.Update(gameTime);

                if (weapon.throwAnimation != null)
                    weapon.throwAnimation.Update(gameTime);
            }


        }

        public void killEnemy(int index)
        {
            enemies.enemies[index].die(enemies.enemies, index);
        }

        public void throwing()
        {
            this.idleCounter = 0;
            inventoryObject.throwObject();


            if (!leftThrow)
            {
                inventoryObject.position.X += 25.0f;
                if (inventoryObject != null && inventoryObject.position.X > windowWidth + 60)
                {
                    throwObjects.Remove(inventoryObject);
                    inventoryObject = null;
                    throwingObject = false;
                    throwInventory = false;
                    throwCounter = 0;
                }
            }
            else
            {
                inventoryObject.position.X -= 25.0f;
                if (inventoryObject != null && inventoryObject.position.X < -60)
                {
                    throwObjects.Remove(inventoryObject);
                    inventoryObject = null;
                    throwingObject = false;
                    throwInventory = false;
                    throwCounter = 0;
                }
            }

            if (inventoryObject != null)
            {
                for (int i = 0; i < enemies.getSize(); i++)
                {
                    if (enemies.getAtIndex(i) != null && enemies.getAtIndex(i).getBounds().Intersects(inventoryObject.getBounds()))
                    {

                        if (inventoryObject.displayName == "Plate")
                        {
                            inventoryObject.damage = 10;
                        }

                        enemies.getAtIndex(i).takeThrowDamage(inventoryObject.damage);
                        //Console.WriteLine("enemy Hitpoints: " + enemies.getAtIndex(i).getHitpoints());
                        if (enemies.getAtIndex(i).getHitpoints() <= 0)
                        {
                            enemies.enemies[i].dropItems();
                            killEnemy(i);
                        }
                        else
                        {
                            Console.WriteLine("throw:" + enemyHudCounter);
                            enemies.enemies[i].drawThumbNail = true;
                            enemies.enemies[i].hudCount = enemyHudCounter;
                            enemyHudCounter++;
                        }

                        if (inventoryObject.displayName != "Plate")
                        {

                            throwObjects.Remove(inventoryObject);
                            inventoryObject = null;
                            throwingObject = false;
                            throwInventory = false;
                            throwCounter = 0;
                            break;
                        }

                    }
                }

            }

        }

        public void idle()
        {
            this.idleCounter++;
            isIdle = true;
            if (left)
            {
                playerIdleAnimation.SetMoveLeft();
            }
            else
            {
                playerIdleAnimation.SetMoveRight();
            }

            playerAnimation.Stop();
            playerAttackAnimation.Stop();
            playerAttack2Animation.Stop();
            playerRecoilAnimation.Stop();
            playerIdleAnimation.LoopAll(1);
        }

        public Boolean isIdlePlayer()
        {
            return this.isIdle;
        }

        public Boolean isAttackingPlayer()
        {
            return this.attacking;
        }


        public void attack()
        {
            if (weapon == specialWeapon)
                attackToPlay = RandomClass.r.Next(weapon.attackAnimations.Count);
            else
                attackToPlay = RandomClass.r.Next(3);   //Which attack variation to play

            this.idleCounter = 0;
            if (throwingObject)
            {
                soundBank.PlayCue("Throw");
                attackToPlay = 0;
            }
            else
            {


                //punching air
                if (weapon.name.Contains("lightsaber"))
                {
                    soundBank.PlayCue("swing1");

                }
                else
                {
                    soundBank.PlayCue("Throw");
                }
            }


            isIdle = false;
            attacking = true;

            playerAnimation.Stop();
            playerIdleAnimation.Stop();
            playerRecoilAnimation.Stop();

            if (weapon != specialWeapon)
            {
                if (left)
                {
                    playerAttackAnimation.SetMoveLeft();
                    playerAttack2Animation.SetMoveLeft();
                    playerAttack3Animation.SetMoveLeft();
                }
                else
                {
                    playerAttackAnimation.SetMoveRight();
                    playerAttack2Animation.SetMoveRight();
                    playerAttack3Animation.SetMoveRight();
                }

                playerAttackAnimation.PlayAll(0.3f);
                playerAttack2Animation.PlayAll(0.3f);
                playerAttack3Animation.PlayAll(0.3f);
            }
            else
            {

                if (left)
                {
                    if (weapon.throwAnimation != null)
                    {
                        weapon.throwAnimation.SetMoveLeft();
                    }
                    for (int i = 0; i < specialAttackAnimations.Count; i++)
                        specialAttackAnimations[i].SetMoveLeft();

                    playerAttackAnimation.SetMoveLeft();

                }
                else
                {
                    if (weapon.throwAnimation != null)
                    {
                        weapon.throwAnimation.SetMoveRight();
                    }
                    for (int i = 0; i < specialAttackAnimations.Count; i++)
                        specialAttackAnimations[i].SetMoveRight();

                    playerAttackAnimation.SetMoveRight();
                }

                if (weapon.throwAnimation != null)
                {
                    weapon.throwAnimation.PlayAll(0.3f);
                }

                for (int i = 0; i < specialAttackAnimations.Count; i++)
                    specialAttackAnimations[i].PlayAll(0.3f);

                playerAttackAnimation.PlayAll(0.3f);

            }
        }


        public void Forward()
        {
            this.idleCounter = 0;
            left = true;
            isIdle = false;
            playerAnimation.SetMoveLeft();
            playerAnimation.LoopAll(WalkAnimationSpeed);
            position.X -= forwardSpeed;
        }
        public void Backward()
        {
            this.idleCounter = 0;
            left = false;
            isIdle = false;
            playerAnimation.SetMoveRight();
            playerAnimation.LoopAll(WalkAnimationSpeed);

            if (enemies.isAllDead() == false)
            {
                scrollingPoint = windowWidth - 160;
            }
            else
            {
                scrollingPoint = 700;
            }

            // Console.WriteLine("Scrolling point: " + scrollingPoint);

            if (!(position.X >= scrollingPoint))
            {
                position.X += forwardSpeed;
            }
        }

        public void Up()
        {
            this.idleCounter = 0;
            isIdle = false;
            playerAnimation.LoopAll(WalkAnimationSpeed);
            position.Y -= topSpeed;
        }
        public void Down()
        {
            this.idleCounter = 0;
            isIdle = false;
            playerAnimation.LoopAll(WalkAnimationSpeed);
            position.Y += topSpeed;
        }

        public void diagonalUpLeft()
        {

            this.idleCounter = 0;
            left = true;
            isIdle = false;
            playerAnimation.SetMoveLeft();
            playerAnimation.LoopAll(WalkAnimationSpeed);
            position.X -= forwardSpeed;
            position.Y -= topSpeed;
        }

        public void diagonalUpRight()
        {

            this.idleCounter = 0;
            left = false;
            isIdle = false;
            playerAnimation.SetMoveRight();
            playerAnimation.LoopAll(WalkAnimationSpeed);
            if (enemies.isAllDead() == false)
            {
                scrollingPoint = windowWidth - 160;
            }
            else
            {
                scrollingPoint = 700;
            }

            // Console.WriteLine("Scrolling point: " + scrollingPoint);

            if (!(position.X >= scrollingPoint))
            {
                position.X += forwardSpeed;
            }
            position.Y -= topSpeed;
        }

        public void diagonalDownRight()
        {

            this.idleCounter = 0;
            left = false;
            isIdle = false;
            playerAnimation.SetMoveRight();
            playerAnimation.LoopAll(WalkAnimationSpeed);
            if (enemies.isAllDead() == false)
            {
                scrollingPoint = windowWidth - 160;
            }
            else
            {
                scrollingPoint = 700;
            }

            //Console.WriteLine("Scrolling point: " + scrollingPoint);

            if (!(position.X >= scrollingPoint))
            {
                position.X += forwardSpeed;
            }
            position.Y += topSpeed;
        }

        public void diagonalDownLeft()
        {

            this.idleCounter = 0;
            left = true;
            isIdle = false;
            playerAnimation.SetMoveLeft();
            playerAnimation.LoopAll(WalkAnimationSpeed);
            position.X -= forwardSpeed;
            position.Y += topSpeed;
        }

        public void dealDamage(Enemy enemy)
        {
            //check if on enemy
            bool checkOnEnemy = false;
            if ((enemy.getPosition().X + 30 >= position.X && enemy.getPosition().X <= position.X) || (enemy.getPosition().X - 30 <= position.X && enemy.getPosition().X >= position.X))
            {
                checkOnEnemy = true;
            }

            if ((enemy.getPosition().X > position.X && !left || enemy.getPosition().X < position.X && left) || checkOnEnemy)
            {
                if (weapon.name.Contains("331O on a Stick"))
                {
                    soundBank.PlayCue("shortPunch");
                    int tmp = RandomClass.r.Next(2);
                    if (tmp == 0)
                        soundBank.PlayCue("keypad1");
                    else
                        soundBank.PlayCue("keypad2");

                }
                else if (weapon.name.Contains("Bear Hands") || weapon.name.Contains("Knife YoYo"))
                {
                    soundBank.PlayCue("impact");
                }
                else if (weapon.name.Contains("Electric Hokey Stick"))
                    soundBank.PlayCue("ElectricStick");
                else if (weapon.name.Contains("lightsaber"))
                    soundBank.PlayCue("hit3");
                else
                    soundBank.PlayCue("shortPunch");
                enemy.takeDamage(weapon, weapon.getDamage());

                if (enemy.getHitpoints() > 0)
                {
                    Console.WriteLine("hit:" + enemyHudCounter);
                    enemy.drawThumbNail = true;
                    enemy.hudCount = enemyHudCounter;
                    enemyHudCounter++;
                }

            }
        }



        public void takeDamage(double amount)
        {
            Vector2 tmp = new Vector2(position.X + 150, position.Y + 100);
            particleSystem.AddExplosion(tmp);
            particleSystem2.AddExplosion(tmp);
            hitpoints -= amount;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        //Switch between weapons
        public void switchEquipedWeapon()
        {
            if (weapon == fists && specialWeapon != null)
            {
                weapon = specialWeapon;
                Console.WriteLine("Special weapon: " + weapon.name);
                playerAnimation = weapon.walkAnimation;
                playerIdleAnimation = weapon.idelAnimation;
                playerRecoilAnimation = weapon.recoilAnimation;
                specialAttackAnimations = weapon.attackAnimations;
                weaponBounds = weapon.weaponBounds;

            }
            else
            {
                weapon = fists;
                Console.WriteLine("Normal weapon: " + weapon.name);
                playerAnimation = playerAnimationBasic;
                playerIdleAnimation = playerIdleAnimationBasic;
                playerRecoilAnimation = playerRecoilAnimationBasic;
                weaponBounds = weapon.weaponBounds;
            }
        }

        public Rectangle getPlayerBounds()
        {
            return playerBounds;
        }

        public double getHitpoints()
        {
            return hitpoints;
        }

        public void recoilPlayerForward()
        {
            this.idleCounter = 0;
            recoilForward = true;
            isIdle = false;
            playerRecoilAnimation.SetMoveRight();

            playerAttackAnimation.Stop();
            playerAttack2Animation.Stop();
            playerAttack3Animation.Stop();
            playerAnimation.Stop();
            playerIdleAnimation.Stop();
            playerRecoilAnimation.PlayAll(0.2f);
        }

        public void recoilPlayerBackward()
        {
            this.idleCounter = 0;
            recoilBackward = true;
            isIdle = false;
            playerRecoilAnimation.SetMoveLeft();

            playerAttackAnimation.Stop();
            playerAttack2Animation.Stop();
            playerAttack3Animation.Stop();
            playerAnimation.Stop();
            playerIdleAnimation.Stop();
            playerRecoilAnimation.PlayAll(0.2f);
        }

        public float getForwardSpeed()
        {
            return forwardSpeed;
        }

        public ThrowObjects getThrowableObject()
        {
            return this.inventoryObject;
        }

        public Rectangle getPlayerPickupBounds()
        {
            return playerPickupBounds;
        }
    }
}
