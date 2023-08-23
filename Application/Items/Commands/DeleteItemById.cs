using EventSourcing.Application.Common;
using EventSourcing.Application.Items.Events;
using EventStore.Client;
using MediatR;

namespace EventSourcing.Application.Items.Commands;

public record DeleteItemByIdCommand(Guid Id) : IRequest;

public class DeleteItemByIdCommandHandler : IRequestHandler<DeleteItemByIdCommand>
{
    private readonly EventStoreClient _client;

    public DeleteItemByIdCommandHandler(EventStoreClient client) => _client = client;

    public async Task Handle(DeleteItemByIdCommand request, CancellationToken cancellationToken)
    {
        var @event = new ItemDeleted(request.Id);
        await _client.AppendMessage(@event);
    }
}
