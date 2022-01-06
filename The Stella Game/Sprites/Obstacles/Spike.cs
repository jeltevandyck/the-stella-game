using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Sprites
{
    public enum SpikeState
    {
        DOWN,
        UP
    }
    public class Spike : SpriteAnimation
    {
        public SpikeState State;
        public Spike(ContentManager content, Vector2 spawnPosition) : base(content)
        {
            this.Texture = content.Load<Texture2D>("Sprites\\Obstacles\\SpriteSheetSpikeLong");
            this.Position = spawnPosition;

            this.CollisionBox = new CollisionBox(spawnPosition, 30, 50, 20,0,false);

            this.Add(new AnimationFrame(new Rectangle(0, 0, 116, 78),1));
            this.Add(new AnimationFrame(new Rectangle(116, 0, 116, 78), 2));
            this.Add(new AnimationFrame(new Rectangle(232, 0, 116, 78), 2));
            this.Add(new AnimationFrame(new Rectangle(348, 0, 116, 78), 2));
        }

        public override void Update(GameTime gameTime, List<IGObject> gObjects)
        {
            if (Index == 0) State = SpikeState.DOWN;
            else State = SpikeState.UP;

            base.Update(gameTime, gObjects);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            base.Draw(gameTime, spriteBatch);

        }


    }
}
