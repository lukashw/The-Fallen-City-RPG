using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace theFallenCity
{
    public class MenuManager
    {
        Menu menu;

        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange +=  menu_OnMenuChange;

        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            xmlManger<Menu> xmlMenuManger = new xmlManger<Menu>();
            menu.UnloadContent();
            //Add trasnistion if you want
            menu = xmlMenuManger.Load(menu.ID);
            menu.LoadContent();

        }


        public void LoadContent(String menuPath)
        {
            if(menuPath != string.Empty)
            {
                menu.ID = menuPath;
            }

        }


        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }

    }
}
