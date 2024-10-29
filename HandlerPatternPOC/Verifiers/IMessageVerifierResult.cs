using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Verifiers;

public interface IMessageVerifierResult
{
    Task ExecuteAsync<TMessage, TMetadata>(
        MessageContainer<TMessage, TMetadata> container)
        where TMessage : Message
        where TMetadata : MessageMetadata;
}
