using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class BookActivityRouter() : IBookActivityRouter
{
    public string GetOperation(RouterParameters parameters)
    {
        //Wires Operations in the future
        if (!IsActionApplicable(parameters.Action))
        {
            return nameof(NoOperation);
        }

        if (parameters.Book != null)
        {
            //Wires Operations in the future
            return nameof(NoOperation);
        }

        if (parameters.EditBookRequest != null)
        {
            return GetEditBookRequestOperation(parameters);
        }

        if (parameters.AddBookRequest != null)
        {
            return GetAddBookRequestOperation(parameters);
        }

        return nameof(NoOperation);
    }

    private static bool IsActionApplicable(IntegrationAction action)
        => !IntegrationAction.NotApplicable.Equals(action);


    private string GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => nameof(AddBookApproved),
            IntegrationAction.Denied => nameof(AddBookDenied),
            _ => nameof(NoOperation)
        };

    private string GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => nameof(EditBookApproved),
            IntegrationAction.Denied =>
                nameof(EditBookDenied),
            _ => nameof(NoOperation)
        };
}