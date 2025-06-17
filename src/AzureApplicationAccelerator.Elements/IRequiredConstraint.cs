using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements
{
    public interface IRequiredConstraint
    {
        [JsonPropertyName("required")]
        bool? Required { get; set; }
    }
}
