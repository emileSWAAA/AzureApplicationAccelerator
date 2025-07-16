using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Interfaces
{
    public interface IRequiredConstraint
    {
        [JsonPropertyName("required")]
        bool? Required { get; set; }
    }
}
