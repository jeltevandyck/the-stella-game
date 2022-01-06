using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;
using The_Stella_Game.Menus;
using The_Stella_Game.Menus.Levels;

namespace The_Stella_Game.Sprites
{
    public class CoinBullet : SpriteAnimation
    {

        public bool LastBullet;
        private Level _currentLevel;

        public CoinBullet(ContentManager content, Vector2 spawnPosition, Level currentLevel) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\SpriteSheetCoin");
            this.CollisionBox = new CollisionBox(spawnPosition, 40, 40);

            _currentLevel = currentLevel;
            Position = spawnPosition;

            Speed = 5f;

            this.Add(new AnimationFrame(new Rectangle(0, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(50, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(100, 0, 50, 50), 5));
            this.Add(new AnimationFrame(new Rectangle(150, 0, 50, 50), 5));
        }

        public void Move(List<IGObject> gObjects)
        {
            foreach(IGObject obj in gObjects)
            {
                if (!(obj is Sprite)) break;
                Sprite sprite = obj as Sprite;

                if (this.DetectCollision(sprite)) this.Intersects(sprite);
            }


            Velocity.Y = -Speed;

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public override void Intersects(Sprite sprite)
        {
            if (sprite is EndBoss)
            {
                Game1.GetInstance().ChangeLevel(_currentLevel.StellaPlayer.Coins);
            }
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);
            
            if (LastBullet && _currentLevel.StellaPlayer.Coins == 0 && Position.Y <= 200)
            {
                Game1.GetInstance().ChangeMenu(new GameOverMenu(Game1.GetInstance(), Game1.GetInstance().GetGraphicsDeviceManager(), Game1.GetInstance().Content));
            } 

            base.Update(gameTime, gObjects);
        }

        public static implicit operator CoinBullet(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
