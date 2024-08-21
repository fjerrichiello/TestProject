namespace RoutingApp;

public interface IMetadataAccessor
{
    string Metadata { get; set; }
}

public class MetadataAccessor : IMetadataAccessor
{
    private string? _metadata;

    public string Metadata
    {
        get => _metadata ?? string.Empty;
        set => _metadata = value;
    }
}