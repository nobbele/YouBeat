using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Parsers
{
    public static class InfoFileParser
    {
        public static T Deserialize<T>(string path)
        {
            T o = default(T);
            PropertyInfo[] properties = typeof(T).GetProperties();

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                    if(split.Length != 2)
                        throw new Exception($"Failed to parse line '{line}'");

                    string key = split[0];
                    string strvalue = split[1];

                    PropertyInfo property = properties.Single(prop => prop.GetCustomAttribute<InfoFilePropertyAttribute>().SerializationName == key);
                    object value = Convert.ChangeType(strvalue, property.PropertyType);
                    property.SetValue(o, value);
                }
            }

            return o;
        }
    }
}
