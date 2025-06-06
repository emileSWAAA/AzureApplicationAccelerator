using AzureApplicationAccelerator.Components.Elements.CheckBox;
using AzureApplicationAccelerator.Components.Elements.DropDown;
using AzureApplicationAccelerator.Components.Elements.FileUpload;
using AzureApplicationAccelerator.Elements.Constants;

namespace AzureApplicationAccelerator.Constants
{
    public static class ElementRegistry
    {
        public static readonly Dictionary<string, ElementComponentMapping> ComponentMap = new()
        {
            [AzureResourceUIConstants.Elements.CheckBox.Type] = new(typeof(CheckBox), typeof(CheckBoxEditor)),
            [AzureResourceUIConstants.Elements.DropDown.Type] = new(typeof(DropDown), typeof(DropDownEditor)),
            [AzureResourceUIConstants.Elements.FileUpload.Type] = new(typeof(FileUpload), typeof(FileUploadEditor))
        };
    }

    public record ElementComponentMapping(Type EditorComponent, Type ConfigComponent) { }
}
