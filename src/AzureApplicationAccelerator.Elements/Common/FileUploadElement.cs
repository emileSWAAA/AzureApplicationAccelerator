using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Common
{
    public class FileUploadElement : UIElement
    {
        [JsonPropertyName("constraints")]
        public FileUploadConstraints? Constraints { get; set; } = new FileUploadConstraints();

        [JsonPropertyName("options")]
        public FileUploadOptions? Options { get; set; } = new FileUploadOptions();
    }

    public class FileUploadConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }

        [JsonPropertyName("accept")]
        public IList<string>? AcceptFileTypes { get; set; } = new List<string>();
    }

    public class FileUploadOptions
    {
        [JsonPropertyName("multiple")]
        public bool? Multiple { get; set; }

        [JsonPropertyName("uploadMode")]
        public FileUploadModeOption? UploadMode { get; set; }

        [JsonPropertyName("openMode")]
        public FileUploadOpenModeOption? OpenMode { get; set; }

        [JsonPropertyName("encoding")]
        public string? Encoding { get; set; }
    }

    public enum FileUploadModeOption
    {
        [EnumMember(Value = "file")]
        File,
        [EnumMember(Value = "url")]
        Url
    }

    public enum FileUploadOpenModeOption
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "binary")]
        Binary
    }
}
