using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace theFallenCity
{
    public class MenuManager
    {
        Menu menu;
        bool isTransitioning;

        void Transition(GameTime gameTime)
        {
            if(isTransitioning)
            {


                for (int i = 0; i < menu.Items.Count; i ++)
                {
                    menu.Items[i].Image.Update(gameTime);
                    float first = menu.Items[0].Image.Alpha;
                    float last = menu.Items[menu.Items.Count - 1].Image.Alpha;
                    if (first == 0.0f && last == 0.0f)
                        menu.ID = menu.Items[menu.ItemNumber].LinkID;
                    else if (first == 1.0f && last == 1.0f)
                    {
                        isTransitioning = false;
                        foreach (MenuItem item in menu.Items)
                            item.Image.RstEffect();
                    }
                }
            }

        }

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
            menu.OnMenuChange += menu_OnMenuChange;
            menu.Transition(0.0f);
            foreach (MenuItem item in menu.Items)
            {
                item.Image.StrEffect();
                item.Image.ActivateEffect("FadeEffect");
            }

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
            if(!isTransitioning)
                menu.Update(gameTime);
            //enter is pressed on a menu item
            if (InputManager.Instance.KeyPressed(Keys.Enter) && !isTransitioning)
            {

                if (menu.Items[menu.ItemNumber].LinkType == "Screen")
                    ScreenManager.instance.ScreenChange(menu.Items[menu.ItemNumber].LinkID);
                else 
                { 
                    isTransitioning = true;
                    //setting the text to one alpha
                    menu.Transition(1.0f);
                    foreach(MenuItem item in menu.Items)
                    {
                        item.Image.StrEffect();
                        item.Image.ActivateEffect("FadeEffect");
                    }

                }
            }
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }

    }
}
