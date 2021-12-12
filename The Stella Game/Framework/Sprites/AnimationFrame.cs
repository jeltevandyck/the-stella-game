using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Stella_Game.Framework
{
    public class AnimationFrame
    {
        public Rectangle Rectangle;

        public int FrameSpeed;

        public AnimationFrame(Rectangle rect, int frameSpeed)
        {
            Rectangle = rect;
            FrameSpeed = frameSpeed;
        }
    }
}
