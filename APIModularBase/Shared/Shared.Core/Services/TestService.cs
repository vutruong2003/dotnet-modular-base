using Shared.Common.DependencyInjection.Attributes;
using Shared.Core.Contracts;

namespace Shared.Core.Services;

[ScopedDependency<ITestService>]
internal class TestService : ITestService
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
    }
}


[ScopedDependency<ITestService>]
internal class TestService2 : ITestService
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
    }
}