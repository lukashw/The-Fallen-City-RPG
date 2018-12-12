using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFallenCity
{
     public class ScreenManager
    {

        public static ScreenManager instance;
        [XmlIgnore]

        public Vector2 Dimensions { private set; get; }
        [XmlIgnore]

        public ContentManager Content { private set; get; }
        xmlManger<gameScreen> xmlGameScreenManager;


        gameScreen currentScreen, newScreen;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        public Image Image;

        [XmlIgnore]
        public bool IsTransitioning { get; private set; }
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null){
                    xmlManger<ScreenManager> xml = new xmlManger<ScreenManager>();
                    instance = xml.Load("Load/ScreenManager.xml");

                }

                return instance;

            }

        }

        //screen transition
        public void ScreenChange(string screenName)
        {
            newScreen = (gameScreen)Activator.CreateInstance(Type.GetType("theFallenCity." + screenName));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGameScreenManager.Type = currentScreen.Type;
                    if (File.Exists(currentScreen.XmlPath))
                        currentScreen = xmlGameScreenManager.Load(currentScreen.XmlPath);
                    currentScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }

        //screen transition

        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            currentScreen = new splashScreen();
            xmlGameScreenManager = new xmlManger<gameScreen>
            {
                Type = currentScreen.Type
            };
            currentScreen = xmlGameScreenManager.Load("Load/splashScreen.xml");


        }

        //loads content
        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }
        //unloads content
        public virtual void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }
        //updates the screen
        public virtual void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
            Transition(gametime);
        }
        //draws everything to the screen
        public virtual void Draw(SpriteBatch spritebatch)
        {
            currentScreen.Draw(spritebatch);
            if(IsTransitioning){
                Image.Draw(spritebatch);
            }
        }
    }
}
