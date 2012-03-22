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
    class Enemy : Entity
    {
        public int health;
        public float spd = 1.5f;
        private Vector2 dest;
        public int maxHealth = 10;

        public Enemy(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "enemy";
            speed = spd;
            health = maxHealth;
        }

        private void MoveToDest()
        {
            dest = Player.player.position;
            rotation = PointDirection(Player.player.position);
        }

        public override void Update()
        {
            if (health <= 0)
            {
                alive = false;
                
                health = maxHealth;
                return;
            }

            MoveToDest();
            base.Update();
        }

        public void Damage(int dmg)
        {
            health -= dmg;
        }



    }
}
