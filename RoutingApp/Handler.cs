namespace RoutingApp;

public class Handler(IRouterParameterFactory factory, IBookActivityRouterAsync router, IBookActivityRouter router2)
{
    public async Task UseHandler(Command command)
    {
        var parameters = await factory.GetParameters(command);

        var operation = await router.GetOperation(parameters);

        await operation.DoOperation();
    }

    public async Task UseHandler2(Command command)
    {
        var parameters = await factory.GetParameters(command);

        var operation = router2.GetOperation(parameters);

        await operation.DoOperation();
    }
}