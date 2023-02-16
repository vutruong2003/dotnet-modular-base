using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.DependencyInjection;
using Shared.Core.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Shared.Core;

public static class Startup
{
    public static IServiceCollection AddSharedCore(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static Task InitSharedCore([NotNull] this IApplicationBuilder application)
    {
        return Task.CompletedTask;
    }
}
