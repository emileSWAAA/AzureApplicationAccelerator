using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Constants;
using AzureApplicationAccelerator.Shared.Interfaces;

namespace AzureApplicationAccelerator.Shared.Services
{
    public class StepService : IStepService
    {
        private readonly IDefinitionStorageService _storage;
        public Step ActiveStep { get; private set; }
        public event Action? OnChange;

        public StepService(IDefinitionStorageService storage)
        {
            _storage = storage;
            ActiveStep = _storage.Definition.Parameters.Basics;
        }

        public Step? GetStep(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            if (name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase))
                return _storage.Definition.Parameters.Basics;

            return _storage.Definition.Parameters.Steps.SingleOrDefault(s => 
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AddStepAsync(Step step)
        {
            if (step == null || string.IsNullOrWhiteSpace(step.Name) || GetStep(step.Name) != null)
                return;

            _storage.Definition.Parameters.Steps.Add(step);
            await _storage.PersistAsync();
            OnChange?.Invoke();
        }

        public async Task<Step> EditStepAsync(string stepName, Step updatedStep)
        {
            ArgumentNullException.ThrowIfNull(updatedStep);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(stepName);

            if (IsBasicsStep(stepName) || IsBasicsStep(updatedStep.Name))
                throw new InvalidOperationException("Basics step cannot be edited.");

            var existingStep = GetStep(stepName);
            if (existingStep is null)
                throw new InvalidOperationException($"Step with name '{stepName}' does not exist.");

            existingStep.Name = updatedStep.Name;
            existingStep.Label = updatedStep.Label;
            existingStep.SubLabel = updatedStep.SubLabel;
            existingStep.BladeTitle = updatedStep.BladeTitle;

            await _storage.PersistAsync();
            OnChange?.Invoke();
            return existingStep;
        }

        public async Task RemoveStepAsync(string stepName)
        {
            if (string.IsNullOrWhiteSpace(stepName) || IsBasicsStep(stepName))
                return;

            var stepToDelete = GetStep(stepName);
            if (stepToDelete is null)
                return;

            _storage.Definition.Parameters.Steps.Remove(stepToDelete);
            await _storage.PersistAsync();
            OnChange?.Invoke();
        }

        public async Task SetActiveStepAsync(Step step)
        {
            if (step is null) return;
            
            SetActiveStep(step);
            await _storage.PersistAsync();
            OnChange?.Invoke();
        }

        public void SetActiveStep(Step step)
        {
            if (IsBasicsStep(step.Name))
            {
                ActiveStep = _storage.Definition.Parameters.Basics;
            }
            else if (_storage.Definition.Parameters.Steps.Contains(step))
            {
                ActiveStep = step;
            }
        }

        private bool IsBasicsStep(string name) =>
            name.Equals(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, StringComparison.OrdinalIgnoreCase);
    }
}