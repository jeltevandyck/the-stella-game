using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class HealthBar : Bar
    {
        private StellaPlayer stellaPlayer;
        public HealthBar(ContentManager content, Vector2 spawnPosition, StellaPlayer stellaplayer) : base(content)
        {
            this.Position = spawnPosition;
            this.stellaPlayer = stellaplayer;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            int lives = stellaPlayer.Health;

            SpriteObjects.Clear();

            for (int i = 0; i < lives; i++)
            {
                SpriteObjects.Add(new Heart(Content, new Vector2(Position.X + (30 * i), Position.Y), true));
            }

            int deaths = 3 - lives;
            for (int i = 0; i < deaths; i++)
            {
                SpriteObjects.Add(new Heart(Content, new Vector2(Position.X + (30 * (i + 1)), Position.Y), false));
            }

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (IGObject obj in SpriteObjects)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }
    }
}
