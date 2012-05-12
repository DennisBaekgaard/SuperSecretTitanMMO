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
    static class DrawableComponentExt
    {

        

        
        public static void UpdateArea(this IDrawableComponentProperties component)
        {
            component.Area = new Rectangle((int)component.Position.X - (component.SpriteIndex.Width / 2), (int)component.Position.Y - (component.SpriteIndex.Height / 2), component.Area.Width, component.Area.Height);
            
        }

        public static void LoadContent(this IDrawableComponentProperties component, ContentManager content)
        {
            component.SpriteIndex = content.Load<Texture2D>("sprites\\" + component.SpriteName);
            component.Area = new Rectangle(0, 0, component.SpriteIndex.Width, component.SpriteIndex.Height);
        }

        public static void Draw(this IDrawableComponentProperties component, SpriteBatch spriteBatch)
        {
            if (!component.Alive) return;
            Vector2 center = new Vector2(component.SpriteIndex.Width / 2, component.SpriteIndex.Height / 2);
            spriteBatch.Draw(component.SpriteIndex, component.Position, null, Color.White, MathHelper.ToRadians(component.Rotation), center, component.Scale, SpriteEffects.None, 0);
        }

        public static void PushTo(this IDrawableComponentProperties component, float pix, float angle)
        {
            //TODO collision detection 
            float newX = (float)Math.Cos(MathHelper.ToRadians(angle));
            float newY = (float)Math.Sin(MathHelper.ToRadians(angle));
            component.Position += new Vector2(newX, newY) * pix;
        }

        public static float PointDirection(this IDrawableComponentProperties component, Vector2 targetPos)
        {
            float diffx = component.Position.X - targetPos.X;
            float diffy = component.Position.Y - targetPos.Y;
            float tan = diffy / diffx;
            float res = MathHelper.ToDegrees((float)Math.Atan2(diffy, diffx));
            res = (res - 180) % 360;

            if (res < 0)
                res += 360;

            return res;
        }


        public static Entity Collision(this IDrawableComponentProperties component, Entity entity)
        {
            foreach (Entity ent in Ressources.objectsList)
            {
                if (ent.GetType() == entity.GetType())
                    if (ent.Area.Intersects(component.Area))
                        return ent;
            }
            return new Enemy(new Vector2(-50, -50));
        }

    }
}
