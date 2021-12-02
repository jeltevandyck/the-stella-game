using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using The_Stella_Game.Sprites;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;

namespace The_Stella_Game.Menus
{
    public class GameMenu : Menu
    { 
        public GameMenu(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel1");

            StellaPlayer stellaPlayer = new StellaPlayer(Content, new Vector2(2, 0));
            stellaPlayer.SetRectangleTexture(Game.GraphicsDevice, stellaPlayer.Texture);
            SpriteObjects.Add(stellaPlayer);

            MiniBoss miniBossMaes = new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300, 75), 400);
            miniBossMaes.SetRectangleTexture(Game.GraphicsDevice, miniBossMaes.Texture);
            SpriteObjects.Add(miniBossMaes);

            MiniBoss miniBossHeineken = new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(600, 330), 400);
            miniBossHeineken.SetRectangleTexture(Game.GraphicsDevice, miniBossHeineken.Texture);
            SpriteObjects.Add(miniBossHeineken);

            //SpriteObjects.Add(new HealthBar(content, new Vector2(100, 100)));

            //Keys
            Key key = new Key(Content, new Vector2(1550, 42));
            SpriteObjects.Add(key);

            //Platforms
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(0, 49)));

            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(170, 50)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(208, 130)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(665, 130)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1122, 132)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1430, 133)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1237, 250)));
            SpriteObjects.Add(new Platform(Content, "V4", new Vector2(1200, 251)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(742, 384)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(383, 385)));
            SpriteObjects.Add(new Platform(Content, "V4", new Vector2(344, 251)));
            SpriteObjects.Add(new Platform(Content, "H6", new Vector2(277, 251)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(0, 251)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 550)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 550)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(919, 551)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(1300, 400)));


            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1050, 700)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1510, 702)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(918, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1377, 853)));


            //Spikes
            Spike spike = new Spike(Content, "SpriteSheetSpikeLong", new Vector2(459, 518));
            spike.SetRectangleTexture(Game.GraphicsDevice, spike.Texture);
            SpriteObjects.Add(spike);
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(489, 518)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(589, 518)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(609, 518)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(709, 518)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(739, 518)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(839, 518)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(869, 518)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(969, 518)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(999, 518)));
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }
    }
}
