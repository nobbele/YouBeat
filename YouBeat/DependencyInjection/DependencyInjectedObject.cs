using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.DependencyInjection
{
    public abstract class DependencyInjectedObject
    {
        public static Dictionary<Type, object> Dependencies = new Dictionary<Type, object>();
        public static void AddDependency<T>(T value)
        {
            Dependencies.Add(typeof(T), value);
        }

        public DependencyInjectedObject()
        {
            SetInjectedProperties();
        }

        private void SetInjectedProperties()
        {
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                        .Where(prop => prop.GetCustomAttribute<DependencyInjectedPropertyAttribute>() != null)
                                        .ToArray();
            foreach (PropertyInfo prop in properties)
            {
#if DEBUG
                if (!Dependencies.TryGetValue(prop.PropertyType, out object value))
                    throw new Exception($"Missing Dependency '{prop.PropertyType.Name}'");
#endif
                prop.SetValue(this, value);
            }
        }
    }
}
