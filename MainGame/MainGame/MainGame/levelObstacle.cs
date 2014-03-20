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
    class levelObstacle
    {
        protected Player player;
        public Vector2 position;
        protected Texture2D[] obstacleSprite;
        protected Vector2 spriteOrigin;
        protected int windowWidth, windowHeight;
        protected EnemyList enemies;
        public SoundBank soundbank;
        public bool playSound = false;
        
        protected Animation obstacleAnimation;
        public Rectangle obstacleBounds;
        public Rectangle enemyBounds;
        protected float damage = 10f;
        protected int hitCount = 0;
        protected int hitDelay = 20;
        protected int speed = 2;
        protected int displaySpeed = 10;
        public int speedCounter =0;
        public int displayCounter = 0;
        public int displaySpeedCounter = 0;
        public bool display = false;
        public Texture2D plainTexture;

        public levelObstacle(GraphicsDevice device, Vector2 position, Texture2D[] sprite, Player player,EnemyList enemies, Texture2D plainTexture)
        {
            this.player = player;
            // The position that is passed in is now set to the position above
            this.position = position;
            // Set the Texture2D
            obstacleSprite = sprite;
            this.plainTexture = plainTexture;

            this.enemies = enemies;
            
            // Setup origin
            spriteOrigin.X = (float)obstacleSprite[0].Width / 2.0f;
            spriteOrigin.Y = (float)obstacleSprite[0].Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            obstacleBounds = new Rectangle((int)(position.X), (int)(position.Y), (int)(10), (int)(obstacleSprite[0].Height));
            enemyBounds = new Rectangle((int)(position.X), (int)(position.Y), (int)(85), (int)(obstacleSprite[0].Height));
            obstacleAnimation = new Animation(position);

        }

        public void addAnimationCells(Texture2D[] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                obstacleAnimation.AddCell(cells[i]);
            }
        }

        public void playAnimation()
        {
            obstacleAnimation.LoopAll(0.2f);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (display)
            {
                obstacleAnimation.SetPosition(position);
                obstacleAnimation.Draw(batch);
            }
            else
            {
                batch.Draw(plainTexture, position, Color.White);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!player.playerDied && !player.levelComplete)
            {
                hitCount++;

                obstacleBounds.X = (int)position.X;
                obstacleBounds.X += 140;
                obstacleBounds.Y = (int)position.Y;
                enemyBounds.Y = (int)position.Y;
                enemyBounds.X = (int)position.X;
                enemyBounds.X += 80;

                obstacleAnimation.Update(gameTime);
                if (this.position.X < 1500 && this.position.X > -50)
                    playSound = true;
                else
                    playSound = false;

                move();
                if (hitCount > 1000)
                    hitCount = 0;
            }
        }

        public virtual void move()
        {

        }
        
    }
}
