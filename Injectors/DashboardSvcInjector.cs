using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class DashboardSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IDashboardService, DashboardService>();
        }

    }
}
