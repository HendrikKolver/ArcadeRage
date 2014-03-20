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
    class StrengthEnemy : Enemy
    {
        public Random r = new Random();
        public StrengthEnemy(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
            : base(device, position, sprite, thumbnail, player, itemToDrop, particleSystem, particleSystem2)
        {
            deathAdjustment = new Vector2(-100, 0);
            damage = damage * 1.2;
            hitpoints = hitpoints * 1.2;
            startingHitPoints = hitpoints;
            //double tmp = r.NextDouble() / 2;
            //Console.WriteLine(tmp);
            speed = (float)(speed * 0.8);
            delaySpeed = (int)(delaySpeed * 1.8);
            WalkAnimationSpeed = 1.1f;
            attackAnimationSpeed = 0.4f;
            recoilAmount = 3;
            type = "Strength";
        }

        public override void setDificulty(int dif)
        {
            difficulty = dif;
            switch (dif)
            {
                case 0:
                    {
                        damage = 8;
                        damage = damage * 1.2;
                        hitpoints = 60;
                        hitpoints = hitpoints * 1.2;
                        break;
                    }
                case 1:
                    {
                        damage = 10;
                        damage = damage * 1.2;
                        hitpoints = 90;
                        hitpoints = hitpoints * 1.2;
                        break;
                    }
                case 2:
                    {
                        damage = 14;
                        damage = damage * 1.2;
                        hitpoints = 120;
                        hitpoints = hitpoints * 1.2;
                        break;
                    }
                case 3: case 4:
                    {
                        damage = 17;
                        damage = damage * 1.2;
                        hitpoints = 145;
                        hitpoints = hitpoints * 1.2;
                        break;
                    }
            }
            startingHitPoints = hitpoints;
        }

        public override void takeDamage(Weapon weapon, double amount)
        {

            if (weapon.getType().Equals("Strength"))
            {
                base.takeDamage(weapon, amount * 0.3);
            }
            else if (weapon.getType().Equals("Agility"))
            {
                base.takeDamage(weapon, amount * 1.0);
            }
            else if (weapon.getType().Equals("Intelligence"))
            {
                base.takeDamage(weapon, amount * 1.4);
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
    }
}
