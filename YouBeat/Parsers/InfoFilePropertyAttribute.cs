using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Parsers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    class InfoFilePropertyAttribute : Attribute
    {
        //Can't make it a auto-property without being exposed to the attribute constructor
#pragma warning disable IDE0032
        private readonly string serializationName;
        public string SerializationName => serializationName;
#pragma warning restore IDE0032

        /// <param name="serializationName">If left to default(null), it will be set to the member's name</param>
        public InfoFilePropertyAttribute([CallerMemberName] string serializationName = null)
        {
            this.serializationName = serializationName;
        }
    }
}
