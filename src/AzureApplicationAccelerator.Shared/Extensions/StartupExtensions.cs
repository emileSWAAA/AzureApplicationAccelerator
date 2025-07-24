using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureApplicationAccelerator.Shared.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddAzureApplicationAcceleratorServices(this IServiceCollection services)
        {
            services.AddScoped<IStepService, StepService>();
            services.AddScoped<IElementService, ElementService>();
            services.AddScoped<IDefinitionStorageService, DefinitionStorageService>();
            services.AddScoped<UIDefinitionService>();

            return services;
        }
    }
}
