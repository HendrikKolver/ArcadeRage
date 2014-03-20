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
    struct AnimationCell
    {
        public Texture2D cell;
    }
    class Animation
    {
        public Rectangle someBounds;

        String direction = "right";
        public int currentCell = 0;
        bool looping = false;
        bool stopped = false;
        public bool playing = false;
        // Time we need to goto next frame
        
        float timeShift = 0.0f;
        // Time since last shift
        
        float totalTime = 0.0f;
        int start = 0, end = 0;
        public List<AnimationCell> cellList = new List<AnimationCell>();
        
        public Vector2 position;
        float scale = 1.0f;

        SpriteEffects spriteEffect = SpriteEffects.None;

        public float Scale
        {
            set
            {
            scale = value;
            }
        }
        Vector2 spriteOrigin = Vector2.Zero;
        
        public Vector2 SpriteOrigin
        {
            set
            {
                spriteOrigin = value;
            }
        }

        public Animation(Vector2 position)
        {
            
            this.position = position;
        }

        public void AddCell( Texture2D cellPicture )
        {
            someBounds = new Rectangle((int)(position.X - cellPicture.Width / 2), (int)(position.Y - cellPicture.Height / 2), cellPicture.Width, cellPicture.Height);
            AnimationCell cell = new AnimationCell();
            cell.cell = cellPicture;
            cellList.Add(cell);
        }

        public Texture2D getLastFrame()
        {
            return cellList.Last().cell;
        }


        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void SetMoveLeft()
        {
            direction = "left";
            spriteEffect = SpriteEffects.FlipHorizontally;
        }

        public void SetMoveRight()
        {
            direction = "right";
            spriteEffect = SpriteEffects.None;
        }

        public String getDirection()
        {
            return direction;
        }

        public void LoopAll(float seconds)
        {
            if (playing) return;
            stopped = false;
            if (looping) return;
            looping = true;
            start = 0;
            end = cellList.Count - 1;
            currentCell = start;
            timeShift = seconds / (float)cellList.Count;
        }

        public void Loop(int start, int end, float seconds)
        {
            if (playing) return;

            stopped = false;

            if (looping) return;

            looping = true;

            this.start = start;
            this.end = end;
            currentCell = start;
            float difference = (float)end - (float)start;
            timeShift = seconds / difference;
        }

        public void Stop()
        {
        
            if (playing) return;
            stopped = true;
            looping = false;
            totalTime = 0.0f;
            timeShift = 0.0f;
        }

        public void GotoFrame(int number)
        {
            if (playing) return;
            if (number < 0 || number >= cellList.Count) return;
            currentCell = number;
        }

        public void PlayAll(float seconds)
        {
            if (playing) return;
            GotoFrame(0);
            stopped = false;
            looping = false;
            playing = true;
            start = 0;
            end = cellList.Count - 1;
            timeShift = seconds / (float)cellList.Count;
        }

        public void Play(int start, int end, float seconds)
        {
            if (playing) return;
            GotoFrame(start);
            stopped = false;
            looping = false;
            playing = true;
            this.start = start;
            this.end = end;
            float difference = (float)end - (float)start;
            timeShift = seconds / difference;
        }

        public void Draw(SpriteBatch batch)
        {
            if (cellList.Count == 0 || currentCell < 0 ||
            cellList.Count <= currentCell) return;
            
            batch.Draw(cellList[currentCell].cell, position, null, Color.White, 0.0f,
            spriteOrigin,
            new Vector2( scale, scale), spriteEffect, 0.0f );
        }



        public void Draw(SpriteBatch batch, float alpha)
        {
            if (cellList.Count == 0 || currentCell < 0 ||
            cellList.Count <= currentCell) return;

            Color tmpCol = Color.White * alpha;

            batch.Draw(cellList[currentCell].cell, position, null, tmpCol, 0.0f,
            spriteOrigin,
            new Vector2(scale, scale), spriteEffect, 0.0f);
        }
        public void Update(GameTime gameTime)
        {
            if (stopped) return;
            if (cellList.Count > 0)
            {
                someBounds.X = (int)position.X - (cellList[0].cell.Width / 2);
                someBounds.Y = (int)position.Y - (cellList[0].cell.Height / 2);
            }
            totalTime += (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (totalTime > timeShift)
            {
                totalTime = 0.0f;
                currentCell++;
                if (looping)
                {
                    if (currentCell > end) currentCell = start;
                }

                if (currentCell > end)
                {
                    currentCell = end;
                    playing = false;
                }
            }
        }
    }
}
