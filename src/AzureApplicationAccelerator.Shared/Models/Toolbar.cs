using AzureApplicationAccelerator.Elements.Models.Elements;
using AzureApplicationAccelerator.Shared.Constants;
using Microsoft.FluentUI.AspNetCore.Components;

namespace AzureApplicationAccelerator.Shared.Models
{
    public class Toolbar
    {
        public IEnumerable<ToolbarGroup> Groups { get; set; }
    }

    public class ToolbarGroup
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public Icon Icon { get; set; }
        public IList<ToolbarItem> Items { get; set; }
    }

    public class ToolbarItem
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public Icon Icon { get; set; }
        public string Type { get; set; }

        public UIElement ToUiElement()
        {
            ArgumentNullException.ThrowIfNull(this, nameof(ToolbarItem));
            if (!ToolbarConstants.UIElementDictionary.TryGetValue(Type, out var elementType))
            {
                throw new ArgumentException($"Unknown toolbar item type: {elementType}");
            }
            if (Activator.CreateInstance(elementType) is not UIElement element)
            {
                throw new InvalidOperationException($"Cannot create instance of type: {elementType}");
            }

            return MapFromToolbarItem(ref element);
        }

        private UIElement MapFromToolbarItem(ref UIElement uIElement)
        {
            ArgumentNullException.ThrowIfNull(uIElement, nameof(uIElement));
            uIElement.Name = Name;
            uIElement.Label = Label;
            uIElement.Type = Type;
            uIElement.Id = Guid.NewGuid();
            uIElement.Visible = true;

            return uIElement;
        }
    }
}