using AzureApplicationAccelerator.Elements.Interfaces;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class EditableGridElement : UIElement
    {
        [JsonPropertyOrder(6)]
        [JsonPropertyName("ariaLabel")]
        public string? AriaLabel { get; set; }

        [JsonPropertyOrder(7)]
        [JsonPropertyName("constraints")]
        public EditableGridConstraints Constraints { get; set; } = new EditableGridConstraints();
    }

    public class EditableGridConstraints
    {
        [JsonPropertyName("width")]
        public string? Width { get; set; }

        [JsonPropertyName("rows")]
        public EditableGridRowConstraints? Rows { get; set; }

        [JsonPropertyName("columns")]
        public IList<EditableGridColumn>? Columns { get; set; } = new List<EditableGridColumn>();
    }

    public class EditableGridRowConstraints
    {
        [JsonPropertyName("count")]
        public EditableGridCountConstraints? Count { get; set; }
    }

    public class EditableGridCountConstraints
    {
        [JsonPropertyName("min")]
        public int? Min { get; set; }

        [JsonPropertyName("max")]
        public int? Max { get; set; }
    }

    public class EditableGridColumn
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("header")]
        public required string Header { get; set; }

        [JsonPropertyName("width")]
        public string? Width { get; set; }

        [JsonPropertyName("element")]
        public required UIElement Element { get; set; }
    }
}
