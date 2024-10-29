using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Verifiers;

public abstract class
    MessageContainerVerifier<TMessage, TMessageMetadata> :
    IMessageContainerVerifier<TMessage,
        TMessageMetadata>
    where TMessage : Message
    where TMessageMetadata : MessageMetadata
{
    public async Task<IMessageVerifierResult> VerifyAsync(
        MessageContainer<TMessage, TMessageMetadata> container)
    {
        return await VerifyInternalAsync(container);
    }

    protected abstract Task<IMessageVerifierResult> VerifyInternalAsync(
        MessageContainer<TMessage, TMessageMetadata> container);
}
