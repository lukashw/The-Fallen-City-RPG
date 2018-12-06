using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using theFallenCity.MainGame;

namespace theFallenCity.MapAge
{
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimentions;

        public Map()
        {   
            Layer = new List<Layer>();
            TileDimentions =  Vector2.Zero;
        }

        public void LoadContent()
        {
            foreach (Layer l in Layer)
                l.LoadContent(TileDimentions);
            //something strange happend with the load content saying it wasnt there but i think its fine
        }

        public void UnloadContent()
        {
            foreach (Layer l in Layer)
                l.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Layer l in Layer)
                l.Update(gameTime, ref player);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Layer l in Layer)
                l.Draw(spriteBatch);
        }
    }
}
