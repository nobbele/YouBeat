using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouBeat.Objects
{
    public class DrawableContainer<T> : IDrawable, IUpdateable where T : IDrawable
    {
        public List<T> Children = new List<T>();

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(IDrawable child in Children)
            {
                child.Draw(rect, spriteBatch, gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(IUpdateable updatable in Children)
            {
                updatable.Update(gameTime);
            }
        }
    }
}
