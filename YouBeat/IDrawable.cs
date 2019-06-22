using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouBeat
{
    public interface IDrawable
    {
        void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime);
    }
}
