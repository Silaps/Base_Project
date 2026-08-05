using BaseProject.Domain.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BaseProject.Application;

public static class ServiceExtension
{
    public static void AddApplicationRepository(this IServiceCollection services)
    {
        List<Assembly> assemblies = new List<Assembly>()
        {
            Assembly.GetExecutingAssembly()
        };

        foreach (var asb in assemblies)
        {
            var implementedClasses = asb.GetTypes()
                .Where(type => type.IsClass && type.CustomAttributes.Where(x => x.AttributeType == typeof(DomainAttribute)).Count() > 0)
                .ToList();

            foreach (var cls in implementedClasses)
            {
                var attribute = cls.GetCustomAttribute<DomainAttribute>();
                if (attribute != null)
                {
                    var serviceType = attribute!.serviceType;
                    var lifetime = attribute.lifetime;

                    switch (lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(serviceType, cls);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(serviceType, cls);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(serviceType, cls);
                            break;
                    }
                }
            }
        }
    }
}
