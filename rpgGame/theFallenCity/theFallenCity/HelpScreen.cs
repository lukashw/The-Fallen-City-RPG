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
    public class HelpScreen:gameScreen
    {

        public string Text, FontNames, Path;
        SpriteFont font;


        public HelpScreen()
        {
            FontNames = "textFonts/FontBoi";

        }

        public override void LoadContent()
        {
            base.LoadContent();
            font = content.Load<SpriteFont>(FontNames);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
         
        }

        public override void Update(GameTime gametime)
        {

            base.Update(gametime);
            if (InputManager.Instance.KeyPressed(Keys.Space))
            {
                ScreenManager.Instance.ScreenChange("TitleScreen");
            }

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            spritebatch.DrawString(font, "Your movement is W, A, S, D. Collect the mushroom to win. ", new Vector2(30, 100), Color.Red);
            spritebatch.DrawString(font, "Press space to go back to he menu. ", new Vector2(30, 300), Color.AliceBlue);


        }



    }
}
