using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Diagnostics;
using The_Stella_Game.Framework;
using The_Stella_Game.Menus;
using The_Stella_Game.Menus.Levels;

namespace The_Stella_Game
{
    public class Game1 : Game
    {
        public static int MAX_WIDTH = 1700;
        public static int MAX_HEIGHT = 900;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Menu menu;
        public List<Level> Levels;

        private static Game1 instance;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = MAX_WIDTH;
            _graphics.PreferredBackBufferHeight = MAX_HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Levels = new List<Level>();

            instance = this;
        }

        public static Game1 GetInstance()
        {
            return instance;
        }
        public GraphicsDeviceManager GetGraphicsDeviceManager()
        {
            return _graphics;
        }

        #region Levels
        public Level GetLastPlayedLevel()
        {
            Level lastplayed = null;
            foreach (Level level in Levels)
            {
                if (!level.Played)
                {
                    lastplayed = level;
                    break;
                }
            }
            return lastplayed;
        }
        public void ResetAllLevels()
        {
            foreach(Level level in Levels) { level.Played = false; }
        }

        public void ChangeLevel(double coins)
        {
            if (!(menu is GameMenu)) return;

            GameMenu gameMenu = menu as GameMenu;
            gameMenu.CurrentLevel.Played = true;

            Level level = this.GetLastPlayedLevel();

            if (level == null)
            {
                this.ResetAllLevels();
                this.ChangeMenu(new VictoryMenu(this, _graphics, Content));
            }
            else
            {
                level.PlaySong();
                gameMenu.CurrentLevel = level;
                gameMenu.CurrentLevel.Load();
                gameMenu.CurrentLevel.StellaPlayer.Coins = coins;
            }
        }

        #endregion

        public void ChangeMenu(Menu menu)
        {
            this.menu = menu;
        }

        protected override void Initialize()
        {
            Levels.Add(new Level1(this, Content));
            Levels.Add(new Level2(this, Content));
            Levels.Add(new EndLevel(this, Content));

            menu = new StartMenu(this, _graphics, Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            menu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            menu.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
