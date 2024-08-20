using RoutingApp.BookActivityOperations;

namespace RoutingApp;

public interface IBookActivityRouter
{
    IBookActivityOperation GetOperation(RouterParameters parameters);
}