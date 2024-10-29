using HandlerPatternPOC.Messages;
using HandlerPatternPOC.Processors;
using HandlerPatternPOC.Verifiers;

namespace HandlerPatternPOC.Handlers;

public record AddCommandVerificationResult(
    AddCommandValidData data,
    IProcessor processor) : IMessageVerifierResult
{
    public async Task ExecuteAsync<TMessage, TMetadata>(
        MessageContainer<TMessage, TMetadata> container)
        where TMessage : Message
        where TMetadata : MessageMetadata
    {
        await processor.ProcessAsync(data);
    }
}
