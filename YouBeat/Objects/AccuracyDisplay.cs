using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.Beatmaps;
using YouBeat.DependencyInjection;
using YouBeat.Store;

namespace YouBeat.Objects
{
    public class AccuracyDisplay : DependencyInjectedObject, IDrawable, IUpdateable
    {
        PlayResult result;

        [DependencyInjectedProperty]
        protected FontStore fontStore { get; set; }

        public AccuracyDisplay(PlayResult result) : base()
        {
            this.result = result;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(fontStore["Arial"], result.Percent.ToString("0.00%"), rect.PercentagePoint(0, 0), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            return;
        }
    }
}
