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
    class Player : Entity
    {
        KeyboardState keyboard;
        MouseState mouse;

        Weapon EqippedWeapon;

        float spd = 2;

        public static Player player;

        public Player(Vector2 pos)
            : base(pos)
        {

            spriteName = "player";
            player = this;

        }

        public override void Update()
        {

            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            //Movements
            if (keyboard.IsKeyDown(Keys.W))
            {
                position.Y -= spd;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                position.X -= spd;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                position.Y += spd;
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                position.X += spd;
            }

            //shoot
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                Shoot(Cursor.cursorPosition, 10 );
            }

            rotation = PointDirection(position.X, position.Y, mouse.X, mouse.Y);
            base.Update();

        }

        private float PointDirection(float x, float y, float x2, float y2)
        {

            float diffx = x - x2;
            float diffy = y - y2;
            float tan = diffy / diffx;
            float res = MathHelper.ToDegrees((float)Math.Atan2(diffy, diffx));
            res = (res - 180) % 360;

            if (res < 0)
                res += 360;

            return res;
        }

        public override bool Collideable
        {
            get { return true; }
        }
    }
}
