using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public abstract class AnimationEntity : SpriteAnimation
    {
        public Vector2 Velocity;

        public AnimationEntity(ContentManager content) : base(content)
        {

        }

        public abstract void Move();
    }
}
