using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class ClaimSvcInjector
    {

        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
        }

    }
}
