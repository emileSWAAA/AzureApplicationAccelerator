using AzureApplicationAccelerator.Elements.Interfaces;
using AzureApplicationAccelerator.Elements.Converters;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class TextBoxElement : UIElement
    {
        [JsonPropertyName("defaultValue")]
        public string? DefaultValue { get; set; }

        [JsonPropertyName("placeholder")]
        public string? Placeholder { get; set; }

        [JsonPropertyName("multiLine")]
        public bool? MultiLine { get; set; }

        [JsonPropertyName("constraints")]
        public TextBoxConstraints Constraints { get; set; } = new TextBoxConstraints();
    }

    public class TextBoxConstraints : IRequiredConstraint
    {
        [JsonPropertyName("required")]
        public bool? Required { get; set; }

        [JsonPropertyName("validations")]
        public IList<TextBoxConstraintValidation>? Validations { get; set; } = new List<TextBoxConstraintValidation>();
    }

    [JsonConverter(typeof(TextBoxValidationJsonConverter))]
    public abstract class TextBoxConstraintValidation
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    public class TextBoxConstraintRegexValidation : TextBoxConstraintValidation
    {
        [JsonPropertyName("regex")]
        public string? Regex { get; set; }

    }

    public class TextBoxConstraintIsValidValidation : TextBoxConstraintValidation
    {
        [JsonPropertyName("isValid")]
        public string? IsValid { get; set; }
    }
}
