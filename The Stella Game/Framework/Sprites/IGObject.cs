using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Stella_Game.Framework
{
    public interface IGObject
    {
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
