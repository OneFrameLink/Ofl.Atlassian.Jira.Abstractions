using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Ofl.Reflection;

namespace Ofl.Atlassian.Jira.V2
{
    public class ExpandsPropertyPathConverter : JsonConverter
    {
        #region Overrides of JsonConverter

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Validate parameters.
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            if (serializer == null) throw new ArgumentNullException(nameof(writer));

            // Get the IEnumerable, get the value.
            var propertyPath = (value as IEnumerable<PropertyPath>)?.ToList();

            // Is the value null or has no elements in it? Write null.
            if (!propertyPath?.Any() ?? false)
            {
                // Write null.
                writer.WriteNull();

                // Get out.
                return;
            }

            // Convert the value.
            var path = propertyPath.Select(
                pp => pp.Path.Select(pi => pi.GetCustomAttribute<JsonPropertyAttribute>().PropertyName ?? pi.Name.ToCamelCaseInvariant()).Join(".")
            ).Join(",");

            // Write.
            writer.WriteValue(path);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Currently not needed.
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            // If null, return false.
            // If it's an IEnumerable<PropertyPath> then it can be converted.
            return objectType != null && typeof(IEnumerable<PropertyPath>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        #endregion
    }
}
