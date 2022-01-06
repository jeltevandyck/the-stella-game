using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace The_Stella_Game.Framework
{
    public abstract class Sprite : IGObject
    {
        public ContentManager Content { get; private set; }
        public Texture2D Texture;
        public Vector2 Position;

        public Vector2 Velocity;
        
        public CollisionBox CollisionBox;

        public float Speed { get; set; } = 2f;
        public Sprite(ContentManager content)
        {
            this.Content = content;
            this.Velocity = new Vector2(0, 0);
        }
        public bool DetectCollision(Sprite sprite)
        {
            Rectangle box = CollisionBox.Box;
            box.X += (int) Velocity.X;
            box.Y += (int) Velocity.Y;

            return box.Intersects(sprite.CollisionBox.Box);
        }
        public virtual void Intersects(Sprite sprite)
        {

        }
        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            if (CollisionBox == null) return;
            else CollisionBox.Update(Position);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CollisionBox.Box, Color.White);
        }

        #region Collision
        //Source - Github Oyyou: https://github.com/Oyyou/MonoGame_Tutorials/blob/master/MonoGame_Tutorials/
        public bool IsTouchingLeft(Sprite sprite)
        {
            return this.CollisionBox.Box.Right + this.Speed > sprite.CollisionBox.Box.Left &&
              this.CollisionBox.Box.Left < sprite.CollisionBox.Box.Left &&
              this.CollisionBox.Box.Bottom > sprite.CollisionBox.Box.Top &&
              this.CollisionBox.Box.Top < sprite.CollisionBox.Box.Bottom;
        }

        public bool IsTouchingRight(Sprite sprite)
        {
            return this.CollisionBox.Box.Left + this.Speed < sprite.CollisionBox.Box.Right &&
              this.CollisionBox.Box.Right > sprite.CollisionBox.Box.Right &&
              this.CollisionBox.Box.Bottom > sprite.CollisionBox.Box.Top &&
              this.CollisionBox.Box.Top < sprite.CollisionBox.Box.Bottom;
        }

        public bool IsTouchingTop(Sprite sprite)
        {
            return this.CollisionBox.Box.Bottom + this.Speed > sprite.CollisionBox.Box.Top &&
              this.CollisionBox.Box.Top < sprite.CollisionBox.Box.Top &&
              this.CollisionBox.Box.Right > sprite.CollisionBox.Box.Left &&
              this.CollisionBox.Box.Left < sprite.CollisionBox.Box.Right;
        }

        public bool IsTouchingBottom(Sprite sprite)
        {
            return this.CollisionBox.Box.Top + this.Speed < sprite.CollisionBox.Box.Bottom &&
              this.CollisionBox.Box.Bottom > sprite.CollisionBox.Box.Bottom &&
              this.CollisionBox.Box.Right > sprite.CollisionBox.Box.Left &&
              this.CollisionBox.Box.Left < sprite.CollisionBox.Box.Right;
        }
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
