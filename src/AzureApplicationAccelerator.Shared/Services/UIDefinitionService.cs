using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Extensions;
using AzureApplicationAccelerator.Shared.Models;
using Microsoft.JSInterop;

namespace AzureApplicationAccelerator.Shared.Services
{
    public class UIDefinitionService
    {
        private const string StorageKey = "createUIDefinition";
        private readonly IJSRuntime _js;

        public CreateUIDefinition Definition { get; private set; } = new();

        public Step ActiveStep { get; private set; }

        public event Action? OnChange;

        public UIDefinitionService(IJSRuntime js) => _js = js;

        public async Task InitializeAsync()
        {
            //var stored = await _js.GetItemAsync<CreateUIDefinition>(StorageKey);
            Definition = new CreateUIDefinition();
            ActiveStep = Definition.Parameters.Basics;
            NotifyChanged();
        }

        public async Task ClearAsync()
        {
            Definition = new CreateUIDefinition();
            await _js.SetItemAsync(StorageKey, Definition);
            NotifyChanged();
        }

        public async Task SwapElements(Guid elementId1, Guid elementId2)
        {
            if (elementId1 == Guid.Empty ||
                elementId2 == Guid.Empty ||
                elementId1 == elementId2)
            {
                throw new ArgumentException("Element IDs cannot be empty or equal.");
            }

            var step = ActiveStep;
            if (step.Elements == null || step.Elements.Count < 2)
            {
                throw new InvalidOperationException("Step must contain at least two elements to swap.");
            }

            var element1 = step.Elements.FirstOrDefault(e => e.Id == elementId1);
            var element2 = step.Elements.FirstOrDefault(e => e.Id == elementId2);
            if (element1 is null || element2 is null)
            {
                throw new InvalidOperationException("One or both elements not found in the step.");
            }

            var index1 = step.Elements.IndexOf(element1);
            var index2 = step.Elements.IndexOf(element2);

            if (index1 == -1 || index2 == -1)
            {
                throw new InvalidOperationException("One or both element indices not found.");
            }

            if (index1 == index2)
            {
                throw new InvalidOperationException("Elements are at the same position; cannot swap.");
            }

            step.Elements[index1] = element2;
            step.Elements[index2] = element1;
            await PersistAsync();
            NotifyChanged();
        }

        private async Task PersistAsync()
        {
            await _js.SetItemAsync(StorageKey, Definition);
        }

        private void NotifyChanged() => OnChange?.Invoke();

        public async Task AddStepAsync(StepDto step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step), "Step cannot be null.");
            }
            if (Definition.Parameters.Steps.Any(s => s.Name.Equals(step.Title, StringComparison.OrdinalIgnoreCase)) ||
                string.IsNullOrWhiteSpace(step.Title))
            {
                return;
            }

            Definition.Parameters.Steps.Add(new Step { 
                Name = step.Title,
                BladeTitle = step.Title,
                Label = step.Label 
            });
            await PersistAsync();
            NotifyChanged();
        }

        public async Task RemoveStepAsync(Guid stepId)
        {
            if (Definition.Parameters.Steps.FirstOrDefault(s => s.Id == stepId) is not Step step ||
                stepId.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsId))
            {
                return;
            }

            Definition.Parameters.Steps.Remove(step);
            await PersistAsync();
            NotifyChanged();
        }

        public async Task SetActiveStepAsync(Guid stepId)
        {
            if (stepId == AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsId)
            {
                ActiveStep = Definition.Parameters.Basics;
            }

            if (Definition.Parameters.Steps.FirstOrDefault(s => s.Id == stepId) is Step step)
            {
                ActiveStep = step;
            }

            await PersistAsync();
            NotifyChanged();
        }

        public async Task AddElementAsync(UIElement element)
        {
            if (element is null)
            {
                throw new ArgumentException("Element is null.");
            }

            ActiveStep.Elements.Add(element);
            await PersistAsync();
            NotifyChanged();
        }

        public async Task AddElementAsync(ToolbarItem? toolbarItem, int? index = null)
        {
            if (toolbarItem is null)
            {
                throw new ArgumentException("Toolbar item is null.");
            }

            if (toolbarItem.ToUiElement() is not UIElement element)
            {
                throw new ArgumentException("Failed to map toolbar item to UI element.");
            }

            if (index.HasValue)
            {
                var insertIndex = index.Value;
                int count = ActiveStep.Elements.Count;

                if (insertIndex < 0 || insertIndex > count)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(index),
                        $"Index must be between 0 and {count} (inclusive)."
                    );
                }

                ActiveStep.Elements.Insert(insertIndex, element);
            }
            else
            {
                ActiveStep.Elements.Add(element);
            }

            await PersistAsync();
            NotifyChanged();
        }

        public async Task UpdateElementAsync(UIElement element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            if (ActiveStep is null)
            {
                throw new InvalidOperationException("No active step to update the element in.");
            }

            var existingElement = ActiveStep.Elements.FirstOrDefault(e => e.Id == element.Id);
            if (existingElement is not null)
            {
                existingElement = element;

                await PersistAsync();
                NotifyChanged();
            }
        }

        public async Task RemoveElementAsync(Guid elementId)
        {
            if (ActiveStep is not null &&
                ActiveStep.Elements.FirstOrDefault(e => e.Id == elementId) is UIElement element)
            {
                ActiveStep.Elements.Remove(element);
                await PersistAsync();
                NotifyChanged();
            }
        }
    }
}
