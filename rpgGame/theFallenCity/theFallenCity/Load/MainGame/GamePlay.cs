using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using theFallenCity.MainGame;
using theFallenCity.MapAge;


namespace theFallenCity
{

    public class GamePlay: gameScreen
    {

        bool gameGunning = true;
        Player player;
        Map map;
        //timer
        TimeSpan GTimer = TimeSpan.Zero;
        public string Text, FontNames, Path;
        SpriteFont font;
        double levelScore = 50000;
        // public static bool GameWin = false;
        public bool GameWins = false;


        //timer end

        public GamePlay()
        {FontNames = "textFonts/FontBoi";}


        public override void LoadContent()
        {

            base.LoadContent();
            font = content.Load<SpriteFont>(FontNames);
            xmlManger<Player> playerLoader = new xmlManger<Player>();
            xmlManger<Map> mapLoader = new xmlManger<Map>();
            player = playerLoader.Load("Load/MainGame/Player.xml");
            map = mapLoader.Load("Load/MainGame/Maps/Map1.xml");
            player.LoadContent();
            map.LoadContent();

           

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            map.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            player.Update(gametime);
            map.Update(gametime, ref player);


            if (gameGunning==true)
            {
                GTimer += gametime.ElapsedGameTime;

                if (levelScore > 0)
                    levelScore = levelScore - 0.5;

            }
            //Pausing the game
            if (InputManager.Instance.KeyPressed(Keys.P))
                gameGunning = false;
            else gameGunning |= InputManager.Instance.KeyReleased(Keys.P);



            if (InputManager.Instance.KeyPressed(Keys.M))
                ScreenManager.Instance.ScreenChange("TitleScreen");


        }

        public void Update(GameTime gameTime, ref Player player)
        {
          
           

        }




        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            map.Draw(spritebatch);
            player.Draw(spritebatch);
            if (gameGunning == false)
                spritebatch.DrawString(font, "Paused " , new Vector2(10, 215), Color.Red);

            spritebatch.DrawString(font, "Time "+ GTimer.ToString(), new Vector2(10, 415), Color.White);
            spritebatch.DrawString(font,"Current score " + levelScore.ToString(), new Vector2(10, 435), Color.Red);



            if (GameWins == true)
                spritebatch.DrawString(font, "You won ", new Vector2(10, 215), Color.Red);





        }
    }
}
