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
        private Texture2D gameBackground;
        public StartMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base (game,graphics, content)
        {
            gameBackground = game.Content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel1");
            SpriteObjects.Add(new Coin(Content, 50, new Vector2(500,20)));

            //Player
            SpriteObjects.Add(new StellaPlayer(Content, new Vector2(2, 5)));

            //Minibosses
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300, 85), 400));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(600, 340), 500));

            //Platforms

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(0, 49)));

            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(170, 50)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(208, 130)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(665, 130)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1122, 132)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1430, 133)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1237, 250)));
            SpriteObjects.Add(new Platform(Content, "V4", new Vector2(1200, 251)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(742, 384)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(383, 385)));
            SpriteObjects.Add(new Platform(Content, "V4", new Vector2(344, 251)));
            SpriteObjects.Add(new Platform(Content, "H6", new Vector2(277, 251)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(0, 251)));

        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameBackground, new Rectangle(0, 0, 1700, 900), Color.White);
            base.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
