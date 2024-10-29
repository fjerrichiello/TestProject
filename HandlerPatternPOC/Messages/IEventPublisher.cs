namespace HandlerPatternPOC.Messages;

public interface IEventPublisher
{
    Task PublishAsync(Message message);
}
