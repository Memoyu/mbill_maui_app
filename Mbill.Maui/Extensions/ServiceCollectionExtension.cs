using Mbill.Maui.Services;
using Mbill.Maui.ViewModels;

namespace Mbill.Maui.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainPageViewModel>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<PlanetsService>();

            return services;
        }
    }
}
