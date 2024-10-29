using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Verifiers;

using System.Threading.Tasks;

public interface IMessageContainerVerifier<TMessage, TMetadata>
    where TMessage : Message
    where TMetadata : MessageMetadata
{
    Task<IMessageVerifierResult> VerifyAsync(
        MessageContainer<TMessage, TMetadata> container);
}
