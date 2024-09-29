using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class EPrescriptionSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IEPrescriptionService, EPrescriptionService>();
        }



    }
}
