using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Extensions;
using AzureApplicationAccelerator.Shared.Interfaces;
using Microsoft.JSInterop;

namespace AzureApplicationAccelerator.Shared.Services
{
    public class DefinitionStorageService : IDefinitionStorageService
    {
        private const string StorageKey = "createUIDefinition";
        private readonly IJSRuntime _js;

        public CreateUIDefinition Definition { get; private set; } = new();
        public event Action? OnChange;

        public DefinitionStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitializeAsync()
        {
            var stored = await _js.GetItemAsync<CreateUIDefinition>(StorageKey);
            if (stored is not null)
            {
                Definition = stored;
            }
            OnChange?.Invoke();
        }

        public async Task ClearAsync()
        {
            Definition = new CreateUIDefinition();
            await PersistAsync();
        }

        public async Task PersistAsync()
        {
            await _js.SetItemAsync(StorageKey, Definition);
            OnChange?.Invoke();
        }
    }
}