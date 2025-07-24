using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Elements.Entities.Common;
using AzureApplicationAccelerator.Shared.Constants;
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

        public UIDefinitionService(IJSRuntime js)
        {
            _js = js;
            ActiveStep = Definition.Parameters.Basics;
        }

        public async Task InitializeAsync()
        {
            var stored = await _js.GetItemAsync<CreateUIDefinition>(StorageKey);
            if (stored is not null)
            {
                Definition = stored;
                ActiveStep = Definition.Parameters.Basics;
            }

            NotifyChanged();
        }

        public async Task ClearAsync()
        {
            Definition = new CreateUIDefinition();
            await _js.SetItemAsync(StorageKey, Definition);
            await PersistAsync();
            NotifyChanged();
        }

        public async Task InsertAtAsync(UIElement element, int targetIndex)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element), "Element cannot be null.");
            }

            var step = ActiveStep;
            if (step.Elements == null || step.Elements.Count == 0)
            {
                throw new InvalidOperationException("Step must contain at least one element.");
            }

            var currentIndex = step.Elements.IndexOf(element);
            if (currentIndex == -1)
            {
                throw new InvalidOperationException("Element not found in the step.");
            }

            if (targetIndex < 0 || targetIndex >= step.Elements.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(targetIndex), "Target index is out of range.");
            }

            if (currentIndex == targetIndex)
            {
                return;
            }

            step.Elements.RemoveAt(currentIndex);
            step.Elements.Insert(targetIndex, element);

            await PersistAsync();
            NotifyChanged();
        }

        private async Task PersistAsync()
        {
            await _js.SetItemAsync(StorageKey, Definition);
        }

        private void NotifyChanged() => OnChange?.Invoke();

        public async Task<Step> GetStep(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Step name cannot be null or empty.", nameof(name));
            }

            if (name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase))
            {
                return Definition.Parameters.Basics;
            }

            return Definition.Parameters.Steps.SingleOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AddStepAsync(Step step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step), "Step cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(step.Name) ||
                await GetStep(step.Name) != null)
            {
                return;
            }

            Definition.Parameters.Steps.Add(step);
            await PersistAsync();
            NotifyChanged();
        }

        public async Task<Step> EditStepAsync(string stepName, Step updatedStep)
        {
            ArgumentNullException.ThrowIfNull(updatedStep);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(stepName, nameof(stepName));

            if (updatedStep.Name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase) ||
                stepName.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Basics step cannot be edited.");
            }

            if (await GetStep(stepName) is not Step existingStep)
            {
                throw new InvalidOperationException($"Step with name '{updatedStep.Name}' does not exist.");
            }

            existingStep.Name = updatedStep.Name;
            existingStep.Label = updatedStep.Label;
            existingStep.SubLabel = updatedStep.SubLabel;
            existingStep.BladeTitle = updatedStep.BladeTitle;

            await PersistAsync();
            NotifyChanged();

            return existingStep;
        }

        public async Task RemoveStepAsync(string stepName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(stepName);

            if (await GetStep(stepName) is not Step stepToDelete ||
                stepName.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase) ||
                stepToDelete.Name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            Definition.Parameters.Steps.Remove(stepToDelete);
            await PersistAsync();
            NotifyChanged();
        }

        public async Task SetActiveStepAsync(Step step)
        {
            if (step is null) { return; }
            if (step.Name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase))
            {
                ActiveStep = Definition.Parameters.Basics;
            }

            if (Definition.Parameters.Steps.Any(s => s == step))
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

        public async Task AddElementAsync(ToolbarItem? toolbarItem, int? index = null, string target = ToolbarConstants.CanvasId)
        {
            if (toolbarItem is null)
            {
                throw new ArgumentException("Toolbar item is null.");
            }

            if (toolbarItem.ToUiElement() is not UIElement element)
            {
                throw new ArgumentException("Failed to map toolbar item to UI element.");
            }

            InsertElementAt(element, index, target);

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

            var existingElement = ActiveStep.Elements.FirstOrDefault(e => e == element);
            if (existingElement is not null)
            {
                existingElement = element;

                await PersistAsync();
                NotifyChanged();
            }
        }

        public async Task RemoveElementAsync(UIElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element), "Element cannot be null.");
            }

            if (ActiveStep is not null &&
                ActiveStep.Elements.Any(e => e == element))
            {
                ActiveStep.Elements.Remove(element);
                await PersistAsync();
                NotifyChanged();
            }
        }

        private void InsertElementAt(UIElement element, int? targetIndex, string targetContainer)
        {
            if (targetContainer.Equals(ToolbarConstants.CanvasId, StringComparison.OrdinalIgnoreCase))
            {
                InsertElementIntoCanvas(element, targetIndex);
            }
            else if (targetContainer.StartsWith(ToolbarConstants.SectionCanvasId, StringComparison.OrdinalIgnoreCase))
            {
                var sectionName = targetContainer.Substring(ToolbarConstants.SectionCanvasId.Length);
                InsertElementIntoSection(element, targetIndex, sectionName);
            }
        }

        private void InsertElementIntoCanvas(UIElement element, int? targetIndex)
        {
            if (targetIndex.HasValue)
            {
                ValidateAndInsert(ActiveStep.Elements, element, targetIndex.Value);
            }
            else
            {
                ActiveStep.Elements.Add(element);
            }
        }

        private void InsertElementIntoSection(UIElement element, int? targetIndex, string sectionName)
        {
            var sectionElement = FindSectionElement(sectionName);
            if (sectionElement != null)
            {
                if (targetIndex.HasValue)
                {
                    ValidateAndInsert(sectionElement.Elements, element, targetIndex.Value);
                }
                else
                {
                    sectionElement.Elements.Add(element);
                }
            }
        }

        private SectionElement? FindSectionElement(string sectionName)
        {
            return ActiveStep.Elements
                .OfType<SectionElement>()
                .FirstOrDefault(s => s.Name.Equals(sectionName, StringComparison.OrdinalIgnoreCase));
        }

        private void ValidateAndInsert(IList<UIElement> elements, UIElement element, int insertIndex)
        {
            int count = elements.Count;
            if (insertIndex < 0 || insertIndex > count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(insertIndex),
                    $"Index must be between 0 and {count} (inclusive)."
                );
            }
            elements.Insert(insertIndex, element);
        }
    }
}
