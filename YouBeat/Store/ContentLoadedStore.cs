using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Store
{
    public abstract class ContentLoadedStore<T>
    {
        protected Dictionary<string, T> m_storage = new Dictionary<string, T>();
        protected ContentManager m_content;

        public ContentLoadedStore(ContentManager content)
        {
            m_content = content;
        }

        public T this[string name] {
            get => m_storage[name];
        }

        public virtual void Add(string assetName, string accessName = null)
        {
            m_storage.Add(accessName ?? assetName, m_content.Load<T>(assetName));
        }
        public virtual void Add(string assetName, T asset)
        {
            m_storage.Add(assetName, asset);
        }
    }
}
