using AzureApplicationAccelerator.Elements.Interfaces;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Models.Elements
{
    public class FileUploadElement : UIElement
    {
        [JsonPropertyName("constraints")]
        public FileUploadConstraints? Constraints { get; set; } = new FileUploadConstraints();

        [JsonPropertyName("options")]
        public FileUploadOptions? Options { get; set; }
    }

    public class FileUploadConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }

        [JsonPropertyName("accept")]
        public string[]? AcceptFileTypes { get; set; } = Array.Empty<string>();
    }

    public class FileUploadOptions
    {
        [JsonPropertyName("multiple")]
        public bool? Multiple { get; set; }

        [JsonPropertyName("uploadMode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileUploadModeOption? UploadMode { get; set; }

        [JsonPropertyName("openMode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileUploadOpenModeOption? OpenMode { get; set; }

        [JsonPropertyName("encoding")]
        public string? Encoding { get; set; }
    }

    public enum FileUploadModeOption
    {
        [JsonPropertyName("file")]
        File,
        [JsonPropertyName("url")]
        Url
    }

    public enum FileUploadOpenModeOption
    {
        [JsonPropertyName("text")]
        Text,
        [JsonPropertyName("binary")]
        Binary
    }
}
