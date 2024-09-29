using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class MasterSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IMasterService, MasterService>();
        }

    }
}
