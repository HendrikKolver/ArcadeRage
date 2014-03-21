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
    class IntelligenceEnemy : Enemy
    {
        
        private bool inRange = false;
        private bool throwing = false;
        private int throwCount = 0;
        private bool left = false;
        private bool projectileMove = false;
        private int ThrowSpeed = 38;
        
        private int attackDelaySpeed = 80;
        //private bool startDelay = true;



        public IntelligenceEnemy(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
            : base(device, position, sprite, thumbnail, player, itemToDrop, particleSystem, particleSystem2)
        {
            damage = damage * 1.0;
            hitpoints = hitpoints * 1.0;
            startingHitPoints = hitpoints;

            speed = (float)(speed * 1.0);
            delaySpeed = (int)(delaySpeed * 0.8);

            WalkAnimationSpeed = 1f;
            startDelay = true;
            type = "Intelligence";
        }

        public override void setDificulty(int dif)
        {
            difficulty = dif;
            switch (dif)
            {
                case 0:
                    {
                        damage = 8;
                        damage = damage * 1.0;
                        hitpoints = 60;
                        hitpoints = hitpoints * 1.0;
                        break;
                    }
                case 1:
                    {
                        damage = 10;
                        damage = damage * 1.0;
                        hitpoints = 90;
                        hitpoints = hitpoints * 1.0;
                        break;
                    }
                case 2:
                    {
                        damage = 14;
                        damage = damage * 1.0;
                        hitpoints = 120;
                        hitpoints = hitpoints * 1.0;
                        break;
                    }
                case 3: case 4:
                    {
                        damage = 17;
                        damage = damage * 1.0;
                        hitpoints = 145;
                        hitpoints = hitpoints * 1.0;
                        break;
                    }
            }
            startingHitPoints = hitpoints;
        }

        public override void takeDamage(Weapon weapon, double amount)
        {
            if (weapon.getType().Equals("Strength"))
            {
                base.takeDamage(weapon, amount * 1.0);
            }
            else if (weapon.getType().Equals("Agility"))
            {
                base.takeDamage(weapon, amount * 1.4);
            }
            else if (weapon.getType().Equals("Intelligence"))
            {
                base.takeDamage(weapon, amount * 0.3);
            }
            else
            {
                base.takeDamage(weapon, amount * 1.0);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!player.playerDied)
            {
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
                    startDelay = true;
                    attackDelay = stunTimer;
                    attackDelaySpeed = maxStun;
                    if (stunTimer >= maxStun)
                    {
                        stunTimer = 0;
                        Stunned = false;
                        delayAttack = false;
                        attackDelaySpeed = 80;
                        //attackDelay = 0;

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
                        position.X -= 5;
                        if (recoilCounter >= 24)
                        {
                            recoilCounter = 0;
                            throwCount = 0;
                            recoilForward = false;
                            throwing = false;
                            inRange = false;
                            startDelay = true;
                            attackDelay = 0;
                        }
                    }
                    else if (recoilBackward)
                    {
                        recoilCounter++;
                        position.X += 5;
                        if (recoilCounter >= 24)
                        {
                            recoilCounter = 0;
                            throwCount = 0;
                            recoilBackward = false;
                            throwing = false;
                            inRange = false;
                            startDelay = true;
                            attackDelay = 0;
                        }
                    }
                    else if (position.X >= player.getPosition().X + 500 && (throwCount == 0 || throwCount >= ThrowSpeed))
                    {
                        if (!startDelay)
                            Forward();
                        inRange = false;

                    }
                    else if (position.X <= player.getPosition().X - 500 && (throwCount == 0 || throwCount >= ThrowSpeed))
                    {
                        if (!startDelay)
                            Backward();
                        inRange = false;

                    }
                    else
                    {
                        inRange = true;

                    }


                    //turn Around
                    if (position.X >= player.getPosition().X + 100)
                    {
                        lookingLeft = true;
                        enemyWalkAnimation.SetMoveLeft();
                        enemyAttackAnimation.SetMoveLeft();
                    }
                    else if (position.X <= player.getPosition().X - 60)
                    {
                        lookingLeft = false;
                        enemyWalkAnimation.SetMoveRight();
                        enemyAttackAnimation.SetMoveRight();
                    }

                    if (position.Y >= player.getPosition().Y + 2 && (throwCount == 0 || throwCount >= 40))
                    {
                        if (!startDelay)
                            Up();
                    }
                    else if (position.Y <= player.getPosition().Y + 2 && (throwCount == 0 || throwCount >= 40))
                    {
                        if (!startDelay)
                            Down();
                    }

                    if (position.Y <= player.getPosition().Y + 55 && position.Y >= player.getPosition().Y - 55)
                    {

                    }
                    else
                    {
                        inRange = false;
                    }

                    

                    //No Close range attack uncomment for close range attack and death
                    /*if (enemyBounds.Intersects(player.getPlayerBounds()))
                    {
                        if (enemyBounds.Intersects(player.getPlayerBounds()) && !player.recoilBackward && !player.recoilForward)
                        {

                            //we have a simple collision!
                        
                            hitCounter++;

                            if (hitCounter >= hitSpeed)
                            {
                                player.takeDamage(damage);
                                Console.WriteLine("player Hitpoints: " + player.getHitpoints());
                                hitCounter = 0;
                                if (position.X >= player.getPosition().X)
                                {
                                    //Console.WriteLine("here:");
                                    player.recoilPlayerForward();

                                }
                                else
                                {
                                    //Console.WriteLine("there:");
                                    player.recoilPlayerBackward();
                                }
                            }
                        }
                        else
                        {
                            hitCounter = 0;
                        }

                    }
                    else*/
                    
                    if (inRange && !throwing && !recoilBackward && !recoilForward && throwCount == 0 && attackDelay >= attackDelaySpeed && !isOffScreen)
                    {
                        attackDelay = 0;
                        if (!lookingLeft)
                        {
                            enemyAttackAnimation.SetMoveRight();
                            ////Console.WriteLine("moveRight");
                        }
                        else
                        {
                            enemyAttackAnimation.SetMoveLeft();
                            // Console.WriteLine("moveLeft");
                        }
                        enemyAttackAnimation.PlayAll(0.75f);
                        throwing = true;
                        throwCount = 0;
                        // Console.WriteLine("ThrwThrow!");
                        projectile.throwObject();
                    }

                    if (startDelay)
                    {
                        if (!lookingLeft)
                            enemyIdleAnimation.SetMoveRight();
                        else
                            enemyIdleAnimation.SetMoveLeft();
                        enemyWalkAnimation.Stop();
                        enemyIdleAnimation.PlayAll(0.8f);

                        attackDelay++;
                        if (attackDelay >= attackDelaySpeed)
                        {
                            startDelay = false;
                        }
                    }

                    if (throwing)
                    {
                        throwCount++;
                        if (throwCount == ThrowSpeed)
                        {
                            startDelay = true;
                            projectileMove = true;
                            //throwing = false;
                            projectile.position = position;
                            if (player.position.X < position.X)
                                left = true;
                            else
                            {
                                left = false;
                            }

                            if (!left)
                                projectile.position.X += 120;
                            else
                                projectile.position.X += 1;
                            projectile.position.Y += 50;

                        }
                    }
                }

                if (projectileMove)
                {

                    if (throwCount >= ThrowSpeed + 20)
                    {
                        throwing = false;
                    }

                    if (left)
                        projectile.position.X -= 10;
                    else
                    {
                        projectile.position.X += 10;
                    }



                    if (projectile.objectBounds.Intersects(player.playerProjectileBounds))
                    {
                        projectileMove = false;
                        throwing = false;
                        throwCount = 0;
                        projectile.position.X = -200;
                        projectile.position.Y = -200;
                        left = false;
                        player.takeDamage(damage);
                        //Console.WriteLine("player Hitpoints: " + player.getHitpoints());
                        if (position.X >= player.getPosition().X)
                        {
                            //Console.WriteLine("here:");
                            player.recoilPlayerForward();

                        }
                        else
                        {
                            //Console.WriteLine("there:");
                            player.recoilPlayerBackward();
                        }
                    }
                    else if (projectile.position.X < -50 || projectile.position.X > 1450)
                    {
                        projectileMove = false;
                        throwing = false;
                        throwCount = 0;
                        projectile.position.X = -200;
                        projectile.position.Y = -200;
                        left = false;
                    }
                }


                if (!dying)
                {
                    enemyBounds.X = (int)position.X;
                    enemyBounds.X += 200;
                    enemyBounds.Y = (int)position.Y;
                    enemyBounds.Y += 195;

                    for (int i = 0; i < 1; i++)
                    {
                        stunStars[i].update(gameTime);
                        stunStars[i].position.X = position.X + 60;
                    }
                }

                if (dying)
                {
                    dieLoop();
                }

                if (this.hasAttackAnimation)
                {
                    enemyAttackAnimation.Update(gameTime);
                }

                enemyWalkAnimation.Update(gameTime);
                if (this.hasRecoilAnimation)
                {
                    enemyRecoilAnimation.Update(gameTime);
                }
                if (this.hasIdleAnimation)
                {
                    enemyIdleAnimation.Update(gameTime);
                }


                this.projectile.setDirection(this.left);
                projectile.Update(gameTime);
                atacking = throwing;


                enemyDeathAnimation.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            projectile.Draw(batch);
        }
        public override void addWeapon(IntelligenceProjectile ip)
        {
            this.projectile = ip;
            this.projectile.setDirection(this.left);
        }
    }
}
