using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.Beatmaps;

namespace YouBeat.Objects
{
    public class AccuracyDisplay : IDrawable, IUpdateable
    {
        PlayResult result;

        public AccuracyDisplay(PlayResult result)
        {
            this.result = result;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(YouBeat.Instance.fontStore["Arial"], (result.Percent).ToString("0.00%"), rect.PercentagePoint(0, 0), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            return;
        }
    }
}
