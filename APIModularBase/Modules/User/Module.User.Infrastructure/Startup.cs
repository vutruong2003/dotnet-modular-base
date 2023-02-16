using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.DependencyInjection;
using System.Reflection;

namespace Module.User.Infrastructure;
public static class Startup
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        DIScanner.RegisterAssembly(services, Assembly.GetExecutingAssembly());

        return services;
    }
}
