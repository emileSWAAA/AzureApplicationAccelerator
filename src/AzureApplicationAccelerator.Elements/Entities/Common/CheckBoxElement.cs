namespace AzureApplicationAccelerator.Elements.Entities.Common
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
