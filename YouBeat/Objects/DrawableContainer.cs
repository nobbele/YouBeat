using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouBeat.Objects
{
    public class DrawableContainer<T> : IDrawable where T : IDrawable
    {
        public List<T> Children = new List<T>();

        public virtual Rectangle GetRectangleFor(Rectangle view, IDrawable child, int index)
        {
            return view;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            int i = 0;
            foreach(IDrawable child in Children)
            {
                DrawChild(rect, spriteBatch, gameTime, child, i);
                i++;
            }
        }

        public virtual void DrawChild(Rectangle view, SpriteBatch spriteBatch, GameTime gameTime, IDrawable child, int index)
        {
            child.Draw(GetRectangleFor(view, child, index), spriteBatch, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            foreach(object o in Children)
            {
                (o as IUpdateable)?.Update(gameTime);
            }
        }
    }
}
