using System.Drawing;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class InfoBoxElement : UIElement
    {
        [JsonPropertyName("options")]
        public InfoBoxOptions Options { get; set; } = new InfoBoxOptions();
    }

    public class InfoBoxOptions
    {
        [JsonPropertyName("icon")]
        public IconType? Icon { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }

    public enum IconType
    {
        None,
        Info,
        Warning,
        Error
    }
}
