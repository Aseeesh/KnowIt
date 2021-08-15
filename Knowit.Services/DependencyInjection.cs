using Knowit.Domain.Mappings;
using Knowit.Services.Services.EventDetailServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Services
{
    public static class DependencyInjection
    {
       
        public static IServiceCollection ConfigureDependenciesServices(this IServiceCollection services)
        {
            services.ConfigureInjection();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(c => c.AddProfile<DtoToModelProfile>());
            return services;
        }

        private static void ConfigureInjection(this IServiceCollection services)
        {
            services.AddTransient<IEventDetailService, EventDetailService>();
        }
    }
}
