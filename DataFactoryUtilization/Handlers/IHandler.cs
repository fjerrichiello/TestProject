namespace DataFactoryUtilization.Handlers;

public interface IHandler
{
    Task HandleAsync(object command);
}
