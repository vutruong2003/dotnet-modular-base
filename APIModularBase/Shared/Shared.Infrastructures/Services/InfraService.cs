using Shared.Common.DependencyInjection.Attributes;
using Shared.Core.Contracts;

namespace Shared.Infrastructures.Services;

[ScopedDependency<IInfraService>]
internal class InfraService : IInfraService
{
    public void LogInfra(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
    }
}
