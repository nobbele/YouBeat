using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public class LazyLoadable<T> where T : class, ILoadable
    {
        public LazyLoadable(T value)
        {
            m_value = value;
        }

        private T m_value = null;
        /// <summary>
        /// Guaranteed to be loaded
        /// </summary>
        public T Value {
            get {
                if (!m_value.IsLoaded())
                    m_value.Load();
                return m_value;
            }
            set => m_value = value;
        }
    }
}
