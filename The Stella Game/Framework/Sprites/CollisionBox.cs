using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class CollisionBox
    {
        public Rectangle Box;

        public int X_Invert = 0;
        public int Y_Invert = 0;

        public int Width { get;  set; }
        public int Height { get;  set; }
        public Boolean Collidable = false;

        public CollisionBox(Vector2 position, int width, int height) : this(position, width, height, 0, 0, false)
        { }


        public CollisionBox(Vector2 position, int width, int height, int x_invert, int y_invert, bool collidable)
        {
            Box = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.X_Invert = x_invert;
            this.Y_Invert = y_invert;
            this.Collidable = collidable;

            this.Width = width;
            this.Height = height;
        }


        public void Update(Vector2 position)
        {
            Box.X = (int)position.X + X_Invert;
            Box.Y = (int)position.Y + Y_Invert;
        }

    }
}
