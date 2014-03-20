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
    class EnemyHandler
    {
        public SpriteFont DropItemFont;
        IntelligenceProjectile projectile;
        //Boss Stuff------------------------
        public Animation Attack1Boss;
        public Animation Attack1BossVar1;
        public Animation Attack1BossVar2;
        public Animation Attack2Boss;
        public Animation Attack2BossVar1;
        public Animation Attack3Boss;
        public Animation Attack3BossVar1;
        public Animation Walk1Boss;
        public Animation Walk2Boss;
        public Animation Walk3Boss;
        public Animation Idle1Boss;
        public Animation Idle2Boss;
        public Animation Idle3Boss;
        public Animation Recoil1Boss;
        public Animation Recoil2Boss;
        public Animation Recoil3Boss;
        public Animation deathBoss;
        public Animation powerUp1;
        public Animation powerUp2;
        private Texture2D bossThumb;
        public Texture2D[] bossFightTextures;
        //-------------------------------------
        //STRENGTH
        private Texture2D[] strengthTextures;
        private Texture2D[] recoilStrengthTextures;
        private Texture2D[] AttackStrengthTextures;
        private Texture2D[] DeathStrengthTextures;
        private Texture2D[] idleStrengthTextures;
        private Texture2D strengthThumb;
        //VARIATION - STRENGTH
        private Texture2D[] strengthTexturesVariation;
        private Texture2D[] recoilStrengthTexturesVariation;
        private Texture2D[] AttackStrengthTexturesVariation;
        private Texture2D[] DeathStrengthTexturesVariation;
        private Texture2D[] idleStrengthTexturesVariation;
        private Texture2D strengthThumbVariation;
        //VARIATION 2 - STRENGTH
        private Texture2D[] strengthTexturesVariation2;
        private Texture2D[] recoilStrengthTexturesVariation2;
        private Texture2D[] AttackStrengthTexturesVariation2;
        private Texture2D[] DeathStrengthTexturesVariation2;
        private Texture2D[] idleStrengthTexturesVariation2;
        private Texture2D strengthThumbVariation2;


        //AGILITY
        private Texture2D[] agilityTextures;
        private Texture2D[] recoilAgilityTextures;
        private Texture2D[] AttackAgilityTextures;
        private Texture2D[] DeathAgilityTextures;
        private Texture2D[] idleAgilityTextures;
        private Texture2D agilityThumb;
        //VARIATION - AGILITY
        private Texture2D[] agilityTexturesVariation;
        private Texture2D[] recoilAgilityTexturesVariation;
        private Texture2D[] AttackAgilityTexturesVariation;
        private Texture2D[] DeathAgilityTexturesVariation;
        private Texture2D[] idleAgilityTexturesVariation;
        private Texture2D agilityThumbVariation;
        //VARIATION 2 - AGILITY
        private Texture2D[] agilityTexturesVariation2;
        private Texture2D[] recoilAgilityTexturesVariation2;
        private Texture2D[] AttackAgilityTexturesVariation2;
        private Texture2D[] DeathAgilityTexturesVariation2;
        private Texture2D[] idleAgilityTexturesVariation2;
        private Texture2D agilityThumbVariation2;

        //INTELLIGENCE
        private Texture2D[] intelligenceTextures;
        private Texture2D[] recoilIntelligenceTextures;
        private Texture2D[] AttackIntelligenceTextures;
        private Texture2D[] DeathIntelligenceTextures;
        private Texture2D[] idleIntelligenceTextures;
        private Texture2D intelligenceThumb;
        //VARIATION - INTELLIGENCE
        private Texture2D[] intelligenceTexturesVariation;
        private Texture2D[] recoilIntelligenceTexturesVariation;
        private Texture2D[] AttackIntelligenceTexturesVariation;
        private Texture2D[] DeathIntelligenceTexturesVariation;
        private Texture2D[] idleIntelligenceTexturesVariation;
        private Texture2D intelligenceThumbVariation;
        //VARIATION - INTELLIGENCE
        private Texture2D[] intelligenceTexturesVariation2;
        private Texture2D[] recoilIntelligenceTexturesVariation2;
        private Texture2D[] AttackIntelligenceTexturesVariation2;
        private Texture2D[] DeathIntelligenceTexturesVariation2;
        private Texture2D[] idleIntelligenceTexturesVariation2;
        private Texture2D intelligenceThumbVariation2;

        //PUNCHING BAG
        private Texture2D[] punchingBagTextures;
        private Texture2D[] recoilPunchingBagTextures;
        private Texture2D[] recoilPunchingBagReverseTextures;
        private Texture2D[] DeathPunchingBagTextures;
        private Texture2D punchingBagThumb;


        private DropItems[] allItems;
        Random randomGenerator;
        Random generator2;
        private List<Texture2D> projectileTextures0L = new List<Texture2D>();
        private List<Texture2D> projectileTextures0R = new List<Texture2D>();
        private List<Texture2D> projectileTextures1L = new List<Texture2D>();
        private List<Texture2D> projectileTextures1R = new List<Texture2D>();

        private GraphicsDevice graphicsDevice;

        private Player player;
        BasicParticleSystem particleSystem;
        BasicParticleSystem particleSystem2;

        public EnemyHandler(Texture2D[] strengthTexture_, Texture2D[] agilityTexture_, Texture2D[] intelligenceTexture_, Texture2D[] punchingBagTextures_, DropItems[] allItems, GraphicsDevice graphicsDevice_, Player player_, BasicParticleSystem particleSystem, BasicParticleSystem particleSystem2)
        {
            //this.strengthTextures = new Texture2D[strengthTexture_.Length];
            //this.agilityTextures = new Texture2D[agilityTexture_.Length];
            //this.intelligenceTextures = new Texture2D[intelligenceTexture_.Length];
            this.particleSystem = particleSystem;
            this.particleSystem2 = particleSystem2;

            strengthTextures = strengthTexture_;
            agilityTextures = agilityTexture_;
            intelligenceTextures = intelligenceTexture_;
            punchingBagTextures = punchingBagTextures_;

            randomGenerator = new Random();
            generator2 = new Random();
            /*this.strengthTexture = strengthTexture_;
            this.agilityTexture = agilityTexture_;
            this.intelligenceTexture = intelligenceTexture_;*/
            this.allItems = allItems;
            this.graphicsDevice = graphicsDevice_;
            this.player = player_;
        }

        public void addBossThumbnail(Texture2D val)
        {
          this.bossThumb = val;
        }

        public void setBossTextures(Texture2D[] val)
        {
            bossFightTextures = val;
        }

        //STRENGTH FUNCTIONS
        public void addStrengthThumbnail(Texture2D strength)
        {
            strengthThumb = strength;
        }
        public void setRecoilStrengthTextures(Texture2D[] val)
        {
            recoilStrengthTextures = val;
        }
        public void setAttackStrengthTextures(Texture2D[] val)
        {
            AttackStrengthTextures = val;
        }
        public void setDeathStrengthTextures(Texture2D[] val)
        {
            DeathStrengthTextures = val;
        }
        public void setIdleStrengthTextures(Texture2D[] val)
        {
            idleStrengthTextures = val;
        }
        //STRENGTH VARIATION 1
        public void addStrengthTextureVariation(Texture2D[] strengthStuff)
        {
            strengthTexturesVariation = strengthStuff;
        }
        public void addStrengthThumbnailVariation(Texture2D strength)
        {
            strengthThumbVariation = strength;
        }
        public void setRecoilStrengthTexturesVariation(Texture2D[] val)
        {
            recoilStrengthTexturesVariation = val;
        }
        public void setAttackStrengthTexturesVariation(Texture2D[] val)
        {
            AttackStrengthTexturesVariation = val;
        }
        public void setDeathStrengthTexturesVariation(Texture2D[] val)
        {
            DeathStrengthTexturesVariation = val;
        }
        public void setIdleStrengthTexturesVariation(Texture2D[] val)
        {
            idleStrengthTexturesVariation = val;
        }
        //STRENGTH VARIATION 2
        public void addStrengthTextureVariation2(Texture2D[] strength)
        {
            strengthTexturesVariation2 = strength;
        }
        public void addStrengthThumbnailVariation2(Texture2D strength)
        {
            strengthThumbVariation2 = strength;
        }
        public void setRecoilStrengthTexturesVariation2(Texture2D[] val)
        {
            recoilStrengthTexturesVariation2 = val;
        }
        public void setAttackStrengthTexturesVariation2(Texture2D[] val)
        {
            AttackStrengthTexturesVariation2 = val;
        }
        public void setDeathStrengthTexturesVariation2(Texture2D[] val)
        {
            DeathStrengthTexturesVariation2 = val;
        }
        public void setIdleStrengthTexturesVariation2(Texture2D[] val)
        {
            idleStrengthTexturesVariation2 = val;
        }


        //INTELLIGENCE FUNCTIONs
        public void addIntelligenceThumbnail(Texture2D intelligence)
        {
            intelligenceThumb = intelligence;
        }
        public void setRecoilIntelligenceTextures(Texture2D[] val)
        {
            recoilIntelligenceTextures = val;
        }
        public void setAttackIntelligenceTextures(Texture2D[] val)
        {
            AttackIntelligenceTextures = val;
        }
        public void setDeathIntelligenceTextures(Texture2D[] val)
        {
            DeathIntelligenceTextures = val;
        }
        public void setIdleIntelligenceTextures(Texture2D[] val)
        {
            idleIntelligenceTextures = val;
        }
        //INTELLIGENCE VARIATION 1
        public void addIntelligenceTextureVariation(Texture2D[] val)
        {
            intelligenceTexturesVariation = val;
        }
        public void addIntelligenceThumbnailVariation(Texture2D intelligence)
        {
            intelligenceThumbVariation = intelligence;
        }
        public void setRecoilIntelligenceTexturesVariation(Texture2D[] val)
        {
            recoilIntelligenceTexturesVariation = val;
        }
        public void setAttackIntelligenceTexturesVariation(Texture2D[] val)
        {
            AttackIntelligenceTexturesVariation = val;
        }
        public void setDeathIntelligenceTexturesVariation(Texture2D[] val)
        {
            DeathIntelligenceTexturesVariation = val;
        }
        public void setIdleIntelligenceTexturesVariation(Texture2D[] val)
        {
            idleIntelligenceTexturesVariation = val;
        }
        //INTELLIGENCE VARIATION 1
        public void addIntelligenceTextureVariation2(Texture2D[] val)
        {
            intelligenceTexturesVariation2 = val;
        }
        public void addIntelligenceThumbnailVariation2(Texture2D intelligence)
        {
            intelligenceThumbVariation2 = intelligence;
        }
        public void setRecoilIntelligenceTexturesVariation2(Texture2D[] val)
        {
            recoilIntelligenceTexturesVariation2 = val;
        }
        public void setAttackIntelligenceTexturesVariation2(Texture2D[] val)
        {
            AttackIntelligenceTexturesVariation2 = val;
        }
        public void setDeathIntelligenceTexturesVariation2(Texture2D[] val)
        {
            DeathIntelligenceTexturesVariation2 = val;
        }
        public void setIdleIntelligenceTexturesVariation2(Texture2D[] val)
        {
            idleIntelligenceTexturesVariation2 = val;
        }


        //AGILITY FUNCTIONS
        public void addAgilityThumbnail(Texture2D agility)
        {
            agilityThumb = agility;
        }
        public void setRecoilAgilityTextures(Texture2D[] val)
        {
            recoilAgilityTextures = val;
        }
        public void setAttackAgilityTextures(Texture2D[] val)
        {
            AttackAgilityTextures = val;
        }
        public void setDeathAgilityTextures(Texture2D[] val)
        {
            DeathAgilityTextures = val;
        }
        public void setIdleAgilityTextures(Texture2D[] val)
        {
            idleAgilityTextures = val;
        }
        //AGILITY VARIATION 1
        public void addAgilityTextureVariation(Texture2D[] val)
        {
            agilityTexturesVariation = val;
        }
        public void addAgilityThumbnailVariation(Texture2D agility)
        {
            agilityThumbVariation = agility;
        }
        public void setRecoilAgilityTexturesVariation(Texture2D[] val)
        {
            recoilAgilityTexturesVariation = val;
        }
        public void setAttackAgilityTexturesVariation(Texture2D[] val)
        {
            AttackAgilityTexturesVariation = val;
        }
        public void setDeathAgilityTexturesVariation(Texture2D[] val)
        {
            DeathAgilityTexturesVariation = val;
        }
        public void setIdleAgilityTexturesVariation(Texture2D[] val)
        {
            idleAgilityTexturesVariation = val;
        }
        //AGILITY VARIATION 2
        public void addAgilityTextureVariation2(Texture2D[] val)
        {
            agilityTexturesVariation2 = val;
        }
        public void addAgilityThumbnailVariation2(Texture2D agility)
        {
            agilityThumbVariation2 = agility;
        }
        public void setRecoilAgilityTexturesVariation2(Texture2D[] val)
        {
            recoilAgilityTexturesVariation2 = val;
        }
        public void setAttackAgilityTexturesVariation2(Texture2D[] val)
        {
            AttackAgilityTexturesVariation2 = val;
        }
        public void setDeathAgilityTexturesVariation2(Texture2D[] val)
        {
            DeathAgilityTexturesVariation2 = val;
        }
        public void setIdleAgilityTexturesVariation2(Texture2D[] val)
        {
            idleAgilityTexturesVariation2 = val;
        }

        //PUNCHING BAG FUNCTIONS
        public void addPunchingBagThumbnail(Texture2D punching)
        {
            punchingBagThumb = punching;
        }
        public void setRecoilPunchingBagTextures(Texture2D[] val)
        {
            recoilPunchingBagTextures = val;
        }
        public void setRecoilPunchingBagReverseTextures(Texture2D[] val)
        {
            recoilPunchingBagReverseTextures = val;
        }
        public void setDeathPunchingBagTextures(Texture2D[] val)
        {
            DeathPunchingBagTextures = val;
        }



        public void addWeapon(IntelligenceProjectile ip)
        {
            this.projectile = ip;
        }

        //Projectiles
        public void addProjectileCell1L(Texture2D texture)  //Binary 1 - Left
        {
            projectileTextures1L.Add(texture);
        }

        public void addProjectileCell0L(Texture2D texture)   //Binary 0 - Left
        {
            projectileTextures0L.Add(texture);
        }

        public void addProjectileCell1R(Texture2D texture)    //Binary 1 - Right
        {
            projectileTextures1R.Add(texture);
        }

        public void addProjectileCell0R(Texture2D texture)    //Binary 0 - Right
        {
            projectileTextures0R.Add(texture);
        }


        //STRENGTH
        public Enemy generateStrengthEnemy(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTextures, strengthThumb, player, allItems[0], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTextures);
            tmp.addAttackCells(AttackStrengthTextures);
            tmp.addDeathCells(DeathStrengthTextures);
            tmp.addIdleCells(idleStrengthTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateStrengthEnemy(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTextures, strengthThumb, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTextures);
            tmp.addAttackCells(AttackStrengthTextures);
            tmp.addDeathCells(DeathStrengthTextures);
            tmp.addIdleCells(idleStrengthTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateStrengthEnemyVariation(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Console.Write("ENEMY: " + strengthTexturesVariation.Length + " , " + strengthThumbVariation == null);
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTexturesVariation, strengthThumbVariation, player, allItems[0], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTexturesVariation);
            tmp.addAttackCells(AttackStrengthTexturesVariation);
            tmp.addDeathCells(DeathStrengthTexturesVariation);
            tmp.addIdleCells(idleStrengthTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateStrengthEnemyVariation(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Console.Write("ENEMY: " + strengthTexturesVariation.Length + " , " + strengthThumbVariation == null);
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTexturesVariation, strengthThumbVariation, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTexturesVariation);
            tmp.addAttackCells(AttackStrengthTexturesVariation);
            tmp.addDeathCells(DeathStrengthTexturesVariation);
            tmp.addIdleCells(idleStrengthTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateStrengthEnemyVariation2(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTexturesVariation2, strengthThumbVariation2, player, allItems[0], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTexturesVariation2);
            tmp.addAttackCells(AttackStrengthTexturesVariation2);
            tmp.addDeathCells(DeathStrengthTexturesVariation2);
            tmp.addIdleCells(idleStrengthTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateStrengthEnemyVariation2(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new StrengthEnemy(graphicsDevice, new Vector2(x, y), strengthTexturesVariation2, strengthThumbVariation2, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilStrengthTexturesVariation2);
            tmp.addAttackCells(AttackStrengthTexturesVariation2);
            tmp.addDeathCells(DeathStrengthTexturesVariation2);
            tmp.addIdleCells(idleStrengthTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }

        //INTELLIGENCE
        public Enemy generateIntelligenceEnemy(float x1, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTextures, intelligenceThumb, player, allItems[1], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTextures);
            tmp.addAttackCells(AttackIntelligenceTextures);
            tmp.addDeathCells(DeathIntelligenceTextures);
            tmp.addIdleCells(idleIntelligenceTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateIntelligenceEnemy(float x1, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTextures, intelligenceThumb, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTextures);
            tmp.addAttackCells(AttackIntelligenceTextures);
            tmp.addDeathCells(DeathIntelligenceTextures);
            tmp.addIdleCells(idleIntelligenceTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateIntelligenceEnemyVariation(float x1, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTexturesVariation, intelligenceThumbVariation, player, allItems[1], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTexturesVariation);
            tmp.addAttackCells(AttackIntelligenceTexturesVariation);
            tmp.addDeathCells(DeathIntelligenceTexturesVariation);
            tmp.addIdleCells(idleIntelligenceTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateIntelligenceEnemyVariation(float x1, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTexturesVariation, intelligenceThumbVariation, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTexturesVariation);
            tmp.addAttackCells(AttackIntelligenceTexturesVariation);
            tmp.addDeathCells(DeathIntelligenceTexturesVariation);
            tmp.addIdleCells(idleIntelligenceTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateIntelligenceEnemyVariation2(float x1, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTexturesVariation2, intelligenceThumbVariation2, player, allItems[1], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTexturesVariation2);
            tmp.addAttackCells(AttackIntelligenceTexturesVariation2);
            tmp.addDeathCells(DeathIntelligenceTexturesVariation2);
            tmp.addIdleCells(idleIntelligenceTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateIntelligenceEnemyVariation2(float x1, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new IntelligenceEnemy(graphicsDevice, new Vector2(x1, y), intelligenceTexturesVariation2, intelligenceThumbVariation2, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            IntelligenceProjectile intelligenceProjectile = new IntelligenceProjectile(graphicsDevice, new Vector2(-200, -200), projectileTextures0R.ElementAt(0));
            for (int x = 0; x < projectileTextures0L.Count; x++)
                intelligenceProjectile.addCell0L(projectileTextures0L.ElementAt(x));

            for (int x = 0; x < projectileTextures0R.Count; x++)
                intelligenceProjectile.addCell0R(projectileTextures0R.ElementAt(x));

            for (int x = 0; x < projectileTextures1L.Count; x++)
                intelligenceProjectile.addCell1L(projectileTextures1L.ElementAt(x));

            for (int x = 0; x < projectileTextures1R.Count; x++)
                intelligenceProjectile.addCell1R(projectileTextures1R.ElementAt(x));

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addWeapon(intelligenceProjectile);
            tmp.addRecoilCells(recoilIntelligenceTexturesVariation2);
            tmp.addAttackCells(AttackIntelligenceTexturesVariation2);
            tmp.addDeathCells(DeathIntelligenceTexturesVariation2);
            tmp.addIdleCells(idleIntelligenceTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }

        //INTELLIGENCE
        public Enemy generateAgilityEnemy(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTextures, agilityThumb, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTextures);
            tmp.addAttackCells(AttackAgilityTextures);
            tmp.addDeathCells(DeathAgilityTextures);
            tmp.addIdleCells(idleAgilityTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateAgilityEnemy(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTextures, agilityThumb, player, allItems[2], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTextures);
            tmp.addAttackCells(AttackAgilityTextures);
            tmp.addDeathCells(DeathAgilityTextures);
            tmp.addIdleCells(idleAgilityTextures);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateAgilityEnemyVariation(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTexturesVariation, agilityThumbVariation, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTexturesVariation);
            tmp.addAttackCells(AttackAgilityTexturesVariation);
            tmp.addDeathCells(DeathAgilityTexturesVariation);
            tmp.addIdleCells(idleAgilityTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateAgilityEnemyVariation(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTexturesVariation, agilityThumbVariation, player, allItems[2], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTexturesVariation);
            tmp.addAttackCells(AttackAgilityTexturesVariation);
            tmp.addDeathCells(DeathAgilityTexturesVariation);
            tmp.addIdleCells(idleAgilityTexturesVariation);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateAgilityEnemyVariation2(float x, float y, bool dropItemOnDeath, int itemToDrop, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTexturesVariation2, agilityThumbVariation2, player, allItems[itemToDrop], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTexturesVariation2);
            tmp.addAttackCells(AttackAgilityTexturesVariation2);
            tmp.addDeathCells(DeathAgilityTexturesVariation2);
            tmp.addIdleCells(idleAgilityTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }
        public Enemy generateAgilityEnemyVariation2(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new AgilityEnemy(graphicsDevice, new Vector2(x, y), agilityTexturesVariation2, agilityThumbVariation2, player, allItems[2], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilAgilityTexturesVariation2);
            tmp.addAttackCells(AttackAgilityTexturesVariation2);
            tmp.addDeathCells(DeathAgilityTexturesVariation2);
            tmp.addIdleCells(idleAgilityTexturesVariation2);
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty((int)diffie);
            return tmp;
        }

        //PUNCHING BAG
        public Enemy generatePunchingBag(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new PunchingBag(graphicsDevice, new Vector2(x, y), punchingBagTextures, punchingBagThumb, player, allItems[2], this.particleSystem, this.particleSystem2);
            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.addRecoilCells(recoilPunchingBagTextures);
            tmp.addRecoilReverseCells(recoilPunchingBagReverseTextures);
            tmp.addDeathCells(DeathPunchingBagTextures);
            tmp.punchingBagDeath();
            tmp.dropItemFont = DropItemFont;

            return tmp;
        }

        public Enemy generateEvilJP(float x, float y, bool dropItemOnDeath, double diffie)
        {
            Enemy tmp = new EvilJP(graphicsDevice, new Vector2(x, y), bossFightTextures, bossThumb, player, allItems[2], this.particleSystem, this.particleSystem2);

            tmp.dropItemOnDeath = dropItemOnDeath;
            tmp.Attack1Boss= this.Attack1Boss;
            tmp.Attack1BossVar1 = this.Attack1BossVar1;
            tmp.Attack1BossVar2 = this.Attack1BossVar2;
            tmp.Attack2Boss = this.Attack2Boss;
            tmp.Attack2BossVar1 = this.Attack2BossVar1;
            tmp.Attack3Boss = this.Attack3Boss;
            tmp.Attack3BossVar1 = this.Attack3BossVar1;
            tmp.Walk1Boss = this.Walk1Boss;
            tmp.Walk2Boss = this.Walk2Boss;
            tmp.Walk3Boss = this.Walk3Boss;
            tmp.Idle1Boss = this.Idle1Boss;
            tmp.Idle2Boss = this.Idle2Boss;
            tmp.Idle3Boss = this.Idle3Boss;
            tmp.Recoil1Boss = this.Recoil1Boss;
            tmp.Recoil2Boss = this.Recoil2Boss;
            tmp.Recoil3Boss = this.Recoil3Boss;
            tmp.deathBoss = this.deathBoss;
            tmp.powerUp1 = this.powerUp1;
            
            tmp.powerUp2 = this.powerUp2;
            tmp.dropItemFont = DropItemFont;
            tmp.setDificulty(1);
            return tmp;
        }

        public void adjustSpeed(Enemy e, double newSpeed)
        {

        }
    }
}
