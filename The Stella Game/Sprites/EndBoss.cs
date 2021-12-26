using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;
using The_Stella_Game.Menus.Levels;

namespace The_Stella_Game.Sprites
{
    class EndBoss : AnimationEntity
    {
        public int Lives { get; set; } = 1;

        public int MoveRange = 100;

        private Boolean _backToSpawn = false;
        public Vat vat;
        private Game1 Game;

        public bool Found;
        public double Value = 1000;

        public EndBoss(Game1 game, ContentManager content, Vector2 spawnPosition, int walkrange) : base(content, spawnPosition)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\EndBoss\\MadBartender");
            this.CollisionBox = new CollisionBox(spawnPosition, 25, 60, 20, 0, true);
            this.MoveRange = walkrange;
            this.Game = game;


            this.Add(new AnimationFrame(new Rectangle(0, 0, 184, 348), 5));
            this.Add(new AnimationFrame(new Rectangle(184, 0, 184, 348), 5));
            this.Add(new AnimationFrame(new Rectangle(368, 0, 184, 348), 5));
            this.Add(new AnimationFrame(new Rectangle(552, 0, 184, 348), 5));
        }

        public override void Move(List<IGObject> gObjects)
        {
            float walkedDistance = (Position.X - SpawnPosition.X) + Speed;
            if (walkedDistance <= MoveRange && !_backToSpawn)
            {
                Velocity.X = Speed;

                if (walkedDistance == MoveRange) _backToSpawn = true;
            }
            else
            {
                Velocity.X = -Speed;

                if (Position.X <= SpawnPosition.X) _backToSpawn = false;
            }

            Position += Velocity;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);

            if (Index == 4 )
            {
                
            }

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Found)
            {
                base.Draw(gameTime, spriteBatch);
            }
            else
            {
                CollisionBox.Box = Rectangle.Empty;
            }
        }

        public override string ToString()
        {
            return "EndBoss";
        }
    }
}
