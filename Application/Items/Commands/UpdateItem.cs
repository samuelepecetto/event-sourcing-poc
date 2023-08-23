using EventSourcing.Application.Common;
using EventSourcing.Application.Items.Events;
using EventSourcing.Application.Items.Models;
using EventStore.Client;
using MediatR;

namespace EventSourcing.Application.Items.Commands;
public record UpdateItemCommand(ExistingItem Item) : IRequest;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly EventStoreClient _client;

    public UpdateItemCommandHandler(EventStoreClient client) => _client = client;
    public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var @event = new ItemUpdated(request.Item.Id,
                                     request.Item.DisplayName,
                                     request.Item.Price,
                                     request.Item.Category);

        await _client.AppendMessage(@event);
    }
}
