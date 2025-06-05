using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Models.Elements
{
    public abstract class UIElement : IUIElement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Visible { get; set; }
        public string? Label { get; set; }
        public string? ToolTip { get; set; }
        //public IOption? Options { get; set; }
    }

    //public class UIElementConstraints
    //{
    //    public bool? Required { get; set; }
    //    public string ValidationMessage { get; set; }
    //    public string Regex { get; set; }
    //    public List<AllowedValue> AllowedValues { get; set; }
    //}

    //public class UIElementOptions
    //{
    //    public string Icon { get; set; }
    //    public string Text { get; set; }
    //    public Link Link { get; set; }
    //}

    //public class ValidationRule
    //{
    //    public string IsValid { get; set; }
    //    public string Regex { get; set; }
    //    public string Message { get; set; }
    //}

    //public class Link
    //{
    //    public string Label { get; set; }
    //    public string Uri { get; set; }
    //}

    //public class ImageReference
    //{
    //    public string Publisher { get; set; }
    //    public string Offer { get; set; }
    //    public string Sku { get; set; }
    //}

    public class AllowedValue
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
    }
}
