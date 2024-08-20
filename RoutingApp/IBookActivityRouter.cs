using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public interface IBookActivityRouter
{
    Task<IBookActivityOperation> GetOperation(RouterParameters parameters);
}