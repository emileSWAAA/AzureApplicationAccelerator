using AzureApplicationAccelerator.Elements.Converters;
using AzureApplicationAccelerator.Elements.Interfaces;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements
{
    [JsonConverter(typeof(UIElementJsonConverter))]
    public class UIElement : IUIElement
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("label")]
        public virtual string? Label { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("toolTip")]
        public string? ToolTip { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UIElement element &&
                string.Equals(Name, element.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Type, element.Type, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Label, element.Label, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Type, Label);
        }
    }

    public class AllowedValue
    {
        [JsonPropertyName("label")]
        public required string Label { get; set; }

        [JsonPropertyName("value")]
        public required string Value { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
