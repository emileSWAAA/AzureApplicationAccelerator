using AzureApplicationAccelerator.Dto;

namespace AzureApplicationAccelerator.Constants
{
    public static class ToolbarProvider
    {
        public static ToolbarGroup[] Groups =>
            [
                new()
                {
                    Name = ToolbarConstants.Groups.Common.Name,
                    Label = ToolbarConstants.Groups.Common.Label,
                    Icon = ToolbarConstants.Groups.Common.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.CheckBox.Type,
                            Name = ToolbarConstants.Items.CheckBox.Name,
                            Label = ToolbarConstants.Items.CheckBox.Label,
                            Icon = ToolbarConstants.Items.CheckBox.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.DropDown.Type,
                            Name = ToolbarConstants.Items.DropDown.Name,
                            Label = ToolbarConstants.Items.DropDown.Label,
                            Icon = ToolbarConstants.Items.DropDown.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.EditableGrid.Type,
                            Name = ToolbarConstants.Items.EditableGrid.Name,
                            Label = ToolbarConstants.Items.EditableGrid.Label,
                            Icon = ToolbarConstants.Items.EditableGrid.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.FileUpload.Type,
                            Name = ToolbarConstants.Items.FileUpload.Name,
                            Label = ToolbarConstants.Items.FileUpload.Label,
                            Icon = ToolbarConstants.Items.FileUpload.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.InfoBox.Type,
                            Name = ToolbarConstants.Items.InfoBox.Name,
                            Label = ToolbarConstants.Items.InfoBox.Label,
                            Icon = ToolbarConstants.Items.InfoBox.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.OptionsGroup.Type,
                            Name = ToolbarConstants.Items.OptionsGroup.Name,
                            Label = ToolbarConstants.Items.OptionsGroup.Label,
                            Icon = ToolbarConstants.Items.OptionsGroup.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.PasswordBox.Type,
                            Name = ToolbarConstants.Items.PasswordBox.Name,
                            Label = ToolbarConstants.Items.PasswordBox.Label,
                            Icon = ToolbarConstants.Items.PasswordBox.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.Section.Type,
                            Name = ToolbarConstants.Items.Section.Name,
                            Label = ToolbarConstants.Items.Section.Label,
                            Icon = ToolbarConstants.Items.Section.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.ServicePrincipalSelector.Type,
                            Name = ToolbarConstants.Items.ServicePrincipalSelector.Name,
                            Label = ToolbarConstants.Items.ServicePrincipalSelector.Label,
                            Icon = ToolbarConstants.Items.ServicePrincipalSelector.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.Slider.Type,
                            Name = ToolbarConstants.Items.Slider.Name,
                            Label = ToolbarConstants.Items.Slider.Label,
                            Icon = ToolbarConstants.Items.Slider.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.TagsByResource.Type,
                            Name = ToolbarConstants.Items.TagsByResource.Name,
                            Label = ToolbarConstants.Items.TagsByResource.Label,
                            Icon = ToolbarConstants.Items.TagsByResource.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.TextBlock.Type,
                            Name = ToolbarConstants.Items.TextBlock.Name,
                            Label = ToolbarConstants.Items.TextBlock.Label,
                            Icon = ToolbarConstants.Items.TextBlock.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.TextBox.Type,
                            Name = ToolbarConstants.Items.TextBox.Name,
                            Label = ToolbarConstants.Items.TextBox.Label,
                            Icon = ToolbarConstants.Items.TextBox.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.Compute.Name,
                    Label = ToolbarConstants.Groups.Compute.Label,
                    Icon = ToolbarConstants.Groups.Compute.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.CredentialsCombo.Type,
                            Name = ToolbarConstants.Items.CredentialsCombo.Name,
                            Label = ToolbarConstants.Items.CredentialsCombo.Label,
                            Icon = ToolbarConstants.Items.CredentialsCombo.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.SizeSelector.Type,
                            Name = ToolbarConstants.Items.SizeSelector.Name,
                            Label = ToolbarConstants.Items.SizeSelector.Label,
                            Icon = ToolbarConstants.Items.SizeSelector.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.UserNameTextBox.Type,
                            Name = ToolbarConstants.Items.UserNameTextBox.Name,
                            Label = ToolbarConstants.Items.UserNameTextBox.Label,
                            Icon = ToolbarConstants.Items.UserNameTextBox.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.KeyVault.Name,
                    Label = ToolbarConstants.Groups.KeyVault.Label,
                    Icon = ToolbarConstants.Groups.KeyVault.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.KeyVaultCertificateSelector.Type,
                            Name = ToolbarConstants.Items.KeyVaultCertificateSelector.Name,
                            Label = ToolbarConstants.Items.KeyVaultCertificateSelector.Label,
                            Icon = ToolbarConstants.Items.KeyVaultCertificateSelector.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.ManagedIdentity.Name,
                    Label = ToolbarConstants.Groups.ManagedIdentity.Label,
                    Icon = ToolbarConstants.Groups.ManagedIdentity.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.IdentitySelector.Type,
                            Name = ToolbarConstants.Items.IdentitySelector.Name,
                            Label = ToolbarConstants.Items.IdentitySelector.Label,
                            Icon = ToolbarConstants.Items.IdentitySelector.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.Network.Name,
                    Label = ToolbarConstants.Groups.Network.Label,
                    Icon = ToolbarConstants.Groups.Network.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.PublicIpAddressCombo.Type,
                            Name = ToolbarConstants.Items.PublicIpAddressCombo.Name,
                            Label = ToolbarConstants.Items.PublicIpAddressCombo.Label,
                            Icon = ToolbarConstants.Items.PublicIpAddressCombo.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.VirtualNetworkCombo.Type,
                            Name = ToolbarConstants.Items.VirtualNetworkCombo.Name,
                            Label = ToolbarConstants.Items.VirtualNetworkCombo.Label,
                            Icon = ToolbarConstants.Items.VirtualNetworkCombo.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.Solutions.Name,
                    Label = ToolbarConstants.Groups.Solutions.Label,
                    Icon = ToolbarConstants.Groups.Solutions.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.ArmApiControl.Type,
                            Name = ToolbarConstants.Items.ArmApiControl.Name,
                            Label = ToolbarConstants.Items.ArmApiControl.Label,
                            Icon = ToolbarConstants.Items.ArmApiControl.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.ResourceSelector.Type,
                            Name = ToolbarConstants.Items.ResourceSelector.Name,
                            Label = ToolbarConstants.Items.ResourceSelector.Label,
                            Icon = ToolbarConstants.Items.ResourceSelector.Icon,
                        }
                    ]
                },
                new()
                {
                    Name = ToolbarConstants.Groups.Storage.Name,
                    Label = ToolbarConstants.Groups.Storage.Label,
                    Icon = ToolbarConstants.Groups.Storage.Icon,
                    Items =
                    [
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.MultiStorageAccountCombo.Type,
                            Name = ToolbarConstants.Items.MultiStorageAccountCombo.Name,
                            Label = ToolbarConstants.Items.MultiStorageAccountCombo.Label,
                            Icon = ToolbarConstants.Items.MultiStorageAccountCombo.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.StorageAccountSelector.Type,
                            Name = ToolbarConstants.Items.StorageAccountSelector.Name,
                            Label = ToolbarConstants.Items.StorageAccountSelector.Label,
                            Icon = ToolbarConstants.Items.StorageAccountSelector.Icon,
                        },
                        new ToolbarItem
                        {
                            Type = ToolbarConstants.Items.StorageBlobSelector.Type,
                            Name = ToolbarConstants.Items.StorageBlobSelector.Name,
                            Label = ToolbarConstants.Items.StorageBlobSelector.Label,
                            Icon = ToolbarConstants.Items.StorageBlobSelector.Icon,
                        }
                    ]
                }
        ];
    }
}