using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Models;
using Microsoft.JSInterop;

namespace AzureApplicationAccelerator.Shared.Services
{
    public class UIDefinitionService
    {
        private readonly IDefinitionStorageService _storage;
        private readonly IStepService _stepService;
        private readonly IElementService _elementService;

        public CreateUIDefinition Definition => _storage.Definition;
        public Step ActiveStep => _stepService.ActiveStep;
        public event Action? OnChange;

        public UIDefinitionService(IJSRuntime js,
            IDefinitionStorageService storage,
            IStepService stepService,
            IElementService elementService)
        {
            _storage = storage;
            _stepService = stepService;
            _elementService = elementService;

            _storage.OnChange += NotifyChanged;
            _stepService.OnChange += NotifyChanged;
            _elementService.OnChange += NotifyChanged;
        }

        public async Task InitializeAsync()
        {
            await _storage.InitializeAsync();
            _stepService.SetActiveStep(_storage.Definition.Parameters.Basics);
        }

        public async Task ClearAsync()
        {
            await _storage.ClearAsync();
            _stepService.SetActiveStep(_storage.Definition.Parameters.Basics);
        }

        // Facade for backward compatibility
        public async Task<Step> GetStep(string name) => _stepService.GetStep(name);
        public async Task AddStepAsync(Step step) => await _stepService.AddStepAsync(step);
        public async Task<Step> EditStepAsync(string stepName, Step updatedStep) => await _stepService.EditStepAsync(stepName, updatedStep);
        public async Task RemoveStepAsync(string stepName) => await _stepService.RemoveStepAsync(stepName);
        public async Task SetActiveStepAsync(Step step) => await _stepService.SetActiveStepAsync(step);

        public async Task AddElementAsync(UIElement element) => await _elementService.AddElementAsync(element);
        public async Task AddElementAsync(ToolbarItem? toolbarItem, int? index = null, string target = "canvas") => await _elementService.AddElementAsync(toolbarItem, index, target);
        public async Task UpdateElementAsync(UIElement element) => await _elementService.UpdateElementAsync(element);
        public async Task RemoveElementAsync(UIElement element) => await _elementService.RemoveElementAsync(element);
        public async Task InsertAtAsync(UIElement element, int targetIndex) => await _elementService.InsertAtAsync(element, targetIndex);

        private void NotifyChanged() => OnChange?.Invoke();
    }
}
