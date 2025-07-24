using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Models;

namespace AzureApplicationAccelerator.Shared.Interfaces
{
    public interface IElementService
    {
        event Action? OnChange;
        Task AddElementAsync(UIElement element);
        Task AddElementAsync(ToolbarItem? toolbarItem, int? index = null, string target = "canvas");
        Task UpdateElementAsync(UIElement element);
        Task RemoveElementAsync(UIElement element);
        Task InsertAtAsync(UIElement element, int targetIndex);
    }
}