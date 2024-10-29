using HandlerPatternPOC.Messages;
using HandlerPatternPOC.Verifiers;

namespace HandlerPatternPOC.Processors;

public class AddCommandProcessor : IMessageVerifierResult
{
    public async Task ExecuteAsync<TMessage, TMetadata>(MessageContainer<TMessage, TMetadata> container) where TMessage : Message where TMetadata : MessageMetadata
    {
        throw new NotImplementedException();
    }
}
