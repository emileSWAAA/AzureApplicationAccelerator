using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class PasswordBoxElement : UIElement, IComplexLabel
    {
        public PasswordBoxConstraints Constraints { get; set; } = new PasswordBoxConstraints();
        public PasswordBoxOptions Options { get; set; } = new PasswordBoxOptions();
        public PasswordBoxLabel Label { get; set; } = new PasswordBoxLabel();
    }

    public class PasswordBoxConstraints : IRequiredConstraint
    {
        public bool? Required { get; set; }
        public string? Regex { get; set; }
        public string? ValidationMessage { get; set; }
    }

    public class PasswordBoxOptions
    {
        public bool HideConfirmation { get; set; } = false;
    }

    public class PasswordBoxLabel
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
