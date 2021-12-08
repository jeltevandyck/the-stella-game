using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class HealthBar : IGObject
    {
        public ContentManager Content { get; private set; }

        public Vector2 Position;
        public CollisionBox CollisionBox;

        private List<Heart> hearts;
        public HealthBar(ContentManager content, Vector2 spawnPosition)
        {
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(spawnPosition, 100,100);
            hearts = new List<Heart>();

            for (int i = 0; i < 3; i++)
            {
                hearts.Add(new Heart(content, new Vector2(0, (i+1)*30)));
            }
        }

        public void Update(GameTime gameTime, List<IGObject> gObjects)
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

            for (int i = 0; i < 3 - player.Health; i++)
            {
                hearts[i].Usable = false;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Heart heart in hearts)
            {
                heart.Draw(gameTime, spriteBatch);
            }
        }
    }
}
