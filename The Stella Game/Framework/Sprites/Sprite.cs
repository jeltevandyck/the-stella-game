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
        public Rectangle CollisionBox;

        public int CollisionBox_X_Extra = 0;
        public int CollisionBox_Y_Extra = 0;

        public Boolean Collidable = false;

        public float Speed { get; set; } = 2f;

        public Sprite(ContentManager content)
        {
            this.Content = content;
        }

        public bool Intersects(Sprite sprite)
        {
            if (sprite.Equals(this)) return false;
            else
            {
                return sprite.CollisionBox.Intersects(CollisionBox);
            }
        }
        public virtual void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            CollisionBox.X = (int) Position.X + CollisionBox_X_Extra;
            CollisionBox.Y = (int) Position.Y + CollisionBox_Y_Extra;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CollisionBox, Color.White);
        }

        #region Collision
        //Source: https://github.com/Oyyou/MonoGame_Tutorials/blob/master/MonoGame_Tutorials/Tutorial009/Sprites/Sprite.cs
        public bool IsTouchingLeft(Sprite sprite)
        {
            return this.CollisionBox.Right + this.Speed > sprite.CollisionBox.Left &&
              this.CollisionBox.Left < sprite.CollisionBox.Left &&
              this.CollisionBox.Bottom > sprite.CollisionBox.Top &&
              this.CollisionBox.Top < sprite.CollisionBox.Bottom;
        }

        public bool IsTouchingRight(Sprite sprite)
        {
            return this.CollisionBox.Left + this.Speed < sprite.CollisionBox.Right &&
              this.CollisionBox.Right > sprite.CollisionBox.Right &&
              this.CollisionBox.Bottom > sprite.CollisionBox.Top &&
              this.CollisionBox.Top < sprite.CollisionBox.Bottom;
        }

        public bool IsTouchingTop(Sprite sprite)
        {
            return this.CollisionBox.Bottom + this.Speed > sprite.CollisionBox.Top &&
              this.CollisionBox.Top < sprite.CollisionBox.Top &&
              this.CollisionBox.Right > sprite.CollisionBox.Left &&
              this.CollisionBox.Left < sprite.CollisionBox.Right;
        }

        public bool IsTouchingBottom(Sprite sprite)
        {
            return this.CollisionBox.Top + this.Speed < sprite.CollisionBox.Bottom &&
              this.CollisionBox.Bottom > sprite.CollisionBox.Bottom &&
              this.CollisionBox.Right > sprite.CollisionBox.Left &&
              this.CollisionBox.Left < sprite.CollisionBox.Right;
        }
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
