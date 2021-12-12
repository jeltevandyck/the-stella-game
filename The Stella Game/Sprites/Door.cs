using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Door : Sprite
    {
        public Door(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Door\\Door");
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(spawnPosition, 70, 87);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {

                spritebatch.Draw(Texture, CollisionBox.Box, Color.White);
        }
    }
}
