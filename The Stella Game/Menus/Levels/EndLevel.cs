using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using The_Stella_Game.Framework;
using The_Stella_Game.Sprites;
using The_Stella_Game.Sprites.Bars;

namespace The_Stella_Game.Menus.Levels
{
    public class EndLevel : Level
    {
        public List<Sprite> CachedSprites { get; private set; }

        public EndLevel(Game1 game, ContentManager content) : base(game, content)
        {
            this.CachedSprites = new List<Sprite>();
        }

        public override void Load()
        {
            SpriteObjects = new List<IGObject>();
            this.Background = Content.Load<Texture2D>("Sprites\\Menu\\BackgroundEndLevel");

            //Player
            StellaPlayer stella = new StellaPlayer(Game1.GetInstance(), Game1.GetInstance().Content, new Vector2(10, 760), this);
            SpriteObjects.Add(stella);

            #region Endboss

            EndBoss endBoss = new EndBoss(Game1.GetInstance(), Content, new Vector2(100, 200), 800, this);
            endBoss.SetRectangleTexture(Game1.GetInstance().GraphicsDevice, endBoss.Texture);
            SpriteObjects.Add(endBoss);

            #endregion


            #region Score- And HealthBar

            SpriteObjects.Add(new HealthBar(Content, new Vector2(750, 0)));
            SpriteObjects.Add(new ScoreBar(Content, new Vector2(850, 5)));

            #endregion

            #region Door

            //SpriteObjects.Add(new Door(Content, new Vector2(1550, 772)));

            #endregion

            #region Platforms
            //Platforms
            
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(0, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(459, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(918, 853)));
            SpriteObjects.Add(new Platform(Content, "H1", new Vector2(1377, 853)));

            #endregion 
        }

        public override void PreUpdate(GameTime gameTime)
        {
            int index = 3;
            foreach (Sprite sprite in CachedSprites)
            {
                if (sprite is CoinBullet) Debug.WriteLine("coinbullet!");
                SpriteObjects.Insert(index++, sprite);
            }
            CachedSprites.Clear();
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
