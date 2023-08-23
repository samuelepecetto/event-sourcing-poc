namespace EventSourcing.API.Configuration;

internal sealed class EventStoreOptions
{
    public const string SectionName = "EventStore";

    public string ConnectionString { get; set; } = string.Empty;
}
