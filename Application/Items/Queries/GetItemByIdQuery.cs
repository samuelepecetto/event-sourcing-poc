using MediatR;

namespace EventSourcing.Application.Items.Queries;
public record GetItemByIdQuery(Guid Id) : IRequest;
