using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Framework
{
    public abstract class Menu
    {
        public int MaxWidth = 1700;
        public int MaxHeight = 900;

        public bool IsMouseVisible { get; set; }
        public ContentManager Content { get; private set; }
        public GraphicsDeviceManager Graphics { get; private set; }
        public List<IGObject> SpriteObjects { get; private set; }
        public Game1 Game { get; private set; }

        public Texture2D Background;

        public Menu(Game1 game, GraphicsDeviceManager graphics, ContentManager content)
        {
            this.Game = game;
            this.Graphics = graphics;
            Content = content;

            SpriteObjects = new List<IGObject>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IGObject obj in SpriteObjects)
            {
                obj.Update(gameTime, SpriteObjects);
            }
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, MaxWidth, MaxHeight), Color.White);

            foreach (IGObject obj in SpriteObjects)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }
    }
}
