using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class LevelsMenu : Menu
    {
        public LevelsMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\StellaLevelsScherm");
            Button level1Button = new Button(Content, "Level1Button", new Vector2(300, 100));
            Button level2Button = new Button(Content, "Level2Button", new Vector2(600, 100));
            Button backButton = new Button(Content, "BackButton", new Vector2(600, 700));

            level1Button.Click += level1Button_Click;
            level2Button.Click += level2Button_Click;
            backButton.Click += BackButton_Click;

            SpriteObjects.Add(level1Button);
            SpriteObjects.Add(level2Button);
            SpriteObjects.Add(backButton);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new StartMenu(Game, Graphics, Content));
        }

        private void level1Button_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new GameMenu(Game, Graphics, Content));
        }

        private void level2Button_Click(object sender, EventArgs e)
        {
            Game.ChangeMenu(new Level2(Game, Graphics, Content));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
