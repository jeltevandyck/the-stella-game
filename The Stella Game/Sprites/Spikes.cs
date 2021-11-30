using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Spikes : SpriteAnimation
    {
        public Spikes(ContentManager content, string sheet, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Spikes\\" + sheet);

            this.Collidable = false;

            this.Position = spawnPosition;
            this.CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 116, 78);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(116, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(232, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(348, 0, 116, 78)));
        }
    }
}
