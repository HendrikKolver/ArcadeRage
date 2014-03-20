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
    class DropItems
    {
        
        public Rectangle objectBounds;
        public Vector2 position;
        public Vector2 position2;
        public Texture2D objectSprite;
        public Texture2D craftingMenuSprite;    //Larger version for the crafting menu
        public Vector2 spriteOrigin;
        public int windowWidth, windowHeight;
        public bool pickedUp = false;
        public String name;
        public float alpha = 1.0f;
        public SpriteFont DropItemFont;
        public int amount = 1;
        public GraphicsDevice device;
        public bool displayInInventory = true; //False -> display in crafting 1/2 slots
        //Shine
        public Animation shineAnimation;
        public Vector2 shinePos;


        public DropItems(GraphicsDevice device, Vector2 position, Texture2D sprite, Texture2D dropItemLarge)
        {
            this.device = device;
            this.position = position;
            // Set the Texture2D
            objectSprite = sprite;
            craftingMenuSprite = dropItemLarge;
            this.position2 = new Vector2(position.X + 2, position.Y + 2);
            
            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), objectSprite.Width, objectSprite.Height);

            shineAnimation = new Animation(shinePos);
            for (int i = 0; i < BGExtras.shine.cellList.Count; i++)
            {
                shineAnimation.AddCell(BGExtras.shine.cellList[i].cell);
            }
        }

        public void setShinePos()
        {
            switch (this.name)
            {
                case "Deadly Nails":{
                    shinePos = new Vector2(position.X+0, position.Y+0);
                } break;
                case "Baseball Bat":{
                    shinePos = new Vector2(position.X - 5, position.Y - 17);
                } break;
                case "Cactus":{
                    shinePos = new Vector2(position.X + 0, position.Y + 0);
                } break;
                case "Car Battery":{
                    shinePos = new Vector2(position.X - 20, position.Y - 10);
                } break;
                case "Chemical Flask":{
                    shinePos = new Vector2(position.X + 0, position.Y - 5);
                } break;
                case "Fluorescent Tube":{
                    shinePos = new Vector2(position.X + 0, position.Y + 0);
                } break;
                case "Gloves":{
                    shinePos = new Vector2(position.X + 0, position.Y + 0);
                } break;
                case "Hockey Stick":{
                    shinePos = new Vector2(position.X + 20, position.Y + 50);
                } break;
                case "Knife":{
                    shinePos = new Vector2(position.X + 0, position.Y - 15);
                } break;
                case "Mouse":{
                    shinePos = new Vector2(position.X + 0, position.Y + 0);
                } break;
                case "Nokia 331O":{
                    shinePos = new Vector2(position.X + 0, position.Y - 20);
                } break;
                case "YoYo":{
                    shinePos = new Vector2(position.X - 30, position.Y - 15);
                } break;
            }
        }

        public DropItems(DropItems copyThis)
        {
            displayInInventory = copyThis.displayInInventory;
            amount = copyThis.amount;
            DropItemFont = copyThis.DropItemFont;
            device = copyThis.device;
            name = copyThis.name;
            position = copyThis.position;
            // Set the Texture2D
            objectSprite = copyThis.objectSprite;
            craftingMenuSprite = copyThis.craftingMenuSprite;
            this.position2 = new Vector2(copyThis.position.X + 2, copyThis.position.Y + 2);

            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), objectSprite.Width, objectSprite.Height);

            shineAnimation = new Animation(shinePos);
            for (int i = 0; i < BGExtras.shine.cellList.Count; i++)
            {
                shineAnimation.AddCell(BGExtras.shine.cellList[i].cell);
            }
        }

        public DropItems(GraphicsDevice device, Vector2 position, Texture2D sprite, Texture2D dropItemLarge, String name)
        {
            this.device = device;
            this.name = name;
            this.position = position;
            // Set the Texture2D
            objectSprite = sprite;
            craftingMenuSprite = dropItemLarge;
            this.position2 = new Vector2(position.X + 2, position.Y + 2);

            // Setup origin
            spriteOrigin.X = (float)objectSprite.Width / 2.0f;
            spriteOrigin.Y = (float)objectSprite.Height / 2.0f;
            // Set window dimensions
            windowHeight = device.Viewport.Height;
            windowWidth = device.Viewport.Width;

            //collision detection
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), objectSprite.Width, objectSprite.Height);
            shineAnimation = new Animation(shinePos);
            for (int i = 0; i < BGExtras.shine.cellList.Count; i++)
            {
                shineAnimation.AddCell(BGExtras.shine.cellList[i].cell);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (!pickedUp)
            {
                Rectangle drawHere = new Rectangle((int)position.X, (int)position.Y, 80, 80);
                if (name == "Baseball Bat") //Needed Rotating
                {
                    float angle = (float)Math.PI / 3.8f;
                    float scale = 0.7f;
                    Vector2 origin = new Vector2(50, 50);
                    batch.Draw(objectSprite, position, null, Color.White, angle, origin, scale, SpriteEffects.None, 0);
                }
                else if (name == "Cactus" || name == "Hockey Stick")
                {
                    drawHere = new Rectangle((int)position.X, (int)position.Y, 160, 160);
                    batch.Draw(objectSprite, drawHere, Color.White);
                }else
                    batch.Draw(objectSprite, drawHere, Color.White);
                shineAnimation.Draw(batch);
            }
            else
            {
                Color myColor = Color.Black * alpha;
                Color myColor2 = Color.White * alpha;
                batch.DrawString(DropItemFont, name, position2, myColor);
                batch.DrawString(DropItemFont, name, position, myColor2);
            }
        }

        public void Update(GameTime gameTime)
        {
            position2.X = position.X + 2;
            position2.Y = position.Y + 2;

            if (!pickedUp)
            {
                if (!shineAnimation.playing)
                    shineAnimation.LoopAll(1.0f);
                this.setShinePos();
                shineAnimation.position = shinePos;
                shineAnimation.Update(gameTime);

                objectBounds.X = (int)position.X + 120;
                objectBounds.Y = (int)position.Y - 40;
            }
            else
            {
                position.X += 1;
                position.Y -= 2;
                position2.X += 1;
                position2.Y -= 2;

                if (alpha > 0.04f)
                    alpha -= 0.01f;
                else
                {
                    alpha = 0f;
                }
            }
            //objectBounds.X = (int)position.Y;
        }

        public void setPosition(Vector2 pos)
        {
            this.position = pos;
            this.position2 = new Vector2(position.X + 2, position.Y + 2);
            objectBounds = new Rectangle((int)(position.X - objectSprite.Width / 2), (int)(position.Y - objectSprite.Height / 2), objectSprite.Width/3, objectSprite.Height/2);
        }

        public Rectangle getBounds()
        {
            return objectBounds;
        }
    }
}
