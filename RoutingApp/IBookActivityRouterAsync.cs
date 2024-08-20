using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public interface IBookActivityRouterAsync
{
    Task<IBookActivityOperation> GetOperation(RouterParameters parameters);
}