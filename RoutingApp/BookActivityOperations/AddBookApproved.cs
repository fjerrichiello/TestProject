using RoutingApp.DummyResources;

namespace RoutingApp.BookActivityOperations;

public class AddBookApproved(IRepository1 repository1, IMetadataAccessor metadataAccessor) : IBookActivityOperation
{
    public async Task DoOperation()
    {
        Console.WriteLine("AddBookApproved");
        Console.WriteLine(metadataAccessor.Metadata);
        await repository1.GetValue();
    }
}