using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;


namespace MainGame
{
    class BloodSpash
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle someBounds;

        public BloodSpash(Texture2D t, Vector2 p)
        {
            texture = t;
            position = p;
            someBounds = new Rectangle((int)(position.X - texture.Width / 2), (int)(position.Y - texture.Height / 2), texture.Width, texture.Height);
        }
    }

    class BloodSpashes
    {
        public List<BloodSpash> floorSplashList;
        public List<BloodSpash> wallSplashList;
        public Texture2D[] floorTextures; //Arrays of all textures in order to choose a random one when needed
        public Texture2D[] wallTextures; //Arrays of all textures in order to choose a random one when needed

        public BloodSpashes(Texture2D[] f, Texture2D[] w)
        {
            floorTextures = f;
            wallTextures = w;
            floorSplashList = new List<BloodSpash>();
            wallSplashList = new List<BloodSpash>();
        }

        public void addRandomFloorSplash(Vector2 position)
        {
            int randomSplash = RandomClass.r.Next(floorTextures.Length);
            floorSplashList.Add(new BloodSpash(floorTextures[randomSplash], position));
        }

        public void addRandomWallSplash(Vector2 position)
        {
            int randomSplash = RandomClass.r.Next(wallTextures.Length);
            wallSplashList.Add(new BloodSpash(wallTextures[randomSplash], position));
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < floorSplashList.Count; i++)
                batch.Draw(floorSplashList[i].texture, floorSplashList[i].position, Color.White);
            for (int i = 0; i < wallSplashList.Count; i++)
                batch.Draw(wallSplashList[i].texture, wallSplashList[i].position, Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
