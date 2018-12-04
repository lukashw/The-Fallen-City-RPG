using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace theFallenCity
{
    public class SpriteSheetEffect :ImageEffect
    {

        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountFrames;

        public int FrameWidth
        {
            get 
            {
                if (image.texture != null)
                    return image.texture.Width  / (int)AmountFrames.X;
                return 0;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (image.texture != null)
                    return image.texture.Height / (int)AmountFrames.Y;
                return 0;
            }
        }

        public SpriteSheetEffect()
        {
            //size of sprite sheet
            AmountFrames = new Vector2(3, 4);
            //starting location of sprite sheet
            CurrentFrame = new Vector2(0, 0);
            SwitchFrame = 80;

            FrameCounter = 0;
        }

        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (image.IsActive)
            {
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;

                    if (CurrentFrame.X * FrameWidth >= image.texture.Width)
                        CurrentFrame.X = 0;
                }
            }
            else
                CurrentFrame.X = 0;

            image.sourceRec = new Rectangle((int)CurrentFrame.X * FrameWidth, (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);


        }

    }

}
