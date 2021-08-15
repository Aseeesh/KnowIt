using Knowit.Domain.Entities;
using Knowit.Infrastructure.Repositories;
using Knowit.Infrastructure.Repositories.Base;
using Knowit.Infrastructure.Repositories.EventDetails;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureIdentity();
            services.ConfigureDatabase(config);
            services.ConfigureDependenciesRepository();

            return services;
        }
        private static void ConfigureIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();
        }
        public static void ConfigureDependenciesRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEventDetailRepository, EventDetailRepository>();

            //services.AddDbContext<AppDbContext>(
            //    options => options.UseSqlServer("Data Source=mssql-server; initial catalog=eventDetailDb; user id=sa; password=sa12345@BD; Integrated Security=False;")
            //);
        }
        private static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));
        }
    }
}
