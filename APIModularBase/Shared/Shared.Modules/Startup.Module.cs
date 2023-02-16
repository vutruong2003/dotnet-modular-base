using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.DependencyInjection;
using Shared.Infrastructures.Contracts;

namespace Shared.Modules;
public static partial class Startup
{
    private static IServiceCollection AddModule<T>(this IServiceCollection services, IConfiguration configuration) where T : IModuleLoader
    {
        return T.Load(services, configuration);
    }
}
