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
    public abstract class Entity
    {
        public Vector2 position;
        public float rotation = 0.0f;
        public Texture2D spriteIndex;
        public string spriteName = "nosprite";
        public float speed = 0.0f;
        public float scale = 1.0f;
        public bool alive = true;
        public Rectangle area;
 

        public Entity(Vector2 pos)
        {
            position = pos;
        }

        public Entity() { }

        public virtual void Update()
        {
            if (!alive) return;
                    
            
            UpdateArea();

            PushTo(speed, rotation);
        }

        public void UpdateArea()
        {
            area.X = (int)position.X - (spriteIndex.Width / 2);
            area.Y = (int)position.Y - (spriteIndex.Height / 2);
        }

        public void LoadContent(ContentManager content)
        {
            spriteIndex = content.Load<Texture2D>("sprites\\" + this.spriteName);
            area = new Rectangle(0, 0, spriteIndex.Width, spriteIndex.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!alive) return;
            Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);
            spriteBatch.Draw(spriteIndex, position, null, Color.White, MathHelper.ToRadians(rotation), center, scale, SpriteEffects.None, 0);
        }

        public virtual void PushTo(float pix, float angle)
        {
            //TODO collision detection 
            float newX = (float)Math.Cos(MathHelper.ToRadians(angle));
            float newY = (float)Math.Sin(MathHelper.ToRadians(angle));
            position.X += pix * newX;
            position.Y += pix * newY;
        }

        public float PointDirection(Vector2 targetPos)
        {
            float diffx = position.X - targetPos.X;
            float diffy = position.Y - targetPos.Y;
            float tan = diffy / diffx;
            float res = MathHelper.ToDegrees((float)Math.Atan2(diffy, diffx));
            res = (res - 180) % 360;

            if (res < 0)
                res += 360;

            return res;
        }

        public void Shoot(Vector2 mousePos, int bulletSpeed)
        {

            foreach (Entity entity in Ressources.objectsList)
            {
                if (entity.GetType() == typeof(Bullet) && !(entity.alive))
                {
                    entity.position = position;
                    entity.rotation = rotation;
                    entity.speed = bulletSpeed;
                    entity.alive = true;
                    entity.UpdateArea();
                    break;
                }
            }
        }

        public Entity Collision(Entity entity)
        {
            foreach (Entity ent in Ressources.objectsList)
            {
                if (ent.GetType() == entity.GetType())
                    if (ent.area.Intersects(area) )
                        return ent;
            }
            return new Enemy(new Vector2(-50, -50));
        }

        
    }
}

