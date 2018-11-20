using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace theFallenCity
{
    public class ImageEffect
    {
        protected Image image;
        public bool IsActive;
        public ImageEffect()
        {
            IsActive = false;
        }

        public virtual void LoadContent(ref Image Image)
        { this.image = Image; }

        public virtual void UnloadContent()
        {}
        public virtual void Update(GameTime gameTime)
        { }

    }
}
