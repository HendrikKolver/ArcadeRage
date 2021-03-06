﻿using System;
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
    class Particle
    {
        Vector4 color;
        Vector4 startColor;
        Vector4 endColor;
        TimeSpan endTime = TimeSpan.Zero;
        TimeSpan lifetime;
        public Vector3 position;
        Vector3 velocity;
        protected Vector3 acceleration = new Vector3( -505.0f, 802.0f, 10.0f );
        public bool Delete;

        public Vector4 Color
        {
            get
            {
                return color;
            }
        }

        public Particle(Vector2 position2, Vector2 velocity2, Vector4 startColor,Vector4 endColor, TimeSpan lifetime)
        {
            velocity = new Vector3(velocity2, 0.0f);
            position = new Vector3(position2, 0.0f);
            this.startColor = startColor;
            this.endColor = endColor;
            this.lifetime = lifetime;
        }

        public void Update(TimeSpan time, TimeSpan elapsedTime)
        {
            //Start the animation 1st time round
            if (endTime == TimeSpan.Zero)
            {
                endTime = time + lifetime;
            }
            if (time > endTime)
            {
                Delete = true;
            }

            float percentLife = (float)((endTime.TotalSeconds - time.TotalSeconds)/ lifetime.TotalSeconds);
            color = Vector4.Lerp(endColor, startColor, percentLife);
            velocity += Vector3.Multiply(acceleration,(float)elapsedTime.TotalSeconds);
            position += Vector3.Multiply(velocity,(float)elapsedTime.TotalSeconds);
        }
    }
        class BasicParticleSystem
        {
            static Random random = new Random();
            List<Particle> particleList = new List<Particle>();
            Texture2D circle;
            int Count = 0;

            public BasicParticleSystem(Texture2D circle)
            {
                this.circle = circle;
            }

            public void AddExplosion(Vector2 position)
            {
                for (int i = 0; i < 150; i++)
                {
                    Vector2 velocity2 = (float)random.Next(150) * Vector2.Normalize(new Vector2((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5)));

                    particleList.Add(new Particle(position, velocity2,(i > 70) ? new Vector4(1.0f, 0f, 0f, 1) : new Vector4(.941f,.845f, 0f, 1),new Vector4(.2f, .2f, .2f, 0f),new TimeSpan(0, 0, 0, 0, random.Next(1000) + 500)));
                    Count++;
                }
            }

            public void AddBigExplosion(Vector2 position)
            {
                for (int i = 0; i < 350; i++)
                {
                    Vector2 velocity2 = (float)random.Next(150) * Vector2.Normalize(new Vector2((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5)));

                    particleList.Add(new Particle(position, velocity2, (i > 70) ? new Vector4(1.0f, 0f, 0f, 1) : new Vector4(.941f, .845f, 0f, 1), new Vector4(.2f, .2f, .2f, 0f), new TimeSpan(0, 0, 0, 0, random.Next(1000) + 500)));
                    Count++;
                }
            }

            public void Update(TimeSpan time, TimeSpan elapsed)
            {
                if (Count > 0)
                {
                    for( int i = 0; i < particleList.Count; i++ )
                    {
                        particleList[i].Update(time, elapsed);
                        if (particleList[i].Delete) particleList.RemoveAt(i);
                    }
                    Count = particleList.Count;
                }
            }

            public void Draw(SpriteBatch batch)
            {
                if (Count != 0)
                {
                    int particleCount = 0;
                    foreach (Particle particle in particleList)

                    {
                        batch.Draw(circle,
                        new Vector2(particle.position.X, particle.position.Y),
                        null, new Color(((Particle)particle).Color), 0,
                        new Vector2(16, 16), .2f,
                        SpriteEffects.None, particle.position.Z);
                        particleCount++;
                    }
                }
            }
        }
}
