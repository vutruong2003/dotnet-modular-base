using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Shared.Infrastructures.Contracts;
public interface IModuleLoader
{
    abstract static IServiceCollection Load([NotNull] IServiceCollection services, IConfiguration configuration);

    abstract static Task Init([NotNull] IApplicationBuilder application);
}