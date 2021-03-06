using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;
using The_Stella_Game.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Stella_Game.Menus
{
    public class StartMenu : Menu
    {
        public StartMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base (game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\StellaStartScherm");
            Button StartButton = new Button(Content, "StartButton", new Vector2(600, 500));
            Button LevelsButton = new Button(Content, "LevelsButton", new Vector2(600, 610));
            Button QuitButton = new Button(Content, "QuitButton", new Vector2(600, 720));

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
            GameMenu menu = new GameMenu(Game, Graphics, Content);
            menu.CurrentLevel = Game1.GetInstance().GetLastPlayedLevel();
            menu.CurrentLevel.Load();
            menu.CurrentLevel.PlaySong();
            Game.ChangeMenu(menu);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) System.Environment.Exit(0);

            base.Update(gameTime);
        }
    }
}
