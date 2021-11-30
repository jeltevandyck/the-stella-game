using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    class Platform : IGObject
    {
        private Texture2D texture;

        public Vector2 Position { get; private set; }

        public bool PlatformMove { get; private set; }
        public int MoveRange { get; private set; }

        public Vector2 SpawnPosition;

        private Boolean _backToSpawn = false;

        public Vector2 Velocity;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public Platform(ContentManager content, string sheet, Vector2 spawnPosition, bool move)
        {
            texture = content.Load<Texture2D>("Sprites\\Platform\\" + sheet);
            Position = spawnPosition;
            SpawnPosition = spawnPosition;
            PlatformMove = move;
            MoveRange = 260;
        }

        public void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            if (PlatformMove == true)
            {
                
                float walkedDistance = (Position.Y - SpawnPosition.Y) + 2f;
                Debug.WriteLine(walkedDistance);
                if (walkedDistance <= MoveRange && !_backToSpawn)
                {
                    Velocity.Y = 2f;

                    if (walkedDistance == MoveRange) _backToSpawn = true;
                }
                else
                {
                    Velocity.Y = -2f;

                    if (Position.Y <= SpawnPosition.Y) _backToSpawn = false;
                }

                Position += Velocity;
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Rectangle, Color.White);
        }
    }
}
