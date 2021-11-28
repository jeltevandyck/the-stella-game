using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;
using System.Diagnostics;

namespace The_Stella_Game.Sprites
{
    public class StellaPlayer : AnimationEntity
    {
        public int Health { get; private set; } = 3;
        public int Quantity { get; private set; } = 1;
        public decimal Coins { get; private set; } = 0;
        public Vector2 SpawnPosition;

        public StellaPlayer(ContentManager contentManager, Vector2 spawnPosition) : base(contentManager)
        {
            this.SpawnPosition = spawnPosition;
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaQuarterGlassSideWays");
            this.Position = spawnPosition;

            this.CollisionBox = new Rectangle((int) Position.X, (int) Position.Y, 100, 99);


            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 99)));
        }

        public override void Move(List<IGObject> gObjects)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl)) Speed = 5f;
            else Speed = 3f;

            if (state.IsKeyDown(Keys.Q)) Velocity.X = -Speed; //LEFT
            if (state.IsKeyDown(Keys.D)) Velocity.X = Speed; //RIGHT
            if (state.GetPressedKeys().Length <= 0)
            {
                Velocity.X = 0;
                Velocity.Y = 0;
            }

            foreach (IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) continue;
                Sprite sprite = obj as Sprite;


                if (sprite.Intersects(this) && !sprite.Collidable)
                {
                    Debug.WriteLine("Collision!!");
                    Velocity.X = 0;
                    Velocity.Y = 0;
                }
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
            return "StellaPlayer";
        }
    }
}
