namespace RoutingApp.BookActivityOperations;

public class AddBookDenied : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("AddBookDenied");
    }
}