using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Verifiers;

public record FailedVerificationResult<TEvent>(
    TEvent message,
    IEventPublisher _eventPublisher) : IMessageVerifierResult
    where TEvent : Message
{
    public async Task ExecuteAsync<TMessage, TMetadata>(
        MessageContainer<TMessage, TMetadata> container)
        where TMessage : Message
        where TMetadata : MessageMetadata
    {
        await _eventPublisher.PublishAsync(message);
    }
}
