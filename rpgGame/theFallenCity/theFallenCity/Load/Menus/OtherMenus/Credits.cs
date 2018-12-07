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
    public class Credits : gameScreen
    {
        public Image image;
        public string Text, FontNames, Path;
        SpriteFont font;

        //splashScreen.png
        //splashScreen/splashScreen
        public Credits()
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
            if(InputManager.Instance.KeyPressed(Keys.Space)){
                ScreenManager.Instance.ScreenChange("TitleScreen");
            }
           
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            image.Draw(spritebatch);
            spritebatch.DrawString(font, "This game was created by Lukas Hensel-Williams", new Vector2(10, 30), Color.Red);
            spritebatch.DrawString(font, "Made for game programing 2018 ", new Vector2(30, 50), Color.Green);
            spritebatch.DrawString(font, "Press the spacebar to go back to the main menu ", new Vector2(30, 80), Color.Green);


        }
    }
}
