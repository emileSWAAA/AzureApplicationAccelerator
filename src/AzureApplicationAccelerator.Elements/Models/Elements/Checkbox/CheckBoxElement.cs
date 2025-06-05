using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Models.Elements.Checkbox
{
    public class CheckBoxElement : UIElement
    {
        public CheckBoxConstraints Constraints { get; set; } = new CheckBoxConstraints();
    }

    public class CheckBoxConstraints : IConstraint
    {
        public bool? Required { get; set; }
        public string? ValidationMessage { get; set; }
        public string? Regex { get; set; }
    }
}
