using AzureApplicationAccelerator.Elements.Interfaces;

namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class SectionElement : UIElement, INoToolTip
    {
        public IList<UIElement> Elements { get; set; } = new List<UIElement>();
    }
}
