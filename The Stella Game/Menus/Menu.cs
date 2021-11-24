using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Sprites;
using Microsoft.Xna.Framework.Content;

namespace The_Stella_Game.Menus
{
    public abstract class Menu
    {
        public int MaxWidth = 1700;
        public int MaxHeight = 900;

        public ContentManager Content { get; private set; }

        public GraphicsDeviceManager Graphics { get; private set; }

        public List<Sprite> Sprites { get; private set; }

        public Menu(GraphicsDeviceManager graphics, ContentManager content)
        {
            this.Graphics = graphics;
            Content = content;

            Sprites = new List<Sprite>();
        }

        public abstract void Initialize();

        public virtual void Update(GameTime gameTime)
        {
            foreach (Sprite sprite in Sprites)
            {
                sprite.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }
    }
}
