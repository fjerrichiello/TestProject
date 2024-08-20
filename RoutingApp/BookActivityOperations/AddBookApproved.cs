namespace RoutingApp.BookActivityOperations;

public class AddBookApproved : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("AddBookApproved");
    }
}