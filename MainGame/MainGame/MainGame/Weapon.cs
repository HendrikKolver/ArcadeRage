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
    class Weapon
    {
        public double damage;
        public String type;
        public String name;
        public Texture2D silhouette;
        public Texture2D mainImage;
        public Texture2D icon;
        public Texture2D info;
        public Rectangle weaponBounds;
        public List<Animation> attackAnimations = new List<Animation>();
        public Animation idelAnimation;
        public Animation recoilAnimation;
        public Animation walkAnimation;
        public Animation throwAnimation;
        public int weaponXAdjustment;
        public int weaponYAdjustment;
        public Vector2 attackpositionAdjustment = new Vector2(0,0);
        public int soundContactDelay;
        
        public int splashCount = 1;
        public int stun =0;
        public int stunChance = 0;

        public Weapon()
        {
            stun = 200;
            stunChance = 20;
            damage = 30;
            type = "None";
            name = "Fists";
            weaponBounds = new Rectangle((int)0, 0, 220, 50);
            weaponXAdjustment = 135;
            weaponYAdjustment = 195;
            soundContactDelay = 6;
        }

        public Weapon(double d, String n, String t, Texture2D s, Texture2D m, Texture2D i, Texture2D inf)
        {
            damage = d;
            type = t;
            name = n;
            silhouette = s;
            mainImage = m;
            icon = i;
            info = inf;
            weaponBounds = new Rectangle((int)0, 0, 220, 50);
            weaponXAdjustment = 135;
            weaponYAdjustment = 195;
            soundContactDelay = 6;
        }

        public void setWeaponBounds(Rectangle r,int x, int y)
        {
            weaponBounds = r;
            weaponXAdjustment = x;
            weaponYAdjustment = y;
        }

        public void setSplash(int s)
        {
            splashCount = s; 
        }

        public void setStun(int s, int stunChance)
        {
            stun = s;
            this.stunChance = stunChance;
        }

        public void setAnimations(List<Animation> a)
        {
            attackAnimations = a;
        }

        public void setIcon(Texture2D i)
        {
            icon = i;
        }

        public void setSilhouette(Texture2D s)
        {
            silhouette = s;
        }

        public void setMainImage(Texture2D m)
        {
            mainImage = m;
        }

        public void setDamage(double damage)
        {
            this.damage = damage;
        }

        public double getDamage()
        {
            return damage;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getType()
        {
            return type;
        }
    }
}
