using GJCentralManager.Domain.Attributes;
using GJCentralManager.Infrastructure.Persistences.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GJCentralManager.Infrastructure.Extensions;

public static class RepositoryExtension
{
    public static void AddInfrastructureRepository(this IServiceCollection services)
    {
        services.AddDbContext<GJCentralmanagerContext>();

        List<Assembly> assemblies = new List<Assembly>()
            {
                Assembly.GetExecutingAssembly()
            };

        foreach (var asb in assemblies)
        {
            var implementedClasses = asb.GetTypes()
                .Where(type => type.IsClass && type.CustomAttributes.Where(x => x.AttributeType == typeof(ImplementationAttribute)).Count() > 0)
                .ToList();

            foreach (var cls in implementedClasses)
            {
                var attribute = cls.GetCustomAttribute<ImplementationAttribute>();
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
