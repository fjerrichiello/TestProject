namespace HandlerPatternPOC.Authorizers;

public interface IAuthorizer
{
    public AuthorizationResult Authorize();
}
