namespace RoutingApp;

public interface IRouterParameterFactory
{
    Task<RouterParameters> GetParameters(Command command);
}