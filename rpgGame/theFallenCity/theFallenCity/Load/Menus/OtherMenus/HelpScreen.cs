using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace theFallenCity
{
    public class HelpScreen : gameScreen 
    {
        //background image
        private Texture2D background;
        public Image image;
        //backgrounf image
        public string Text, FontNames, Path;
        SpriteFont font;
        ContentManager ContentP = Game1.MyContent;
     


        public HelpScreen()
        {
            FontNames = "textFonts/FontBoi";
            //graphics = new GraphicsDeviceManager();
            ContentP.RootDirectory = "Content";
        }

        public override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            background = ContentP.Load<Texture2D>("splashScreen/BlankBack");
            base.LoadContent();
           image.LoadContent();

            font = content.Load<SpriteFont>(FontNames);


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
            base.Draw(spritebatch);
            image.Draw(spritebatch);


            spritebatch.DrawString(font, "Your movement is W, A, S, D. Collect the mushroom to win. ", new Vector2(30, 100), Color.Red);
            spritebatch.DrawString(font, "Press Enter to go back to he menu. ", new Vector2(30, 300), Color.AliceBlue);

        }



    }
}
