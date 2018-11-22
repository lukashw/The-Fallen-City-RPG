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
        public Image image; 

        //splashScreen.png
        //splashScreen/splashScreen

        public override void LoadContent()
        {
            base.LoadContent();
            image.LoadContent();
            image.FadeEffect.FadeSpeed = 0.5f;

            //content = new ContentManager(screenManager.Instance.Content.ServiceProvider, "Content");
            //logoPath = "splashScreen/splashScreen";
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            image.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {

            base.Update(gametime);
            image.Update(gametime);
            if(Keyboard.GetState().IsKeyDown(Keys.Enter) && !ScreenManager.Instance.IsTransitioning){
                ScreenManager.Instance.ScreenChange("splashScreen");
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            image.Draw(spritebatch);
        }
    }
}
