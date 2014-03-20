using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MainGame
{
    class HUD
    {
        public int health;
        // crafted weapon
        // throwable weapon

        protected Texture2D HUDSprite;
        protected Texture2D emptyHealthBar;
        protected Texture2D fullHealthBar;
        protected Texture2D healthBarLeft;
        protected Texture2D healthBarRight;
        protected Texture2D itemExists;

        private SpriteBatch batch;
        GraphicsDevice graphicsDevice;
        Player player;

        Texture2D otherDefault;
        Texture2D weaponDefault;
        Texture2D throwable;

        //LevelProgressHUD
        double progress = 0;
        double maxProgress = 4000;
        Texture2D defaultProgressScreen;
        Texture2D levelProgressTexture;
        Texture2D jpsFace;
        Texture2D progressBG;

        public HUD(GraphicsDeviceManager device, Texture2D sprite, Texture2D emptyHealthBar, Texture2D fullHealthBar, Texture2D healthBarLeft, Texture2D healthBarRight, Texture2D itemExists, Player player_)
        {
            player = player_;
            health = 100;
            // default
            graphicsDevice = device.GraphicsDevice;
            batch = new SpriteBatch(device.GraphicsDevice);

            HUDSprite = sprite;
            this.fullHealthBar = fullHealthBar;
            this.emptyHealthBar = emptyHealthBar;
            this.healthBarLeft = healthBarLeft;
            this.healthBarRight = healthBarRight;
            this.itemExists = itemExists;
        }

        public void setProgressAmount(double amount)
        {
            progress = amount;
        }

        public void setTotalAmount(double amount)
        {
            maxProgress = amount;
        }

        public void LoadLevelProgress(Texture2D defaultProgressScreen, Texture2D levelProgressTexture, Texture2D jpsFace, Texture2D progressBG)
        {
            this.defaultProgressScreen = defaultProgressScreen;
            this.levelProgressTexture = levelProgressTexture;
            this.jpsFace = jpsFace;
            this.progressBG = progressBG;
        }

        public void SetProgressScreen(Texture2D progressScreen)
        {
            this.defaultProgressScreen = progressScreen;
        }

        public void LoadSprite(String type, Texture2D texture)
        {
            if (type == "weaponDefault")
                weaponDefault = texture;
            else if (type == "otherDefault")
                otherDefault = texture;
            else
                throwable = texture;

        }

        public int getHealth()
        {
            return health;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        


        public void Draw()
        {
            int hitpoints = (int)player.getHitpoints();

            //Determine Health Bar size
            int width = hitpoints * 442 / 100;  //442: width of health image
            int height = 52;


            batch.Begin();



            /*//Slot 2 - Throwable Items
            if (player.throwInventory)
            {
                if (player.getThrowableObject().name == "throwable1" || (player.getThrowableObject().displayName == "Baseball"))
                    batch.Draw(throwable1, new Vector2(243f, 749f), Color.White);
            }
            else
                batch.Draw(otherDefault, new Vector2(243f, 749f), Color.White);*/
            batch.Draw(HUDSprite, new Vector2(0.0f, 0.0f), Color.White);

            Rectangle drawHere = new Rectangle(399, 803, 442, 52);  //Empty Health
            batch.Draw(emptyHealthBar, drawHere, Color.White);

            drawHere = new Rectangle(399, 803, width, height);  //Adjusted Health
            batch.Draw(fullHealthBar, drawHere, Color.White);

            if (player.getHitpoints() > 0)
            {
                if (width <= 14)
                {
                    drawHere = new Rectangle(399, 803, 7, 52);  //HBL
                    batch.Draw(healthBarLeft, drawHere, Color.White);
                    drawHere = new Rectangle(399 + 7, 803, 7, 52);  //HBR
                    batch.Draw(healthBarRight, drawHere, Color.White);
                }
                else
                {
                    drawHere = new Rectangle(399, 803, 7, 52);  //HBL
                    batch.Draw(healthBarLeft, drawHere, Color.White);
                    drawHere = new Rectangle(399 + width - 7, 803, 13, 52);  //HBR
                    batch.Draw(healthBarRight, drawHere, Color.White);
                }
            }

            Rectangle drawHere2;
            //Slot 1 - Weapon
            if (player.weapon == player.specialWeapon)
            {
                batch.Draw(itemExists, new Vector2(32, 720), Color.White);
                drawHere2 = new Rectangle(32, 718, 130, 130);
                batch.Draw(player.specialWeapon.icon, drawHere2, Color.White);
            }
            else
            {
                batch.Draw(itemExists, new Vector2(32, 720), Color.White);
                drawHere2 = new Rectangle(32, 698, 150, 150);
                batch.Draw(weaponDefault, drawHere2, Color.White);
            }
            

            //Slot 2 - Throwable Items
            if (player.throwInventory)
            {
                if (player.getThrowableObject().name.Length > 0)
                {
                    batch.Draw(itemExists, new Vector2(218, 720), Color.White);
                    drawHere2 = new Rectangle(218, 720, 128, 128);
                    batch.Draw(throwable, drawHere2, Color.White);
                }
            }

            //Progress Bar

            if (defaultProgressScreen != null)
            {
                int progWidth = (int)((this.progress / maxProgress) * 300);
                int progHeight = 10;
                drawHere = new Rectangle(1007, 820, progWidth, progHeight);
                batch.Draw(progressBG, new Vector2(0, 0), Color.White);
                batch.Draw(this.levelProgressTexture, drawHere, Color.White);
                batch.Draw(this.defaultProgressScreen, new Vector2(0, 0), Color.White);
                batch.Draw(this.jpsFace, new Vector2(1007 + progWidth - 10, 795), Color.White);
            }

            batch.End();
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
