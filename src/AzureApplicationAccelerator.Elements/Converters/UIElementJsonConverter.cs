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
            var actualType = value.GetType();
            JsonSerializer.Serialize(writer, value, actualType, options);
        }
    }
}
