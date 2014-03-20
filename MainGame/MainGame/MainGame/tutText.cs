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
    class tutText
    {
        List<Texture2D> textureListPt1;
        List<Texture2D> textureListPt2;
        public bool levelCompleted = false;
        public Vector2 position;
        public Vector2 position2;
        public Texture2D objectSprite;
        public Vector2 spriteOrigin;
        public int windowWidth, windowHeight;
        float alpha = 1.0f;
        public int textNumber = 0;
        public int nextNumber = 0;
        public bool fading = false;
        public bool goingDown = true;
        public bool startedDraw = false;
        public bool started = false;

        public tutText(GraphicsDevice device, Vector2 position, Texture2D sprite)
        {
            textureListPt1 = new List<Texture2D>();
            textureListPt2 = new List<Texture2D>();
            this.position = position;
            position2 = position;
            position2.X += 4096;
            
            // Set the Texture2D
            objectSprite = sprite;

            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;
        }

        public void addTextFramePt1(Texture2D t)
        {

            textureListPt1.Add(t);
            
        }

        public void addTextFramePt2(Texture2D t)
        {
            textureListPt2.Add(t);
        }

        public void update(GameTime gameTime)
        {
            //Console.WriteLine(alpha);
            if (fading && goingDown && started)
            {
                
                alpha -= 0.03f;
                if (alpha <= 0)
                {
                    goingDown = false;
                    textNumber = nextNumber;
                    alpha = 0;
                    startedDraw = true;
                }
            }
            else
            if (fading && !goingDown && started)
            {
                alpha += 0.03f;
                if (alpha >= 1f)
                {
                    alpha = 1f;
                    fading = false;
                    goingDown = true;
                    
                    
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (!levelCompleted && started && startedDraw)
            {
                Color myColor = Color.White * alpha;
                batch.Draw(textureListPt1[textNumber-1], position, myColor);
                batch.Draw(textureListPt2[textNumber-1], position2, myColor);
            }
        }

        public void setText(int n)
        {
            
            if (n < textureListPt1.Count+1)
            {
                started = true;
                nextNumber = n;
                fading = true;
            }
        }


    }
}
