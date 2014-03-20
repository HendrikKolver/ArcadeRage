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
    class IntelligenceProjectile
    {
        public Rectangle objectBounds;
        public Vector2 position;
        public Texture2D objectSprite;
        public Vector2 spriteOrigin;
        public int windowWidth, windowHeight;
        public double damage;
        public float throwSpeed;
        
        public bool throwing = false;
        public bool left = false;

        bool binaryOne = false;

        private Animation projectile0L;
        private Animation projectile1L;
        private Animation projectile0R;
        private Animation projectile1R;

        Random randomSelect = new Random();

        
        public IntelligenceProjectile(GraphicsDevice device, Vector2 position, Texture2D sprite)
        {
            projectile0L = new Animation(position);
            projectile1L = new Animation(position);
            projectile0R = new Animation(position);
            projectile1R = new Animation(position);

            this.position = position;
            // Set the Texture2D
            objectSprite = sprite;

            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), 50, 105);

            damage = 60;
            throwSpeed = 12f;
        }

        public void setDirection(bool left)
        {
            this.left = left;
        }

        public void Draw(SpriteBatch batch)
        {
             
            if (this.left)
            {
                if (!binaryOne)
                {
                    projectile0L.SetPosition(position);
                    projectile0L.Draw(batch);
                }
                else
                {
                    projectile1L.SetPosition(position);
                    projectile1L.Draw(batch);
                }
            }
            else
            {
                if (binaryOne)
                {
                    projectile0R.SetPosition(position);
                    projectile0R.Draw(batch);
                }
                else
                {
                    projectile1R.SetPosition(position);
                    projectile1R.Draw(batch);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (throwing)
            {
                projectile0L.Update(gameTime);
                projectile1L.Update(gameTime);
                projectile0R.Update(gameTime);
                projectile1R.Update(gameTime);
            }
            objectBounds.X = (int)position.X;
            objectBounds.Y = (int)position.Y+115 ;
            
        }

        public Rectangle getBounds()
        {
            return objectBounds;
        }

        public void throwObject()
        {
            int num = randomSelect.Next(10);
            if (num < 5)
            {
                binaryOne = false;
            }
            else
            {
                binaryOne = true;
            }
            projectile0L.LoopAll(0.6f);
            projectile0R.LoopAll(0.6f);
            projectile1L.LoopAll(0.6f);
            projectile1R.LoopAll(0.6f);
            throwing = true;
        }

        public void addCell0L(Texture2D t)
        {
            projectile0L.AddCell(t);
        }

        public void addCell1L(Texture2D t)
        {
            projectile1L.AddCell(t);
        }

        public void addCell0R(Texture2D t)
        {
            projectile0R.AddCell(t);
        }

        public void addCell1R(Texture2D t)
        {
            projectile1R.AddCell(t);
        }
    }
    
}
