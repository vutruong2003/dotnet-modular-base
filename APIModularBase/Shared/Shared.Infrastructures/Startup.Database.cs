using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructures;
public static partial class Startup
{
    public static IServiceCollection AddSqlServer<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
    {
        var connectionString = config.GetConnectionString("Default")!;
        services.AddSqlServer<T>(connectionString);
        return services;
    }

    public static IServiceCollection AddSqlServer<T>(this IServiceCollection services, string connectionString) where T : DbContext
    {
        services.AddDbContext<T>(m => m.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
        
        return services;
    }

    public static async Task MigrateDatabase<T>(this IApplicationBuilder application) where T : DbContext
    {
        using var scope = application.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        await dbContext.Database.MigrateAsync();
    }
}
