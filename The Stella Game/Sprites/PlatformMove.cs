using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class PlatformMove : Platform
    {
        public int MoveRange { get; private set; }
        public Vector2 SpawnPosition { get; private set; }

        private bool _backToSpawn = false;
        
        public PlatformMove(ContentManager content, string sheet, Vector2 spawnPosition) : base(content, sheet, spawnPosition)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Platform\\" + sheet);
            this.Position = spawnPosition;
            MoveRange = 260;
            SpawnPosition = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, Texture.Width, Texture.Height, 0, 0, false);
        }
        
        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            int walkedDistance = ((int) Position.Y - (int) SpawnPosition.Y) + 2;
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
    }
}