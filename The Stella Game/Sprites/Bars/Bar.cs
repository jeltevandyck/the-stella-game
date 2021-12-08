using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public abstract class Bar : IGObject
    {
        public ContentManager Content { get; private set; }
        public Vector2 Position;
        public CollisionBox CollisionBox;

        public List<IGObject> SpriteObjects;

        public Bar(ContentManager content)
        {
            this.Content = content;
            this.SpriteObjects = new List<IGObject>();
        }

        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (IGObject obj in SpriteObjects)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }
    }
}
