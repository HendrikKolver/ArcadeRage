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
    class EvilJP : Enemy
    {
        public Random r = new Random();
        public bool stageSet = false;
        public Animation changeUpAnimation;
        int currentStage = 0;
        bool changingAnimations = false;
        int changeCounter = 0;
        int changeSpeed = 0;
        

        public EvilJP(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
            : base(device, position, sprite, thumbnail, player, itemToDrop, particleSystem, particleSystem2)
        {
            deathAdjustment = new Vector2(-100, 0);
            damage = damage * 1.2;
            //hitpoints = hitpoints * 1.2;
            
            startingHitPoints = hitpoints;
            
            speed = (float)(speed * 1.4);
            delaySpeed = (int)(delaySpeed * 1.2);
            WalkAnimationSpeed = 0.8f;
            attackAnimationSpeed = 0.4f;
            recoilAmount = 3;
            type = "evilJP";
            //setStage();
            changeSpeed = 80;
            changingAnimations = false;
            deathSpeed = 5.0f;
        }

        public override void setStage(int stage)
        {
            changingAnimations = false;
            currentStage = stage;
            //Console.WriteLine(stage);
            if (stage == 0)
            {
                enemyWalkAnimation = Walk1Boss;
                enemyAttackAnimation = Attack1Boss;
                enemyIdleAnimation = Idle1Boss;
                enemyRecoilAnimation = Recoil1Boss;
                enemyDeathAnimation = deathBoss;
                changeUpAnimation = deathBoss;
                damage = 10;
                recoilBackward = false;
                recoilForward = false;
                recoilCounter = 0;
                
            }else if(stage == 1)
            {
                
                enemyWalkAnimation = Walk2Boss;
                enemyAttackAnimation = Attack2Boss;
                enemyIdleAnimation = Idle2Boss;
                enemyRecoilAnimation = Recoil2Boss;
                enemyDeathAnimation = deathBoss;
                changeUpAnimation = powerUp1;
                damage = 12;
                changingAnimations = true;
                changeUpAnimation.PlayAll(1.2f);
                

                if (lookingLeft)
                {
                    enemyWalkAnimation.SetMoveLeft();
                    enemyIdleAnimation.SetMoveLeft();
                    enemyRecoilAnimation.SetMoveLeft();
                    enemyAttackAnimation.SetMoveLeft();
                    if (changeUpAnimation != null)
                        changeUpAnimation.SetMoveLeft();
                }
                else
                {
                    enemyWalkAnimation.SetMoveRight();
                    enemyIdleAnimation.SetMoveRight();
                    enemyRecoilAnimation.SetMoveRight();
                    enemyAttackAnimation.SetMoveRight();
                    if (changeUpAnimation!=null)
                        changeUpAnimation.SetMoveRight();
                }
            }
            else if (stage == 2)
            {
                enemyWalkAnimation = Walk3Boss;
                enemyAttackAnimation = Attack3Boss;
                enemyIdleAnimation = Idle3Boss;
                enemyRecoilAnimation = Recoil3Boss;
                enemyDeathAnimation = deathBoss;
                changeUpAnimation = powerUp2;
                damage = 14;
                changingAnimations = true;
                changeUpAnimation.PlayAll(1.2f);

                if (lookingLeft)
                {
                    enemyWalkAnimation.SetMoveLeft();
                    enemyIdleAnimation.SetMoveLeft();
                    enemyRecoilAnimation.SetMoveLeft();
                    enemyAttackAnimation.SetMoveLeft();
                }
                else
                {
                    enemyWalkAnimation.SetMoveRight();
                    enemyIdleAnimation.SetMoveRight();
                    enemyRecoilAnimation.SetMoveRight();
                    enemyAttackAnimation.SetMoveRight();
                }
            }

            
        }

        public override void setDificulty(int dif)
        {  
            damage = 10;
            hitpoints = 6000;
            startingHitPoints = hitpoints;
        }

        public override void Update(GameTime gameTime)
        {
            if (!player.playerDied)
            {
                if (!stageSet)
                {
                    stageSet = true;
                    setStage(0);
                }
                if (Stunned)
                {
                    //Console.WriteLine("Stunned!!!!!!!!!!!!!!!!!!!!");
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
                        delaySpeed = (int)(60 * 1.8);
                        Stunned = false;
                        delayAttack = false;

                        for (int i = 0; i < 1; i++)
                        {
                            stunStars[i].Start = false;
                            stunStars[i].stars.Stop();
                        }
                    }
                }

                if (changingAnimations)
                {
                    
                    changeCounter++;
                    

                    if (changeCounter >= changeSpeed)
                    {
                        recoilBackward = false;
                        recoilForward = false;
                        recoilCounter = 0;
                        changingAnimations = false;
                        changeCounter = 0;
                    }
                }

                if (!playerDied && !dying && !changingAnimations)
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
                        if (currentStage == 0)
                        {
                            int choice = RandomClass.r.Next(3);
                            switch (choice)
                            {
                                case 0:
                                    {
                                    enemyAttackAnimation = Attack1Boss;
                                    break;
                                    }
                                case 1:
                                    {
                                        enemyAttackAnimation = Attack1BossVar1;
                                        break;
                                    }
                                case 2:
                                    {
                                        enemyAttackAnimation = Attack1BossVar2;
                                        break;
                                    }
                            }
                        }
                        else if (currentStage == 1)
                        {
                            int choice = RandomClass.r.Next(2);
                            switch (choice)
                            {
                                case 0:
                                    {
                                        enemyAttackAnimation = Attack2Boss;
                                        break;
                                    }
                                case 1:
                                    {
                                        enemyAttackAnimation = Attack2BossVar1;
                                        break;
                                    }  
                            }
                        }
                        else if (currentStage == 2)
                        {
                            int choice = RandomClass.r.Next(2);
                            switch (choice)
                            {
                                case 0:
                                    {
                                        enemyAttackAnimation = Attack3Boss;
                                        break;
                                    }
                                case 1:
                                    {
                                        enemyAttackAnimation = Attack3BossVar1;
                                        break;
                                    }
                            }
                        }

                        if (lookingLeft)
                        {
                            enemyAttackAnimation.SetMoveLeft();
                        }
                        else
                        {
                            enemyAttackAnimation.SetMoveRight();
                        }

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
                    enemyBounds.X += 200;
                    enemyBounds.Y = (int)position.Y;
                    enemyBounds.Y += 195;
                    attackBounds.X = (int)position.X;
                    attackBounds.X += 235;
                    attackBounds.Y = (int)position.Y;
                    attackBounds.Y += 195;

                    enemyRecoilAnimation.Update(gameTime);
                    enemyWalkAnimation.Update(gameTime);
                    enemyAttackAnimation.Update(gameTime);
                    enemyIdleAnimation.Update(gameTime);

                    if (changeUpAnimation!= null)
                        changeUpAnimation.Update(gameTime);

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

        public override void Draw(SpriteBatch batch)
        {
            if (changingAnimations)
            {
                
                //if (changeUpAnimation.playing)
                    //Console.WriteLine("playing");
                //changeUpAnimation.SetPosition(position);
                changeUpAnimation.SetPosition(new Vector2(position.X, position.Y - 200));
                changeUpAnimation.Draw(batch);
            }
            else if (dying)
            {
                if (enemyDeathAnimation.currentCell >= 125)
                {
                    BGExtras.credits.isPlaying = true;  //Time to play the credits
                }
                else
                    Console.WriteLine(enemyDeathAnimation.currentCell);
                
                enemyDeathAnimation.SetPosition(new Vector2(position.X + deathAdjustment.X, position.Y + deathAdjustment.Y));
                enemyDeathAnimation.Draw(batch);
            }
            else if (atacking)
            {
                if (currentStage == 2)
                {
                    enemyAttackAnimation.SetPosition(new Vector2(position.X - 50, position.Y - 50));
                }
                else if(currentStage == 1)
                    enemyAttackAnimation.SetPosition(new Vector2(position.X - 50, position.Y));
                else
                    enemyAttackAnimation.SetPosition(position);

                enemyAttackAnimation.Draw(batch);
            }
            else if ((recoilForward || recoilBackward))
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
            drawHUD(batch);
        }

        public void drawHUD(SpriteBatch batch)
        {
            int height = 38;
            int HP = (int)this.hitpoints;
            if (this.currentStage == 0) //Fist HuD
            {
                double width = (((HP - 4000.0) / 2000.0) * 188.0);
                Rectangle drawHere = new Rectangle(600, 107, (int)width, height);  //Empty Health
                batch.Draw(BGExtras.emptyJPHealth, new Vector2(0, 0), Color.White);
                batch.Draw(BGExtras.blueHP, drawHere, Color.White);
                batch.Draw(BGExtras.hud1, new Vector2(0, 0), Color.White);
            }
            else if (this.currentStage == 1) //Gloves HuD
            {
                double width = (((HP - 2000.0) / 2000.0) * 185.0);
                Rectangle drawHere = new Rectangle(415, 107, (int)width, height);  //Empty Health
                batch.Draw(BGExtras.emptyJPHealth, new Vector2(0, 0), Color.White);
                batch.Draw(BGExtras.purpleHP, drawHere, Color.White);
                batch.Draw(BGExtras.hud2, new Vector2(0, 0), Color.White);
            }
            else if (this.currentStage == 2) //LightSaber HuD
            {
                double width = (((HP - 0.0) / 2000.0) * 186.0);
                Rectangle drawHere = new Rectangle(227, 107, (int)width, height);  //Empty Health
                batch.Draw(BGExtras.emptyJPHealth, new Vector2(0, 0), Color.White);
                batch.Draw(BGExtras.redHP, drawHere, Color.White);
                batch.Draw(BGExtras.hud3, new Vector2(0, 0), Color.White);
            }
        }

        public override void recoilEnemyForward()
        {
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilForward = true;
            
            enemyRecoilAnimation.SetMoveRight();
            
            this.enemyRecoilAnimation.PlayAll(0.3f);
           
        }

        public override void recoilEnemyBackward()
        {
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilBackward = true;
            
            this.enemyRecoilAnimation.SetMoveLeft();
            this.enemyRecoilAnimation.PlayAll(0.3f);
            
        }

        public override void takeDamage(Weapon weaponType, double amount)
        {
            if (!changingAnimations)
            {
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
                if (this.speed != 0)
                    addBloodSplash(weaponType.name);

                if (hitpoints > 0)
                {
                    displayBloodDamage();
                }
            }
            // drawThumbNail = true;

        }
    }
}
