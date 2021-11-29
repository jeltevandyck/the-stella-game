using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class StartMenu : Menu
    {
        private Texture2D gameBackground;
        public StartMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base (game, graphics, content)
        {
            gameBackground = game.Content.Load<Texture2D>("Sprites\\Menu\\StellaStartScherm");
            var StartButton = new Button(Content, "StartButton", new Vector2(600, 500));
            var LevelsButton = new Button(Content, "LevelsButton", new Vector2(600, 610));
            var QuitButton = new Button(Content, "QuitButton", new Vector2(600, 720));

            StartButton.Click += StartButton_Click;
            LevelsButton.Click += LevelsButton_Click;
            QuitButton.Click += QuitButton_Click;

            SpriteObjects.Add(StartButton);
            SpriteObjects.Add(LevelsButton);
            SpriteObjects.Add(QuitButton);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LevelsButton_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new LevelsMenu(Game, Graphics, Content));
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new GameMenu(Game, Graphics, Content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameBackground, new Rectangle(0, 0, 1700, 900), Color.White);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
