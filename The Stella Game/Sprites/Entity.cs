using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public abstract class Entity : Sprite
    {
        public Vector2 Velocity;
        public Entity(ContentManager content) : base(content)
        {
        }

        public abstract void Move();
    }
}