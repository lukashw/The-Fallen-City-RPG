﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFallenCity
{
    public class gameScreen
    {
        protected ContentManager content;

        public virtual void loadContent()
        {
            content = new ContentManager(screenManager.Instance.Content.ServiceProvider, "Content");

        }

        public virtual void unloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gametime)
        {

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
        }

    }
}