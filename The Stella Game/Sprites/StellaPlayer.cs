using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;
using System.Diagnostics;
using The_Stella_Game.Menus;
using Microsoft.Xna.Framework.Audio;
using The_Stella_Game.Menus.Levels;

namespace The_Stella_Game.Sprites
{

    public class StellaPlayer : AnimationEntity
    {
        public int Health { get; private set; } = 3;
        public int KeyQuantity { get; private set; } = 0;
        public double Score { get; private set; } = 0;

        public double Coins { get; private set; } = 0;
        public bool Jumped { get; private set; } = false;
        public bool IsFalling { get; private set; } = false;

        private Game1 Game;

        private Cooldown SpikeCooldown;
        private Cooldown MiniBossCooldown;
        private Cooldown VatCooldown;
        private Cooldown ShootCooldown;

        public SoundEffect StellaDamageSound;

        private Level _level;
        private bool hasShot;

        public StellaPlayer(Game1 game, ContentManager contentManager, Vector2 spawnPosition, Level level) : base(contentManager, spawnPosition)
        {
            this.Texture = contentManager.Load<Texture2D>("Sprites\\Player\\SpriteSheetStellaEmptyGlassSideways");
            this.Game = game;
            this.CollisionBox = new CollisionBox(spawnPosition, 25, 47, 20, 0, true);

            this._level = level;

            StellaDamageSound = contentManager.Load<SoundEffect>("Music\\SoundEffect\\StellaDamage");

            this.Add(new AnimationFrame(new Rectangle(0, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(200, 0, 100, 99), 5));
            this.Add(new AnimationFrame(new Rectangle(300, 0, 100, 99), 5));

            SpikeCooldown = new Cooldown(2f);
            MiniBossCooldown = new Cooldown(2f);
            VatCooldown = new Cooldown(2f);
            ShootCooldown = new Cooldown(1f);
        }

        public override void Move(List<IGObject> gObjects)
        {
            foreach (IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) continue;
                Sprite sprite = obj as Sprite;

                if (sprite.Equals(this)) continue;

                if (this.DetectCollision(sprite))
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
                    coin.CoinSound.Play();
                    this.Score += coin.Value;
                    this.Coins += 1;
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

                    Game1.GetInstance().ChangeLevel();
                }
            }

            if (sprite is Spike)
            {
                Spike s = sprite as Spike;
                if (s.State == SpikeState.UP )
                {

                    if (!SpikeCooldown.Enabled)
                    {
                        StellaDamageSound.Play();
                        this.Health -= 1;
                        SpikeCooldown.Enabled = true;
                    }
                }
                else
                {
                    s.CollisionBox.Box = Rectangle.Empty;
                }
            }

            if (sprite is MiniBoss)
            {
                MiniBoss miniBoss = sprite as MiniBoss;
                if (!MiniBossCooldown.Enabled)
                {
                    if (this.IsTouchingTop(miniBoss))
                    {
                        miniBoss.MiniBossSound.Play();
                        this.Score += miniBoss.Value;
                        miniBoss.Lives -= 1;
                        miniBoss.Found = true;
                    }
                    else
                    {
                        StellaDamageSound.Play();
                        this.Health -= 1;
                        MiniBossCooldown.Enabled = true;
                    }
                }
            }

            if (sprite is Vat)
            {
                if (!VatCooldown.Enabled)
                {
                    StellaDamageSound.Play();
                    this.Health -= 1;
                    VatCooldown.Enabled = true;
                }
            }
        }
        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            MiniBossCooldown.Update(gameTime);
            SpikeCooldown.Update(gameTime);
            VatCooldown.Update(gameTime);
            ShootCooldown.Update(gameTime);

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl)) Speed = 5f;
            else Speed = 3f;

            if (state.IsKeyDown(Keys.Z)) Velocity.Y = -Speed; //UP
            else if (state.IsKeyDown(Keys.S)) Velocity.Y = Speed; //DOWN
            else Velocity.Y = 0f;

            if (state.IsKeyDown(Keys.Q)) Velocity.X = -Speed; //LEFT
            else if (state.IsKeyDown(Keys.D)) Velocity.X = Speed; //RIGHT
            else Velocity.X = 0f;

            if (state.IsKeyDown(Keys.E) && !ShootCooldown.Enabled) hasShot = true;

            if (state.IsKeyDown(Keys.Space) && !Jumped)
            {
                    Jumped = true;
            }

            if (this.Health == 0)
            {
                Game.ChangeMenu(new GameOverMenu(Game, Graphics, Content));
                this.Reset();
            }
            
            if (hasShot && !ShootCooldown.Enabled && (_level is EndLevel))
            {
                ShootCooldown.Enabled = true;
                hasShot = false;

                EndLevel endLevel = _level as EndLevel;
                endLevel.CachedSprites.Add(new CoinBullet(Content, Position));

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

        public void Reset()
        {
            this.KeyQuantity = 0;
            this.Health = 3;
        }

        public override string ToString()
        {
            return "StellaPlayer";
        }
    }
}
