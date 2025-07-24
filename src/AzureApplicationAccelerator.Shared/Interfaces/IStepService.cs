using AzureApplicationAccelerator.Elements;

namespace AzureApplicationAccelerator.Shared.Interfaces
{
    public interface IStepService
    {
        Step ActiveStep { get; }
        event Action? OnChange;
        Step? GetStep(string name);
        Task AddStepAsync(Step step);
        Task<Step> EditStepAsync(string stepName, Step updatedStep);
        Task RemoveStepAsync(string stepName);
        Task SetActiveStepAsync(Step step);
        void SetActiveStep(Step step);
    }
}