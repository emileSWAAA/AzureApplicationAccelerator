using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class UIElementJsonConverter : JsonConverter<UIElement>
    {
        public override UIElement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            using var jsonDoc = JsonDocument.ParseValue(ref readerCopy);
            var jsonObject = jsonDoc.RootElement;

            if (!jsonObject.TryGetProperty("type", out var typeProperty))
            {
                throw new JsonException("Missing 'type' property on UIElement.");
            }

            var typeDiscriminator = typeProperty.GetString();

            if (string.IsNullOrWhiteSpace(typeDiscriminator) ||
                !AzureResourceUIConstants.TypeMapping.TryGetValue(typeDiscriminator, out var targetType))
            {
                throw new JsonException($"Unknown UIElement type: '{typeDiscriminator}'.");
            }

            return JsonSerializer.Deserialize(ref reader, targetType, options) as UIElement;
        }

        public override void Write(Utf8JsonWriter writer, UIElement value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            var actualType = value.GetType();
            var properties = actualType.GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(value);
                if (!ShouldSerializeValue(propValue, prop.PropertyType))
                {
                    continue;
                }

                var jsonPropertyName = prop.GetCustomAttributes(typeof(JsonPropertyNameAttribute), inherit: false)
                    .FirstOrDefault() as JsonPropertyNameAttribute;
                var propertyName = jsonPropertyName?.Name ?? prop.Name;

                writer.WritePropertyName(propertyName);
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }

            writer.WriteEndObject();
        }

        private static bool ShouldSerializeValue(object? value, Type propertyType)
        {
            if (value == null)
            {
                return false;
            }

            var defaultValue = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
            if (Equals(value, defaultValue))
            {
                return false;
            }

            if (value is string stringValue)
            {
                return !string.IsNullOrEmpty(stringValue);
            }

            if (propertyType.IsClass && !propertyType.IsArray && !IsSimpleType(propertyType))
            {
                var nestedProperties = propertyType.GetProperties();
                foreach (var nestedProp in nestedProperties)
                {
                    var nestedValue = nestedProp.GetValue(value);
                    if (ShouldSerializeValue(nestedValue, nestedProp.PropertyType))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (value is System.Collections.IEnumerable enumerable && value is not string)
            {
                return enumerable.Cast<object>().Any();
            }

            return true;
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(int)
                || type == typeof(DateTime)
                || type == typeof(Guid);
        }
    }
}
