using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using theFallenCity.MainGame;
using theFallenCity.MapAge;

namespace theFallenCity
{

    public class GamePlay: gameScreen
    {
        Player player;
        Map map;

        public GamePlay()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
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
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            map.Draw(spritebatch);
            player.Draw(spritebatch);
        }
    }
}
