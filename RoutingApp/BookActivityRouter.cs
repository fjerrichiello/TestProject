using Microsoft.Extensions.DependencyInjection;
using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class BookActivityRouter(IServiceProvider _serviceProvider) : IBookActivityRouter
{
    public IBookActivityOperation GetOperation(RouterParameters parameters)
    {
        //Wires Operations in the future
        if (!IsActionApplicable(parameters.Action))
        {
            return _serviceProvider.GetRequiredKeyedService<NoOperation>(nameof(NoOperation));
        }

        if (parameters.Book != null)
        {
            //Wires Operations in the future
            return _serviceProvider.GetRequiredKeyedService<NoOperation>(nameof(NoOperation));
        }

        if (parameters.EditBookRequest != null)
        {
            return GetEditBookRequestOperation(parameters);
        }

        if (parameters.AddBookRequest != null)
        {
            return GetAddBookRequestOperation(parameters);
        }

        return _serviceProvider.GetRequiredKeyedService<NoOperation>(nameof(NoOperation));
    }

    private static bool IsActionApplicable(IntegrationAction action)
        => !IntegrationAction.NotApplicable.Equals(action);


    private IBookActivityOperation GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => _serviceProvider.GetRequiredKeyedService<AddBookApproved>(
                nameof(AddBookApproved)),
            IntegrationAction.Denied => _serviceProvider.GetRequiredKeyedService<AddBookDenied>(nameof(AddBookDenied)),
            _ => _serviceProvider.GetRequiredKeyedService<NoOperation>(nameof(NoOperation))
        };

    private IBookActivityOperation GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => _serviceProvider.GetRequiredKeyedService<EditBookApproved>(
                nameof(EditBookApproved)),
            IntegrationAction.Denied =>
                _serviceProvider.GetRequiredKeyedService<EditBookDenied>(nameof(EditBookDenied)),
            _ => _serviceProvider.GetRequiredKeyedService<NoOperation>(nameof(NoOperation))
        };
}