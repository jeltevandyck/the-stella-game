using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class VictoryMenu : Menu
    {
        public VictoryMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\YouWonScherm");
            Button homeButton = new Button(Content, "HomeButton", new Vector2(550, 450));
            Button restartButton = new Button(Content, "RestartButton", new Vector2(550, 580));
            Button quitButton = new Button(Content, "QuitButton2", new Vector2(550, 710));

            homeButton.Click += homeButton_Click;
            restartButton.Click += restartButton_Click;
            quitButton.Click += quitButton_Click;

            SpriteObjects.Add(homeButton);
            SpriteObjects.Add(restartButton);
            SpriteObjects.Add(quitButton);

        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new StartMenu(Game, Graphics, Content));
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new GameMenu(Game, Graphics, Content));
        }
    }
}