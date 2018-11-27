using Microsoft.Xna.Framework;
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

        public string XmlPath;

        public gameScreen()
        {
            Type = this.GetType();
            XmlPath ="Load/"+Type.ToString().Replace("theFallenCity.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gametime)
        {
            InputManager.Instance.Update();

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
        }

    }
}
