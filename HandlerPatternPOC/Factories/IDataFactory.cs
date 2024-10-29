namespace HandlerPatternPOC.Factories;

public interface IDataFactory
{
    Task<HandlerOneData> GetDataAsync(object command);
}
