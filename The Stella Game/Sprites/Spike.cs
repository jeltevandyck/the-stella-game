using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Spike : SpriteAnimation
    {
        public Spike(ContentManager content, string sheet, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Obstacles\\" + sheet);
            this.Position = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, 30, 50, 20, 0, true);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(116, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(232, 0, 116, 78)));
            this.Add(new AnimationFrame(new Rectangle(348, 0, 116, 78)));
        }
    }
}
