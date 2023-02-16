using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.User;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Shared.Modules;
public static partial class Startup
{
    public static IServiceCollection AddModules([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        services.AddModule<UserModule>(configuration);

        return services;
    }

    public static Task InitModules([NotNull] this IApplicationBuilder application)
    {
        return Task.CompletedTask;
    }
}
