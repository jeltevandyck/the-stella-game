using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;
using The_Stella_Game.Menus;

namespace The_Stella_Game
{
    public class Game1 : Game
    {
        public static int MAX_WIDTH = 1700;
        public static int MAX_HEIGHT = 900;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Menu menu;

        private static Game1 instance;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = MAX_WIDTH;
            _graphics.PreferredBackBufferHeight = MAX_HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

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

        public void ChangeMenu(Menu menu)
        {
            this.menu = menu;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menu = new GameMenu(this, _graphics, Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            menu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            menu.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
