using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public class BookActivityRouter : IBookActivityRouter
{
    public  IBookActivityOperation GetOperation(RouterParameters parameters)
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


    private static IBookActivityOperation GetAddBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => new AddBookApproved(),
            IntegrationAction.Denied => new AddBookApproved(),
            _ => new NoOperation()
        };

    private static IBookActivityOperation GetEditBookRequestOperation(RouterParameters parameters)
        => parameters.Action switch
        {
            IntegrationAction.Approved => new EditBookApproved(),
            IntegrationAction.Denied => new EditBookApproved(),
            _ => new NoOperation()
        };
}