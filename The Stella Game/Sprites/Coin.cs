using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Coin : SpriteAnimation
    {
        public double Value = 100;

        public bool Found;

        public Coin(ContentManager content, Vector2 spawnPosition) : base(content) {

            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\SpriteSheetCoin");

            this.Position = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, 40, 40);
            this.Add(new AnimationFrame(new Rectangle(0, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(50, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(150, 0, 50, 50)));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Found)
            {
                base.Draw(gameTime, spriteBatch);
            }
            
            
        }

        public override string ToString()
        {
            return "Coin";
        }
    }
}