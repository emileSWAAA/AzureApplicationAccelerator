using AzureApplicationAccelerator.Client.Components.Elements.CheckBox;
using AzureApplicationAccelerator.Client.Components.Elements.DropDown;
using AzureApplicationAccelerator.Client.Components.Elements.FileUpload;
using AzureApplicationAccelerator.Elements;

namespace AzureApplicationAccelerator.Client
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
