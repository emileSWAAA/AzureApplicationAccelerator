using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class UIElementJsonConverter : JsonConverter<UIElement>
    {
        public override UIElement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Create a copy of the reader to peek at the type
            var readerCopy = reader;
            using var jsonDoc = JsonDocument.ParseValue(ref readerCopy);
            var jsonObject = jsonDoc.RootElement;

            if (!jsonObject.TryGetProperty("type", out var typeProperty))
            {
                throw new JsonException("Missing 'type' property on UIElement.");
            }

            var typeDiscriminator = typeProperty.GetString();
            if (string.IsNullOrWhiteSpace(typeDiscriminator))
            {
                throw new JsonException("Empty 'type' property on UIElement.");
            }

            if (!AzureResourceUIConstants.TypeMapping.TryGetValue(typeDiscriminator, out var targetType))
            {
                throw new JsonException($"Unknown UIElement type: '{typeDiscriminator}'.");
            }

            var newOptions = new JsonSerializerOptions(options);
            foreach (var converter in options.Converters)
            {
                if (converter.GetType() != typeof(UIElementJsonConverter))
                {
                    newOptions.Converters.Add(converter);
                }
            }

            return JsonSerializer.Deserialize(ref reader, targetType, newOptions) as UIElement;
        }

        public override void Write(Utf8JsonWriter writer, UIElement value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            var actualType = value.GetType();
            var properties = actualType.GetProperties();

            foreach (var prop in properties)
            {
                if (prop.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                try
                {
                    var propValue = prop.GetValue(value);
                    if (!ShouldSerializeValue(propValue, prop.PropertyType))
                    {
                        continue;
                    }

                    var jsonPropertyName = prop.GetCustomAttributes(typeof(JsonPropertyNameAttribute), inherit: false)
                        .FirstOrDefault() as JsonPropertyNameAttribute;
                    var propertyName = jsonPropertyName?.Name ?? prop.Name;

                    // Apply the naming policy from options if no explicit JsonPropertyName is specified
                    if (jsonPropertyName == null && options.PropertyNamingPolicy != null)
                    {
                        propertyName = options.PropertyNamingPolicy.ConvertName(propertyName);
                    }

                    writer.WritePropertyName(propertyName);
                    JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
                }
                catch (TargetParameterCountException)
                {
                    continue;
                }
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
                    if (nestedProp.GetIndexParameters().Length > 0 || !nestedProp.CanRead)
                    {
                        continue;
                    }

                    try
                    {
                        var nestedValue = nestedProp.GetValue(value);
                        if (ShouldSerializeValue(nestedValue, nestedProp.PropertyType))
                        {
                            return true;
                        }
                    }
                    catch (TargetParameterCountException)
                    {
                        continue;
                    }
                    catch (TargetInvocationException)
                    {
                        continue;
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
