﻿namespace HandlerPatternPOC.Messages;

public interface IMessageContainerHandler<TMessage, TMetadata>
    where TMessage : Message
    where TMetadata : MessageMetadata
{
    Task HandleAsync(
        MessageContainer<TMessage, TMetadata> container);
}
