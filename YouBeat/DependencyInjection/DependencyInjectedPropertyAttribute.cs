using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DependencyInjectedPropertyAttribute : Attribute
    {
        public DependencyInjectedPropertyAttribute()
        {
        }
    }
}
