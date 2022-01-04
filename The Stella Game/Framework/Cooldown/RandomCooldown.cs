using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class RandomCooldown : Cooldown
    {
        private int _min;
        private int _max;

        public RandomCooldown(float delay, int min, int max) : base(delay)
        {
            this._min = min;
            this._max = max;
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                Delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Delay <= 0f)
                {
                    Enabled = false;
                    Delay = (new Random()).Next(_min, _max);
                }
            }
        }
    }
}
