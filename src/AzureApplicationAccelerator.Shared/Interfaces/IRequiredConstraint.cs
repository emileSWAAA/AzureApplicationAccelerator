using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Shared.Interfaces
{
    public interface IRequiredConstraint
    {
        [JsonPropertyName("required")]
        bool? Required { get; set; }
    }
}
