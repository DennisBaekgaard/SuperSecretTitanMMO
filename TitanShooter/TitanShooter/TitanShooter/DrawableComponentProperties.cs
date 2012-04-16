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
    interface IDrawableComponentProperties
    {
        Vector2 Position {get; set;}
        float Rotation { get; set; }
        Texture2D SpriteIndex { get; set; }
        string SpriteName { get; set; }
        float Speed { get; set; }
        float Scale { get; set; }
        bool Alive { get; set; }
        Rectangle Area { get; set; }
    }
}
