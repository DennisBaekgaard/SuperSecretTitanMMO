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
        private Dictionary<Weapon, Texture2D> textures;

        private List<Bullet> bullets;

        private class Bullet
        {
            public Texture2D Texture;
            public Vector2 Position;
            public float Direction;
            public float Speed;
        }

        public BulletCollection(Game1 game)
            : base(game)
        {
            this.bullets = new List<Bullet>();
        }

        public void Add(Weapon weapon, Vector2 position, float direction, float speed)
        {
            Texture2D texture;
            if (!this.textures.ContainsKey(weapon))
                this.textures.Add(weapon, weapon.LoadTexture(this.Game.Content));
            texture = textures[weapon];
            this.bullets.Add(new Bullet() { Position = position, Direction = direction, Speed = speed, Texture = texture });
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
                Vector2 center = new Vector2(v.Texture.Width / 2, v.Texture.Height / 2);
                spriteBatch.Draw(v.Texture, v.Position, null, Color.White, 
                    MathHelper.ToRadians(v.Direction), center, 1, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }
    }
}
