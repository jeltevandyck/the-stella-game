using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites.Bars
{
    class ScoreBar : Bar
    {
        SpriteFont ScoreFont;
        StellaPlayer player = null;

        public ScoreBar(ContentManager content, Vector2 spawnPosition, StellaPlayer player) : base(content, spawnPosition)
        {
            this.ScoreFont = content.Load<SpriteFont>("Fonts\\ScoreFont");
            this.player = player;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(ScoreFont, $"Muntjes: {player.Coins}", this.Position, Color.White);
        }
    }
}
