namespace RoutingApp.BookActivityOperations;

public class NoOperation : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("NoOperation");
    }
}