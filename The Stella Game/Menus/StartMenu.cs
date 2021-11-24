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
            SpriteObjects.Add(new Coin(Content, 50));

            MiniBoss heineken = new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(100, 0));
            heineken.WalkRange = 400;
            heineken.Speed = 3f;

            SpriteObjects.Add(heineken);
            //SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetCristalSideways"));
            //SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetMaesSideways"));

            SpriteObjects.Add(new StellaPlayer(Content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
