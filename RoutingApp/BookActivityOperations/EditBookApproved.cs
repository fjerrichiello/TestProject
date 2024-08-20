namespace RoutingApp.BookActivityOperations;

public class EditBookApproved : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("EditBookApproved");
    }
}