using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{ 
    public class AppointmentSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
