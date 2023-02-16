using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.User.Core;
public static class Startup
{
    public static IServiceCollection AddUserCore(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}