using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class BasicsStepConverter : JsonConverter<Step>
    {
        public override Step Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var elements = JsonSerializer.Deserialize<List<UIElement>>(ref reader, options);
            return new Step
            {
                Name = AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName,
                Elements = elements ?? []
            };
        }

        public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Elements, options);
        }
    }

}
