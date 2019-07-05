using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouBeat.Objects
{
    public class VerticalContainer<T> : DrawableContainer<T> where T : IDrawable, ISize
    {
        public int Spacing;

        public override void DrawChild(Rectangle view, SpriteBatch spriteBatch, GameTime gameTime, IDrawable child, int index)
        {
            base.DrawChild(view, spriteBatch, gameTime, child, index);
        }

        public override Rectangle GetRectangleFor(Rectangle view, IDrawable child, int index)
        {
            Vector2 size = (child as ISize).GetSize(view);
            view.Height = (int)size.Y;
            view.Width = (int)size.X;

            float ySpacing = (Spacing * size.Y) * index;
            view.Y += (int)ySpacing;

            return view;
        }
    }
}
