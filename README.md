# Azure Application Accelerator - CreateUIDefinition

![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)

> **CreateUIDefinition.json Builder using Azure Resource UI Elements**

## Objective

Creating Azure Marketplace Applications often involves dealing with the complex and verbose `CreateUIDefinition.json` schema. This repository is designed to make that process significantly easier and more efficient. By providing a modern, intuitive UI builder, developers and solution architects can visually construct Azure UI definitions without needing to hand-code JSON. Whether you're configuring a single resource selector or a full multi-step form, this tool empowers you to rapidly prototype and produce valid, production-ready definitions with minimal effort and high confidence.

## Live site

You can already use the application through this live website.
Please be aware, this project is under construction and thus bugs and changes are due to be made frequently.

[Demo](https://amp-accelerator-hmhch0fuejbydpdb.swedencentral-01.azurewebsites.net/)

## Table of Contents

* [Overview](#overview)
* [Features](#features)
* [Implemented UI Elements](#implemented-ui-elements)
* [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [License](#license)

## Overview

This project provides a builder for `CreateUIDefinition.json` files leveraging Azure Resource UI Elements. It streamlines the creation of UI definitions for Azure resources by generating JSON definitions that can be directly consumed by Azure tooling.

## Features

| Feature                                          |     Status    |
| ------------------------------------------------ | :-----------: |
| UI Elements mapped to Azure schema               | ⏳ In Progress |
| UI property panel with configurable fields       | ⏳ In Progress |
| Layout and grouping support                      |       ✔️      |
| Validation rules configuration                   |       ✔️      |
| Azure UI Functions integration                   |       ❌       |
| Output generation (e.g., ARM template inclusion) |       ❌       |

> *Note: Azure UI Functions and output generation are planned for upcoming releases.*

## Implemented UI Elements

| Element Name                                   | Implemented [10/26] | Documentation                                                                                                                              |
| ---------------------------------------------- | :---------: | ------------------------------------------------------------------------------------------------------------------------------------------ |
| Microsoft.Common.CheckBox                      |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-checkbox)                      |
| Microsoft.Common.DropDown                      |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-dropdown)                      |
| Microsoft.Common.EditableGrid                  |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-editablegrid)                  |
| Microsoft.Common.FileUpload                    |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-fileupload)                    |
| Microsoft.Common.InfoBox                       |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-infobox)                       |
| Microsoft.Common.OptionsGroup                  |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-optionsgroup)                  |
| Microsoft.Common.PasswordBox                   |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-passwordbox)                   |
| Microsoft.Common.Section                       |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-section)                       |
| Microsoft.Common.ServicePrincipalSelector      |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-serviceprincipalselector)      |
| Microsoft.Common.Slider                        |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-slider)                        |
| Microsoft.Common.TagsByResource                |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-tagsbyresource)                |
| Microsoft.Common.TextBlock                     |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textblock)                     |
| Microsoft.Common.TextBox                       |      ✔️     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-common-textbox)                       |
| Microsoft.Compute.CredentialsCombo             |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-credentialscombo)             |
| Microsoft.Compute.SizeSelector                 |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-sizeselector)                 |
| Microsoft.Compute.UserNameTextBox              |      ❌     | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-compute-usernametextbox)              |
| Microsoft.KeyVault.KeyVaultCertificateSelector |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-keyvault-keyvaultcertificateselector) |
| Microsoft.ManagedIdentity.IdentitySelector     |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-managedidentity-identityselector)     |
| Microsoft.Network.PublicIpAddressCombo         |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-publicipaddresscombo)         |
| Microsoft.Network.VirtualNetworkCombo          |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-network-virtualnetworkcombo)          |
| Microsoft.Solutions.ArmApiControl              |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-armapicontrol)              |
| Microsoft.Solutions.ResourceSelector           |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-solutions-resourceselector)           |
| Microsoft.Storage.MultiStorageAccountCombo     |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-multistorageaccountcombo)     |
| Microsoft.Storage.StorageAccountSelector       |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageaccountselector)       |
| Microsoft.Storage.StorageBlobSelector          |      ❌      | [Docs](https://learn.microsoft.com/en-us/azure/azure-resource-manager/managed-applications/microsoft-storage-storageblobselector)          |

> *Note: Some elements are not implemented yet and will be included in future versions.*

## Installation

This is a Blazor WebAssembly application using .NET 9.0 and [Fluent UI for Blazor](https://github.com/microsoft/fluentui-blazor). No Node.js or npm is required.

1. Clone the repository:

   ```bash
   git clone https://github.com/emileSWAAA/AzureApplicationAccelerator.git
   ```
2. Navigate into the project directory:

   ```bash
   cd src
   ```
3. Run the application:

   ```bash
   dotnet run --project AzureApplicationAccelerator
   ```

## Usage

Open the application in your browser. Use the intuitive interface to add UI elements and configure their properties. The app will generate a valid `CreateUIDefinition.json` which you can download or copy into your Azure Marketplace offer.

## Roadmap

Here's what we have planned for upcoming releases to enhance functionality, usability, and AI support:

* [ ] **Complete UI Element Coverage**: Implement support for all available Azure UI elements to cover the full schema.
* [ ] **Output Variables Support**: Enable generation of custom output variables that integrate with ARM templates.
* [ ] **Azure UI Functions**: Allow users to define and attach UI functions for advanced logic and validation.
* [ ] **Import Feature**: Add the ability to import existing `CreateUIDefinition.json` files for editing and extension.
* [ ] **Agentic AI Features**: Integrate AI assistants to guide users, suggest optimizations, and even generate initial configurations based on high-level goals.

> Have a feature request? Feel free to [open an issue](https://github.com/emileSWAAA/AzureApplicationAccelerator/issues) or contribute directly!

## Contributing

Contributions are welcome! Please open issues or pull requests for bug fixes and new features.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
