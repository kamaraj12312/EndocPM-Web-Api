using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EndocPM.WebAPI
{
    public class UserSvcInjector
    {
        public static void InjectInjectors(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
