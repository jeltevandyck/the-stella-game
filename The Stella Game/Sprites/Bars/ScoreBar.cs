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

        public double Score;
        public ScoreBar(ContentManager content, Vector2 spawnPosition) : base(content, spawnPosition)
        {
            this.ScoreFont = content.Load<SpriteFont>("Fonts\\ScoreFont");
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {

            foreach (IGObject obj in gObjects)
            {
                if (obj is StellaPlayer)
                {
                    player = obj as StellaPlayer;
                    Score = player.Score;
                    break;
                }
            }

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(ScoreFont, $"Score: {Score}", this.Position, Color.White);
        }
    }
}
