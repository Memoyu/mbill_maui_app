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
    }
}
