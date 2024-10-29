using DataFactoryUtilization.Verifiers;

namespace DataFactoryUtilization.Authorizers;

public class DataAuthorizer : IAuthorizer
{
    public AuthorizationResult Authorize()
    {
        return new AuthorizationResult();
    }
}
