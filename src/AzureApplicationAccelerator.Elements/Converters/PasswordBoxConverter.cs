using AzureApplicationAccelerator.Elements.Entities.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Converters
{
    public class PasswordBoxConverter : JsonConverter<PasswordBoxElement>
    {
        public override PasswordBoxElement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, PasswordBoxElement value, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (value.Options.HideConfirmation)
            {
                value.Label.ConfirmPassword = null;
            }

            var cleanOptions = new JsonSerializerOptions(options);
            JsonConverter? thisConverter = cleanOptions.Converters.FirstOrDefault(c => c is PasswordBoxConverter);
            if (thisConverter != null)
            {
                cleanOptions.Converters.Remove(thisConverter);
            }

            JsonSerializer.Serialize(writer, value, cleanOptions);
        }
    }
}
