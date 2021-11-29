using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class GameMenu : Menu
    {
        private Texture2D gameBackground;
        public GameMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            gameBackground = game.Content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel1");

            StellaPlayer stellaPlayer = new StellaPlayer(Content, new Vector2(2, 0));
            stellaPlayer.SetRectangleTexture(Game.GraphicsDevice, stellaPlayer.Texture);
            SpriteObjects.Add(stellaPlayer);

            MiniBoss miniBossMaes = new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300, 85), 400);
            miniBossMaes.SetRectangleTexture(Game.GraphicsDevice, miniBossMaes.Texture);
            SpriteObjects.Add(miniBossMaes);

            MiniBoss miniBossHeineken = new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(600, 340), 400);
            miniBossHeineken.SetRectangleTexture(Game.GraphicsDevice, miniBossHeineken.Texture);
            SpriteObjects.Add(miniBossHeineken);


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

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameBackground, new Rectangle(0, 0, 1700, 900), Color.White);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
