using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class Platform : Sprite
    {
        public Platform(ContentManager content, string sheet, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Platform\\" + sheet);
            this.Position = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, Texture.Width, Texture.Height, 0, 0, false);
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, CollisionBox.Box, Color.White);
        }
    }
}
