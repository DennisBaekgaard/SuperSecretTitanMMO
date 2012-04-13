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
    class Bullet : Item, IDrawableComponentProperties
    {
        public Bullet(Vector2 pos)
            : base(pos)
        {

            SpriteName = "bullet";

        }

        public override void Update()
        {
            if (!Alive) return;

            if (Position.X < 0 || Position.Y < 0 || Position.X > Game1.gameArea.Width || Position.Y > Game1.gameArea.Height) 
                Alive = false;

            Entity targetEnemy = this.Collision(this);

            if (targetEnemy != null && targetEnemy is Enemy && targetEnemy.Alive == true)
            {
                (targetEnemy as Enemy).Damage(1);
                Alive = false;
            }
                     
            base.Update();
        }
    }
}
