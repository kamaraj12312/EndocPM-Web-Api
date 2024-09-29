using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class ELabSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IELabService, ELabService>();
        }

    }
}
