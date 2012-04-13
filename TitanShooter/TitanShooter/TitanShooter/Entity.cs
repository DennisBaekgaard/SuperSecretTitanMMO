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
    public abstract class Entity : IDrawableComponentProperties
    {

        private Vector2 position;
        private float rotation;
        private Texture2D spriteIndex;
        private string spriteName;
        private float speed;
        private float scale = 1;
        private bool alive = true;
        private Rectangle area;


        public Vector2 Position { get { return position; } set { position = value; } }
        public float Rotation { get { return rotation; } set { rotation = value; } }
        public Texture2D SpriteIndex { get { return spriteIndex; } set { spriteIndex = value; } }
        public string SpriteName { get { return spriteName; } set { spriteName = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public float Scale { get { return scale; } set { scale = value; } }
        public bool Alive { get { return alive; } set { alive = value; } }
        public Rectangle Area { get { return area; } set { area = value; } }


        public Entity(Vector2 pos)
        {
            Position = pos;
        }

        public Entity() { }

        public virtual void Update()
        {
            if (!Alive) return;
            

            this.UpdateArea();

            this.PushTo(Speed, Rotation);
        }

        public void Shoot(Vector2 mousePos, int bulletSpeed)
        {

            foreach (Entity entity in Ressources.objectsList)
            {
                if (entity.GetType() == typeof(Bullet) && !(entity.Alive))
                {
                    entity.Position = Position;
                    entity.Rotation = Rotation;
                    entity.Speed = bulletSpeed;
                    entity.Alive = true;
                    entity.UpdateArea();
                    break;
                }
            }
        }




    }
}

