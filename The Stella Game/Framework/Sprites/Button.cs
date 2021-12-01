using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Framework
{
    public class Button : IGObject
    {
        private MouseState currentState;
        private Texture2D texture;
        private MouseState previousState;
        public event EventHandler Click;

        public Vector2 Position { get; private set; }
        public bool Clicked { get; private set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public Button(ContentManager content, string sheet, Vector2 spawnPosition)
        {
            this.texture = content.Load<Texture2D>("Sprites\\Button\\" + sheet);
            this.Position = spawnPosition;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Rectangle, Color.White);
        }

        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            previousState = currentState;
            currentState = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentState.X, currentState.Y, 1, 1);

            if (mouseRectangle.Intersects(Rectangle))
            {
                if (currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());

                }
            }
        }
    }
}
