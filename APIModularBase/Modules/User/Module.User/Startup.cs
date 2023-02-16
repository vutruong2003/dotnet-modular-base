using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.User.Core;
using Module.User.Infrastructure;
using Shared.Infrastructures.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Module.User;

public class UserModule : IModuleLoader
{
    public static IServiceCollection Load([NotNull] IServiceCollection services, IConfiguration configuration)
    {
        return services.AddUserCore(configuration)
            .AddUserInfrastructure(configuration);
    }

    static Task IModuleLoader.Init([NotNull] IApplicationBuilder application)
    {
        return Task.CompletedTask;
    }
}
