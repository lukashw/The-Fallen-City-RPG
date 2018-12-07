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
        public string Text, FontNames, Path;
        SpriteFont font;

        //splashScreen.png
        //splashScreen/splashScreen
        public splashScreen()
        {
            FontNames = "textFonts/FontBoi";

        }


        public override void LoadContent()
        {
            base.LoadContent();
            image.LoadContent();
            image.FadeEffect.FadeSpeed = 0.5f;
            font = content.Load<SpriteFont>(FontNames);

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
            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ScreenChange("TitleScreen");
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            image.Draw(spritebatch);
            spritebatch.DrawString(font, "Press Enter to continue ", new Vector2(400, 435), Color.Red);

        }
    }
}
