using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace The_Stella_Game.Framework
{
    public abstract class Sprite : IGObject
    {
        public ContentManager Content { get; private set; }
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle CollisionBox;

        public Boolean Collidable = false;

        public float Speed { get; set; } = 2f;

        public Sprite(ContentManager content)
        {
            this.Content = content;
        }

        public bool Intersects(Sprite sprite)
        {
            if (sprite.Equals(this)) return false;
            else
            {
                Debug.WriteLine("" + sprite.ToString() + " intersects with " + this.ToString() + " = " + sprite.CollisionBox.Intersects(CollisionBox));
                return sprite.CollisionBox.Intersects(CollisionBox);
            }
        }
        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            CollisionBox.X = (int) Position.X;
            CollisionBox.Y = (int) Position.Y;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CollisionBox, Color.White);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
