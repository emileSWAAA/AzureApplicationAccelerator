using System.Text.Json;
using System.Text.Json.Serialization;
using AzureApplicationAccelerator.Elements.Entities.Common;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class TextBoxValidationJsonConverter : JsonConverter<TextBoxConstraintValidation>
    {
        public override TextBoxConstraintValidation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Create a copy of the reader to peek at the properties
            var readerCopy = reader;
            using var jsonDoc = JsonDocument.ParseValue(ref readerCopy);
            var jsonObject = jsonDoc.RootElement;

            // Determine the type based on which property is present
            if (jsonObject.TryGetProperty("regex", out _))
            {
                return JsonSerializer.Deserialize<TextBoxConstraintRegexValidation>(ref reader, options);
            }
            else if (jsonObject.TryGetProperty("isValid", out _))
            {
                return JsonSerializer.Deserialize<TextBoxConstraintIsValidValidation>(ref reader, options);
            }

            // Default to regex validation if no specific property found
            return JsonSerializer.Deserialize<TextBoxConstraintRegexValidation>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, TextBoxConstraintValidation value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}