using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using theFallenCity.MainGame;
using Microsoft.Xna.Framework.Input;

namespace theFallenCity.MapAge
{
   

    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;

            public TileMap()
            {
                Row = new List<string>();
            }


        }

     

        //text
        public string Text, FontNames, Path;
        SpriteFont font;
        ContentManager ContentP = Game1.MyContent;



        [XmlElement("TileMap")]
        public TileMap Tile;
        public string SolidTiles;
        public Image Image;
        List<Tile> tiles;
        string state;
        public bool GameWin = false;



        public Layer()
        {
            Image = new Image();
            tiles = new List<Tile>();
            SolidTiles = string.Empty;
            ContentP.RootDirectory = "Content";
            FontNames = "textFonts/FontBoi";

        }

        //internal void LoadContent()
        //{
        //    throw new NotImplementedException(); what is this
        //}

        public void LoadContent(Vector2 tileDimentions)
        {
            font = ContentP.Load<SpriteFont>(FontNames);

            Image.LoadContent();
            Vector2 position = -tileDimentions; //new Vector2(32, 32);

            foreach(string row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimentions.X;
                position.Y += tileDimentions.Y;

                foreach(string s in split)
                {
                    if(s != String.Empty)
                    {
                        position.X += tileDimentions.X;

                        if (!s.Contains("x"))
                        {
                            state = "Passive";
                            tiles.Add(new Tile());

                            string str = s.Replace("[", String.Empty);
                            //first tile number value
                            int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                            //second tile number value
                            int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                            //colosion for game
                            if (SolidTiles.Contains("[" + value1.ToString() + ":" + value2.ToString() + "]"))
                                state = "Solid";
                            //Collecting shroom

                            tiles[tiles.Count - 1].LoadContent(position, new Rectangle(
                                value1 * (int)tileDimentions.X, value2 * (int)tileDimentions.Y,
                                (int)tileDimentions.X, (int)tileDimentions.Y), state);
                        }

                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Tile tile in tiles)
                tile.Update(gameTime, ref player);

            Rectangle playerLoc = new Rectangle((int)player.Image.Position.X, (int)player.Image.Position.Y,
                                                    player.Image.sourceRec.Width, player.Image.sourceRec.Height);
            //Player location
            Rectangle TempLoc = new Rectangle(100, 50, 5, 5);


            if (playerLoc.Intersects(TempLoc))
            {
                GameWin = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.sourceRec = tile.SourceRect;
                Image.Draw(spriteBatch);
            }


            if (GameWin == true)
            {
                spriteBatch.DrawString(font, "You won press space to advance", new Vector2(5, 215), Color.Green);
                if (InputManager.Instance.KeyPressed(Keys.Space))
                {
                    ScreenManager.Instance.ScreenChange("Level2");
                }
            }


        }
    }
}
