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
    class Bullet : Item
    {
        public Bullet(Vector2 pos)
            : base(pos)
        {

            spriteName = "bullet";

        }

        public override void Update()
        {
            if (!alive) return;

            if (position.X < 0 || position.Y < 0 || position.X > Game1.gameArea.Width || position.Y > Game1.gameArea.Height) 
                alive = false;

            Entity targetEnemy = Collision();

            if (targetEnemy != null && targetEnemy is Enemy && targetEnemy.alive == true)
            {
                (targetEnemy as Enemy).Damage(1);
                alive = false;
            }
                     
            base.Update();
        }
    }
}
