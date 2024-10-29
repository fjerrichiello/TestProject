using HandlerPatternPOC.Authorizers;
using HandlerPatternPOC.Commands;
using HandlerPatternPOC.Events;
using HandlerPatternPOC.Factories;
using HandlerPatternPOC.Messages;
using HandlerPatternPOC.Processors;
using HandlerPatternPOC.Validators;
using HandlerPatternPOC.Verifiers;

namespace HandlerPatternPOC.Handlers;

public class AddCommandVerifier(
    IDataFactory dataFactory,
    IAuthorizer authorizer,
    IValidator validator,
    IEventPublisher eventPublisher)
    : IMessageContainerVerifier<AddCommand, CommandMetadata>
{
    public async Task<IMessageVerifierResult> VerifyAsync(
        MessageContainer<AddCommand, CommandMetadata> container)
    {
        var data = await dataFactory.GetDataAsync(container.Message);

        var authResult = authorizer.Authorize();

        if (!authResult.IsAuthorized)
        {
            return new FailedVerificationResult<AddCommandFailedAuthorization>(
                new AddCommandFailedAuthorization(authResult.ErrorMessages),
                eventPublisher);
        }

        var validResult = validator.Validate();
        if (!validResult.IsValid)
        {
            return new FailedVerificationResult<AddCommandFailedValidation>(
                new AddCommandFailedValidation(validResult.ErrorMessages),
                eventPublisher);
        }

        return new AddCommandProcessor();
    }
}
