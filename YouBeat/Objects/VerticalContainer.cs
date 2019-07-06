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

        public VerticalContainer(int spacing) : base()
        {
            Spacing = spacing;
        }

        public override bool DrawChild(Rectangle view, SpriteBatch spriteBatch, GameTime gameTime, IDrawable child, int index)
        {
            return base.DrawChild(view, spriteBatch, gameTime, child, index);
        }

        public override bool GetRectangleFor(ref Rectangle view, IDrawable child, int index)
        {
            Rectangle originalView = view;

            Vector2 size = (child as ISize).GetSize(view);
            view.Height = (int)size.Y;
            view.Width = (int)size.X;

            float yPosition = (Spacing + size.Y) * index;
            view.Y += (int)yPosition;

            return (view.Y + view.Height) < (originalView.Y + originalView.Height);
        }
    }
}
