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
    class Ressources
    {

        public static List<Entity> objectsList = new List<Entity>();
        public static void Initialize()
        {
            objectsList.Add(new Player(new Vector2(50, 50)));
            objectsList.Add(new Cursor(new Vector2(0, 0)));

            //Add bullets
              for (int i = 0; i < 64; i++) {
                  Entity entity= new Bullet(new Vector2(0, 0));
                  entity.Alive = false;
                  objectsList.Add(entity);
              }
            /*
              //Walls
              objectsList.Add(new Wall(new Vector2(250, 250)));
              objectsList.Add(new Wall(new Vector2(282, 250)));
              objectsList.Add(new Wall(new Vector2(314, 250)));
            */
            //Enemies 
            objectsList.Add(new Enemy(new Vector2(300, 300)));
            objectsList.Add(new Enemy(new Vector2(400, 300)));
     
        }

        public static void Reset()
        {

            foreach (Entity entity in objectsList)
            {

                entity.Alive = false;
            }

        }

    }
}
