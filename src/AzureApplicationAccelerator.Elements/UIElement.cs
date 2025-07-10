using AzureApplicationAccelerator.Elements.Converters;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements
{
    [JsonConverter(typeof(UIElementJsonConverter))]
    public class UIElement : IUIElement
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("description")]
        public bool? Visible { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("toolTip")]
        public string? ToolTip { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UIElement element &&
                   Name == element.Name &&
                   Type == element.Type &&
                   Label == element.Label;
        }
    }

    public class AllowedValue
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
