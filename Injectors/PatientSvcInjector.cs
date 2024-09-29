using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI.Injectors
{
    public class PatientSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
        }

    }
}
