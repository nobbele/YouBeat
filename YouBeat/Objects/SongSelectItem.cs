using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.Beatmaps;
using YouBeat.DependencyInjection;
using YouBeat.Store;

namespace YouBeat.Objects
{
    public class SongSelectItem : DependencyInjectedObject, IDrawable, ISize
    {
        [DependencyInjectedProperty]
        public TextureStore textureStore { get; set; }

        public BeatmapStoreInfo beatmapStoreInfo;

        public SongSelectItem(BeatmapStoreInfo beatmapStoreInfo)
        {
            this.beatmapStoreInfo = beatmapStoreInfo;
        }

        public Vector2 GetSize(Rectangle view) => view.PercentagePoint(1, 1, 1, 0.25f).Size.ToVector2();

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(textureStore["BeatSquareTexture"], rect, Color.White);
        }
    }
}
