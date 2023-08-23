using EventSourcing.Application.Common;
using EventSourcing.Application.Items.Events;
using EventSourcing.Application.Items.Models;
using EventStore.Client;
using MediatR;

namespace EventSourcing.Application.Items.Commands;
public record CreateItemCommand(NewItem Item) : IRequest<Guid>;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly EventStoreClient _client;

    public CreateItemCommandHandler(EventStoreClient client) => _client = client;
    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var newId = Guid.NewGuid();
        var @event = new ItemCreated(newId,
                                     request.Item.DisplayName,
                                     request.Item.Price,
                                     request.Item.Category);

        await _client.AppendMessage(@event);

        return newId;
    }
}
