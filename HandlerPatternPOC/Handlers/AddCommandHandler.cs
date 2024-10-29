using HandlerPatternPOC.Commands;
using HandlerPatternPOC.Messages;
using HandlerPatternPOC.Verifiers;

namespace HandlerPatternPOC.Handlers;

public class
    AddCommandHandler(
        IMessageContainerVerifier<AddCommand, CommandMetadata> verifier)
    : MessageContainerHandler<AddCommand, CommandMetadata>
{
    protected override async Task HandleInternalAsync(
        MessageContainer<AddCommand, CommandMetadata> container)
    {
        var result = await verifier.VerifyAsync(container);

        await result.ExecuteAsync(container);
    }
}
