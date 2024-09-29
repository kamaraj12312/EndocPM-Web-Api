using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI.Injectors
{
    public class ProviderSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IProviderService, ProviderService>();
        }
    }
}
