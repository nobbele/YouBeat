using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouBeat.DependencyInjection;
using YouBeat.Store;

namespace YouBeat.Screens
{
    public class SongSelect : DependencyInjectedObject, IScreen
    {
        [DependencyInjectedProperty]
        protected BeatmapStore beatmapStore { get; set; }

        public bool IsLoaded { get; set; }

        public void Load()
        {
            if(!beatmapStore.IsLoaded)
            {
                beatmapStore.Load();
            }

            IsLoaded = true;
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {

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
