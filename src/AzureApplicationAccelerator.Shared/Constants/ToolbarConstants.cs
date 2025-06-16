using AzureApplicationAccelerator.Shared.Models.Elements;
using Microsoft.FluentUI.AspNetCore.Components;
using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons;

namespace AzureApplicationAccelerator.Shared.Constants
{
    public static class ToolbarConstants
    {
        public static Dictionary<string, Type> UIElementDictionary => new()
        {
            { Items.CheckBox.Type, typeof(CheckBoxElement) },
            { Items.DropDown.Type, typeof(DropDownElement) },
            { Items.FileUpload.Type, typeof(FileUploadElement) },
            //{ Items.EditableGrid.Type, typeof(EditableGridElement) },
            //{ Items.InfoBox.Type, typeof(InfoBoxElement) },
            //{ Items.OptionsGroup.Type, typeof(OptionsGroupElement) },
            //{ Items.PasswordBox.Type, typeof(PasswordBoxElement) },
            //{ Items.Section.Type, typeof(SectionElement) },
            //{ Items.ServicePrincipalSelector.Type, typeof(ServicePrincipalSelectorElement) },
            //{ Items.Slider.Type, typeof(SliderElement) },
            //{ Items.TagsByResource.Type, typeof(TagsByResourceElement) },
            //{ Items.TextBlock.Type, typeof(TextBlockElement) },
            //{ Items.TextBox.Type, typeof(TextBoxElement) },
            //{ Items.CredentialsCombo.Type, typeof(CredentialsComboElement) },
            //{ Items.SizeSelector.Type, typeof(SizeSelectorElement) },
            //{ Items.UserNameTextBox.Type, typeof(UserNameTextBoxElement) },
            //{ Items.KeyVaultCertificateSelector.Type, typeof(KeyVaultCertificateSelectorElement) },
            //{ Items.IdentitySelector.Type, typeof(IdentitySelectorElement) },
            //{ Items.PublicIpAddressCombo.Type, typeof(PublicIpAddressComboElement) },
            //{ Items.VirtualNetworkCombo.Type, typeof(VirtualNetworkComboElement) },
            //{ Items.ArmApiControl.Type, typeof(ArmApiControlElement) },
            //{ Items.ResourceSelector.Type, typeof(ResourceSelectorElement) },
            //{ Items.MultiStorageAccountCombo.Type, typeof(MultiStorageAccountComboElement) },
            //{ Items.StorageAccountSelector.Type, typeof(StorageAccountSelectorElement) },
            //{ Items.StorageBlobSelector.Type, typeof(StorageBlobSelectorElement) }
        };

        public static class Groups
        {
            public static class Common
            {
                public const string Name = "Common";
                public const string Label = "Common";
                public static readonly Icon Icon = new Icons.Regular.Size24.Settings();
            }

            public static class Compute
            {
                public const string Name = "Compute";
                public const string Label = "Compute";
                public static readonly Icon Icon = new Icons.Regular.Size24.Server();
            }

            public static class KeyVault
            {
                public const string Name = "KeyVault";
                public const string Label = "Key Vault";
                public static readonly Icon Icon = new Icons.Regular.Size24.Key();
            }

            public static class ManagedIdentity
            {
                public const string Name = "ManagedIdentity";
                public const string Label = "Managed Identity";
                public static readonly Icon Icon = new Icons.Regular.Size24.PersonPasskey();
            }

            public static class Network
            {
                public const string Name = "Network";
                public const string Label = "Network";
                public static readonly Icon Icon = new Icons.Regular.Size24.NetworkCheck();
            }

            public static class Solutions
            {
                public const string Name = "Solutions";
                public const string Label = "Solutions";
                public static readonly Icon Icon = new Icons.Regular.Size24.PuzzleCube();
            }

            public static class Storage
            {
                public const string Name = "Storage";
                public const string Label = "Storage";
                public static readonly Icon Icon = new Icons.Regular.Size24.Archive();
            }
        }

        public static class Items
        {

            public static class CheckBox
            {
                public const string Type = "Microsoft.Common.CheckBox";
                public const string Name = "Checkbox";
                public const string Label = "Checkbox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-checkbox";
                public static readonly Icon Icon = new Icons.Regular.Size24.CheckboxChecked();
            }

            public static class DropDown
            {
                public const string Type = "Microsoft.Common.DropDown";
                public const string Name = "Dropdown";
                public const string Label = "Dropdown";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-dropdown";
                public static readonly Icon Icon = new Icons.Regular.Size24.ChevronDown();
            }

            public static class EditableGrid
            {
                public const string Type = "Microsoft.Common.EditableGrid";
                public const string Name = "Editable Grid";
                public const string Label = "Editable Grid";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-editablegrid";
                public static readonly Icon Icon = new Icons.Regular.Size24.Table();
            }

            public static class FileUpload
            {
                public const string Type = "Microsoft.Common.FileUpload";
                public const string Name = "File Upload";
                public const string Label = "File Upload";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-fileupload";
                public static readonly Icon Icon = new Icons.Regular.Size24.FolderArrowUp();
            }

            public static class InfoBox
            {
                public const string Type = "Microsoft.Common.InfoBox";
                public const string Name = "Info Box";
                public const string Label = "Info Box";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-infobox";
                public static readonly Icon Icon = new Icons.Regular.Size24.Info();
            }

            public static class OptionsGroup
            {
                public const string Type = "Microsoft.Common.OptionsGroup";
                public const string Name = "Options Group";
                public const string Label = "Options Group";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-optionsgroup";
                public static readonly Icon Icon = new Icons.Regular.Size24.List();
            }

