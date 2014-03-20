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
    class ThrowObjects
    {
        public Rectangle objectBounds;
        public Vector2 position;
        public Vector2 textPosition;
        public Vector2 textPosition2;
        public Texture2D objectSprite;
        public Vector2 spriteOrigin;
        public int windowWidth, windowHeight;
        public double damage;
        public float throwSpeed;
        public String name;
        public bool throwing = false;
        private Animation spinAnimation;
        public bool pickedUp = false;
        float alpha = 1.0f;
        public float alpha2 = 0.0f;
        public SpriteFont DropItemFont;
        public String displayName = ""; 
        
        
        public ThrowObjects(GraphicsDevice device, Vector2 position, Texture2D sprite, String name)
        {
            spinAnimation = new Animation(position);

            this.name = name;
            this.position = position;
            textPosition = new Vector2(position.X, position.Y);
            textPosition2 = new Vector2(textPosition.X + 2, textPosition.Y + 2);
            // Set the Texture2D
            objectSprite = sprite;

            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), objectSprite.Width, objectSprite.Height);

            damage = 60;
            throwSpeed = 12f;
        }

        public void Draw(SpriteBatch batch)
        {
            if (!throwing)
            {
                Color tmp = (Color.White * alpha2);
                if (displayName == "Plate")
                {
                    int w =  (int) (objectSprite.Width * 0.7);
                    int h = (int) (objectSprite.Height * 0.7);
                    Rectangle drawHere = new Rectangle( (int) position.X, (int) position.Y, w, h);
                    batch.Draw(objectSprite, drawHere, Color.White);
                }
                else if (displayName == "Barbarian Ball")
                {
                    int w = (int)(objectSprite.Width * 0.7);
                    int h = (int)(objectSprite.Height * 0.7);
                    Rectangle drawHere = new Rectangle((int)position.X, (int)position.Y, w, h);
                    batch.Draw(objectSprite, drawHere, Color.White);
                }else
                 batch.Draw(objectSprite, position, null, tmp, 0.0f, spriteOrigin, 1.0f, SpriteEffects.None, 0.0f);
            }
            else
            {
                if (displayName == "Plate" || displayName == "Barbarian Ball")
                {
                    Console.WriteLine("HERE");
                    spinAnimation.Scale = 1.5f;
                }
                spinAnimation.SetPosition(position);
                spinAnimation.Draw(batch);
            }

            if (pickedUp)
            {
                Color myColor = Color.Black * alpha;
                Color myColor2 = new Color(224,255,252) * alpha;
                batch.DrawString(DropItemFont, displayName, textPosition2, myColor);
                batch.DrawString(DropItemFont, displayName, textPosition, myColor2);
            }

        }

        public void Update(GameTime gameTime)
        {
            if (pickedUp)
            {
                textPosition2.X += 1;
                textPosition2.Y -= 2;
                textPosition.X += 1;
                textPosition.Y -= 2;

                if (alpha > 0.04f)
                    alpha -= 0.01f;
                else
                {
                    alpha = 0f;
                }
            }

            if (throwing)
            {
                spinAnimation.Update(gameTime);
            }
            objectBounds.X = (int)position.X+80;
            //objectBounds.X = (int)position.Y;
            
        }

        public Rectangle getBounds()
        {
            return objectBounds;
        }

        public void throwObject()
        {
            spinAnimation.LoopAll(0.4f);
            throwing = true;
        }

        public void addCell(Texture2D t)
        {
            spinAnimation.AddCell(t);
        }



    }
}
