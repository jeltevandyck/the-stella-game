using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Bar : IGObject
    {
        public ContentManager Content { get; private set; }
        public SpriteFont _font;
        public Vector2 Position;

        public Bar(ContentManager content, Vector2 position)
        {
            Content = content;
            Position = position;
        }

        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
