namespace HandlerPatternPOC.Authorizers;

public class DataAuthorizer : IAuthorizer
{
    public AuthorizationResult Authorize()
    {
        return new AuthorizationResult();
    }
}
