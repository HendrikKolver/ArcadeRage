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
    class TeslaObstacle : levelObstacle
    {
        
        public TeslaObstacle(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Player player, EnemyList enemies, Texture2D plainCoil)
            : base(device, position, sprite, player, enemies, plainCoil)
        {
            speed = 300;
            displaySpeed = 100;
            damage = 10f;
        }

        public override void move()
        {
            if (display == false)
            {
                if (speedCounter < speed)
                    speedCounter++;
                else
                {
                    if (playSound)
                        soundbank.PlayCue("ElectricShock");
                    display = true;
                    displaySpeedCounter = 0;
                }
            }
            else if (display)
            {
                if (displaySpeedCounter < displaySpeed)
                    displaySpeedCounter++;
                else
                {
                    display = false;
                    speedCounter = 0;
                }
            }

            if (display && obstacleBounds.Intersects(player.getPlayerPickupBounds()) && hitCount > hitDelay)
            {
                hitCount = 0;
                player.takeDamage(damage);
                
                if (!player.left)
                {
                    player.recoilPlayerForward();
                }
                else
                {
                    player.recoilPlayerBackward();
                }
            }

            for (int i = 0; i < enemies.getSize(); i++)
            {
                if (display && enemies.getAtIndex(i) !=null && enemyBounds.Intersects(enemies.getAtIndex(i).getBounds()) && hitCount > hitDelay)
                {
                    hitCount = 0;
                    enemies.getAtIndex(i).takeObstacleDamage(damage);
                    if (enemies.getAtIndex(i).getHitpoints() <= 0)
                    {
                        enemies.enemies[i].dropItems();
                        player.killEnemy(i);

                    }

                }
            }
        }
    }
}
