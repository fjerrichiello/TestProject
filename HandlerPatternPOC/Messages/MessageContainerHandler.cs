using HandlerPatternPOC.Verifiers;

namespace HandlerPatternPOC.Messages;

public abstract class
    MessageContainerHandler<TMessage, TMessageMetadata> :
    IMessageContainerHandler<TMessage,
        TMessageMetadata>
    where TMessage : Message
    where TMessageMetadata : MessageMetadata
{
    public async Task HandleAsync(
        MessageContainer<TMessage, TMessageMetadata> container)
    {
        await HandleInternalAsync(container);
    }

    protected abstract Task HandleInternalAsync(
        MessageContainer<TMessage, TMessageMetadata> container);
}
