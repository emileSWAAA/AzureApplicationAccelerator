namespace AzureApplicationAccelerator.Shared.Constants
{
    public class AzureResourceUIConstants
    {
        public static class CreateUiDefinition
        {
            public const string Schema = "https://schema.management.azure.com/schemas/0.1.2-preview/CreateUIDefinition.MultiVm.json#";
            public const string Handler = "Microsoft.Azure.CreateUIDef";
            public const string Version = "0.1.2-preview";

            public static class Steps
            {
                public static Guid BasicsId = Guid.Parse("ED688F25-252B-475E-9814-25E31AE2D857");
                public static string BasicsName = "Basics";

                public static Guid ReviewAndCreateId = Guid.Parse("4687DBA5-CF2F-40CB-ACF2-C8E338988ED8");
                public static string ReviewAndCreateName = "Review and Create";
            }
        }

        public static readonly Dictionary<string, string> ElementTypeInfoLinks = new Dictionary<string, string>
        {
            { Elements.CheckBox.Type, Elements.CheckBox.InfoLink },
            { Elements.DropDown.Type, Elements.DropDown.InfoLink },
            { Elements.EditableGrid.Type, Elements.EditableGrid.InfoLink },
            { Elements.FileUpload.Type, Elements.FileUpload.InfoLink },
            { Elements.InfoBox.Type, Elements.InfoBox.InfoLink },
            { Elements.OptionsGroup.Type, Elements.OptionsGroup.InfoLink },
            { Elements.PasswordBox.Type, Elements.PasswordBox.InfoLink },
            { Elements.Section.Type, Elements.Section.InfoLink },
            { Elements.ServicePrincipalSelector.Type, Elements.ServicePrincipalSelector.InfoLink },
            { Elements.Slider.Type, Elements.Slider.InfoLink },
            { Elements.TagsByResource.Type, Elements.TagsByResource.InfoLink },
            { Elements.TextBlock.Type, Elements.TextBlock.InfoLink },
            { Elements.TextBox.Type, Elements.TextBox.InfoLink },
            { Elements.CredentialsCombo.Type, Elements.CredentialsCombo.InfoLink },
            { Elements.SizeSelector.Type, Elements.SizeSelector.InfoLink },
            { Elements.UserNameTextBox.Type, Elements.UserNameTextBox.InfoLink },
            { Elements.KeyVaultCertificateSelector.Type, Elements.KeyVaultCertificateSelector.InfoLink },
            { Elements.IdentitySelector.Type, Elements.IdentitySelector.InfoLink },
            { Elements.PublicIpAddressCombo.Type, Elements.PublicIpAddressCombo.InfoLink },
            { Elements.VirtualNetworkCombo.Type, Elements.VirtualNetworkCombo.InfoLink },
            { Elements.ArmApiControl.Type, Elements.ArmApiControl.InfoLink },
            { Elements.ResourceSelector.Type, Elements.ResourceSelector.InfoLink },
            { Elements.MultiStorageAccountCombo.Type, Elements.MultiStorageAccountCombo.InfoLink },
            { Elements.StorageAccountSelector.Type, Elements.StorageAccountSelector.InfoLink },
            { Elements.StorageBlobSelector.Type, Elements.StorageBlobSelector.InfoLink }
        };

        public static class Elements
        {

            public static class CheckBox
            {
                public const string Type = "Microsoft.Common.CheckBox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-checkbox";
            }

            public static class DropDown
            {
                public const string Type = "Microsoft.Common.DropDown";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-dropdown";
            }

            public static class EditableGrid
            {
                public const string Type = "Microsoft.Common.EditableGrid";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-editablegrid";
            }

            public static class FileUpload
            {
                public const string Type = "Microsoft.Common.FileUpload";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-fileupload";
            }

            public static class InfoBox
            {
                public const string Type = "Microsoft.Common.InfoBox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-infobox";
            }

            public static class OptionsGroup
            {
                public const string Type = "Microsoft.Common.OptionsGroup";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-optionsgroup";
            }

            public static class PasswordBox
            {
                public const string Type = "Microsoft.Common.PasswordBox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-passwordbox";
            }

            public static class Section
            {
                public const string Type = "Microsoft.Common.Section";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-section";
            }

            public static class ServicePrincipalSelector
            {
                public const string Type = "Microsoft.Common.ServicePrincipalSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-serviceprincipalselector";
            }

            public static class Slider
            {
                public const string Type = "Microsoft.Common.Slider";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-slider";
            }

            public static class TagsByResource
            {
                public const string Type = "Microsoft.Common.TagsByResource";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-tagsbyresource";
            }

            public static class TextBlock
            {
                public const string Type = "Microsoft.Common.TextBlock";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textblock";
            }

            public static class TextBox
            {
                public const string Type = "Microsoft.Common.TextBox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textblock";
            }

            public static class CredentialsCombo
            {
                public const string Type = "Microsoft.Compute.CredentialsCombo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-credentialscombo";
            }

            public static class SizeSelector
            {
                public const string Type = "Microsoft.Compute.SizeSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-sizeselector";
            }

            public static class UserNameTextBox
            {
                public const string Type = "Microsoft.Compute.UserNameTextBox";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-usernametextbox";
            }

            public static class KeyVaultCertificateSelector
            {
                public const string Type = "Microsoft.KeyVault.KeyVaultCertificateSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-keyvault-keyvaultcertificateselector";
            }

            public static class IdentitySelector
            {
                public const string Type = "Microsoft.ManagedIdentity.IdentitySelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-managedidentity-identityselector";
            }

            public static class PublicIpAddressCombo
            {
                public const string Type = "Microsoft.Network.PublicIpAddressCombo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-publicipaddresscombo";
            }

            public static class VirtualNetworkCombo
            {
                public const string Type = "Microsoft.Network.VirtualNetworkCombo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-virtualnetworkcombo";
            }

            public static class ArmApiControl
            {
                public const string Type = "Microsoft.Solutions.ArmApiControl";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-armapicontrol";
            }

            public static class ResourceSelector
            {
                public const string Type = "Microsoft.Solutions.ResourceSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-resourceselector";
            }

            public static class MultiStorageAccountCombo
            {
                public const string Type = "Microsoft.Storage.MultiStorageAccountCombo";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-multistorageaccountcombo";
            }

            public static class StorageAccountSelector
            {
                public const string Type = "Microsoft.Storage.StorageAccountSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageaccountselector";
            }

            public static class StorageBlobSelector
            {
                public const string Type = "Microsoft.Storage.StorageBlobSelector";
                public const string InfoLink = "https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageblobselector";
            }
        }
    }
}