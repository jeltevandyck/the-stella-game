using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Vat :  Sprite
    {
        public Vector2 SpawnPosition { get; private set; }
        public bool Found;

        public Vat(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\EndBoss\\VatBoss");
            this.CollisionBox = new CollisionBox(spawnPosition, 115, 128, 00, 0, true);

            SpawnPosition = spawnPosition;
            
        }

        public void Move(List<IGObject> gObjects)
        {
            Velocity.Y = +Speed;

            Position += Velocity;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Found)
            {
                spriteBatch.Draw(Texture, CollisionBox.Box, Color.White);
            }
            else
            {
                CollisionBox.Box = Rectangle.Empty;
            }
        }

        public object Clone()
        {
           return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return "VatBoss";

            
        }
    }
}
