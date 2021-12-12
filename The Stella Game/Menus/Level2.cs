using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;
using The_Stella_Game.Sprites;

namespace The_Stella_Game.Menus
{
    class Level2 : Menu
    {
        public Level2(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel2");

            //Player
            SpriteObjects.Add(new StellaPlayer(game,Content, new Vector2(750, 200)));

            //Minibos


            //SpriteObjects.Add(new HealthBar(content, new Vector2(100, 100)));

            //Door



            //Coins


            //Keys


            //Platforms
                //Horitontal
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(660, 400)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(962, 322)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1250, 100)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(0, 528)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(360, 529)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(458, 700)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(915, 528)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(1373, 530)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(458, 853)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(915, 856)));

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(2, 100)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(222, 200)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(452, 300)));

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1380, 270)));

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1220, 778)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1530, 778)));

            //Vertical
            SpriteObjects.Add(new Platform(Content, "V3", new Vector2(624, 300)));
            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(923, 322)));
            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(1180, 780)));

            //Spikes

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }
    }
}
