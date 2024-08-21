using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public static class Registration
{
    public static IServiceCollection AddOperations(this IServiceCollection services, params Type[] sourceTypes)
    {
        var serviceRegistrations = sourceTypes.Select(sourceType => sourceType.Assembly)
            .Distinct()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(IsBookActivityOperation)
            .ToList();

        foreach (var serviceRegistration in serviceRegistrations)
        {
            services.AddKeyedScoped(typeof(IBookActivityOperation), serviceRegistration.Name);
        }

        return services;
    }

    private static bool IsBookActivityOperation(Type type)
    {
        return type.IsClass && type.GetInterfaces().Any(IsBookActivityOperationInterface);
    }

    private static bool IsBookActivityOperationInterface(Type interfaceType)
    {
        return interfaceType == typeof(IBookActivityOperation);
    }
}