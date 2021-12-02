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
        public Vector2 SpawnPosition { get; private set; }
        public Entity(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.SpawnPosition = spawnPosition;
            this.Position = spawnPosition;
        }

        public abstract void Move();
    }
}