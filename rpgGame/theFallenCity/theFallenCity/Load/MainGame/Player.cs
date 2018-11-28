using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace theFallenCity.MainGame
{
    public class Player
    {
        public Vector2 Velocity;
        public Image Image;
        public float MoveSpeed;

        public Player()
        {
            Velocity = Vector2.Zero;
        }

        public void LoadContent()
        {
            Image.LoadContent();
        }

        public  void UnloadContent()
        {
            Image.UnloadContent();
        }

        public  void Update(GameTime gametime)
        {
            //(player movement) if diagonal momvent is wanted then remove the if statements
            if (Velocity.X == 0)
            {
                if (InputManager.Instance.KeyDown(Keys.S))
                    //down
                    Velocity.Y = MoveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                else if (InputManager.Instance.KeyDown(Keys.W))
                    //up
                    Velocity.Y = -MoveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                else
                    Velocity.Y = 0;
            }

            if(Velocity.Y ==0)
            {
            if (InputManager.Instance.KeyDown(Keys.D))
                //left
                Velocity.X = MoveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
            else if (InputManager.Instance.KeyDown(Keys.A))
                //right
                Velocity.X = -MoveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
            else
                Velocity.X = 0;
            }
            Image.Position += Velocity;

        }

        public  void Draw(SpriteBatch spritebatch)
        {
            Image.Draw(spritebatch);
        }
    }
}
