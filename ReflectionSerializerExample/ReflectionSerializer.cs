using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace ReflectionSerializerExample
{
    internal class ReflectionSerializer
    {
        public static object Serialize(object obj)
        {
            // Handle null case
            if (obj == null)
                return "null";

            var result = new Dictionary<string, object>();

            // Get the type of the object
            var type = obj.GetType();

            // Get all properties of the object
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Get the value of the property
                var value = property.GetValue(obj);

                // Recursively serialize the value if it's a complex object, otherwise just add it to the dictionary
                if (value != null && !property.PropertyType.IsPrimitive && property.PropertyType != typeof(string))
                {
                    result[property.Name] = Serialize(value); // Call serialize recursively
                }
                else
                {
                    result[property.Name] = value;
                }
            }
          
            return result;
        }

        public static string ConvertToJson(object obj)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            return System.Text.Json.JsonSerializer.Serialize(obj, options);
        }
    }
}
