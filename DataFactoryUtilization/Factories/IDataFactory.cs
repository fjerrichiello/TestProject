namespace DataFactoryUtilization.Factories;

public interface IDataFactory
{
    Task<HandlerOneData> GetDataAsync(object command);
}
