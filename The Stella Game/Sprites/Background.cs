using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public class Background : Sprite
    {

        public string Name { get; private set; }
        public Background(ContentManager content, string backgroundName) : base(content)
        {
            this.Name = backgroundName;
            this.Texture = content.Load<Texture2D>("Sprites\\BackGround\\" + backgroundName);
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(0, 0, Game1.MAX_WIDTH, Game1.MAX_HEIGHT), Color.White);
        }
    }
}
