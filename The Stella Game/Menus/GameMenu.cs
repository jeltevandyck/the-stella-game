using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;
using Microsoft.Xna.Framework.Input;

namespace The_Stella_Game.Menus
{
    public class GameMenu : Menu
    {
        public GameMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            Coin coin = new Coin(Content, 50);
            coin.SetRectangleTexture(Graphics.GraphicsDevice, coin.Texture);
            SpriteObjects.Add(coin);

            //MiniBoss miniBoss = new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300,10));
            //miniBoss.SetRectangleTexture(Graphics.GraphicsDevice, miniBoss.Texture);
            //SpriteObjects.Add(miniBoss);

            StellaPlayer stella = new StellaPlayer(Content);
            stella.SetRectangleTexture(Graphics.GraphicsDevice, stella.Texture);
            SpriteObjects.Add(stella);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }
    }
}
