using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;

namespace The_Stella_Game.Menus
{
    public class StartMenu : Menu
    {
        public StartMenu(GraphicsDeviceManager graphics, ContentManager content) : base (graphics, content)
        {
        }

        public override void Initialize()
        {
            //Sprites.Add(new StellaPlayer(Content));
            //Change
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            base.Draw(gameTime, spriteBatch);
        }
    }
}
