using Microsoft.Extensions.DependencyInjection;

namespace Shared.Common.DependencyInjection.Attributes;
public class TransientDependencyAttribute : DependencyAttribute
{
    public TransientDependencyAttribute() : base(ServiceLifetime.Transient)
    {

    }
}

public class TransientDependencyAttribute<T> : DependencyAttribute<T>
{
    public TransientDependencyAttribute() : base(ServiceLifetime.Transient)
    {

    }
}