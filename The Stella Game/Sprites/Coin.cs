using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace The_Stella_Game.Sprites
{
    public class Coin : Sprite
    {
        public decimal Coins;
        public Coin(ContentManager content, decimal coins) : base(content) {
            this.Coins = coins;
            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\coin_idle");
            this.Position = new Vector2(200, 200);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}