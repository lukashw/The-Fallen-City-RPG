using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//uppercase is public lower is private

namespace theFallenCity 
{
    public class Image
    {
        [XmlIgnore]
        public Texture2D texture;
        //declaing variables and stuff
        public Vector2 Position, Scale;
        public float Alpha;
        public string Text, FontNames, Path;


        public Rectangle sourceRec;


        Vector2 origin;
        //declaing variables and stuff
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;
        public Image()
        {
            //set defaults for class
            Path = Text = String.Empty;
            FontNames = "FontBoi";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            sourceRec = Rectangle.Empty; 
        }

        //loading content
         public void LoadContent()
        {
            content = new ContentManager(screenManager.Instance.Content.ServiceProvider, "Content");
            if (Path!=string.Empty){

                texture = content.Load<Texture2D>(Path);
            }

            font = content.Load<SpriteFont>(FontNames);

            Vector2 dimentions = Vector2.Zero;
            //whichever element is taller(text or image) that will be the max hieght of the image

            if (texture!=null){
                dimentions.X += texture.Width;
                dimentions.X += font.MeasureString(Text).X;
            }
            if(texture !=null){
                dimentions.Y = Math.Max(texture.Height, font.MeasureString(Text).Y);
            }else{
                dimentions.Y = font.MeasureString(Text).Y;
            }

            if (sourceRec == Rectangle.Empty){
                sourceRec = new Rectangle(0, 0, (int)dimentions.X, (int)dimentions.Y);

            }

            renderTarget = new RenderTarget2D(screenManager.Instance.GraphicsDevice, (int)dimentions.X, (int)dimentions.Y);
            //setting render target as main target
            screenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            screenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            screenManager.Instance.SpriteBatch.Begin();

            if (texture != null)
            {
                screenManager.Instance.SpriteBatch.Draw(texture, Vector2.Zero, Color.White);
            }
            screenManager.Instance.SpriteBatch.DrawString(font, Text, Vector2.Zero, Color.White);

            screenManager.Instance.SpriteBatch.End();

            texture = renderTarget;
            screenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }
        //unloading content
        public virtual void UnloadContent()
        {

            content.Unload();

        }
        //update Game  time 
        public void Update(GameTime gameTime)
        {

        }
        //public draw spritebatch
        public void Draw(SpriteBatch spriteBatch)
        {
            //getting center point of image
            origin = new Vector2(sourceRec.Width / 2, sourceRec.Height / 2);
            spriteBatch.Draw(texture, Position + origin, sourceRec, Color.White * Alpha, 0.0f, origin,Scale, SpriteEffects.None, 0.0f);
        }


    }
}
