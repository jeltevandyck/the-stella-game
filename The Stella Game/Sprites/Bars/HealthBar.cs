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

        public CollisionBox CollisionBox;

        private List<Heart> hearts;
        public HealthBar(ContentManager content, Vector2 spawnPosition) : base(content, spawnPosition)
        {
            this.CollisionBox = new CollisionBox(spawnPosition, 100,100);
            hearts = new List<Heart>();

            for (int i = 0; i < 3; i++)
            {
                hearts.Add(new Heart(content, new Vector2(0, (i + 1) * 30)));
            }
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            StellaPlayer player = null;
            foreach (IGObject obj in gObjects)
            {
                if (obj is StellaPlayer)
                {
                    player = obj as StellaPlayer;
                    break;
                }
            }

            hearts.Clear();

            int lives = player.Health;
            int deaths = (3 - player.Health) > 3 ? 3 : (3 - player.Health);

            int index_x = 0;

            for (int i = 0; i < lives; i++)
            {
                Heart heart = new Heart(Content, new Vector2(Position.X + index_x, Position.Y));
                heart.Usable = true;
                index_x += 30;
                hearts.Add(heart);
            }

            for (int i = 0; i < deaths; i++)
            {
                Heart heart = new Heart(Content, new Vector2(Position.X + index_x, Position.Y));
                heart.Usable = false;
                index_x += 30;
                hearts.Add(heart);
            }

            foreach (Heart heart in hearts)
            {
                heart.Update(gameTime, gObjects);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Heart heart in hearts)
            {
                heart.Draw(gameTime, spriteBatch);
            }
        }
    }
}
