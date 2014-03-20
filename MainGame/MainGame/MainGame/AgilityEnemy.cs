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
    class AgilityEnemy : Enemy
    {
        public int xAdjustment = 0;
        public int yAdjustment = 0;
        public AgilityEnemy(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Texture2D thumbnail, Player player, DropItems itemToDrop, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
            : base(device, position, sprite, thumbnail, player, itemToDrop, particleSystem, particleSystem2)
        {
            damage = damage * 0.3;
            hitpoints = hitpoints * 0.6;
            startingHitPoints = hitpoints;
            speed = (float)(speed * 1.55);
            hitSpeed = (int)(hitSpeed * 0.8);
            WalkAnimationSpeed = 0.9f;
            type = "Agility";
            xAdjustment = 150;
            yAdjustment = 60; 
            //attackBounds = new Rectangle((int)(position.X + 125), (int)(position.Y), 100, 100);
            enemyBounds = new Rectangle((int)(position.X + 150), (int)(position.Y), 60, 100);
           // attackXAdjustment = 165;
            boundsXAdjustment = 180;
            deathSpeed = 0.8f;
            enemyWalkAnimation.Scale = 0.85f;
            enemyRecoilAnimation.Scale = 0.85f;
            enemyAttackAnimation.Scale = 0.85f;
            enemyDeathAnimation.Scale = 0.85f;
            enemyIdleAnimation.Scale = 0.85f;
            attackAnimationSpeed = 0.3f;
        }

        public override void setDificulty(int dif)
        {
            difficulty = dif;
            switch (dif)
            {
                case 0:
                    {
                        damage = 8;
                        damage = damage * 0.3;
                        hitpoints = 60;
                        hitpoints = hitpoints * 0.6;
                        break;
                    }
                case 1:
                    {
                        damage = 10;
                        damage = damage * 0.3;
                        hitpoints = 90;
                        hitpoints = hitpoints * 0.6;
                        break;
                    }
                case 2:
                    {
                        damage = 14;
                        damage = damage * 0.3;
                        hitpoints = 120;
                        hitpoints = hitpoints * 0.6;
                        break;
                    }
                case 3: case 4:
                    {
                        damage = 17;
                        damage = damage * 0.3;
                        hitpoints = 145;
                        hitpoints = hitpoints * 0.6;
                        break;
                    }
            }
            startingHitPoints = hitpoints;
        }

        public override void takeDamage(Weapon weapon, double amount)
        {
            if (weapon.getType().Equals("Strength"))
            {
                base.takeDamage(weapon, amount * 1.4);
            }
            else if (weapon.getType().Equals("Agility"))
            {
                base.takeDamage(weapon, amount * 0.3);
            }
            else if (weapon.getType().Equals("Intelligence"))
            {
                base.takeDamage(weapon, amount * 1.0);
            }
            else
            {
                base.takeDamage(weapon, amount * 1.0);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (dying && hasDeathAnimation)
            {
                Vector2 tmp = new Vector2(position.X - xAdjustment, position.Y);
                enemyDeathAnimation.SetPosition(tmp);
                enemyDeathAnimation.Draw(batch);
            }
            else if (atacking && hasAttackAnimation)
            {
                Vector2 tmp = new Vector2(position.X - xAdjustment, position.Y - yAdjustment);
                enemyAttackAnimation.SetPosition(tmp);
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
    }
}
