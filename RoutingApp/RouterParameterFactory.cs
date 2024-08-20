using RoutingApp.DummyResources;

namespace RoutingApp;

public class RouterParameterFactory(IService1 service1, IService2 service2) : IRouterParameterFactory
{
    public async Task<RouterParameters> GetParameters(Command command)
    {
        //Do work
        
        
        return new RouterParameters(IntegrationAction.Approved, null, new AddBookRequest(), null);
    }
}