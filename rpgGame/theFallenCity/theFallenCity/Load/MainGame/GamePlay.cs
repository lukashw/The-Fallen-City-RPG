using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using theFallenCity.MainGame;
using theFallenCity.MapAge;
using Microsoft.Xna.Framework.Content;


namespace theFallenCity
{

    public class GamePlay: gameScreen
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(2000);
        ContentManager ContentP = Game1.MyContent;
        Player player;
        Map map;
        //timer
        TimeSpan bombTimer = TimeSpan.Zero;
        public string Text, FontNames, Path;
        SpriteFont font;



        //timer end

        public GamePlay()
        {
            FontNames = "textFonts/FontBoi";

        }


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

            bombTimer += gametime.ElapsedGameTime;




        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            map.Draw(spritebatch);
            player.Draw(spritebatch);

            spritebatch.DrawString(font, bombTimer.ToString(), new Vector2(10, 10), Color.White);

        }
    }
}
