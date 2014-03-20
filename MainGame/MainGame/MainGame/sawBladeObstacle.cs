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
    class sawBladeObstacle : levelObstacle
    {
        public bool directionUp = false;
        

        public sawBladeObstacle(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Player player,EnemyList enemies, Texture2D t)
            : base(device, position, sprite, player, enemies, t)
        {
        
        }

        public override void move()
        {
            if (directionUp && position.Y > 500)
            {
                position.Y -= speed;
            }
            else if (directionUp && position.Y <= 500)
            {
                directionUp = false;
            }
            else if (!directionUp && position.Y < 800)
            {
                position.Y += speed;
            }
            else if (!directionUp && position.Y >= 800)
            {
                directionUp = true;
            }

            if (obstacleBounds.Intersects(player.getPlayerPickupBounds()) && hitCount>hitDelay)
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
        }
    }
}
