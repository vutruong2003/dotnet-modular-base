using Microsoft.Extensions.DependencyInjection;

namespace Shared.Common.DependencyInjection.Attributes;
public class SingletonDependencyAttribute : DependencyAttribute
{
    public SingletonDependencyAttribute() : base(ServiceLifetime.Singleton)
    {

    }
}

public class SingletonDependencyAttribute<T> : DependencyAttribute<T>
{
    public SingletonDependencyAttribute() : base(ServiceLifetime.Singleton)
    {
    }
}