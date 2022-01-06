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
    public class Level1 : Level
    {
        public Level1(Game1 game, ContentManager content) : base(game, content)
        { 
        }

        public override void Load()
        {
            SpriteObjects = new List<IGObject>();
            this.Background = Content.Load<Texture2D>("Sprites\\Menu\\BackgroundLevel1");

            //Player
            StellaPlayer = new StellaPlayer(Game1.GetInstance(), Game1.GetInstance().Content, new Vector2(10, 50), this);
            SpriteObjects.Add(StellaPlayer);

            #region Minibosses

            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(300, 75), 400));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(600, 330), 400));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetCristalSideways", new Vector2(1300, 645), 300));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetMaesSideways", new Vector2(100, 799), 250));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetHeinekenSideways", new Vector2(400, 799), 300));
            SpriteObjects.Add(new MiniBoss(Content, "SpriteSheetCristalSideways", new Vector2(700, 799), 200));

            #endregion

            #region Score- And HealthBar

            SpriteObjects.Add(new HealthBar(Content, new Vector2(750, 0), StellaPlayer));
            SpriteObjects.Add(new ScoreBar(Content, new Vector2(850, 5), StellaPlayer));

            #endregion

            #region Door

            SpriteObjects.Add(new Door(Content, new Vector2(1550, 772)));

            #endregion

            #region Coins

            //Rij 1
            SpriteObjects.Add(new Coin(Content, new Vector2(100, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(350, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(600, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(850, 100)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1100, 100)));

            //Rij 2
            SpriteObjects.Add(new Coin(Content, new Vector2(50, 275)));
            SpriteObjects.Add(new Coin(Content, new Vector2(500, 355)));
            SpriteObjects.Add(new Coin(Content, new Vector2(750, 355)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1000, 355)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1600, 225)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1350, 225)));

            //Rij 3
            SpriteObjects.Add(new Coin(Content, new Vector2(100, 520)));
            SpriteObjects.Add(new Coin(Content, new Vector2(350, 520)));
            SpriteObjects.Add(new Coin(Content, new Vector2(560, 520)));
            SpriteObjects.Add(new Coin(Content, new Vector2(810, 520)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1060, 520)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1370, 470)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1570, 420)));

            //Rij 4
            SpriteObjects.Add(new Coin(Content, new Vector2(350, 700)));
            SpriteObjects.Add(new Coin(Content, new Vector2(560, 700)));
            SpriteObjects.Add(new Coin(Content, new Vector2(810, 700)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1200, 820)));
            SpriteObjects.Add(new Coin(Content, new Vector2(1400, 820)));

            #endregion

            #region Keys
            //Keys
            SpriteObjects.Add(new Key(Content, new Vector2(1500, 45)));
            SpriteObjects.Add(new Key(Content, new Vector2(10, 460)));
            SpriteObjects.Add(new Key(Content, new Vector2(10, 760)));

            #endregion

            #region Spikes
            //Spikes
            SpriteObjects.Add(new Spike(Content, new Vector2(459, 510)));

            SpriteObjects.Add(new Spike(Content, new Vector2(599, 510)));

            SpriteObjects.Add(new Spike(Content, new Vector2(729, 510)));

            SpriteObjects.Add(new Spike(Content, new Vector2(859, 510)));

            SpriteObjects.Add(new Spike(Content, new Vector2(989, 510)));

            SpriteObjects.Add(new Spike(Content, new Vector2(1109, 510)));

            #endregion

            #region Platforms
            //Platforms
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(0, 130)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(266, 128)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(723, 128)));
            SpriteObjects.Add(new Platform(Content, "H5", new Vector2(1182, 132)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1430, 133)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1237, 250)));
            SpriteObjects.Add(new Platform(Content, "V4", new Vector2(1200, 251)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(742, 384)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(383, 385)));
            SpriteObjects.Add(new Platform(Content, "V5", new Vector2(344, 306)));
            SpriteObjects.Add(new Platform(Content, "H6", new Vector2(277, 306)));
            SpriteObjects.Add(new Platform(Content, "H4", new Vector2(0, 306)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 550)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 550)));
            SpriteObjects.Add(new Platform(Content, "H2", new Vector2(919, 551)));

            SpriteObjects.Add(new Platform(Content, "H5", new Vector2(1320, 500)));
            SpriteObjects.Add(new Platform(Content, "H5", new Vector2(1520, 450)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1050, 700)));
            SpriteObjects.Add(new Platform(Content, "H3", new Vector2(1510, 702)));

            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(918, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1377, 853)));

            #endregion 
        }

        public override void PlaySong()
        {
            this.BackgroundSong = Content.Load<Song>("Music\\Level1BackgroundMusic");
            MediaPlayer.Volume -= 0.7f;
            MediaPlayer.Play(BackgroundSong);
            MediaPlayer.MediaStateChanged += ChangeState_Media;
        }

        private void ChangeState_Media(object sender, EventArgs e)
        {
            MediaPlayer.Play(BackgroundSong);
        }
    }
}
