namespace HandlerPatternPOC.Processors;

public interface IProcessor
{
    Task ProcessAsync(object data);
}
