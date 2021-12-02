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
        public Heart(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Hearts\\" + TextureName);
            this.Position = spawnPosition;
            this.CollisionBox = new CollisionBox(Position, 20, 20, 0, 0, true);
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            this.Texture = Content.Load<Texture2D>("Sprites\\Hearts\\" + Usable);

            base.Update(gameTime, gObjects);
        }
    }
}
