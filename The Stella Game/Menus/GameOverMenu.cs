using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class GameOverMenu : Menu
    {
        public GameOverMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\StellaGameOverScherm");
            Button restartButton = new Button(Content, "RestartButton", new Vector2(550, 650));
            restartButton.Click += restartButton_Click;
            SpriteObjects.Add(restartButton);

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Game.ResetAllLevels();
            Game.ChangeMenu(new StartMenu(Game, Graphics, Content));
        }
    }
}
