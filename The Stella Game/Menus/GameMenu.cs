using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class GameMenu : Menu
    {
        private Texture2D gameBackground;

        private List<IGObject> gameButtons;
        public GameMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game,graphics, content)
        {
            gameBackground = game.Content.Load<Texture2D>("Sprites\\Menu\\StellaStartScherm");
            var StartButton = new Button(Content, "StartButton", new Vector2(600, 500));
            var LevelsButton = new Button(Content, "LevelsButton", new Vector2(600, 610));
            var QuitButton = new Button(Content, "QuitButton", new Vector2(600, 720));

            StartButton.Click += StartButton_Click;
            LevelsButton.Click += LevelsButton_Click;
            QuitButton.Click += QuitButton_Click;

            gameButtons = new List<IGObject>()
            {
                StartButton,
                LevelsButton,
                QuitButton
            };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LevelsButton_Click(object sender, EventArgs e)
        {
            Game.changeMenu(new LevelsMenu(Game, Graphics, Content));
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Game.changeMenu(new StartMenu(Game, Graphics, Content));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in gameButtons)
            {
                item.Update(gameTime, gameButtons);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameBackground, new Rectangle(0, 0, 1700, 900), Color.White);
            foreach (var item in gameButtons)
            {
                item.Draw(gameTime, spriteBatch);
            }
            
            spriteBatch.End();
        }
    }
}
