using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace theFallenCity
{
    public class Menu
    {
        //Events
        public event EventHandler OnMenuChange;

        public string Axis;
        public string Effects;
        [XmlElement("Item")]
        public List<MenuItem> Items;
        int itemNumber;
        string id;

        public string ID {
            get { return id; }
            set {id = value;OnMenuChange (this, null);
            }
        }

        void alignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach(MenuItem item in Items)
            {
                //add the total width adn height of menu items
                dimensions += new Vector2(item.Image.sourceRec.Width, item.Image.sourceRec.Height);
            }

            //figure out menu location inorder to center text
            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X - dimensions.X) / 2,
                                     (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);
            foreach (MenuItem item in Items)
            {
                if (Axis == "X")
                {
                    item.Image.Position = new Vector2(dimensions.X, 
                    (ScreenManager.Instance.Dimensions.Y - item.Image.sourceRec.Height) / 2);
                }else if (Axis == "Y")
                {
                    item.Image.Position = new Vector2((ScreenManager.Instance.Dimensions.X - item.Image.sourceRec.Width) / 2, dimensions.Y);
                }

                dimensions += new Vector2(item.Image.sourceRec.Width, item.Image.sourceRec.Height);


            }
        }


        public Menu()
        {
            id = string.Empty;
            itemNumber = 0;
            Effects = string.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }


        public void LoadContent()
        {
            string[] split = Effects.Split(':');
            foreach(MenuItem item in Items)
            {
                item.Image.LoadContent();
                foreach(string s  in split)
                {
                    item.Image.ActivateEffect(s);
                }

            }
            alignMenuItems();
        }

        public void UnloadContent()
        {
            foreach(MenuItem item in Items)
            {
                item.Image.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            if( Axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Up))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Down))
                    itemNumber--;

            }
            if (Axis == "Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Up))
                    itemNumber--;
            }

            if (itemNumber < 0)
                itemNumber = 0;
            else if (itemNumber > Items.Count - 1)
                itemNumber = Items.Count - 1;

            for (int i = 0; i < Items.Count; i++ )
            {
                if(i == itemNumber)
                    Items[i].Image.IsActive = true;
                else
                    Items[i].Image.IsActive = false;

                Items[i].Image.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in Items)
                item.Image.Draw(spriteBatch);
        }
      
    }
}
