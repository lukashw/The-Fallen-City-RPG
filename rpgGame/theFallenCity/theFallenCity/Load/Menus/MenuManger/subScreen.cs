﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace theFallenCity
{
    public class SubScreen : gameScreen
    {
        MenuManager menuManager;

        public SubScreen()
        {
            menuManager = new MenuManager();

        }

        public override void LoadContent()
        {

            base.LoadContent();
            menuManager.LoadContent("Load/Menus/LevelSelect.xml");
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
