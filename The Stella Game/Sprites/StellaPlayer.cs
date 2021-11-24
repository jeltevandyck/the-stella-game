using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Stella_Game.Sprites
{
    public class StellaPlayer : AnimationEntity
    {
        public int Health { get; private set; } = 3;

        public StellaPlayer(ContentManager contentManager) : base(contentManager)
        {
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaEmptyGlassSideways");
            this.Position = new Vector2(0, 0);
            this.CollisionBox = new Rectangle((int) Position.X, (int) Position.Y, 100, 100);


            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 99)));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 99)));
        }

        public override void Move()
        {
             KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl)) Speed = 5f;
            else Speed = 3f;

            if (state.IsKeyDown(Keys.Z)) Velocity.Y = -Speed; //UP
            if (state.IsKeyDown(Keys.S)) Velocity.Y = Speed; //DOWN
            if (state.IsKeyDown(Keys.Q))
            {
                Velocity.X = -Speed; //LEFT
            }
            if (state.IsKeyDown(Keys.D))
            {
                Velocity.X = Speed; //RIGHT
            }
            if (state.GetPressedKeys().Length <= 0)
            {
                Velocity.X = 0;
                Velocity.Y = 0;
            }

            Position += Velocity;
        }

        public override void Update(GameTime gameTime)
        {
            this.Move();

            base.Update(gameTime);
        }
    }
}
