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
        public decimal Coins;
        public Coin(ContentManager content, decimal coins) : base(content) {
            this.Coins = coins;
            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\SpriteSheetCoin");

            this.Collidable = true;

            this.Position = new Vector2(200, 0);
            this.CollisionBox = new Rectangle((int) Position.X,(int) Position.Y, 40, 40);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(50, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 50, 50)));
            this.Add(new AnimationFrame(new Rectangle(150, 0, 50, 50)));
        }

        public override string ToString()
        {
            return "Coin";
        }
    }
}