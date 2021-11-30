using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Key : IGObject
    {
        private Texture2D texture;
        public Vector2 Position { get; private set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public Key(ContentManager content, Vector2 spawnPosition)
        {
            texture = content.Load<Texture2D>("Sprites\\Key\\VatBierPixilated");
            Position = spawnPosition;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }

        public void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            
        }
    }
}