            public static class PasswordBox
            {
                public const string Type = "Microsoft.Common.PasswordBox";
                public const string Name = "Password Box";
                public const string Label = "Password Box";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-passwordbox";
                public static readonly Icon Icon = new Icons.Regular.Size24.Password();
            }

            public static class Section
            {
                public const string Type = "Microsoft.Common.Section";
                public const string Name = "Section";
                public const string Label = "Section";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-section";
                public static readonly Icon Icon = new Icons.Regular.Size24.GroupList();
            }

            public static class ServicePrincipalSelector
            {
                public const string Type = "Microsoft.Common.ServicePrincipalSelector";
                public const string Name = "Service Principal Selector";
                public const string Label = "Service Principal Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-serviceprincipalselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.PersonPasskey();
            }

            public static class Slider
            {
                public const string Type = "Microsoft.Common.Slider";
                public const string Name = "Slider";
                public const string Label = "Slider";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-slider";
                public static readonly Icon Icon = new Icons.Regular.Size24.ArrowAutofitContent();
            }

            public static class TagsByResource
            {
                public const string Type = "Microsoft.Common.TagsByResource";
                public const string Name = "Tags by Resource";
                public const string Label = "Tags by Resource";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-tagsbyresource";
                public static readonly Icon Icon = new Icons.Regular.Size24.TagMultiple();
            }

            public static class TextBlock
            {
                public const string Type = "Microsoft.Common.TextBlock";
                public const string Name = "Text Block";
                public const string Label = "Text Block";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textblock";
                public static readonly Icon Icon = new Icons.Regular.Size24.SlideText();
            }

            public static class TextBox
            {
                public const string Type = "Microsoft.Common.TextBox";
                public const string Name = "Text Box";
                public const string Label = "Text Box";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textblock";
                public static readonly Icon Icon = new Icons.Regular.Size24.TextField();
            }

            public static class CredentialsCombo
            {
                public const string Type = "Microsoft.Compute.CredentialsCombo";
                public const string Name = "Credentials Combo";
                public const string Label = "Credentials Combo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-credentialscombo";
                public static readonly Icon Icon = new Icons.Regular.Size24.ShieldBadge();
            }

            public static class SizeSelector
            {
                public const string Type = "Microsoft.Compute.SizeSelector";
                public const string Name = "Size Selector";
                public const string Label = "Size Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-sizeselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.SlideSize();
            }

            public static class UserNameTextBox
            {
                public const string Type = "Microsoft.Compute.UserNameTextBox";
                public const string Name = "Username Text Box";
                public const string Label = "Username Text Box";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-usernametextbox";
                public static readonly Icon Icon = new Icons.Regular.Size24.Person();
            }

            public static class KeyVaultCertificateSelector
            {
                public const string Type = "Microsoft.KeyVault.KeyVaultCertificateSelector";
                public const string Name = "Key Vault Certificate Selector";
                public const string Label = "Key Vault Certificate Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-keyvault-keyvaultcertificateselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.Certificate();
            }

            public static class IdentitySelector
            {
                public const string Type = "Microsoft.ManagedIdentity.IdentitySelector";
                public const string Name = "Identity Selector";
                public const string Label = "Identity Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-managedidentity-identityselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.LinkPerson();
            }

            public static class PublicIpAddressCombo
            {
                public const string Type = "Microsoft.Network.PublicIpAddressCombo";
                public const string Name = "Public IP Address Combo";
                public const string Label = "Public IP Address Combo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-publicipaddresscombo";
                public static readonly Icon Icon = new Icons.Regular.Size24.Globe();
            }

            public static class VirtualNetworkCombo
            {
                public const string Type = "Microsoft.Network.VirtualNetworkCombo";
                public const string Name = "Virtual Network Combo";
                public const string Label = "Virtual Network Combo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-virtualnetworkcombo";
                public static readonly Icon Icon = new Icons.Regular.Size20.VirtualNetwork();
            }

            public static class ArmApiControl
            {
                public const string Type = "Microsoft.Solutions.ArmApiControl";
                public const string Name = "ARM API Control";
                public const string Label = "ARM API Control";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-armapicontrol";
                public static readonly Icon Icon = new Icons.Regular.Size24.Globe();
            }

            public static class ResourceSelector
            {
                public const string Type = "Microsoft.Solutions.ResourceSelector";
                public const string Name = "Resource Selector";
                public const string Label = "Resource Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-resourceselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.Database();
            }

            public static class MultiStorageAccountCombo
            {
                public const string Type = "Microsoft.Storage.MultiStorageAccountCombo";
                public const string Name = "Multi Storage Account Combo";
                public const string Label = "Multi Storage Account Combo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-multistorageaccountcombo";
                public static readonly Icon Icon = new Icons.Regular.Size24.ArchiveMultiple();
            }

            public static class StorageAccountSelector
            {
                public const string Type = "Microsoft.Storage.StorageAccountSelector";
                public const string Name = "Storage Account Selector";
                public const string Label = "Storage Account Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageaccountselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.Database();
            }

            public static class StorageBlobSelector
            {
                public const string Type = "Microsoft.Storage.StorageBlobSelector";
                public const string Name = "Storage Blob Selector";
                public const string Label = "Storage Blob Selector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageblobselector";
                public static readonly Icon Icon = new Icons.Regular.Size24.DocumentGlobe();
            }
        }
    }
}
