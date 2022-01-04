using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class CoinBullet : SpriteAnimation
    {

        private bool _hit = false; 

        public CoinBullet(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Coin\\SpriteSheetCoin");
            this.CollisionBox = new CollisionBox(spawnPosition, 40, 40);

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
                Game1.GetInstance().ChangeLevel();
            }
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Move(gObjects);

            base.Update(gameTime, gObjects);
        }

    }
}
