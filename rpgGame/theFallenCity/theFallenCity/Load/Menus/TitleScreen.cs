using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace theFallenCity
{
    public class TitleScreen : gameScreen
    {
        //this is the main draw class for the title screen 
        MenuManager menuManager;

        public TitleScreen()
        {
            menuManager = new MenuManager();

        }

        public override void LoadContent()
        {
            base.LoadContent();
            menuManager.LoadContent("Load/Menus/TitleMenu.xml");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            menuManager.UnloadContent();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            menuManager.Draw(spritebatch);
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            menuManager.Update(gametime);
        }

       
    }
}
