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
     public class screenManager
    {
        private static screenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        xmlManger<gameScreen> xmlGameScreenManager;
        gameScreen currentScreen;


        public static screenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new screenManager();

                return instance;

            }

        }

        public screenManager()
        {
            Dimensions = new Vector2(640, 480);
            
            currentScreen = new splashScreen();
            xmlGameScreenManager = new xmlManger<gameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Load/splashScreen.xml");


        }

        //loads content
        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "content");
            currentScreen.loadContent();
        }
        //unloads content
        public virtual void UnloadContent()
        {
            currentScreen.unloadContent();
        }
        //updates the screen
        public virtual void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }
        //draws everything to the screen
        public virtual void Draw(SpriteBatch spritebatch)
        {
            currentScreen.Draw(spritebatch);
        }
    }
}
