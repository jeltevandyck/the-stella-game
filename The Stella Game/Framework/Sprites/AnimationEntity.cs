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
        public Vector2 SpawnPosition { get; private set; }
        public AnimationEntity(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.SpawnPosition = spawnPosition;
        }

        public abstract void Move(List<IGObject> gObjects);
    }
}
