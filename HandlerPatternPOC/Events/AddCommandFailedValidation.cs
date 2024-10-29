using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Events;

public record AddCommandFailedValidation(string message) : Message;
