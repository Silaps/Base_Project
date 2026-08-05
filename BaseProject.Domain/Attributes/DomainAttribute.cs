using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class DomainAttribute : Attribute
{
    public Type serviceType { get; }
    public ServiceLifetime lifetime { get; }

    public DomainAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        this.serviceType = serviceType;
        this.lifetime = lifetime;
    }
}