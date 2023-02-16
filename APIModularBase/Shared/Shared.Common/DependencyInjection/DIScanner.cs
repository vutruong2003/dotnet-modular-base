using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Common.DependencyInjection.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Shared.Common.DependencyInjection;

public class DIScanner
{
    public static void RegisterAssembly([NotNull] IServiceCollection services, [NotNull] Assembly assembly, bool allowMultiple = true)
    {
        var serviceDescriptors = assembly.DefinedTypes
             .Select(t => new
             {
                 TypeInfo = t,
                 ServiceDescriptors = t.GetCustomAttributes()
                     .Where(ca => ca is BaseDependencyAttribute)
                     .Select(ca =>
                     {
                         var attribute = (BaseDependencyAttribute)ca;
                         var serviceDescriptor = attribute.BuildServiceDescriptor(t);

                         return serviceDescriptor;
                     })
                     .ToList()
             })
             .Where(x => x.ServiceDescriptors.Any())
             .SelectMany(x => x.ServiceDescriptors);

        if (allowMultiple)
        {
            services.Add(serviceDescriptors);
        }
        else
        {
            services.TryAdd(serviceDescriptors);
        }
    }
}
