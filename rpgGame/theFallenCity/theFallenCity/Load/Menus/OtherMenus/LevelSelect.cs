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
    public class LevelSelect : gameScreen
    {
        public Image image;
        public string Text, FontNames, Path;
        SpriteFont font;

        //splashScreen.png
        //splashScreen/splashScreen
        public LevelSelect()
        {
            FontNames = "textFonts/FontBoi";

        }


        public override void LoadContent()
        {
            base.LoadContent();
            image.LoadContent();
            //image.FadeEffect.FadeSpeed = 0.5f;
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
            if(InputManager.Instance.KeyPressed(Keys.NumPad1, Keys.F1)){
                ScreenManager.Instance.ScreenChange("GamePlay");
            }
            if (InputManager.Instance.KeyPressed(Keys.NumPad2, Keys.F2))
            {
                ScreenManager.Instance.ScreenChange("Level2");
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            image.Draw(spritebatch);
            spritebatch.DrawString(font, "Press number one to go to the first level ", new Vector2(10, 30), Color.Red);
            spritebatch.DrawString(font, "Press number Two to go to the Second level ", new Vector2(30, 50), Color.Green);

        }
    }
}
