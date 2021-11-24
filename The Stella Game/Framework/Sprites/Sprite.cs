using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace The_Stella_Game.Sprites
{
    public abstract class Sprite : IGObject
    {
        public ContentManager Content { get; private set; }
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle Rectangle;

        public Boolean Collidable = false;

        public float Speed { get; set; } = 2f;

        public Sprite(ContentManager content)
        {
            this.Content = content;
        }

        public Boolean IsColliding(Sprite sprite)
        {
            
            return true;
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Rectangle, Color.White);
        }
    }
}
