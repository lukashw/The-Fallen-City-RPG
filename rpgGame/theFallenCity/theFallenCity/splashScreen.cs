using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFallenCity
{
    public class splashScreen : gameScreen
    {
        Texture2D image;
        public string path;
        
        //splashScreen.png
        //splashScreen/splashScreen

        public override void loadContent()
        {
            base.loadContent();
            //content = new ContentManager(screenManager.Instance.Content.ServiceProvider, "Content");
            //logoPath = "splashScreen/splashScreen";
            image = content.Load<Texture2D>(path);
        }

        public override void unloadContent()
        {
            base.unloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, Vector2.Zero, Color.White);


        }
    }
}
