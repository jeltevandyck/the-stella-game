using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public abstract class Menu
    {
        public int MaxWidth = 1700;
        public int MaxHeight = 900;

        public ContentManager Content { get; private set; }

        public GraphicsDeviceManager Graphics { get; private set; }

        public List<IGObject> SpriteObjects { get; private set; }

        public Menu(GraphicsDeviceManager graphics, ContentManager content)
        {
            this.Graphics = graphics;
            Content = content;

            SpriteObjects = new List<IGObject>();
        }

        public abstract void Initialize();

        public virtual void Update(GameTime gameTime)
        {
            foreach (IGObject obj in SpriteObjects)
            {
                obj.Update(gameTime);
            }
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
