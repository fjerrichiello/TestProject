namespace RoutingApp.BookActivityOperations;

public class EditBookDenied : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("EditBookDenied");
    }
}