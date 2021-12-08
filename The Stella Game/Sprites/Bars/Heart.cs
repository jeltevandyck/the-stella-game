using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Heart : Sprite
    {
        public bool Usable = true;
        public String TextureName
        {
            get { return Usable ? "Heart" : "HeartGrey"; }
        }
        public Heart(ContentManager content, Vector2 spawnPosition, bool usable) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Hearts\\" + TextureName);
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(Position, 20, 20, 0, 0, true);
            this.Usable = usable;
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Texture = Content.Load<Texture2D>("Sprites\\Hearts\\" + TextureName);

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, CollisionBox.Box, Color.White);
        }
    }
}
