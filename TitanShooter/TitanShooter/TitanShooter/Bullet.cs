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
    public class Bullet : IPosition
    {
        public Bullet(Texture2D texture, Vector2 position, float direction, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.direction = direction;
            this.speed = speed;
        }

        private Texture2D texture;
        private Vector2 position;
        private float direction;
        private float speed;

        public Vector2 Position
        {
            get { return position; }
        }

        public void Update()
        {/*
            if (!Alive) return;

            if (position.X < 0 || position.Y < 0 || position.X > Game1.gameArea.Width || position.Y > Game1.gameArea.Height) 
                Alive = false;

            Entity targetEnemy = this.Collision(this);

            if (targetEnemy != null && targetEnemy is Enemy && targetEnemy.Alive == true)
            {
                (targetEnemy as Enemy).Damage(1);
                Alive = false;
            }
                     
            base.Update();*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 center = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position, null, Color.White,
                MathHelper.ToRadians(direction), center, 1, SpriteEffects.None, 0);
        }
    }
}
