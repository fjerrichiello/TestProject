namespace HandlerPatternPOC.Messages;

public record CommandMetadata(IEnumerable<string> Tags, string AuthenticatedUser, Guid RequestId) : MessageMetadata(Tags, AuthenticatedUser);
