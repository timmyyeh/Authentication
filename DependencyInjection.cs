using authentication.Interfaces;
using authentication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace authentication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureIdentity(this IServiceCollection services, IConfiguration config)
        {
            // get authsettings from appsettings.json
            IConfigurationSection section = config.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(section);
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}