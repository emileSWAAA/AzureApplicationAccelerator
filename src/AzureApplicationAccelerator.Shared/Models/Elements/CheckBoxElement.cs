using AzureApplicationAccelerator.Shared.Interfaces;

namespace AzureApplicationAccelerator.Shared.Models.Elements
{
    public class CheckBoxElement : UIElement
    {
        public CheckBoxConstraints Constraints { get; set; } = new CheckBoxConstraints();
    }

    public class CheckBoxConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }
        public string? ValidationMessage { get; set; }
        public string? Regex { get; set; }
    }
}
