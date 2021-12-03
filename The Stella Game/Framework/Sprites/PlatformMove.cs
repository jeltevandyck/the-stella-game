using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace The_Stella_Game.Framework.Sprites
{
    class PlatformMove: Sprite
    {
        public int MoveRange { get; private set; }

        public Vector2 SpawnPosition;

        private Boolean _backToSpawn = false;

        public Vector2 Velocity;
        public PlatformMove(ContentManager content, string sheet, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Platform\\" + sheet);
            this.Position = spawnPosition;
            MoveRange = 260;
            SpawnPosition = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, Texture.Width, Texture.Height, 0, 0, false);
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
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
            Velocity = Vector2.Zero;
            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, CollisionBox.Box, Color.White);
        }


    }
}
