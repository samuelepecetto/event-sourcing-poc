using System.Text.Json;
using EventSourcing.Application.Items.Events;
using EventStore.Client;

namespace EventSourcing.Application.Common;
public static class EventStoreClientExtensions
{
    public static async Task AppendMessage<T>(this EventStoreClient client, T @event)
    {
        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(@event);

        var eventData = new EventData(Uuid.NewUuid(),
                                      typeof(T).Name,
                                      utf8Bytes.AsMemory());
        var writeResult = await client.AppendToStreamAsync(IItemEvents.StreamName,
                                                  StreamState.Any,
                                                  new[] { eventData });
    }
}
