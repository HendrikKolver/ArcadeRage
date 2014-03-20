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
    
    class StunStar
    {
        public Texture2D image;
        public float alpha = 1.0f;
        public Vector2 position;
        public bool Start = false;
        public bool left = false;
        public SpriteFont tmpFont;
        public int tmp;
        public Animation stars;

        public StunStar()
        {
            position = new Vector2(0, 0);
            tmp = RandomClass.r.Next(3);
            stars = new Animation(new Vector2(0, 0));
            for (int i = 0; i < 34; i++)
                stars.AddCell(BGExtras.stars.cellList[i].cell);
        }

        public void update(GameTime gameTime)
        {
            
            if (Start)
            {
                if (!stars.playing)
                {
                    stars.PlayAll(1.5f);
                }
                //position.Y -= 1;
                alpha -= 0.02f;
                
                if (alpha <= 0)
                {
                    Start = false;
                    alpha = 1.0f;
                }
                stars.position = position;
                stars.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (Start)
            {
                stars.Draw(batch);
                Color myColor = Color.White * alpha;
                //batch.DrawString(tmpFont, "Star", position, myColor);
            }
        }
    }
}
