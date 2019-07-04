using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public class FontStore
    {
        private Dictionary<string, SpriteFont> m_fonts = new Dictionary<string, SpriteFont>();
        private ContentManager m_content;

        public FontStore(ContentManager content)
        {
            m_content = content;
        }

        public SpriteFont this[string name] 
        {
            get => m_fonts[name];
        }

        public void Add(string assetName, string accessName = null)
        {
            m_fonts.Add(accessName ?? assetName, m_content.Load<SpriteFont>(assetName));
        }
    }
}
