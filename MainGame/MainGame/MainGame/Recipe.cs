using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MainGame
{
    static class Recipe
    {
        public static Texture2D silCanada;
        public static Texture2D mainCanada;
        public static Texture2D iconCanada;

        public static Texture2D silNailBat;
        public static Texture2D mainNailBat;
        public static Texture2D iconNailBat;
        public static Texture2D infoNailBat;

        public static Texture2D silNokia;
        public static Texture2D mainNokia;
        public static Texture2D iconNokia;
        public static Texture2D infoNokia;

        public static Texture2D silCactus;
        public static Texture2D mainCactus;
        public static Texture2D iconCactus;
        public static Texture2D infoCactus;

        public static Texture2D silYoYo;
        public static Texture2D mainYoYo;
        public static Texture2D iconYoYo;
        public static Texture2D infoYoYo;

        public static Texture2D silBearHands;
        public static Texture2D mainBearHands;
        public static Texture2D iconBearHands;
        public static Texture2D infoBearHands;

        public static Texture2D silLightSaber;
        public static Texture2D mainLightSaber;
        public static Texture2D iconLightSaber;
        public static Texture2D infoLightSaber;

        public static Texture2D silRadio;
        public static Texture2D mainRadio;
        public static Texture2D iconRadio;
        public static Texture2D infoRadio;

        public static Texture2D silAcidMouse;
        public static Texture2D mainAcidMouse;
        public static Texture2D iconAcidMouse;
        public static Texture2D infoAcidMouse;

        public static Texture2D silHockey;
        public static Texture2D mainHockey;
        public static Texture2D iconHockey;
        public static Texture2D infoHockey;

        public static List<Animation> nailBatAttack = new List<Animation>();
        public static Animation nailBatIdle;
        public static Animation nailBatRecoil;
        public static Animation nailBatWalkAnimation;
        public static Animation nailBatThrowAnimation;

        public static List<Animation> cactusBatAttack = new List<Animation>();
        public static Animation cactusBatIdle;
        public static Animation cactusBatRecoil;
        public static Animation cactusBatWalkAnimation;
        public static Animation cactusBatThrowAnimation;

        public static List<Animation> bearHandsAttack = new List<Animation>();
        public static Animation bearHandsIdle;
        public static Animation bearHandsRecoil;
        public static Animation bearHandsWalkAnimation;
        public static Animation bearHandsThrowAnimation;

        public static List<Animation> knifeYoyoAttack = new List<Animation>();
        public static Animation knifeYoyoIdle;
        public static Animation knifeYoyoRecoil;
        public static Animation knifeYoyoWalkAnimation;
        public static Animation knifeYoyoThrowAnimation;

        public static List<Animation> acidMouseAttack = new List<Animation>();
        public static Animation acidMouseIdle;
        public static Animation acidMouseRecoil;
        public static Animation acidMouseWalkAnimation;
        public static Animation acidMouseThrowAnimation;

        public static List<Animation> radioactiveAttack = new List<Animation>();
        public static Animation radioactiveIdle;
        public static Animation radioactiveRecoil;
        public static Animation radioactiveWalkAnimation;
        public static Animation radioactiveThrowAnimation;

        public static List<Animation> nokiaAttack = new List<Animation>();
        public static Animation nokiaIdle;
        public static Animation nokiaRecoil;
        public static Animation nokiaWalkAnimation;
        public static Animation nokiaThrowAnimation;

        public static List<Animation> hockeyAttack = new List<Animation>();
        public static Animation hockeyIdle;
        public static Animation hockeyRecoil;
        public static Animation hockeyWalkAnimation;
        public static Animation hockeyThrowAnimation;

        public static List<Animation> lightsaberAttack = new List<Animation>();
        public static Animation lightsaberIdle;
        public static Animation lightsaberRecoil;
        public static Animation lightsaberWalkAnimation;
        public static Animation lightsaberThrowAnimation;


        public static DropItems[] allItems;

        
        public static Weapon checkRecipe(DropItems item1, DropItems item2)
        {
                //Leaf of canada
            if ((item1.name.Equals("Green Circle") && item2.name.Equals("Red Square")) || (item2.name.Equals("Green Circle") && item1.name.Equals("Red Square")))
            {
                Weapon tmp =new Weapon(500, "Weapon of Canada", "Strength", silCanada, mainCanada, iconCanada, iconCanada);
               tmp.setSplash(10);
               return tmp;
            }
                //Nail Bat
            else if ((item1.name.Equals("Deadly Nails") && item2.name.Equals("Baseball Bat")) || (item2.name.Equals("Deadly Nails") && item1.name.Equals("Baseball Bat")))
            {
                Weapon tmp = new Weapon(45, "Nail Bat", "Strength", silNailBat, mainNailBat, iconNailBat, infoNailBat);
                tmp.setSplash(2);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 300, 50);
                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 70, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = nailBatAttack;
                tmp.idelAnimation = nailBatIdle;
                tmp.recoilAnimation = nailBatRecoil;
                tmp.walkAnimation = nailBatWalkAnimation;
                tmp.throwAnimation = nailBatThrowAnimation;
                return tmp;

            }
            //Cactus Bat
            else if ((item1.name.Equals("Cactus") && item2.name.Equals("Gloves")) || (item2.name.Equals("Cactus") && item1.name.Equals("Gloves")))
            {
                Weapon tmp = new Weapon(60, "Cactus Bat", "Strength", silCactus, mainCactus, iconCactus, infoCactus);
                tmp.setSplash(4);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 300, 50);
                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 70, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = cactusBatAttack;
                tmp.idelAnimation = cactusBatIdle;
                tmp.recoilAnimation = cactusBatRecoil;
                tmp.walkAnimation = cactusBatWalkAnimation;
                tmp.throwAnimation = cactusBatThrowAnimation;
                return tmp;
            }
            //Knife yoyo
            else if ((item1.name.Equals("Knife") && item2.name.Equals("YoYo")) || (item2.name.Equals("Knife") && item1.name.Equals("YoYo")))
            {
                Weapon tmp = new Weapon(70, "Knife YoYo", "Agility", silYoYo, mainYoYo, iconYoYo, infoYoYo);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 300, 50);
                tmp.stun = 250;
                tmp.stunChance = 4;
                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 70, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = knifeYoyoAttack;
                tmp.idelAnimation = knifeYoyoIdle;
                tmp.recoilAnimation = knifeYoyoRecoil;
                tmp.walkAnimation = knifeYoyoWalkAnimation;
                tmp.throwAnimation = knifeYoyoThrowAnimation;
                return tmp;
            }
            //Bear Hands
            else if ((item1.name.Equals("Gloves") && item2.name.Equals("Knife")) || (item2.name.Equals("Gloves") && item1.name.Equals("Knife")))
            {
                Weapon tmp = new Weapon(80, "Bear Hands", "Agility", silBearHands, mainBearHands, iconBearHands, infoBearHands);
                tmp.stun = 200;
                tmp.stunChance = 5;

                tmp.attackAnimations = bearHandsAttack;
                tmp.idelAnimation = bearHandsIdle;
                tmp.recoilAnimation = bearHandsRecoil;
                tmp.walkAnimation = bearHandsWalkAnimation;
                tmp.throwAnimation = bearHandsThrowAnimation;
                return tmp;
            }
            //Light saber
            else if ((item1.name.Equals("Car Battery") && item2.name.Equals("Fluorescent Tube")) || (item2.name.Equals("Car Battery") && item1.name.Equals("Fluorescent Tube")))
            {
                Weapon tmp = new Weapon(105, "Light Saber", "Intelligence", silLightSaber, mainLightSaber, iconLightSaber, infoLightSaber);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 300, 50);
                tmp.setSplash(10);
                tmp.soundContactDelay = 10;
                tmp.name = "lightsaber";
                tmp.setWeaponBounds(tmpBounds, 70, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = lightsaberAttack;
                tmp.idelAnimation = lightsaberIdle;
                tmp.recoilAnimation = lightsaberRecoil;
                tmp.walkAnimation = lightsaberWalkAnimation;
                tmp.throwAnimation = lightsaberThrowAnimation;
                return tmp;
            }
            //Acid Mouse
            else if ((item1.name.Equals("Mouse") && item2.name.Equals("Chemical Flask")) || (item2.name.Equals("Mouse") && item1.name.Equals("Chemical Flask")))
            {
                Weapon tmp = new Weapon(95, "Acid Mouse", "Intelligence", silAcidMouse, mainAcidMouse, iconAcidMouse, infoAcidMouse);
                tmp.stun = 200;
                tmp.stunChance = 10;
                Rectangle tmpBounds = new Rectangle((int)0, 0, 310, 50);
                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 80, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = acidMouseAttack;
                tmp.idelAnimation = acidMouseIdle;
                tmp.recoilAnimation = acidMouseRecoil;
                tmp.walkAnimation = acidMouseWalkAnimation;
                tmp.throwAnimation = acidMouseThrowAnimation;
                return tmp;
            }
            //Radio Active Hands
            else if ((item1.name.Equals("Gloves") && item2.name.Equals("Chemical Flask")) || (item2.name.Equals("Gloves") && item1.name.Equals("Chemical Flask")))
            {
                Weapon tmp = new Weapon(100, "Radio Active Hands", "Intelligence", silRadio, mainRadio, iconRadio, infoRadio);
                tmp.attackpositionAdjustment = new Vector2(-50, -0);
                tmp.attackAnimations = radioactiveAttack;
                tmp.idelAnimation = radioactiveIdle;
                tmp.recoilAnimation = radioactiveRecoil;
                tmp.walkAnimation = radioactiveWalkAnimation;
                tmp.throwAnimation = radioactiveThrowAnimation;
                return tmp;
            }
            //Electric Hockey Stick
            else if ((item1.name.Equals("Car Battery") && item2.name.Equals("Hockey Stick")) || (item2.name.Equals("Car Battery") && item1.name.Equals("Hockey Stick")))
            {
                Weapon tmp = new Weapon(80, "Electric Hokey Stick", "Agility", silHockey, mainHockey, iconHockey, infoHockey);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 400, 50);
                tmp.setSplash(4);

                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 20, 195);
                tmp.attackpositionAdjustment = new Vector2(-100, -50);
                tmp.attackAnimations = hockeyAttack;
                tmp.idelAnimation = hockeyIdle;
                tmp.recoilAnimation = hockeyRecoil;
                tmp.walkAnimation = hockeyWalkAnimation;
                tmp.throwAnimation = hockeyThrowAnimation;
                return tmp;
            }
            //3310 on a Stick
            else if ((item1.name.Equals("Hockey Stick") && item2.name.Equals("Nokia 331O")) || (item2.name.Equals("Hockey Stick") && item1.name.Equals("Nokia 331O")))
            {
                Weapon tmp = new Weapon(90, "331O on a Stick", "Strength", silNokia, mainNokia, iconNokia, infoNokia);
                tmp.stun = 250;
                tmp.stunChance = 5;
                tmp.setSplash(2);
                Rectangle tmpBounds = new Rectangle((int)0, 0, 300, 50);
                tmp.soundContactDelay = 10;
                tmp.setWeaponBounds(tmpBounds, 70, 195);
                tmp.attackpositionAdjustment = new Vector2(-50, -50);
                tmp.attackAnimations = nokiaAttack;
                tmp.idelAnimation = nokiaIdle;
                tmp.recoilAnimation = nokiaRecoil;
                tmp.walkAnimation = nokiaWalkAnimation;
                tmp.throwAnimation = nokiaThrowAnimation;
                return tmp;
            }
            return null;
        }

        public static DropItems[] uncraftItems(Weapon w)
        {
            DropItems[] tmpItems = new DropItems[2];
            if (w.name.Contains("Nail Bat"))
            {
                tmpItems[0] = new DropItems(allItems[3]);
                tmpItems[1] = new DropItems(allItems[4]);
                return tmpItems;
            }
            else if (w.name.Contains("Nokia 331O"))
            {
                tmpItems[0] = new DropItems(allItems[16]);
                tmpItems[1] = new DropItems(allItems[6]);
                return tmpItems;
            }
            else if (w.name.Contains("Cactus Bat"))
            {
                tmpItems[0] = new DropItems(allItems[9]);
                tmpItems[1] = new DropItems(allItems[5]);
                return tmpItems;
            }
            else if (w.name.Contains("Knife YoYo"))
            {
                tmpItems[0] = new DropItems(allItems[11]);
                tmpItems[1] = new DropItems(allItems[14]);
                return tmpItems;
            }
            else if (w.name.Contains("Bear Hands"))
            {
                tmpItems[0] = new DropItems(allItems[9]);
                tmpItems[1] = new DropItems(allItems[11]);
                return tmpItems;
            }
            else if (w.name.Contains("Light Saber") || w.name.Contains("lightsaber"))
            {
                tmpItems[0] = new DropItems(allItems[6]);
                tmpItems[1] = new DropItems(allItems[8]);
                return tmpItems;
            }
            else if (w.name.Contains("Acid Mouse"))
            {
                tmpItems[0] = new DropItems(allItems[7]);
                tmpItems[1] = new DropItems(allItems[12]);
                return tmpItems;
            }
            else if (w.name.Contains("Radio Active Hands"))
            {
                tmpItems[0] = new DropItems(allItems[7]);
                tmpItems[1] = new DropItems(allItems[9]);
                return tmpItems;
            }
            else if (w.name.Contains("Electric Hokey Stick"))
            {
                
                tmpItems[0] = new DropItems(allItems[6]);
                tmpItems[1] = new DropItems(allItems[10]);
                return tmpItems;
            }
            else if (w.name.Contains("331O on a Stick"))
            {
                tmpItems[0] = new DropItems(allItems[10]);
                tmpItems[1] = new DropItems(allItems[13]);
                return tmpItems;
            }
            else
                return null;

            
        }
    }
}
