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

namespace TitanShooter
{
    public class Weapon : Item
    {
        public Weapon(Vector2 pos) : base(pos) { }

        public int ID;
        public string WeaponType;
        public string BulletType;

        public int ClipSize;
        public int MaxClips;

        public int ReloadTimer;
        public int ReloadTime; 

        public int ShootDelay;
        public int ShootDelayCnt;

        public int Weight;

        public int LevelReq;s
        public double Multiplier;
        public int ItemLevel { get { return ItemLevel; } set { ItemLevel = (int)Math.Round((double)LevelReq * Multiplier, MidpointRounding.AwayFromZero); } }
        //husk kontroller værdier!

        public int Damage;

        public Texture2D LoadTexture(ContentManager Content)
        {
            return Content.Load<Texture2D>("bullet");

        }

        public float BulletSpeed
        {
            get { return 15; }
        }
    }
}
