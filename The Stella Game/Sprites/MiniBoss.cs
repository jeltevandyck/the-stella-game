using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class MiniBoss : AnimationEntity
    {
        public int Lives { get; private set; } = 1;

        public int WalkRange = 100;

        private Boolean _backToSpawn = false;

        public MiniBoss(ContentManager content, string sheet, Vector2 spawnPosition) : this(content, sheet, spawnPosition, 100)
        {
        }

        public MiniBoss(ContentManager content, string sheet, Vector2 spawnPosition, int walkrange) : base(content, spawnPosition)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Miniboss\\" + sheet);
            this.CollisionBox = new CollisionBox(spawnPosition, 25, 60, 20, 0, true);
            this.WalkRange = walkrange;

            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 100)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 100)));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 100)));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 100)));
        }

        public override void Move(List<IGObject> gObjects)
        {
            float walkedDistance = (Position.X - SpawnPosition.X) + Speed;
            if (walkedDistance <= WalkRange && !_backToSpawn)
            {
                Velocity.X = Speed;

                if (walkedDistance == WalkRange) _backToSpawn = true; 
            } else
            {
                Velocity.X = -Speed;

                if (Position.X <= SpawnPosition.X) _backToSpawn = false;
            }

            Position += Velocity;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);

            base.Update(gameTime, gObjects);
        }

        public override string ToString()
        {
            return "Miniboss";
        }
    }
}
