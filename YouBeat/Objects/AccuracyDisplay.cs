using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.Beatmaps;

namespace YouBeat.Objects
{
    public class AccuracyDisplay : IDrawable, IUpdatable
    {
        PlayResult result;

        public AccuracyDisplay(PlayResult result)
        {
            this.result = result;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
