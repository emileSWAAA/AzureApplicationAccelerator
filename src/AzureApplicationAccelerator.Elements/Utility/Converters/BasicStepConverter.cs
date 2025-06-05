using AzureApplicationAccelerator.Elements.Models;
using AzureApplicationAccelerator.Elements.Models.Elements;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Utility.Converters
{
    public class BasicsStepConverter : JsonConverter<Step>
    {
        public override Step Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var elements = JsonSerializer.Deserialize<List<UIElement>>(ref reader, options);
            return new Step { Elements = elements ?? new List<UIElement>() };
        }

        public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Elements, options);
        }
    }

}
