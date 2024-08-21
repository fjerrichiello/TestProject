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
            return _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(NoOperation));
        }

        if (parameters.Book != null)
        {
            //Wires Operations in the future
            return _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(NoOperation));
        }

        if (parameters.EditBookRequest != null)
        {
            return GetEditBookRequestOperation(parameters);
        }

        if (parameters.AddBookRequest != null)
        {
            return GetAddBookRequestOperation(parameters);
        }

        return _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(NoOperation));
    }

    private static bool IsActionApplicable(IntegrationAction action)
        => !IntegrationAction.NotApplicable.Equals(action);


    private IBookActivityOperation GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(
                nameof(AddBookApproved)),
            IntegrationAction.Denied => _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(
                nameof(AddBookDenied)),
            _ => _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(NoOperation))
        };

    private IBookActivityOperation GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(
                nameof(EditBookApproved)),
            IntegrationAction.Denied =>
                _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(EditBookDenied)),
            _ => _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(nameof(NoOperation))
        };

    private IBookActivityOperation GetKeyedService(Type type) =>
        _serviceProvider.GetRequiredKeyedService<IBookActivityOperation>(type.Name);
}