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
        private Texture2D texture;

        private List<Bullet> bullets;

        private class Bullet
        {
            public Vector2 Position;
            public float Direction;
            public float Speed;
        }

        public BulletCollection(Game1 game)
            : base(game)
        {
            this.bullets = new List<Bullet>();
        }

        public void Add(Vector2 position, float direction, float speed)
        {
            this.bullets.Add(new Bullet() { Position = position, Direction = direction, Speed = speed });
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("bullet");
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
            Vector2 center = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Begin();
            foreach (var v in bullets)
            {
                spriteBatch.Draw(texture, v.Position, null, Color.White, 
                    MathHelper.ToRadians(v.Direction), center, 1, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }
    }
}
