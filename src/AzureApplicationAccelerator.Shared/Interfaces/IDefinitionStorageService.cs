using AzureApplicationAccelerator.Elements;

namespace AzureApplicationAccelerator.Shared.Interfaces
{
    public interface IDefinitionStorageService
    {
        CreateUIDefinition Definition { get; }
        event Action? OnChange;
        Task InitializeAsync();
        Task ClearAsync();
        Task PersistAsync();
    }
}