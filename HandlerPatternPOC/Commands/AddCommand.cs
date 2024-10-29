using HandlerPatternPOC.Messages;

namespace HandlerPatternPOC.Commands;

public record AddCommand(int id, int id2, string value, string value2)
    : Message;
