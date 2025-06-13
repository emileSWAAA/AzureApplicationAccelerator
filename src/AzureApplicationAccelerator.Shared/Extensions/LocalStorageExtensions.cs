using Microsoft.JSInterop;
using System.Text.Json;

namespace AzureApplicationAccelerator.Shared.Extensions
{
    public static class LocalStorageExtensions
    {
        public static async ValueTask SetItemAsync<T>(
            this IJSRuntime js, string key, T item)
            => await js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(item));

        public static async ValueTask<T?> GetItemAsync<T>(
            this IJSRuntime js, string key)
        {
            var json = await js.InvokeAsync<string>("localStorage.getItem", key);
            return string.IsNullOrEmpty(json)
                ? default
                : JsonSerializer.Deserialize<T>(json)!;
        }
    }
}
