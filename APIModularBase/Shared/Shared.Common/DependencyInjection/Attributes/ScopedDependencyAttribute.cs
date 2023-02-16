using Microsoft.Extensions.DependencyInjection;

namespace Shared.Common.DependencyInjection.Attributes;
public class ScopedDependencyAttribute : DependencyAttribute
{
    public ScopedDependencyAttribute() : base(ServiceLifetime.Scoped)
    {

    }
}

public class ScopedDependencyAttribute<T> : DependencyAttribute<T>
{
    public ScopedDependencyAttribute() : base(ServiceLifetime.Scoped)
    {
    }
}