using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Key : Sprite
    {

        public double Value = 150;
        public bool Found;
        public Key(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Key\\VatBierPixilated");
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(spawnPosition, 100, 100);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            if (!Found)
            {
                spritebatch.Draw(Texture, CollisionBox.Box, Color.White);
            }
            else
            {
                CollisionBox.Box = Rectangle.Empty;
            }
        }
    }
}
