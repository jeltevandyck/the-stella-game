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

        public StellaPlayer(ContentManager contentManager, Vector2 spawnPosition) : base(contentManager, spawnPosition)
        {
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaQuarterGlassSideWays");

            this.CollisionBox = new CollisionBox(spawnPosition, 25, 55, 20, 0, true);

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

            if (state.IsKeyDown(Keys.Z)) Velocity.Y = -Speed; //UP
            if (state.IsKeyDown(Keys.S)) Velocity.Y = Speed; //DOWN

            if (state.IsKeyDown(Keys.Q)) Velocity.X = -Speed; //LEFT
            if (state.IsKeyDown(Keys.D)) Velocity.X = Speed; //RIGHT
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);

            foreach (IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) continue;
                Sprite sprite = obj as Sprite;

                if (sprite.Equals(this)) continue;

                if (((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite))) && !sprite.CollisionBox.Collidable)
                    this.Velocity.X = 0;

                if (((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite))) && !sprite.CollisionBox.Collidable)
                    this.Velocity.Y = 0;
            }

            Position += Velocity;

            Velocity = Vector2.Zero;

            base.Update(gameTime, gObjects);
        }

        public override string ToString()
        {
            return "StellaPlayer";
        }
    }
}
