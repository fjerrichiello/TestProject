using DataFactoryUtilization.Verifiers;

namespace DataFactoryUtilization.Authorizers;

public interface IAuthorizer
{
    public AuthorizationResult Authorize();
}
