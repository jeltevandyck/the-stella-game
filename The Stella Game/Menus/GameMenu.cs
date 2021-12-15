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
            
            //Player
            SpriteObjects.Add(new StellaPlayer(game,Content, new Vector2(10, 500)));

            //Minibos
            MiniBoss miniBossMaes = new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300, 75), 400);
            miniBossMaes.SetRectangleTexture(Game.GraphicsDevice, miniBossMaes.Texture);
            SpriteObjects.Add(miniBossMaes);

            MiniBoss miniBossHeineken = new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(600, 330), 400);
            miniBossHeineken.SetRectangleTexture(Game.GraphicsDevice, miniBossHeineken.Texture);
            SpriteObjects.Add(miniBossHeineken);

            //SpriteObjects.Add(new HealthBar(content, new Vector2(100, 100)));

            //Door

            SpriteObjects.Add(new Door(Content, new Vector2(1550, 772)));
            //Coins

            SpriteObjects.Add(new Coin(Content, new Vector2(300, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(500, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(800, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1000, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1600, 220)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1300, 220)));
            


            //Keys
            SpriteObjects.Add(new Key(Content, new Vector2(1500, 45)));
            SpriteObjects.Add(new Key(Content, new Vector2(10, 460)));
            SpriteObjects.Add(new Key(Content, new Vector2(10, 760)));

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
            SpriteObjects.Add(new PlatformMove(Content, "H2", new Vector2(1300, 400)));


            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1050, 700)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1510, 702)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(918, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1377, 853)));


            //Spikes
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(459, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(489, 510)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(599, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(629, 510)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(729, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(759, 510)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(859, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(899, 510)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(989, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(1019, 510)));

            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(1109, 510)));
            SpriteObjects.Add(new Spike(Content, "SpriteSheetSpikeLong", new Vector2(1139, 510)));
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }
    }
}
