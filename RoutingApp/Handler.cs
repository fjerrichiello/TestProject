﻿namespace RoutingApp;

public class Handler(IRouterParameterFactory factory, IBookActivityRouter router)
{
    public async Task UseHandler(Command command)
    {
        var parameters = await factory.GetParameters(command);

        var operation = await router.GetOperation(parameters);

        await operation.DoOperation();
    }
}