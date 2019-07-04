using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Store
{
    public class FontStore : ContentLoadedStore<SpriteFont>
    {
        public FontStore(ContentManager content) : base(content) { }
    }
}
