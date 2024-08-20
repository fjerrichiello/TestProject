using Microsoft.Extensions.DependencyInjection;
using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class BookActivityRouter(IServiceScopeFactory _serviceScopeFactory) : IBookActivityRouter
{
    public IBookActivityOperation GetOperation(RouterParameters parameters)
    {
        //Wires Operations in the future
        if (IsActionApplicable(parameters.Action))
        {
            return new NoOperation();
        }

        if (parameters.Book != null)
        {
            //Wires Operations in the future

            return new NoOperation();
        }

        if (parameters.EditBookRequest != null)
        {
            return GetEditBookRequestOperation(parameters);
        }

        if (parameters.AddBookRequest != null)
        {
            return GetAddBookRequestOperation(parameters);
        }

        return new NoOperation();
    }

    private static bool IsActionApplicable(IntegrationAction action)
        => !IntegrationAction.NotApplicable.Equals(action);


    private IBookActivityOperation GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => new AddBookApproved(),
            IntegrationAction.Denied => new AddBookDenied(),
            _ => new NoOperation()
        };

    private IBookActivityOperation GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => new EditBookApproved(),
            IntegrationAction.Denied => new EditBookDenied(),
            _ => new NoOperation()
        };
}