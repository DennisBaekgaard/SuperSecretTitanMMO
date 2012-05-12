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
    public class BulletCollection : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private List<Bullet> bullets;

        public BulletCollection(Game1 game)
            : base(game)
        {
            this.bullets = new List<Bullet>();
        }

        public void Add(Weapon weapon, Vector2 position, float direction)
        {
            this.bullets.Add(weapon.CreateBullet(position, direction));
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var v in bullets)
            {
                // Do something that calculates the new position...
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (var v in bullets)
            {
                v.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
