using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.DependencyInjection;
using Shared.Core.Contracts;
using Shared.Infrastructures.Persistences;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Shared.Infrastructures;
public static partial class Startup
{
    public static IServiceCollection AddSharedInfrastructure([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        DIScanner.RegisterAssembly(services, typeof(Startup).Assembly);

        return services.AddSqlServer<ModuleDbContext>(configuration)
            .AddScoped<IModuleDbContext>(provider => provider.GetRequiredService<ModuleDbContext>());
    }

    public static async Task InitSharedInfrastructure([NotNull] this IApplicationBuilder application)
    {
        await application.MigrateDatabase<ModuleDbContext>();
    }
}
