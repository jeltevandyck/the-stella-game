using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class SpriteAnimation : Sprite
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public AnimationFrame CurrentFrame { get; private set; }
        private List<AnimationFrame> _animationFrames;

        private int index = 0;
        private double frameMovement = 0;

        private Texture2D RectangleTexture;

        public SpriteAnimation(ContentManager content) : base(content)
        {
            _animationFrames = new List<AnimationFrame>();
        }

        public void Add(AnimationFrame aFrame)
        {
            _animationFrames.Add(aFrame);
            CurrentFrame = _animationFrames[0];
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            CurrentFrame = _animationFrames[index];

            frameMovement += CurrentFrame.Rectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.Rectangle.Width / 5)
            {
                index++;
                frameMovement = 0;
            }

            if (index >= _animationFrames.Count) index = 0;

            base.Update(gameTime, gObjects);
        }

        public SpriteAnimation SetRectangleTexture(GraphicsDevice graphicsDevice, Texture2D texture)
        {
            var colours = new List<Color>();

            for (int y = 0; y < CollisionBox.Box.Height; y++)
            {
                for (int x = 0; x < CollisionBox.Box.Width; x++)
                {
                    if (y == 0 || // On the top
                        x == 0 || // On the left
                        y == texture.Height - 1 || // on the bottom
                        x == texture.Width - 1) // on the right
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0)); // transparent 
                    }
                }
            }

            RectangleTexture = new Texture2D(graphicsDevice, CollisionBox.Box.Width, CollisionBox.Box.Height);
            RectangleTexture.SetData<Color>(colours.ToArray());

            return this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CurrentFrame.Rectangle, Color.White, 0, new Vector2(0, 0), .6f, SpriteEffects.None, 0);
            
            if (RectangleTexture != null) spriteBatch.Draw(RectangleTexture, new Vector2(CollisionBox.Box.X, CollisionBox.Box.Y), Color.Red);
        }
    }
}
