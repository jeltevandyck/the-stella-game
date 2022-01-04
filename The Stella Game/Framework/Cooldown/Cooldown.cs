using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class Cooldown
    {
        public bool Enabled = false;
        public float Delay = 5f;

        private float _delayReset;

        public Cooldown(float delay)
        {
            Delay = delay;
            _delayReset = delay;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                Delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Delay <= 0f)
                {
                    Enabled = false;
                    Delay = _delayReset;
                }
            }
        }
    }
}
