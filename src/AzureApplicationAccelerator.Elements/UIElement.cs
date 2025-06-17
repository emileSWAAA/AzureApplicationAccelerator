using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements
{
    public abstract class UIElement : IUIElement
    {
        [JsonIgnore]
        public Guid Id { get; set; }

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
