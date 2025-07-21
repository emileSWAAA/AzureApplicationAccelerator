using AzureApplicationAccelerator.Elements.Interfaces;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class TextBoxElement : UIElement
    {
        [JsonPropertyName("defaultValue")]
        public string? DefaultValue { get; set; }

        public string? Placeholder { get; set; }

        [JsonPropertyName("multiLine")]
        public bool? MultiLine { get; set; }

        public TextBoxConstraints Constraints { get; set; } = new TextBoxConstraints();
    }

    public class TextBoxConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }

        public IList<TextBoxConstraintValidation>? Validations { get; set; } = new List<TextBoxConstraintValidation>();
    }

    public abstract class TextBoxConstraintValidation
    {
        public string? Message { get; set; }
    }

    public class TextBoxConstraintRegexValidation : TextBoxConstraintValidation
    {
        public string? Regex { get; set; }

    }

    public class TextBoxConstraintIsValidValidation : TextBoxConstraintValidation
    {
        [JsonPropertyName("isValid")]
        public string? IsValid { get; set; }
    }
}
