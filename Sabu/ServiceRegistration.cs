using Sabu.Services.Abstracts;
using Sabu.Services.Implements;

namespace Sabu
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }
}
