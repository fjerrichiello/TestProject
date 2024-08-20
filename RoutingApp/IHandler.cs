namespace RoutingApp;

public interface IHandler
{
    public Task UseHandler(Command command);
}