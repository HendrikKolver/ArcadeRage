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
    class PunchingBag : Enemy
    {
        public Animation enemyRecoilReverseAnimation;
        public Animation deathForwardAnimation;
        public Animation deathBackwardAnimation;
        
        public Random r = new Random();
        public PunchingBag(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
            : base(device, position, sprite, thumbnail, player, itemToDrop, particleSystem, particleSystem2)
        {
            enemyRecoilReverseAnimation = new Animation(position);
            deathForwardAnimation = new Animation(position);
            deathBackwardAnimation = new Animation(position);
            damage = damage * 1.2;
            hitpoints = hitpoints * 3;
            startingHitPoints = hitpoints;
            //double tmp = r.NextDouble() / 2;
            //Console.WriteLine(tmp);
            speed = 0;
            delaySpeed = (int)(delaySpeed * 1.8);
            WalkAnimationSpeed = 1.1f;
        }

        private void addCells()
        {
            //Forward
            for (int i = 0; i < enemyRecoilAnimation.cellList.Count; i++)
                deathForwardAnimation.AddCell(enemyRecoilAnimation.cellList[i].cell);
            for (int i = 0; i < enemyDeathAnimation.cellList.Count; i++)
                deathForwardAnimation.AddCell(enemyDeathAnimation.cellList[i].cell);

            //Backward
            for (int i = 0; i < enemyRecoilReverseAnimation.cellList.Count; i++)
                deathBackwardAnimation.AddCell(enemyRecoilReverseAnimation.cellList[i].cell);
            for (int i = 0; i < enemyDeathAnimation.cellList.Count; i++)
                deathBackwardAnimation.AddCell(enemyDeathAnimation.cellList[i].cell);
        }

        public override void punchingBagDeath()
        {
            addCells();
        }

        public override void Draw(SpriteBatch batch)
        {

            enemyRecoilAnimation.SetMoveRight();
            enemyRecoilReverseAnimation.SetMoveRight();

            if (recoilForward && hasRecoilAnimation && !dying)
            {
                enemyRecoilReverseAnimation.SetPosition(position);
                enemyRecoilReverseAnimation.Draw(batch);
            }
            else if (recoilBackward && hasRecoilAnimation && !dying)
            {
                enemyRecoilAnimation.SetPosition(position);
                enemyRecoilAnimation.Draw(batch);
            }
            else if (dying)
            {
                if (position.X < player.position.X)
                {
                    deathBackwardAnimation.SetPosition(position);
                    deathBackwardAnimation.Draw(batch);
                }
                else
                {
                    deathForwardAnimation.SetPosition(position);
                    deathForwardAnimation.Draw(batch);
                }
            }else
            {
                enemyRecoilAnimation.SetPosition(position);
                enemyRecoilAnimation.Draw(batch);
                enemyRecoilAnimation.Stop();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!playerDied && !dying)
            {
                if (position.X >= 1300 || position.X <= -200)
                    isOffScreen = true;
                else
                    isOffScreen = false;

                if (recoilForward)
                {
                    recoilCounter++;
                    if (recoilCounter >= 24)
                    {
                        recoilCounter = 0;
                        recoilForward = false;
                    }
                }
                else if (recoilBackward)
                {
                    recoilCounter++;
                    if (recoilCounter >= 24)
                    {
                        recoilCounter = 0;
                        recoilBackward = false;
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
                enemyRecoilReverseAnimation.Update(gameTime);
            }
            else
            {
                deathForwardAnimation.Update(gameTime);
                deathBackwardAnimation.Update(gameTime);
            }
            if (dying)
                dieLoop();
        }

        public override void addRecoilReverseCells(Texture2D[] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                enemyRecoilReverseAnimation.AddCell(cells[i]);
            }
        }

        public override void recoilEnemyBackward()
        {
            enemyRecoilReverseAnimation.Stop();
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilBackward = true;
            if (this.hasRecoilAnimation)
            {
                this.enemyRecoilAnimation.SetMoveLeft();
                this.enemyRecoilAnimation.PlayAll(0.4f);
            }
        }

        public override void recoilEnemyForward()
        {
            enemyRecoilAnimation.Stop();
            enemyAttackAnimation.Stop();
            hitCounter = 0;
            atacking = false;
            registerHit = false;
            recoilForward= true;
            if (this.hasRecoilAnimation)
            {
                this.enemyRecoilReverseAnimation.SetMoveLeft();
                this.enemyRecoilReverseAnimation.PlayAll(0.4f);
            }
        }

        public override void die(Enemy[] enemies, int index)
        {
            this.drawThumbNail = false;
            Console.WriteLine("HERE");
            dying = true;
            deathForwardAnimation.PlayAll(1.0f);
            deathBackwardAnimation.PlayAll(1.0f);

            enemyAttackAnimation.Stop();
            enemyRecoilAnimation.Stop();
            enemyWalkAnimation.Stop();
            enemyIdleAnimation.Stop();
            dying = true;
            this.enemies = enemies;
            enemyIndex = index;
            enemyBounds = new Rectangle(0, 0, 0, 0);
        }


        public override void takeDamage(Weapon weapon, double amount)
        {
            if (weapon.getType().Equals("Strength"))
            {
                base.takeDamage(weapon, amount * 0.6);
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
            hitCount++;
        }

        protected override void displayBloodDamage()
        {

        }

        public override void dropItems()
        {

        }
    }
}
