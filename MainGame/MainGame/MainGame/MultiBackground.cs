using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame
{
    class MultiBackground : Microsoft.Xna.Framework.Game
    {
        private bool moving = false;
        private bool moveLeftRight = false;
        private bool moveRightLeft = true;
        public float newMoveDistance = 0;

        public Texture2D trees1;
        public Texture2D trees2;

        public Texture2D bgTexture;
        public Texture2D bgTexture2;

        public Texture2D tutTexture1;
        public Texture2D tutTexture2;

        GraphicsDeviceManager graphics;
        public bool tutLevel = false;
        public bool lastLevel = false;

        private Vector2 windowSize;
        private List<BackgroundLayer> layerList;
        private SpriteBatch batch;

        //SNOW Effect
        static int snowParticles = 2000;    //Density Adjustment
        Vector2[] snow = new Vector2[snowParticles]; 
        double[] alphaSnow = new double[snowParticles];
        double[] particleSize = new double[snowParticles];
        double[] wind = new double[snowParticles];
        double[] moveY = new double[snowParticles];
        bool isSnowing = true;
                
        //RAIN Effect
        static int rainParticles = 2000;    //Density Adjustment
        Vector2[] rain = new Vector2[rainParticles];
        double[] alphaRain = new double[rainParticles];
        double[] particleSizeRain = new double[rainParticles];
        double[] windRain = new double[rainParticles];
        double[] moveYRain = new double[rainParticles];
        bool isRaining = true;

        Vector2 quitPoint;
        Vector2 startPoint;
        Random random; 


        public MultiBackground(GraphicsDeviceManager graphics)
        {
            this.graphics = new GraphicsDeviceManager(this);
            windowSize.X = graphics.PreferredBackBufferWidth;
            windowSize.Y = graphics.PreferredBackBufferHeight;
            batch = new SpriteBatch(graphics.GraphicsDevice);
            layerList = new List<BackgroundLayer>();
            initSnow();
            initRain();
        }

        public void initSnow()
        {
            for (int i = 0; i < alphaSnow.Length; i++)
            {
                alphaSnow[i] = .2 + RandomClass.r.NextDouble() * .8;
                particleSize[i] = RandomClass.r.Next(3, 6);
                wind[i] = -0.6 + RandomClass.r.NextDouble() * 1.6;
                moveY[i] = 0.5 + RandomClass.r.NextDouble();
            }
        }

        public void initRain()
        {
            for (int i = 0; i < alphaRain.Length; i++)
            {
                alphaRain[i] = .5 + RandomClass.r.NextDouble() * .5;
                particleSizeRain[i] = RandomClass.r.Next(4, 8);
                windRain[i] = RandomClass.r.NextDouble() * 1.0;
                moveYRain[i] = 3.5 + RandomClass.r.NextDouble();
            }
        }

        public BackgroundLayer GetLastLayer()
        {
            return layerList[layerList.Count - 1];
        }

        public void shake(int x)
        {
            for (int i = 6; i < layerList.Count; i++)
            {
                layerList[i].position.X += x;
            }
        }

        public void AddLayer(Texture2D picture, float depth, float moveRate)
        {
            BackgroundLayer layer = new BackgroundLayer();
            layer.picture = picture;
            layer.depth = depth;
            layer.moveRate = moveRate;
            layer.pictureSize.X = picture.Width;
            layer.pictureSize.Y = picture.Height;
            layerList.Add(layer);
        }

        public int CompareDepth(BackgroundLayer layer1, BackgroundLayer layer2)
        {
            if (layer1.depth < layer2.depth)
                return 1;
            if (layer1.depth > layer2.depth)
                return -1;
            if (layer1.depth == layer2.depth)
                return 0;
            return 0;
        }

        public void Move(float rate)
        {
            float moveRate = rate / 60.0f;
            foreach (BackgroundLayer layer in layerList)
            {
                float moveDistance = layer.moveRate * moveRate;
                if (!moving)
                {
                    if (moveLeftRight)
                    {
                        layer.position.X += moveDistance;
                        layer.position.X = layer.position.X % layer.pictureSize.X;
                    }
                    else if (moveRightLeft)
                    {
                        layer.position.X -= moveDistance;
                        layer.position.X = layer.position.X % layer.pictureSize.X;
                    }
                    else
                    {
                        layer.position.Y += moveDistance;
                        layer.position.Y = layer.position.Y % layer.pictureSize.Y;
                    }
                }
            }
        }

        public void Draw()
        {
            layerList.Sort(CompareDepth);
            batch.Begin();

            for (int i = 0; i < 3; i++)
            {
                batch.Draw(layerList[i].picture, new Vector2(layerList[i].position.X + ((i - 1) * 4096), 0.0f), layerList[i].color);
            }

            if (lastLevel)
            {
                BGExtras.lightning.SetPosition(new Vector2(0, 0));
                BGExtras.lightning.Draw(batch);
            }

            //batch.Draw(layerList[0].picture, new Vector2(layerList[0].position.X, 0.0f), layerList[0].color);
            int x = 1;
            for (int i = 3; i < 6; i++)
            {
                if (tutLevel)
                    batch.Draw(layerList[i].picture, new Vector2(layerList[i].position.X + ((x - 1) * 4096 - 180), 0.0f), layerList[i].color);
                else
                    batch.Draw(layerList[i].picture, new Vector2(layerList[i].position.X + ((x - 1) * 4096), 0.0f), layerList[i].color);
                x++;
            }

            if (!tutLevel && !lastLevel)
                DrawSnow();
            else if (lastLevel)
                DrawRain();

            x = 1;
            for (int i = 6; i < layerList.Count; i++)
            {
                //layerList[i].color = new Color(new Vector4(0.0f, 0.0f, 0.0f, 0.5f));
                batch.Draw(layerList[i].picture, new Vector2(layerList[i].position.X + ((x - 1) * 4096), 0.0f), layerList[i].color);
                x++;
            }
            
            
            batch.End();

            
        }

        public void DrawSnow()
        {
            this.quitPoint = new Vector2(0, BGExtras.h + BGExtras.snowFlakes.Height);
            this.startPoint = new Vector2(0, 0 - BGExtras.snowFlakes.Height);

            if (!isSnowing)
                return;
            int i;
            if (this.snow[0] == new Vector2(0, 0))
            {
                random = new Random();
                for (i = 0; i < this.snow.Length; i++)
                    this.snow[i] = new Vector2((random.Next(0, (BGExtras.w - BGExtras.snowFlakes.Width))), (random.Next(0, (BGExtras.h))));
            }

            i = 0;
            foreach (Vector2 snowPnt in snow)
            {
                Rectangle snowParticle = new Rectangle((int)snowPnt.X, (int)snowPnt.Y, (int)particleSize[i], (int) particleSize[i]);
                batch.Draw(BGExtras.snowFlakes, snowParticle, Color.White * (float) alphaSnow[i]);

                this.snow[i].Y += (float) moveY[i];
                this.snow[i].X += (float) wind[i];

                if (this.snow[i].Y >= this.quitPoint.Y) //Keep On screen
                    this.snow[i] = new Vector2((random.Next(0, (BGExtras.w - BGExtras.snowFlakes.Width))), this.startPoint.Y);
                i++;
            }
        }

        public void DrawRain()
        {

            

            this.quitPoint = new Vector2(0, BGExtras.h + BGExtras.rainDrops.Height);
            this.startPoint = new Vector2(0, 0 - BGExtras.rainDrops.Height);

            if (!isRaining)
                return;
            int i;
            if (this.rain[0] == new Vector2(0, 0))
            {
                random = new Random();
                for (i = 0; i < this.rain.Length; i++)
                    this.rain[i] = new Vector2((random.Next(0, (BGExtras.w - BGExtras.rainDrops.Width))), (random.Next(0, (BGExtras.h))));
            }

            i = 0;
            foreach (Vector2 rainPnt in rain)
            {
                Rectangle rainParticle = new Rectangle((int)rainPnt.X, (int)rainPnt.Y, (int)particleSizeRain[i], (int)particleSizeRain[i] * 5);
                batch.Draw(BGExtras.rainDrops, rainParticle, Color.White * (float)alphaRain[i]);

                this.rain[i].Y += (float)moveYRain[i];
                this.rain[i].X += (float)windRain[i];

                if (this.rain[i].Y >= this.quitPoint.Y) //Keep On screen
                    this.rain[i] = new Vector2((random.Next(0, (BGExtras.w - BGExtras.rainDrops.Width))), this.startPoint.Y);
                i++;
            }
        }

        public void setMoveRate(float moveRate)
        {
            for (int i = 0; i < layerList.Count; i++)
            {
                layerList[i].moveRate = moveRate;
            }
        }

        public float getMoveRate()
        {
            return layerList[0].moveRate;
        }

        public List<BackgroundLayer> getLayerList()
        {
            return layerList;
        }

        public void SetMoveUpDown()
        {
            moveLeftRight = false;
        }

        public void SetMoveLeftRight()
        {
            moveLeftRight = true;
        }

        public void SetMoveRightLeft()
        {
            moveRightLeft = true;
        }

        public void Stop()
        {
            moving = false;
        }

        public void StartMoving()
        {
            moving = true;
        }

        public void SetLayerPosition(int layerNumber, Vector2 startPosition)
        {
            if (layerNumber < 0 || layerNumber >= layerList.Count) return;
            layerList[layerNumber].position = startPosition;
        }

        public void SetLayerAlpha(int layerNumber, float percent)
        {
            if (layerNumber < 0 || layerNumber >= layerList.Count) return;
            float alpha = (percent / 100.0f);
            layerList[layerNumber].color = new Color(new Vector4(0.0f, 0.0f, 0.0f, alpha));
        }

        public void Update(GameTime gameTime)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (moving)
                {
                    if (moveRightLeft)
                    {
                        layerList[i].position.X -= layerList[i].moveRate / 120.0f;
                        layerList[i].position.X = layerList[i].position.X % layerList[i].pictureSize.X;
                    }
                }
            }

            for (int i = 3; i < 6; i++)
            {
                if (moving)
                {
                    if (moveRightLeft)
                    {
                        if (this.tutLevel)
                            layerList[i].position.X -= (layerList[i].moveRate / 43.0f);
                        else
                            layerList[i].position.X -= layerList[i].moveRate / 100f;
                        layerList[i].position.X = layerList[i].position.X % layerList[i].pictureSize.X;
                    }
                }
            }

            for (int i = 6; i < layerList.Count; i++)
            {
                float moveDistance = layerList[i].moveRate / 40.0f;
                if (moving)
                {
                    if (moveLeftRight)
                    {
                        layerList[i].position.X += moveDistance;
                        layerList[i].position.X = layerList[i].position.X % layerList[i].pictureSize.X;
                    }
                    else if (moveRightLeft)
                    {
                        
                        layerList[i].position.X -= newMoveDistance;
                        //layer.position.X = layer.position.X % layer.pictureSize.X;
                    }
                    else
                    {
                        layerList[i].position.Y += moveDistance;
                        layerList[i].position.Y = layerList[i].position.Y % layerList[i].pictureSize.Y;
                    }
                }
            }


            for (int x = 0; x < snowParticles; x++)
            {
                if (moving && !tutLevel)
                {
                    snow[x].X -= newMoveDistance;
                }
            }

            if (RandomClass.r.Next(100) == 0 && lastLevel)
            {
                int rand = RandomClass.r.Next(1);
                if (rand == 0)
                    BGExtras.lightning.SetMoveLeft();
                else
                    BGExtras.lightning.SetMoveRight();
                BGExtras.lightning.PlayAll(0.5f);
            }
            BGExtras.lightning.Update(gameTime);
        }
    }
}
