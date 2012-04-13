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
    class Cursor : Entity
    {

        MouseState mouse;

        public static Vector2 cursorPosition { get; private set; }


        public Cursor(Vector2 pos)
            : base(pos)
        {
            Position = pos;
            SpriteName = "crosshair";
        }

        public override void Update()
        {
            mouse = Mouse.GetState();

            Position = new Vector2(mouse.X, mouse.Y);
            cursorPosition = Position;

            base.Update();
        }


        
    }
}
