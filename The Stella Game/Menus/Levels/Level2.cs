using System;
using System.Collections.Generic;
using System.Text;
using The_Stella_Game.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using The_Stella_Game.Framework;
using The_Stella_Game.Sprites.Bars;
using The_Stella_Game.Menus.Levels;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace The_Stella_Game.Menus.Levels
{
    public class Level2 : Level
    {
        public Level2(Game1 game, ContentManager content) : base(game, content)
        {
        }

        public override void Load()
        {
            SpriteObjects = new List<IGObject>();
            this.Background = Content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel2");

            //Player
            StellaPlayer = new StellaPlayer(Game1.GetInstance(), Game1.GetInstance().Content, new Vector2(750, 200), this);
            SpriteObjects.Add(StellaPlayer);

            #region Minibosses

            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(1000, 475), 300));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(1400, 475), 200));

            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetCristalSideways", new Vector2(200, 800), 200));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(450, 800), 300));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetCristalSideways", new Vector2(800, 800), 250));

            #endregion

            #region Score- and Healthbar
            SpriteObjects.Add(new HealthBar(Content, new Vector2(750, 0), StellaPlayer));
            SpriteObjects.Add(new ScoreBar(Content, new Vector2(850, 5), StellaPlayer));
            #endregion

            #region Door

            SpriteObjects.Add(new Door(Content, new Vector2(1620, 700)));

            #endregion

            #region Coins

            SpriteObjects.Add(new Coin(Content, new Vector2(300, 170)));
            SpriteObjects.Add(new Coin(Content, new Vector2(520, 270)));

            SpriteObjects.Add(new Coin(Content, new Vector2(980, 290)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1120, 290)));

            SpriteObjects.Add(new Coin(Content, new Vector2(1500, 500)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1300, 500)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1100, 500)));

            SpriteObjects.Add(new Coin(Content, new Vector2(200, 820)));
            SpriteObjects.Add(new Coin(Content, new Vector2(400, 820)));
            SpriteObjects.Add(new Coin(Content, new Vector2(600, 820)));
            SpriteObjects.Add(new Coin(Content, new Vector2(800, 820)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1000, 820)));

            #endregion

            #region Keys

            SpriteObjects.Add(new Key(Content, new Vector2(15, 7)));
            SpriteObjects.Add(new Key(Content, new Vector2(1450, 158)));
            SpriteObjects.Add(new Key(Content, new Vector2(15, 764)));

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

            SpriteObjects.Add(new Spike(Content, new Vector2(0, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(40, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(80, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(120, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(160, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(200, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(240, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(280, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(320, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(360, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(400, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(440, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(480, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(520, 490)));
            SpriteObjects.Add(new Spike(Content, new Vector2(560, 490)));


            #endregion
        }

        public override void PlaySong()
        {
            this.BackgroundSong = Content.Load<Song>("Music\\Level2BackgroundMusic");
            MediaPlayer.Volume = 0.7f;
            MediaPlayer.Play(BackgroundSong);
            MediaPlayer.MediaStateChanged += ChangeState_Media;
        }

        private void ChangeState_Media(object sender, EventArgs e)
        {
            MediaPlayer.Play(BackgroundSong);
        }
    }
}
