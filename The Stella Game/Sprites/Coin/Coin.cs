using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Coin : SpriteAnimation
    {
        public double Value = 100;

        public bool Found;

        public SoundEffect CoinSound;
        public Coin(ContentManager content, Vector2 spawnPosition) : base(content) {
            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\SpriteSheetCoin");

            this.CoinSound = content.Load<SoundEffect>("Music\\SoundEffect\\Coin");

            this.CollisionBox = new CollisionBox(spawnPosition, 40, 40);
            this.Position = spawnPosition;
            this.Add(new AnimationFrame(new Rectangle(0, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(50, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(150, 0, 50, 50), 5));
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Found)
            {
                base.Draw(gameTime, spriteBatch);
            }
            else
            {
                CollisionBox.Box = Rectangle.Empty;
            }
        }
        public override string ToString()
        {
            return "Coin";
        }
    }
}