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
    public abstract class Entity : DrawableComponent
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

        

        
    }
}

