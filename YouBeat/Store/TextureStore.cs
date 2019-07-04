using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Store
{
    public class TextureStore : ContentLoadedStore<Texture2D>
    {
        public TextureStore(ContentManager content) : base(content) { }
    }
}
