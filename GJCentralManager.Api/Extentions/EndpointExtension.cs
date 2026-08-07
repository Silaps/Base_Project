using GJCentralManager.Api.EndPoints;
using System.Reflection;

namespace GJCentralManager.Api.Extentions;

public static class EndpointExtension
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        // Busca todas las clases que implementen IEndpoint
        var endpointTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndpoint).IsAssignableFrom(t));

        foreach (var type in endpointTypes)
        {
            // Instancia la clase y llama al método
            var endpoint = Activator.CreateInstance(type) as IEndpoint;
            endpoint?.MapEndpoint(app);
        }

        return app;
    }
}
