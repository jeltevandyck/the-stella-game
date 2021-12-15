using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class Cooldown
    {
        public bool Enabled = false;
        public float Delay = 1f;

        public Cooldown(float delay)
        {
            Delay = delay;
        }

        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;
            Delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Delay < 0) Enabled = false;
        }
    }
}
