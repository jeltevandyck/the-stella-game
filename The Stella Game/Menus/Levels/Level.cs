using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus.Levels
{
    public class Level
    {
        public ContentManager Content { get; private set; }
        public GraphicsDeviceManager Graphics { get; private set; }
        public List<IGObject> SpriteObjects { get; private set; }
        public Game1 Game { get; private set; }

        public bool Played = false;

        public Texture2D Background;
        public Level(Game1 game, ContentManager content)
        {
            this.Game = game;
            this.Content = content;

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
            spriteBatch.Draw(Background, new Rectangle(0, 0, Game1.MAX_WIDTH, Game1.MAX_HEIGHT), Color.White);

            foreach (IGObject obj in SpriteObjects)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }
    }
}
