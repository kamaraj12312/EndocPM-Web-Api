using EndocPM.WebAPI.Injectors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class BaseInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped(typeof(IGlobalGenericRepository<>), typeof(GlobalGenericRepository<>));
            //services.AddScoped<IGlobalUnitOfWork, GlobalUnitOfWork>();

            UserSvcInjector.InjectInjectors(services);
            MasterSvcInjector.InjectInjectors(services);
            AppointmentSvcInjector.InjectInjectors(services);
            ProviderSvcInjector.InjectInjectors(services);
            PatientSvcInjector.InjectInjectors(services);
            EPrescriptionSvcInjector.InjectInjectors(services);
            ELabSvcInjector.InjectInjectors(services);
            DashboardSvcInjector.InjectInjectors(services);
            ClaimSvcInjector.InjectInjectors(services);



        }
    }
}
