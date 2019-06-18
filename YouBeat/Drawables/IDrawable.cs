using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Drawables
{
    public interface IDrawable
    {
        void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime);
    }
}
