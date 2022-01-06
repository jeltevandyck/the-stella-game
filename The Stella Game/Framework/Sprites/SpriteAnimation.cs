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
        public int Index { get; private set; } = 0;
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

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            CurrentFrame = _animationFrames[Index];

            frameMovement += CurrentFrame.Rectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.Rectangle.Width / CurrentFrame.FrameSpeed)
            {
                Index++;
                frameMovement = 0;
            }

            if (Index >= _animationFrames.Count) Index = 0;

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CurrentFrame.Rectangle, Color.White, 0, new Vector2(0, 0), .6f, SpriteEffects.None, 0);
        }
    }
}
