using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Events;

public record AddCommandFailedAuthorization(string message) : Message;
