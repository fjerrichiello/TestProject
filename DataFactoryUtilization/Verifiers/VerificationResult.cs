using DataFactoryUtilization.Authorizers;
using DataFactoryUtilization.Validators;

namespace DataFactoryUtilization.Verifiers;

public class VerificationResult<TResult>
{
    public bool Success { get; private set; } = true;

    public TResult? SuccessResult { get; set; }
    public AuthorizationResult? AuthorizationResult { get; private set; }
    public ValidationResult? ValidationResult { get; private set; }

    public void Authorize(IAuthorizer authorizer)
    {
        var result = authorizer.Authorize();

        if (result.IsAuthorized)
        {
            return;
        }

        AuthorizationResult = result;
        Success = false;
    }

    public void Validate(IValidator validator)
    {
        var result = validator.Validate();

        if (result.IsValid)
        {
            return;
        }

        ValidationResult = result;
        Success = false;
    }
}
