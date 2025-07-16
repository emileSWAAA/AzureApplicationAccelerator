using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class DropDownElement : UIElement
    {
        public string? Placeholder { get; set; }
        public List<string>? DefaultValue { get; set; }
        public bool? Multiselect { get; set; }
        public bool? SelectAll { get; set; }
        public bool? Filter { get; set; }
        public string? FilterPlaceholder { get; set; }
        public bool? MultiLine { get; set; }
        public string? DefaultDescription { get; set; }

        public DropDownConstraints Constraints { get; set; } = new DropDownConstraints();
    }

    public class DropDownConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }
        public List<AllowedValue>? AllowedValues { get; set; } = new List<AllowedValue>();
    }
}
