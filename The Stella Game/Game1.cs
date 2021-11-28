using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Menus;

namespace The_Stella_Game
{
    public class Game1 : Game
    {
        public static int MAX_WIDTH = 1700;
        public static int MAX_HEIGHT = 900;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Menu currentMenu;
        private Menu nextMenu;

        public void changeMenu(Menu menu)
        {
            nextMenu = menu;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = MAX_WIDTH;
            _graphics.PreferredBackBufferHeight = MAX_HEIGHT;
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            currentMenu = new GameMenu(this,_graphics, Content);
            
        }

        protected override void Update(GameTime gameTime)
        {

            if (nextMenu != null)
            {
                currentMenu = nextMenu;
                nextMenu = null;
            }
            currentMenu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentMenu.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
