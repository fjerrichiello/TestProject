using Microsoft.Extensions.DependencyInjection;
using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class BookActivityRouterAsync(IServiceScopeFactory _serviceScopeFactory) : IBookActivityRouterAsync
{
    public async Task<IBookActivityOperation> GetOperation(RouterParameters parameters)
    {
        //Wires Operations in the future
        if (IsActionApplicable(parameters.Action))
        {
            return new NoOperation();
        }

        if (parameters.Book != null)
        {
            //Wires Operations in the future

            return await GetOperation(typeof(NoOperation));
        }

        if (parameters.EditBookRequest != null)
        {
            return await GetEditBookRequestOperation(parameters);
        }

        if (parameters.AddBookRequest != null)
        {
            return await GetAddBookRequestOperation(parameters);
        }

        return await GetOperation(typeof(NoOperation));
    }

    private static bool IsActionApplicable(IntegrationAction action)
        => !IntegrationAction.NotApplicable.Equals(action);


    private async Task<IBookActivityOperation> GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => await GetOperation(typeof(AddBookApproved)),
            IntegrationAction.Denied => await GetOperation(typeof(AddBookDenied)),
            _ => await GetOperation(typeof(NoOperation))
        };

    private async Task<IBookActivityOperation> GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => await GetOperation(typeof(EditBookApproved)),
            IntegrationAction.Denied => await GetOperation(typeof(EditBookDenied)),
            _ => await GetOperation(typeof(NoOperation))
        };

    private async Task<IBookActivityOperation> GetOperation(Type serviceType)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        //SET Metadata

        var service = scope.ServiceProvider.GetRequiredKeyedService<IBookActivityOperation>(serviceType.Name);

        return service;
    }
}