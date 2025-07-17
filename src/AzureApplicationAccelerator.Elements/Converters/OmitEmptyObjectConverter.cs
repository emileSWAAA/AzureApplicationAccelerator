using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class OmitEmptyObjectConverter : JsonConverter<UIElement>
    {
        public override UIElement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<UIElement>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, UIElement value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            var properties = typeof(UIElement).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            bool hasNonEmptyProperty = false;

            foreach (var property in properties)
            {
                var propValue = property.GetValue(value);

                if (propValue != null)
                {
                    if (propValue is string str && !string.IsNullOrWhiteSpace(str))
                    {
                        hasNonEmptyProperty = true;
                        break;
                    }
                    else if (!(propValue is string))
                    {
                        hasNonEmptyProperty = true;
                        break;
                    }
                }
            }

            if (!hasNonEmptyProperty)
            {
                writer.WriteNullValue();
                return;
            }

            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}