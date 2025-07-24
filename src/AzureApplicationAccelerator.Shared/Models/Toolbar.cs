using AzureApplicationAccelerator.Elements;
using Microsoft.FluentUI.AspNetCore.Components;

namespace AzureApplicationAccelerator.Shared.Models
{
    public class Toolbar
    {
        public required IEnumerable<ToolbarGroup> Groups { get; set; }
    }

    public class ToolbarGroup
    {
        public required string Name { get; set; }
        public required string Label { get; set; }
        public required Icon Icon { get; set; }
        public required IList<ToolbarItem> Items { get; set; }
    }

    public class ToolbarItem
    {
        public required string Name { get; set; }
        public required string Label { get; set; }
        public required Icon Icon { get; set; }
        public required string Type { get; set; }

        public virtual UIElement ToUiElement()
        {
            ArgumentNullException.ThrowIfNull(this, nameof(ToolbarItem));
            if (!AzureResourceUIConstants.TypeMapping.TryGetValue(Type, out var elementType))
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
            uIElement.Visible = true;

            return uIElement;
        }
    }
}