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
    //Source - Github Oyyou: https://github.com/Oyyou/MonoGame_Tutorials/blob/master/MonoGame_Tutorials/
    public class Button : IGObject
    {
        private MouseState currentState;
        private Texture2D texture;
        private MouseState previousState;
        public event EventHandler Click;

        public Vector2 Position { get; private set; }
        public bool Clicked { get; private set; }

        public CollisionBox CollisionBox;
        public Button(ContentManager content, string sheet, Vector2 spawnPosition)
        {
            this.texture = content.Load<Texture2D>("Sprites\\Button\\" + sheet);
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(Position, texture.Width, texture.Height);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, CollisionBox.Box, Color.White);
        }

        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            previousState = currentState;
            currentState = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentState.X, currentState.Y, 1, 1);

            if (mouseRectangle.Intersects(CollisionBox.Box))
            {
                if (currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)  Click?.Invoke(this, new EventArgs());
            }
        }
    }
}
