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
            Coin coin = new Coin(Content, 50);
            coin.SetRectangleTexture(Graphics.GraphicsDevice, coin.Texture);
            SpriteObjects.Add(coin);

            MiniBoss miniBoss = new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300,10));
            miniBoss.SetRectangleTexture(Graphics.GraphicsDevice, miniBoss.Texture);
            SpriteObjects.Add(miniBoss);

            StellaPlayer stella = new StellaPlayer(Content);
            stella.SetRectangleTexture(Graphics.GraphicsDevice, stella.Texture);
            SpriteObjects.Add(stella);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
