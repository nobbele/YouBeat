using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouBeat.Objects
{
    public class DrawableContainer<T> : IDrawable where T : IDrawable
    {
        public List<T> Children = new List<T>();

        /// <returns>false if drawing should stop after this object, true if drawing should continue</returns>
        public virtual bool GetRectangleFor(ref Rectangle view, IDrawable child, int index)
        {
            return true;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            int i = 0;
            foreach(IDrawable child in Children)
            {
                if (!DrawChild(rect, spriteBatch, gameTime, child, i))
                    break;
                i++;
            }
        }

        /// <returns>false if drawing should stop after this object, true if drawing should continue</returns>
        public virtual bool DrawChild(Rectangle view, SpriteBatch spriteBatch, GameTime gameTime, IDrawable child, int index)
        {
            bool ret = GetRectangleFor(ref view, child, index);
            child.Draw(view, spriteBatch, gameTime);
            return ret;
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
