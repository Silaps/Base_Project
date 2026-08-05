using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ImplementationAttribute : Attribute
{
    public Type serviceType { get; }
    public ServiceLifetime lifetime { get; }

    public ImplementationAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        this.serviceType = serviceType;
        this.lifetime = lifetime;
    }
}