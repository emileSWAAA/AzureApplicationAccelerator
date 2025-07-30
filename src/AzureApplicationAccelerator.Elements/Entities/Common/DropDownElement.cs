using AzureApplicationAccelerator.Elements.Interfaces;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class DropDownElement : UIElement
    {
        [JsonPropertyName("placeholder")]
        public string? Placeholder { get; set; }
        
        [JsonPropertyName("defaultValue")]
        public List<string>? DefaultValue { get; set; }
        
        [JsonPropertyName("multiselect")]
        public bool? Multiselect { get; set; }
        
        [JsonPropertyName("selectAll")]
        public bool? SelectAll { get; set; }
        
        [JsonPropertyName("filter")]
        public bool? Filter { get; set; }
        
        [JsonPropertyName("filterPlaceholder")]
        public string? FilterPlaceholder { get; set; }
        
        [JsonPropertyName("multiLine")]
        public bool? MultiLine { get; set; }
        
        [JsonPropertyName("defaultDescription")]
        public string? DefaultDescription { get; set; }

        [JsonPropertyName("constraints")]
        public DropDownConstraints Constraints { get; set; } = new DropDownConstraints();
    }

    public class DropDownConstraints : IRequiredConstraint
    {
        [JsonPropertyName("required")]
        public bool? Required { get; set; }
        
        [JsonPropertyName("allowedValues")]
        public List<AllowedValue>? AllowedValues { get; set; } = new List<AllowedValue>();
    }
}
