using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.DependencyInjection;
using YouBeat.Objects;
using YouBeat.Store;

namespace YouBeat.Screens
{
    public class SongSelect : DependencyInjectedObject, IScreen
    {
        [DependencyInjectedProperty]
        protected BeatmapStore beatmapStore { get; set; }

        public bool IsLoaded { get; set; }

        public VerticalContainer<SongSelectItem> songSelectItemContainer;

        public void Load()
        {
            if(!beatmapStore.IsLoaded)
            {
                beatmapStore.Load();
            }

            songSelectItemContainer = new VerticalContainer<SongSelectItem>();
            songSelectItemContainer.Children.AddRange(beatmapStore.Beatmaps.Select(beatmap => new SongSelectItem(beatmap)));

            IsLoaded = true;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            songSelectItemContainer.Draw(rect.PercentagePoint(0.5f, 0, 1, 0.5f), spriteBatch, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Unload()
        {
            IsLoaded = false;
        }
    }
}
