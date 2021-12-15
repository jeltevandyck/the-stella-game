﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;
using System.Diagnostics;
using The_Stella_Game.Menus;

namespace The_Stella_Game.Sprites
{

    public class StellaPlayer : AnimationEntity
    {
        public int Health { get; private set; } = 3;
        public int KeyQuantity { get; private set; } = 0;
        public double Score { get; private set; } = 0;
        public bool Jumped { get; private set; } = false;
        public bool IsFalling { get; private set; } = false;

        private Game1 Game;

        public StellaPlayer(Game1 game, ContentManager contentManager, Vector2 spawnPosition) : base(contentManager, spawnPosition)
        {
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaEmptyGlassSideways");
            this.Game = game;
            this.CollisionBox = new CollisionBox(spawnPosition, 25, 47, 20, 0, true);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 99), 5));
        }

        public override void Move(List<IGObject> gObjects)
        {
            foreach (IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) continue;
                Sprite sprite = obj as Sprite;

                if (sprite.Equals(this)) continue;

                if (this.DetectCollision(sprite) && !sprite.CollisionBox.Collidable)
                {
                    this.Intersects(sprite);

                    Velocity.Y = 0f;

                    if (this.IsTouchingLeft(sprite) && Velocity.X > 0) Velocity.X = 0f;
                    else if (this.IsTouchingRight(sprite) && Velocity.X < 0) Velocity.X = 0f;

                    IsFalling = false;
                    break;
                }
                else
                {
                    if (!Jumped)
                    {
                        Velocity.Y = Speed;
                        IsFalling = true;
                    }
                    
                }
            }

            if (Position.X + Velocity.X + CollisionBox.Box.Width >= Game1.MAX_WIDTH && Velocity.X > 0) Velocity.X = 0;
            if (Position.X <= 0 && Velocity.X < 0) Velocity.X = 0;

            Position += Velocity;
            Velocity = Vector2.Zero;

            if (Jumped)
            {
                Position.Y -= 5f;
                Velocity.Y = 0f;
                Jumped = false;
            }


        }

        public override void Intersects(Sprite sprite)
        {
            if (sprite is Coin)
            {
                Coin coin = sprite as Coin;

                if (!coin.Found)
                {
                    this.Score += coin.Value;
                    coin.Found = true;

                }

            }

            if (sprite is Key)
            {
                Key key = sprite as Key;

                if (!key.Found)
                {
                    this.KeyQuantity += 1;
                    this.Score += key.Value;
                    key.Found = true;
                }

            }

            if (sprite is Door)
            {
                
                if (this.KeyQuantity == 3)
                {
                    this.KeyQuantity = 0;
                    this.Game.ChangeMenu(new Level2(Game, Graphics, Content));
                    
                }
            }

            if (sprite is Spike)
            {
                this.Health -= 1;

                Debug.WriteLine("HIt the spike");
            }

            
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

            if (state.IsKeyDown(Keys.Space) && !IsFalling)
            {
                Jumped = true;
            }
            this.Move(gObjects);

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (this.KeyQuantity == 0)
            {
                this.Texture = Content.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaEmptyGlassSideways");
            }
            else if (this.KeyQuantity == 1)
            {
                this.Texture = Content.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaQuarterGlassSideWays");
            }
            else if (this.KeyQuantity == 2)
            {
                this.Texture = Content.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaHalfFullGlassGlassSideways");
            }
            else if (this.KeyQuantity == 3)
            {
                this.Texture = Content.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaGlassSideways");
            }
            base.Draw(gameTime, spriteBatch);
        }
        public override string ToString()
        {
            return "StellaPlayer";
        }
    }
}
