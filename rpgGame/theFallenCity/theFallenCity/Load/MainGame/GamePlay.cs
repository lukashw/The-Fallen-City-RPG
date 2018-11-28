using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using theFallenCity.MainGame;

namespace theFallenCity
{

    public class GamePlay: gameScreen
    {
        Player player;

        public GamePlay()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            xmlManger<Player> playerLoader = new xmlManger<Player>();
            player = playerLoader.Load("Load/MainGame/Player.xml");
            player.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            player.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            player.Draw(spritebatch);
        }
    }
}
