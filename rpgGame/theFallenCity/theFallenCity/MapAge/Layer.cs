using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

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

        [XmlElement("TileMap")]
        public TileMap Tile;
        public Image Image;
        List<Tile> tiles;

        public Layer()
        {
            Image = new Image();
            tiles = new List<Tile>();

        }

        //internal void LoadContent()
        //{
        //    throw new NotImplementedException(); what is this
        //}

        public void LoadContent(Vector2 tileDimentions)
        {
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

                        tiles.Add(new Tile());

                        string str = s.Replace("[", String.Empty);
                        //first tile number value
                        int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        //second tile number value
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                        tiles[tiles.Count - 1].LoadContent(position, new Rectangle(
                            value1 * (int)tileDimentions.X, value2 * (int)tileDimentions.Y, 
                            (int)tileDimentions.X, (int)tileDimentions.Y));

                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.sourceRec = tile.SourceRect;
                Image.Draw(spriteBatch);
            }

        }
    }
}
