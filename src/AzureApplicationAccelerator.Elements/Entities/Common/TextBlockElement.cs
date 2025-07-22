using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class TextBlockElement : UIElement, INoLabel
    {
        public override string Label => string.Empty;

        public TextBlockOptions? Options { get; set; } = new TextBlockOptions();
    }

    public class TextBlockOptions
    {
        public string? Text { get; set; }

        public TextBlockLink Link { get; set; } = new TextBlockLink();
    }

    public class TextBlockLink
    {
        public string? Label { get; set; }

        public string? Uri { get; set; }
    }
}
