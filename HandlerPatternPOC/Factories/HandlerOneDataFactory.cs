namespace HandlerPatternPOC.Factories;

public class HandlerOneDataFactory : IDataFactory
{
    public async Task<HandlerOneData> GetDataAsync(object command)
    {
        throw new NotImplementedException();
    }
}
