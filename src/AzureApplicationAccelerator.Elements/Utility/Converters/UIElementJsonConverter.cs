using AzureApplicationAccelerator.Elements.Models.Elements;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Utility.Converters
{
    public class UIElementJsonConverter : JsonConverter<UIElement>
    {
        public override UIElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, UIElement value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            JsonSerializer.Serialize(writer, value, type, options);
        }
    }
}
