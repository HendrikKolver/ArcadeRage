using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace MainGame
{
    class Credits
    {
        public Texture2D blankBlack;
        public Texture2D [] allImages;
        public bool isPlaying = false;
        public bool musicPlaying = false;
        public Cue music;

        

        private SoundBank soundbank;

        //Frame 1
        float fadeInFirstOpacity = 0.01f;

        //Frame 2
        double f2Y = 900.0;

        //Frame 3
        double f3Y = 1700.0;

        //Frame 4
        float fadeInF4 = 0.01f;

        //Other Frames
        float generalFader = 0.01f;

        public int currentSection = 0;

        public Credits(SoundBank soundbank)
        {
            this.soundbank = soundbank;
        }

        public void Draw(SpriteBatch batch)
        {
            if (isPlaying)
            {
                if (currentSection == 0)  //Fade In
                {
                    Color myColor = Color.Black * fadeInFirstOpacity;
                    Rectangle drawHere = new Rectangle(0, 0, 1440, 900);
                    batch.Draw(blankBlack, drawHere, myColor);
                }
                else
                {
                    batch.Draw(blankBlack, new Vector2(0, 0), Color.White);  //Draw a black base for text
                    if (currentSection == 1)
                    {
                        Rectangle drawHere = new Rectangle(0, (int) f2Y, 1440, 900);
                        batch.Draw(allImages[0], drawHere, Color.White);

                        drawHere = new Rectangle(0, (int) f3Y, 1440, 900);
                        batch.Draw(allImages[1], drawHere, Color.White);
                    }
                    else if (currentSection == 2 || currentSection == 3)
                    {
                        Color myColor = Color.White * fadeInF4;
                        Rectangle drawHere = new Rectangle(0, 0, 1440, 900);
                        batch.Draw(allImages[2], drawHere, myColor);
                    }
                    else if (currentSection >= 4 && currentSection <= 11)
                    {
                        Color myColor = Color.White * generalFader;
                        Rectangle drawHere = new Rectangle(0, 0, 1440, 900);

                        switch (currentSection)
                        {
                            case 4: case 5:  batch.Draw(allImages[3], drawHere, myColor); break;
                            case 6: case 7:  batch.Draw(allImages[4], drawHere, myColor); break;
                            case 8: case 9:  batch.Draw(allImages[5], drawHere, myColor); break;
                            case 10: case 11: batch.Draw(allImages[6], drawHere, myColor); break;
                            case 12: case 13: batch.Draw(allImages[7], drawHere, myColor); break;
                        }
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isPlaying)
            {
                if (music == null)
                {
                    music = soundbank.GetCue("Credits");
                }
                if (!music.IsPlaying)
                {
                    music = soundbank.GetCue("Credits");
                    music.Play();
                    musicPlaying = true;
                }
                if (currentSection == 0)
                {
                    if (fadeInFirstOpacity < 1.0f)
                    {
                        fadeInFirstOpacity += 0.01f;
                    }
                    else if (fadeInFirstOpacity >= 1.0f && currentSection == 0) //Fade In complete
                    {
                        currentSection = 1;
                    }
                }
                else if (currentSection == 1)
                {
                    f2Y -= 1.5;
                    f3Y -= 1.5;
                    if (f3Y <= -550)
                    {
                        currentSection = 2;
                    }
                }
                else if (currentSection == 2)
                {
                    if (fadeInF4 < 1.0f)
                    {
                        fadeInF4 += 0.008f;
                    }
                    else if (fadeInF4 > 1.0f)
                    {
                        fadeInF4 = 2.0f;    //Make the text hold a little
                        currentSection = 3;
                    }
                }
                else if (currentSection == 3)
                {
                    if (fadeInF4 > 0.0f)
                    {
                        fadeInF4 -= 0.01f;
                    }
                    else
                    {
                        currentSection = 4;
                        generalFader = -0.5f;
                    }
                }
                else if (currentSection == 4 || currentSection == 6 || currentSection == 8 || currentSection == 10 || currentSection == 12)
                {
                    if (generalFader < 1.0f)
                    {
                        generalFader += 0.01f;
                    }
                    else
                    {
                        generalFader = 2.0f;
                        switch (currentSection)
                        {
                            case 4: currentSection = 5; break;
                            case 6: currentSection = 7; break;
                            case 8: currentSection = 9; break;
                            case 10: currentSection = 11; break;
                            case 12: currentSection = 13; break;
                            case 14: currentSection = 15; break;
                        }

                    }
                }
                else if (currentSection == 5 || currentSection == 7 || currentSection == 9 || currentSection == 11 || currentSection == 13)
                {
                    if (generalFader > 0.0f)
                    {
                        generalFader -= 0.01f;
                    }
                    else
                    {
                        generalFader = -0.5f;
                        switch (currentSection)
                        {
                            case 5: currentSection = 6; break;
                            case 7: currentSection = 8; break;
                            case 9: currentSection = 10; break;
                            case 11: currentSection = 12; break;
                            case 13: currentSection = 14; break;
                        }
                    }
                }
            }
            else
            {
                music.Stop(AudioStopOptions.Immediate);
            }
        }

        public void reset()
        {
           
            isPlaying = false;
            musicPlaying = false;
            fadeInFirstOpacity = 0.01f;
            f2Y = 900.0;
            f3Y = 1700.0;
            fadeInF4 = 0.01f;
            generalFader = 0.01f;
            currentSection = 0;
        }
    }
}
