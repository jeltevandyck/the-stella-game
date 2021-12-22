using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Framework;
using The_Stella_Game.Sprites;
using The_Stella_Game.Sprites.Bars;

namespace The_Stella_Game.Menus
{
    class Level2 : Menu
    {
        public Level2(Game1 game, GraphicsDeviceManager graphics, ContentManager content) : base(game, graphics, content)
        {
            this.Background = content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel2");

            this.BackgroundSong = content.Load<Song>("Music\\Level2BackgroundMusic");
            MediaPlayer.Volume -= 0.7f;
            MediaPlayer.Play(BackgroundSong);
            MediaPlayer.MediaStateChanged += ChangeState_Media;

            //Player
            SpriteObjects.Add(new StellaPlayer(game,Content, new Vector2(750, 200)));

            #region Minibosses

            SpriteObjects.Add(new MiniBoss(content, "SpriteSheetMaesSideways", new Vector2(1000, 475), 300));
            SpriteObjects.Add(new MiniBoss(content, "SpriteSheetHeinekenSideways", new Vector2(1400,475),200));

            SpriteObjects.Add(new MiniBoss(content, "SpriteSheetCristalSideways", new Vector2(200, 800), 200));
            SpriteObjects.Add(new MiniBoss(content, "SpriteSheetHeinekenSideways", new Vector2(450, 800), 300));
            SpriteObjects.Add(new MiniBoss(content, "SpriteSheetCristalSideways", new Vector2(800, 800), 250));

            #endregion

            #region Score- and Healthbar
            SpriteObjects.Add(new HealthBar(content, new Vector2(750, 0)));
            SpriteObjects.Add(new ScoreBar(content, new Vector2(850, 5)));
            #endregion

            #region Door

            #endregion

            #region Coins

            SpriteObjects.Add(new Coin(content, new Vector2(300,170)));
            SpriteObjects.Add(new Coin(content, new Vector2(520, 270)));

            SpriteObjects.Add(new Coin(content, new Vector2(980, 290)));
            SpriteObjects.Add(new Coin(content, new Vector2(1120, 290)));

            SpriteObjects.Add(new Coin(content, new Vector2(1500, 500)));
            SpriteObjects.Add(new Coin(content, new Vector2(1300, 500)));
            SpriteObjects.Add(new Coin(content, new Vector2(1100, 500)));

            SpriteObjects.Add(new Coin(content, new Vector2(200, 820)));
            SpriteObjects.Add(new Coin(content, new Vector2(400, 820)));
            SpriteObjects.Add(new Coin(content, new Vector2(600, 820)));
            SpriteObjects.Add(new Coin(content, new Vector2(800, 820)));
            SpriteObjects.Add(new Coin(content, new Vector2(1000, 820)));

            #endregion

            #region Keys

            SpriteObjects.Add(new Key(content, new Vector2(15, 7)));
            SpriteObjects.Add(new Key(content, new Vector2(1450, 158)));
            SpriteObjects.Add(new Key(content, new Vector2(15, 764)));

            #endregion 

            #region Platforms
            //Horitontal
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(660, 400)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(962, 322)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(0, 528)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(360, 529)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(915, 528)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(1373, 530)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(458, 853)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(915, 856)));

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(2, 100)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(222, 200)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(452, 300)));

            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1380, 250)));

            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1220, 778)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(1530, 778)));

            //Vertical
            SpriteObjects.Add(new Platform(Content, "V3", new Vector2(624, 300)));
            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(923, 322)));
            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(1180, 780)));

            #endregion

            #region Spikes

            SpriteObjects.Add(new Spike(content, new Vector2(0, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(40, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(80, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(120, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(160, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(200, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(240, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(280, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(320, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(360, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(400, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(440, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(480, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(520, 490)));
            SpriteObjects.Add(new Spike(content, new Vector2(560, 490)));


            #endregion
        }

        private void ChangeState_Media(object sender, EventArgs e)
        {
            MediaPlayer.Play(BackgroundSong);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab)) Game.ChangeMenu(new StartMenu(Game, Graphics, Content));

            base.Update(gameTime);
        }
    }
}
