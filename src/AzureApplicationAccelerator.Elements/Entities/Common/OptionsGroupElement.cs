using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class OptionsGroupElement : UIElement
    {
        [JsonPropertyName("defaultValue")]
        public string? DefaultValue { get; set; }

        [JsonPropertyName("constraints")]
        public OptionsGroupConstraints Constraints { get; set; } = new OptionsGroupConstraints();
    }

    public class OptionsGroupConstraints : IRequiredConstraint
    {
        [JsonPropertyName("allowedValues")]
        public IList<OptionItem> AllowedValues { get; set; } = new List<OptionItem>();

        [JsonPropertyName("required")]
        public bool? Required { get; set; }
    }

    public class OptionItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
}