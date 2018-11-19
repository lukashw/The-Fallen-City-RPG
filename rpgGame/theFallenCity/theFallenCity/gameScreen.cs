﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

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
        [XmlIgnore]
        public Type Type;

        public gameScreen()
        {
            Type = this.GetType();
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(screenManager.Instance.Content.ServiceProvider, "Content");

        }

        public virtual void UnloadContent()
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
