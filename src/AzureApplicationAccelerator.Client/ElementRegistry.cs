using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Client.Components.Elements;

namespace AzureApplicationAccelerator.Client
{
    public static class ElementRegistry
    {
        public static readonly Dictionary<string, ElementComponentMapping> ComponentMap = new()
        {
            [AzureResourceUIConstants.Elements.CheckBox.Type] = new(typeof(CheckBox), typeof(CheckBoxEditor)),
            [AzureResourceUIConstants.Elements.DropDown.Type] = new(typeof(DropDown), typeof(DropDownEditor)),
            [AzureResourceUIConstants.Elements.EditableGrid.Type] = new(typeof(EditableGrid), typeof(EditableGridEditor)),
            [AzureResourceUIConstants.Elements.FileUpload.Type] = new(typeof(FileUpload), typeof(FileUploadEditor)),
            [AzureResourceUIConstants.Elements.InfoBox.Type] = new(typeof(InfoBox), typeof(InfoBoxEditor)),
            [AzureResourceUIConstants.Elements.OptionsGroup.Type] = new(typeof(OptionsGroup), typeof(OptionsGroupEditor)),
            [AzureResourceUIConstants.Elements.PasswordBox.Type] = new(typeof(PasswordBox), typeof(PasswordBoxEditor)),
            [AzureResourceUIConstants.Elements.Section.Type] = new(typeof(Section), typeof(SectionEditor)),
            [AzureResourceUIConstants.Elements.ServicePrincipalSelector.Type] = new(typeof(ServicePrincipalSelector), typeof(ServicePrincipalSelectorEditor)),
            [AzureResourceUIConstants.Elements.Slider.Type] = new(typeof(Slider), typeof(SliderEditor)),
            [AzureResourceUIConstants.Elements.TagsByResource.Type] = new(typeof(TagsByResource), typeof(TagsByResourceEditor)),
            [AzureResourceUIConstants.Elements.TextBlock.Type] = new(typeof(TextBlock), typeof(TextBlockEditor)),
            [AzureResourceUIConstants.Elements.TextBox.Type] = new(typeof(TextBox), typeof(TextBoxEditor)),
            [AzureResourceUIConstants.Elements.CredentialsCombo.Type] = new(typeof(CredentialsCombo), typeof(CredentialsComboEditor)),
            [AzureResourceUIConstants.Elements.SizeSelector.Type] = new(typeof(SizeSelector), typeof(SizeSelectorEditor)),
            [AzureResourceUIConstants.Elements.UserNameTextBox.Type] = new(typeof(UserNameTextBox), typeof(UserNameTextBoxEditor)),
            [AzureResourceUIConstants.Elements.KeyVaultCertificateSelector.Type] = new(typeof(KeyVaultCertificateSelector), typeof(KeyVaultCertificateSelectorEditor)),
            [AzureResourceUIConstants.Elements.IdentitySelector.Type] = new(typeof(IdentitySelector), typeof(IdentitySelectorEditor)),
            [AzureResourceUIConstants.Elements.PublicIpAddressCombo.Type] = new(typeof(PublicIpAddressCombo), typeof(PublicIpAddressComboEditor)),
            [AzureResourceUIConstants.Elements.VirtualNetworkCombo.Type] = new(typeof(VirtualNetworkCombo), typeof(VirtualNetworkComboEditor)),
            [AzureResourceUIConstants.Elements.ArmApiControl.Type] = new(typeof(ArmApiControl), typeof(ArmApiControlEditor)),
            [AzureResourceUIConstants.Elements.ResourceSelector.Type] = new(typeof(ResourceSelector), typeof(ResourceSelectorEditor)),
            [AzureResourceUIConstants.Elements.MultiStorageAccountCombo.Type] = new(typeof(MultiStorageAccountCombo), typeof(MultiStorageAccountComboEditor)),
            [AzureResourceUIConstants.Elements.StorageAccountSelector.Type] = new(typeof(StorageAccountSelector), typeof(StorageAccountSelectorEditor)),
            [AzureResourceUIConstants.Elements.StorageBlobSelector.Type] = new(typeof(StorageBlobSelector), typeof(StorageBlobSelectorEditor)),
        };
    }

    public record ElementComponentMapping(Type EditorComponent, Type ConfigComponent) { }
}
