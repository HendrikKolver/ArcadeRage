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
    class Enemy
    {
        //boss Stuff--------------------------------------------------
        public Animation Attack1Boss;
        public Animation Attack1BossVar1;
        public Animation Attack1BossVar2;
        public Animation Attack2Boss;
        public Animation Attack2BossVar1;
        public Animation Attack3Boss;
        public Animation Attack3BossVar1;
        public Animation Walk1Boss;
        public Animation Walk2Boss;
        public Animation Walk3Boss;
        public Animation Idle1Boss;
        public Animation Idle2Boss;
        public Animation Idle3Boss;
        public Animation Recoil1Boss;
        public Animation Recoil2Boss;
        public Animation Recoil3Boss;
        public Animation deathBoss;
        public Animation powerUp1;
        public Animation powerUp2;

        //-----------------------------------------------------------
        public List<StunStar> stunStars;

        public float deathSpeed;
        public Vector2 deathAdjustment;
        public int attackXAdjustment = 235;
        public int boundsXAdjustment = 200;

        public bool Stunned = false;
        public int stunStarWait = 0;
        public int stunTimer = 0;
        public int maxStun = 0;
        public int stunChance = 0;
        protected int recoilAmount;
        protected float attackAnimationSpeed;
        protected int difficulty;
        public double hudCount;
        public bool drawThumbNail = false;

        public bool dropItemOnDeath = true;
        public int hitCount = 0;
        public IntelligenceProjectile projectile;
        public bool playerDied = false;
        protected Enemy[] enemies;
        protected int enemyIndex;

        public SpriteFont dropItemFont;
        

        public int dyingCounter = 0;
        public bool dying = false;
        public bool dead = false;

        public bool registerHit = false;

        protected double scrollSpeed;
        protected int hitCounter;
        protected int hitSpeed;
        protected Rectangle enemyBounds;
        protected Rectangle attackBounds;
        protected bool recoilForward = false;
        protected bool recoilBackward = false;
        protected int recoilCounter;
        protected Random r;
        protected bool updateDeath = false;
        protected bool isOffScreen = true;

        protected double damage;
        protected double hitpoints;
        protected double startingHitPoints;
        public double speed;
        protected Player player;

        protected int delayTimer = 0;
        protected bool delayAttack = false;
        protected int delaySpeed = 60;

        public Vector2 position;
        protected Texture2D[] enemySprite;
        public Texture2D thumbnail;
        protected Vector2 spriteOrigin;
        protected int windowWidth, windowHeight;

        protected DropItems itemToDrop;
        protected GraphicsDevice device;

        protected Animation enemyRecoilAnimation;
        protected Animation enemyWalkAnimation;
        protected Animation enemyAttackAnimation;
        public Animation enemyDeathAnimation;
        protected Animation enemyIdleAnimation;

        public bool hasIdleAnimation = false;
        public bool hasAttackAnimation = false;
        public bool hasDeathAnimation = false;
        public bool atacking = false;
        protected float WalkAnimationSpeed;
        protected bool lookingLeft = false;

        protected int attackDelay = 0;

        BasicParticleSystem particleSystem;
        BasicParticleSystem particleSystem2;
        Random speedRandom = new Random();

        public bool hasRecoilAnimation = false;    //Temporary variable until all recoil animations are drawn
        protected bool startDelay = false;

        public String type = "NONE";

        public Enemy(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
        {
            deathAdjustment = new Vector2(0, 0);

            stunStars = new List<StunStar>();
            for (int i = 0; i < 1; i++)
            {
                stunStars.Add(new StunStar());
            }

            deathSpeed = 1.0f;

            recoilAmount = 5;
            attackAnimationSpeed = 0.7f;
            this.particleSystem = particleSystem;
            this.particleSystem2 = particleSystem2;
            this.device = device;
            scrollSpeed = 0;
            recoilCounter = 0;
            this.itemToDrop = itemToDrop;
            this.player = player;
            // The position that is passed in is now set to the position above
            this.position = position;
            // Set the Texture2D
            enemySprite = sprite;
            this.thumbnail = thumbnail;
            r = new Random();

            // Setup origin
            spriteOrigin.X = (float)enemySprite[0].Width / 2.0f;
            spriteOrigin.Y = (float)enemySprite[0].Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            enemyBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 70, 100);
            attackBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 2, 100);

            damage = 8;
            hitpoints = 60;

            double tmpSpeed = (RandomClass.r.NextDouble() / 2) + 1.35;
            //Console.WriteLine(tmpSpeed);
            speed = tmpSpeed;

            hitSpeed = 25;
            hitCounter = 0;

            enemyWalkAnimation = new Animation(position);
            for (int i = 0; i < enemySprite.Length; i++)
            {
                enemyWalkAnimation.AddCell(enemySprite[i]);
            }
            enemyRecoilAnimation = new Animation(position);
            enemyAttackAnimation = new Animation(position);
            enemyDeathAnimation = new Animation(position);
            enemyIdleAnimation = new Animation(position);
            
        }

        public virtual void setDificulty(int dif)
        {
            switch (dif)
            {
                case 0:
                    {
                        damage = 8;
                        hitpoints = 60;
                        break;
                    }
                case 1:
                    {
                        damage = 10;
                        hitpoints = 90;
                        break;
                    }
                case 2:
                    {
                        damage = 14;
                        hitpoints = 120;
                        break;
                    }
                case 3: case 4:
                    {
                        damage = 17;
                        hitpoints = 145;
                        break;
                    }


            }
        }



        public void addRecoilCells(Texture2D[] cells)
        {
            hasRecoilAnimation = true;
            for (int i = 0; i < cells.Length; i++)
            {
                enemyRecoilAnimation.AddCell(cells[i]);
            }
        }

        public virtual void addRecoilReverseCells(Texture2D[] cells)
        {
            /*for (int i = 0; i < cells.Length; i++)
            {
                enemyRecoilAnimation.AddCell(cells[i]);*/
        }

        public void addAttackCells(Texture2D[] cells)
        {
            hasAttackAnimation = true;
            for (int i = 0; i < cells.Length; i++)
            {
                enemyAttackAnimation.AddCell(cells[i]);
            }
        }

        public void addDeathCells(Texture2D[] cells)
        {
            hasDeathAnimation = true;
            for (int i = 0; i < cells.Length; i++)
            {
                enemyDeathAnimation.AddCell(cells[i]);
            }
        }

        public void addIdleCells(Texture2D[] cells)
        {
            hasIdleAnimation = true;
            for (int i = 0; i < cells.Length; i++)
            {
                enemyIdleAnimation.AddCell(cells[i]);
            }
        }

        public virtual void punchingBagDeath()
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (dying && hasDeathAnimation)
            {
                
                enemyDeathAnimation.SetPosition(new Vector2(position.X + deathAdjustment.X, position.Y + deathAdjustment.Y));
                enemyDeathAnimation.Draw(batch);
            }
            else if (atacking && hasAttackAnimation)
            {
                
                enemyAttackAnimation.SetPosition(position);
                enemyAttackAnimation.Draw(batch);
            }
            else if ((recoilForward || recoilBackward) && hasRecoilAnimation)
            {
                
                enemyRecoilAnimation.SetPosition(position);
                enemyRecoilAnimation.Draw(batch);
            }
            else if (delayAttack || startDelay)
            {
                
                enemyIdleAnimation.SetPosition(position);
                enemyIdleAnimation.Draw(batch);
            }
            else
            {
                
                enemyWalkAnimation.SetPosition(position);
                enemyWalkAnimation.Draw(batch);
            }

            for (int i = 0; i < 1; i++)
            {
                if (!dying)
                {
                    stunStars[i].Draw(batch);
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!player.playerDied)
            {
                if (Stunned)
                {

                    stunTimer++;
                    stunStarWait++;
                    for (int i = 0; i < 1; i++)
                    {
                        if (stunStarWait >= 40 && !stunStars[i].Start)
                        {
                            stunStars[i].position.X = position.X + 60;
                            stunStars[i].position.Y = position.Y - 150;
                            stunStars[i].tmpFont = dropItemFont;
                            stunStars[i].Start = true;
                        }
                    }

                    if (stunTimer >= maxStun)
                    {
                        stunTimer = 0;
                        delaySpeed = 60;
                        Stunned = false;
                        delayAttack = false;

                        for (int i = 0; i < 1; i++)
                        {
                            stunStars[i].Start = false;
                            stunStars[i].stars.Stop();
                        }
                    }
                }

                if (!playerDied && !dying)
                {
                    if (position.X >= 1300 || position.X <= -200)
                        isOffScreen = true;
                    else
                        isOffScreen = false;

                    if (recoilForward)
                    {
                        recoilCounter++;
                        position.X -= recoilAmount;
                        if (recoilCounter >= 24)
                        {
                            recoilCounter = 0;
                            recoilForward = false;
                        }
                    }
                    else if (recoilBackward)
                    {
                        recoilCounter++;
                        position.X += recoilAmount;
                        if (recoilCounter >= 24)
                        {
                            recoilCounter = 0;
                            recoilBackward = false;
                        }
                    }
                    else
                        if (position.X >= player.getPosition().X + 100)
                        {
                            if (!delayAttack)
                                Forward();
                        }
                        else if (position.X <= player.getPosition().X - 70)
                        {
                            if (!delayAttack)
                                Backward();
                        }

                    if (position.Y >= player.getPosition().Y + 2)
                    {
                        if (!delayAttack)
                            Up();
                    }
                    else if (position.Y <= player.getPosition().Y + 2)
                    {
                        if (!delayAttack)
                            Down();
                    }

                    if (delayAttack)
                    {
                        enemyIdleAnimation.PlayAll(1.2f);
                        delayTimer++;
                        if (delayTimer >= delaySpeed)
                        {
                            delayAttack = false;
                        }
                    }

                    if ((attackBounds.Intersects(player.getPlayerBounds()) && !player.recoilBackward && !player.recoilForward) && !atacking && !delayAttack && !isOffScreen)
                    {
                        delayTimer = 0;
                        delayAttack = true;
                        atacking = true;
                        enemyAttackAnimation.PlayAll(attackAnimationSpeed);
                    }

                    if (atacking)
                    {
                        hitCounter++;

                        if (hitCounter == hitSpeed - 10)
                        {
                            registerHit = true;
                        }
                        else
                            if (hitCounter >= hitSpeed)
                            {
                                atacking = false;
                                hitCounter = 0;
                            }
                    }

                    if (registerHit)
                    {
                        if (attackBounds.Intersects(player.getPlayerBounds()) && !player.recoilBackward && !player.recoilForward)
                        {
                            player.takeDamage(damage);
                            //Console.WriteLine("player Hitpoints: " + player.getHitpoints());

                            registerHit = false;
                            if (position.X >= player.getPosition().X)
                            {
                                player.recoilPlayerForward();
                            }
                            else
                            {
                                player.recoilPlayerBackward();
                            }
                        }
                        else
                        {
                            registerHit = false;
                        }
                    }
                }
                if (!dying)
                {
                    enemyBounds.X = (int)position.X;
                    enemyBounds.X += boundsXAdjustment;
                    enemyBounds.Y = (int)position.Y;
                    enemyBounds.Y += 195;
                    attackBounds.X = (int)position.X;
                    attackBounds.X += attackXAdjustment;
                    attackBounds.Y = (int)position.Y;
                    attackBounds.Y += 195;

                    enemyRecoilAnimation.Update(gameTime);
                    enemyWalkAnimation.Update(gameTime);
                    enemyAttackAnimation.Update(gameTime);
                    enemyIdleAnimation.Update(gameTime);

                    for (int i = 0; i < 1; i++)
                    {
                        stunStars[i].update(gameTime);
                        stunStars[i].position.X = position.X + 60;
                    }
                }
                else
                {
                    enemyDeathAnimation.Update(gameTime);
                }

                if (dying)
                {
                    dieLoop();
                }
            }
        }

        public virtual void die(Enemy[] enemies, int index)
        {
            drawThumbNail = false;

            if (lookingLeft)
                enemyDeathAnimation.SetMoveLeft();
            else
            {
                enemyDeathAnimation.SetMoveRight();
            }
            enemyDeathAnimation.PlayAll(deathSpeed);
            enemyAttackAnimation.Stop();
            enemyRecoilAnimation.Stop();
            enemyWalkAnimation.Stop();
            enemyIdleAnimation.Stop();
            dying = true;
            this.enemies = enemies;
            enemyIndex = index;
            enemyBounds = new Rectangle(0, 0, 0, 0);

            //
        }

        public void dieLoop()
        {
            dyingCounter++;
            if (dyingCounter == 30)
            {
                dead = true;
                //enemyDeathAnimation.Stop();
                // enemies[enemyIndex] = null;
            }
        }

        public void Forward()
        {
            Rectangle tmpBounds = enemyBounds;
            tmpBounds.X -= (int)(((2.0 * speed) + scrollSpeed)*2);
            if (BGExtras.teslaCoil != null && tmpBounds.Intersects(BGExtras.teslaCoil.enemyBounds) && BGExtras.teslaCoil.display)
            {
                delayAttack = true;
                startDelay = true;
                delayTimer = 0;
                attackDelay = 0;
            }
            else
            {
                startDelay = false;
                delayAttack = false;
                lookingLeft = true;
                enemyWalkAnimation.SetMoveLeft();
                enemyAttackAnimation.SetMoveLeft();
                enemyIdleAnimation.SetMoveLeft();
                enemyWalkAnimation.LoopAll(WalkAnimationSpeed);
                
                position.X -= (float)((2.0 * speed) + scrollSpeed);
            }
        }
        public void Backward()
        {
            Rectangle tmpBounds = enemyBounds;
            tmpBounds.X += (int)(((2.0 * speed) + scrollSpeed) * 2);
            if (BGExtras.teslaCoil != null && tmpBounds.Intersects(BGExtras.teslaCoil.enemyBounds) && BGExtras.teslaCoil.display)
            {
                
                delayAttack = true;
                startDelay = true;
                delayTimer = 0;
                attackDelay = 0;

            }
            else
            {
                
                startDelay = false;
                delayAttack = false;
                lookingLeft = false;
                enemyWalkAnimation.SetMoveRight();
                enemyAttackAnimation.SetMoveRight();
                enemyIdleAnimation.SetMoveRight();
                enemyWalkAnimation.LoopAll(WalkAnimationSpeed);
                
                position.X += (float)((2.0 * speed) + scrollSpeed);
            }
        }

        public void Up()
        {
            Rectangle tmpBounds = enemyBounds;

            if (BGExtras.teslaCoil != null && tmpBounds.Intersects(BGExtras.teslaCoil.enemyBounds) && BGExtras.teslaCoil.display)
            {
                delayAttack = true;
                startDelay = true;
                delayTimer = 0;
                attackDelay = 0;
            }
            else
            {
                startDelay = false;
                delayAttack = false;
                enemyWalkAnimation.LoopAll(WalkAnimationSpeed);
                position.Y -= (float)(0.5 * speed);
            }
        }
        public void Down()
        {
            Rectangle tmpBounds = enemyBounds;

            if (BGExtras.teslaCoil != null && tmpBounds.Intersects(BGExtras.teslaCoil.enemyBounds) && BGExtras.teslaCoil.display)
            {
                delayAttack = true;
                startDelay = true;
                delayTimer = 0;
                attackDelay = 0;
            }
            else
            {
                startDelay = false;
                delayAttack = false;
                enemyWalkAnimation.LoopAll(WalkAnimationSpeed);
                position.Y += (float)(0.5 * speed);
            }
        }



        public virtual void recoilEnemyForward()
        {
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilForward = true;
            if (this.hasRecoilAnimation)
            {
                enemyRecoilAnimation.SetMoveRight();
                //this.enemyWalkAnimation.Stop();
                this.enemyRecoilAnimation.PlayAll(0.3f);
            }
        }

        public virtual void recoilEnemyBackward()
        {
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilBackward = true;
            if (this.hasRecoilAnimation)
            {
                this.enemyRecoilAnimation.SetMoveLeft();
                this.enemyRecoilAnimation.PlayAll(0.3f);
            }
        }

        public virtual void takeDamage(Weapon weaponType, double amount)
        {
            if (weaponType.stun != 0 && !Stunned)
            {
                int tmp = RandomClass.r.Next(weaponType.stunChance);
                Console.WriteLine(tmp);
                if (tmp == 1)
                {
                    Stunned = true;
                    maxStun = weaponType.stun;
                    delaySpeed = maxStun;
                    delayAttack = true;

                }
            }

            if (position.X >= player.getPosition().X)   //Play animation for recoil
            {
                recoilBackward = true;
                recoilEnemyBackward();
            }
            else
            {
                recoilForward = true;
                recoilEnemyForward();
            }
            hitpoints -= amount;
            if(this.speed !=0)
                addBloodSplash(weaponType.name);

            if (hitpoints > 0)
            {
                displayBloodDamage();
            }
            
           // drawThumbNail = true;
                
        }

        public void addBloodSplash(String weaponName)
        {
            int displaySplash = RandomClass.r.Next(4);
            int heightVariation = -25 + RandomClass.r.Next(50);
            if (difficulty == 0)
            {
                //no blood on tut
            }
            else if (!weaponName.Equals("Fists"))
            {
                if (difficulty == 2)
                {
                    if (position.Y > 400)
                    {
                        BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 150 + heightVariation));
                    }
                    else if ((position.Y < 550))
                    {
                        
                            BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 100 + heightVariation));
                    }
                }
                else if (difficulty == 3)
                {
                    if (position.Y < 450)
                        BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 200 + heightVariation));
                }
                else
                {
                    if (position.Y > 400)
                    {
                        BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 150 + heightVariation));
                    }
                    else
                    {
                        Rectangle r = new Rectangle((int)position.X + 50, (int)position.Y - 50 + heightVariation, 100, 100);  //Blood spash check w:100, h:100 fixed
                        if (!r.Intersects(BGExtras.spinningGlobe.someBounds) && !r.Intersects(BGExtras.torches.someBounds) && !r.Intersects(BGExtras.torches2.someBounds))
                            BGExtras.allBloodSplashes.addRandomWallSplash(new Vector2(position.X + 50, position.Y - 50 + heightVariation));
                        else
                            BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 200 + heightVariation));
                    }
                }
            }
            else
            {
                if (displaySplash == 1)
                {
                    if (difficulty == 2)
                    {
                        if (position.Y > 400)
                        {
                            BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 150 + heightVariation));
                        }
                        else if ((position.Y < 550))
                        {

                            BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 100 + heightVariation));
                        }
                    }
                    else
                    {
                        if (position.Y > 400)
                        {
                            BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 150 + heightVariation));
                        }
                        else
                        {
                            Rectangle r = new Rectangle((int)position.X + 50, (int)position.Y - 50 + heightVariation, 100, 100);  //Blood spash check w:100, h:100 fixed
                            if (!r.Intersects(BGExtras.spinningGlobe.someBounds))
                                BGExtras.allBloodSplashes.addRandomWallSplash(new Vector2(position.X + 50, position.Y - 50 + heightVariation));
                            else
                                BGExtras.allBloodSplashes.addRandomFloorSplash(new Vector2(position.X + 100, position.Y + 200 + heightVariation));
                        }
                    }
                }
            }
        }

        public void takeThrowDamage(double amount)
        {
            if (position.X >= player.getPosition().X)
            {
                recoilBackward = true;
                recoilEnemyBackward();
            }
            else
            {
                recoilForward = true;
                recoilEnemyForward();
            }
            hitpoints -= amount;
            if (this.speed != 0)
                addBloodSplash("none"); ;
            if (hitpoints > 0)
                displayBloodDamage();
        }

        public void takeObstacleDamage(double amount)
        {
            if (enemyBounds.X >= BGExtras.teslaCoil.enemyBounds.X)
            {
                recoilBackward = true;
                recoilEnemyBackward();
            }
            else
            {
                recoilForward = true;
                recoilEnemyForward();
            }
            hitpoints -= amount;
            if (this.speed != 0)
                addBloodSplash("none");
            if (hitpoints > 0)
                displayBloodDamage();
        }

        protected virtual void displayBloodDamage()
        {
            //Console.WriteLine(enemyWalkAnimation.getDirection());
            

            if (enemyWalkAnimation.getDirection() == "right")
            {
                Vector2 tmp = new Vector2(position.X + 110, position.Y + 100);
                particleSystem.AddExplosion(tmp);
                particleSystem2.AddExplosion(tmp);
            }
            else
            {
                Vector2 tmp = new Vector2(position.X + 220, position.Y + 100);
                particleSystem.AddExplosion(tmp);
                particleSystem2.AddExplosion(tmp);
            }
        }

        protected virtual void displayBigBloodDamage()
        {
            //Console.WriteLine(enemyWalkAnimation.getDirection());

            if (enemyWalkAnimation.getDirection() == "right")
            {
                Vector2 tmp = new Vector2(position.X + 110, position.Y + 100);
                particleSystem.AddBigExplosion(tmp);
                particleSystem2.AddBigExplosion(tmp);
            }
            else
            {
                Vector2 tmp = new Vector2(position.X + 220, position.Y + 100);
                particleSystem.AddBigExplosion(tmp);
                particleSystem2.AddBigExplosion(tmp);
            }
        }

        public double getHitpoints()
        {
            return hitpoints;
        }

        public double getMaxHitPoints()
        {
            return startingHitPoints;
        }

        public double getDamage()
        {
            return damage;
        }

        public double getSpeed()
        {
            return speed;
        }

        public Rectangle getBounds()
        {
            return enemyBounds;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public double getScrollSpeed()
        {
            return scrollSpeed;
        }

        public void setScrollSpeed(double s)
        {
            scrollSpeed = s;
        }

        public virtual void dropItems()
        {
            //int tmp = RandomClass.r.Next(10);
            if (dropItemOnDeath)
            {
                Vector2 tmpVector = new Vector2(position.X + 100, position.Y + 200);
                DropItems tmpItem = new DropItems(itemToDrop.device, itemToDrop.position, itemToDrop.objectSprite, itemToDrop.craftingMenuSprite, itemToDrop.name);
                tmpItem.setPosition(tmpVector);
                tmpItem.DropItemFont = dropItemFont;
                InventoryHolder.tmpInventory.Add(tmpItem);
            }
           // Console.WriteLine(tmp);
        }

        public void AddWalkCell(Texture2D cellPicture)
        {
            enemyWalkAnimation.AddCell(cellPicture);
        }

        public virtual void addWeapon(IntelligenceProjectile ip)
        {

        }

        public virtual void setStage(int stage)
        {

        }



    }
}
