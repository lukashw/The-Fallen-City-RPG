using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using theFallenCity.MainGame;

namespace theFallenCity.MapAge
{
    public class Tile
    {

        Vector2 position;
        Rectangle sourceRect;
        string state;
        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }


        public Vector2 Position
        {
            get { return position; }
        }

        public Tile()
        {
        }



        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;

        }
        public void UnloadContent()
        {

        }


        public void Update(GameTime gameTime, ref Player player)
        {
            if (state == "Solid")
            {
                Rectangle tileRect = new Rectangle((int)Position.X,(int)Position.Y, SourceRect.Width, SourceRect.Height);
                Rectangle playerRect = new Rectangle((int)player.Image.Position.X, (int)player.Image.Position.Y, player.Image.sourceRec.Width, player.Image.sourceRec.Height);

                if (playerRect.Intersects(tileRect))
                {
                    if (player.Velocity.X < 0)
                        player.Image.Position.X = tileRect.Right;
                    else if (player.Velocity.X > 0)
                        player.Image.Position.X = tileRect.Left - player.Image.sourceRec.Width;
                    else if (player.Velocity.Y < 0)
                        player.Image.Position.Y = tileRect.Bottom;
                    else
                        player.Image.Position.Y = tileRect.Top - player.Image.sourceRec.Height;

                    player.Velocity = Vector2.Zero;
                }
            }
        }

       
    }
}
