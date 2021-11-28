using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    class LevelsMenu : Menu
    {
        private Texture2D gameBackground;

        private List<IGObject> levelButtons;
        public LevelsMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            gameBackground = game.Content.Load<Texture2D>("Sprites\\Menu\\StellaLevelsScherm");
            var level1Button = new Button(Content, "Level1Button", new Vector2(300, 100));
            var level2Button = new Button(Content, "Level2Button", new Vector2(600, 100));
            var backButton = new Button(Content, "BackButton", new Vector2(600, 700));

            level1Button.Click += level1Button_Click;
            level2Button.Click += level2Button_Click;
            backButton.Click += BackButton_Click;


            levelButtons = new List<IGObject>()
            {
                level1Button,
                level2Button,
                backButton
            };
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Game.changeMenu(new GameMenu(Game, Graphics, Content));
        }

        private void level1Button_Click(object sender, EventArgs e)
        {
            Game.changeMenu(new StartMenu(Game, Graphics, Content));
            
        }

        private void level2Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in levelButtons)
            {
                item.Update(gameTime, levelButtons);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(gameBackground, new Rectangle(0, 0, 1700, 900), Color.White);
            foreach (var item in levelButtons)
            {
                item.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
