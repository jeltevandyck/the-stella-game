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
        public bool IsFalling { get; private set; } = false;
        public bool Jumped { get; private set; } = false;
        public StellaPlayer(ContentManager contentManager, Vector2 spawnPosition) : base(contentManager, spawnPosition)
        {
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaQuarterGlassSideWays");

            this.CollisionBox = new CollisionBox(spawnPosition, 25, 47, 20, 0, true);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 99)));
        }

        public override void Move(List<IGObject> gObjects)
        {
            foreach (IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) continue;
                Sprite sprite = obj as Sprite;

                if (sprite.Equals(this)) continue;

                if (this.Intersects(sprite) && !sprite.CollisionBox.Collidable)
                {
                    Velocity.Y = 0f;
                    IsFalling = false;
                    break;
                }
                else
                {
                    Velocity.Y = Speed;
                    IsFalling = true;
                }
            }

            if (Jumped)
            {
                //TODO
            }


            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl)) Speed = 5f;
            else Speed = 3f;

            if (state.IsKeyDown(Keys.Z)) Velocity.Y = -Speed; //UP
            else if (state.IsKeyDown(Keys.S)) Velocity.Y = Speed; //DOWN
            else Velocity.Y = 0f;

            if (state.IsKeyDown(Keys.Q)) Velocity.X = -Speed; //LEFT
            else if (state.IsKeyDown(Keys.D)) Velocity.X = Speed; //RIGHT
            else Velocity.X = 0f;

            if (state.IsKeyDown(Keys.Space) && !IsFalling && !Jumped) Jumped = true;
            
            this.Move(gObjects);

            base.Update(gameTime, gObjects);
        }

        public override string ToString()
        {
            return "StellaPlayer";
        }
    }
}
