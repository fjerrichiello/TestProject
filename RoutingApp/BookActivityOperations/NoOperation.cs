namespace RoutingApp.BookActivityOperations;

public class NoOperation : IBookActivityOperation
{
    public async Task DoOperation()
    {
        throw new NotImplementedException();
    }
}