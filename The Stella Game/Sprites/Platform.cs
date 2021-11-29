using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Platform : IGObject
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
        public Platform(ContentManager content, string sheet, Vector2 spawnPosition)
        {
            this.texture = content.Load<Texture2D>("Sprites\\Platform\\" + sheet);
            this.Position = spawnPosition;
        }

        public void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Rectangle, Color.White);
        }
    }
}
