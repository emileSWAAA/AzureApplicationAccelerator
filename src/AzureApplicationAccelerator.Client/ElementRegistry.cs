using AzureApplicationAccelerator.Client.Components.Elements.Common.CheckBox;
using AzureApplicationAccelerator.Client.Components.Elements.Common.DropDown;
using AzureApplicationAccelerator.Client.Components.Elements.Common.FileUpload;
using AzureApplicationAccelerator.Client.Components.Elements.Common.InfoBox;
using AzureApplicationAccelerator.Elements;

namespace AzureApplicationAccelerator.Client
{
    public static class ElementRegistry
    {
        public static readonly Dictionary<string, ElementComponentMapping> ComponentMap = new()
        {
            [AzureResourceUIConstants.Elements.CheckBox.Type] = new(typeof(CheckBox), typeof(CheckBoxEditor)),
            [AzureResourceUIConstants.Elements.DropDown.Type] = new(typeof(DropDown), typeof(DropDownEditor)),
            [AzureResourceUIConstants.Elements.FileUpload.Type] = new(typeof(FileUpload), typeof(FileUploadEditor)),
            [AzureResourceUIConstants.Elements.InfoBox.Type] = new(typeof(InfoBox), typeof(InfoBoxEditor)),
        };
    }

    public record ElementComponentMapping(Type EditorComponent, Type ConfigComponent) { }
}
