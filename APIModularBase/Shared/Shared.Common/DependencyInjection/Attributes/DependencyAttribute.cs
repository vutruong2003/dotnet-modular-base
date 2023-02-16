using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Common.DependencyInjection.Attributes;

public abstract class BaseDependencyAttribute : Attribute
{
    public ServiceLifetime ServiceLifeTime { get; set; }

    public BaseDependencyAttribute(ServiceLifetime lifetime)
    {
        ServiceLifeTime = lifetime;
    }

    protected virtual ServiceDescriptor BuildServiceDescriptorFromType(Type serviceType, TypeInfo implementationType)
    {
        var targetType = implementationType.AsType();
        serviceType = serviceType ?? targetType;

        return new ServiceDescriptor(serviceType, targetType, ServiceLifeTime);
    }

    public abstract ServiceDescriptor BuildServiceDescriptor(TypeInfo type);
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class DependencyAttribute : BaseDependencyAttribute
{
    public Type ServiceType { get; set; } = null!;

    public DependencyAttribute(ServiceLifetime lifetime) : base(lifetime) { }

    public override ServiceDescriptor BuildServiceDescriptor(TypeInfo type)
    {
        return BuildServiceDescriptorFromType(ServiceType, type);
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class DependencyAttribute<T> : BaseDependencyAttribute
{
    public DependencyAttribute(ServiceLifetime lifetime) : base(lifetime) 
    {
        
    }

    public override ServiceDescriptor BuildServiceDescriptor(TypeInfo type)
    {
        var serviceType = typeof(T);
        
        return BuildServiceDescriptorFromType(serviceType, type);
    }
}