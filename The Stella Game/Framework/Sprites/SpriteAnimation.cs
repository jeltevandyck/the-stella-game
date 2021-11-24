using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Sprites;

namespace The_Stella_Game.Sprites
{
    public class SpriteAnimation : Sprite
    {
        public AnimationFrame CurrentFrame { get; private set; }
        private List<AnimationFrame> _animationFrames;

        private int index = 0;
        private double frameMovement = 0;

        public SpriteAnimation(ContentManager content) : base(content)
        {
            _animationFrames = new List<AnimationFrame>();
        }

        public void Add(AnimationFrame aFrame)
        {
            _animationFrames.Add(aFrame);
            CurrentFrame = _animationFrames[0];
        }

        public override void Update(GameTime gameTime)
        {
            CurrentFrame = _animationFrames[index];

            frameMovement += CurrentFrame.Rectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.Rectangle.Width / 5)
            {
                index++;
                frameMovement = 0;
            }

            if (index >= _animationFrames.Count) index = 0;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CurrentFrame.Rectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }
    }
}
