using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Elements.Entities.Common;
using AzureApplicationAccelerator.Shared.Constants;
using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Models;

namespace AzureApplicationAccelerator.Shared.Services
{
    public class ElementService : IElementService
    {
        private readonly IStepService _stepService;
        private readonly IDefinitionStorageService _storage;
        public event Action? OnChange;

        public ElementService(IStepService stepService, IDefinitionStorageService storageService)
        {
            _stepService = stepService;
            _storage = storageService;
        }

        public async Task AddElementAsync(UIElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            _stepService.ActiveStep.Elements.Add(element);
            await PersistAndNotify();
        }

        public async Task AddElementAsync(ToolbarItem? toolbarItem, int? index = null, string target = ToolbarConstants.CanvasId)
        {
            ArgumentNullException.ThrowIfNull(toolbarItem);

            var element = toolbarItem.ToUiElement() ??
                throw new ArgumentException("Failed to map toolbar item to UI element.");

            InsertElementAt(element, index, target);
            await PersistAndNotify();
        }

        public async Task UpdateElementAsync(UIElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            var index = _stepService.ActiveStep.Elements.IndexOf(element);
            if (index >= 0)
            {
                _stepService.ActiveStep.Elements[index] = element;
                await PersistAndNotify();
            }
        }

        public async Task RemoveElementAsync(UIElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            if (RemoveFromCollection(_stepService.ActiveStep.Elements, element))
            {
                await PersistAndNotify();
                return;
            }

            foreach (var section in _stepService.ActiveStep.Elements.OfType<SectionElement>())
            {
                if (RemoveFromCollection(section.Elements, element))
                {
                    await PersistAndNotify();
                    return;
                }
            }
        }

        public async Task InsertAtAsync(UIElement element, int targetIndex)
        {
            ArgumentNullException.ThrowIfNull(element);

            var elements = _stepService.ActiveStep.Elements;
            var currentIndex = elements.IndexOf(element);

            if (currentIndex == -1)
                throw new InvalidOperationException("Element not found in the step.");

            if (currentIndex == targetIndex)
                return;

            elements.RemoveAt(currentIndex);
            elements.Insert(targetIndex, element);

            await PersistAndNotify();
        }

        private void InsertElementAt(UIElement element, int? index, string target)
        {
            if (element is SectionElement &&
                target.StartsWith(ToolbarConstants.SectionCanvasId, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Cannot put a Section element in Section.");
            }

            var collection = GetTargetCollection(target);
            if (collection is null) return;

            if (index.HasValue)
                collection.Insert(Math.Min(index.Value, collection.Count), element);
            else
                collection.Add(element);
        }

        private IList<UIElement>? GetTargetCollection(string target)
        {
            if (target.Equals(ToolbarConstants.CanvasId, StringComparison.OrdinalIgnoreCase))
                return _stepService.ActiveStep.Elements;

            if (target.StartsWith(ToolbarConstants.SectionCanvasId, StringComparison.OrdinalIgnoreCase))
            {
                var sectionName = target.Substring(ToolbarConstants.SectionCanvasId.Length);
                return _stepService.ActiveStep.Elements
                    .OfType<SectionElement>()
                    .FirstOrDefault(s => s.Name.Equals(sectionName, StringComparison.OrdinalIgnoreCase))
                    ?.Elements;
            }

            return null;
        }

        private bool RemoveFromCollection(IList<UIElement> collection, UIElement element)
        {
            return collection.Remove(element);
        }

        private async Task PersistAndNotify()
        {
            await _storage.PersistAsync();
            OnChange?.Invoke();
        }
    }
}