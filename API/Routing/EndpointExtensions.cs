using EventSourcing.Application.Items.Commands;
using EventSourcing.Application.Items.Queries;
using MediatR;
using TinyFp.Extensions;

namespace EventSourcing.Api.Routing;
internal static class EndpointExtensions
{
    private static readonly Delegate GetItemAsync =
        async (IMediator mediator, [AsParameters] GetItemsQuery query) => await mediator.Send(query);
    private static readonly Delegate GetItemByIdAsync =
        async (IMediator mediator, [AsParameters] GetItemByIdQuery query) => await mediator.Send(query);
    private static readonly Delegate PostItemAsync =
        async (IMediator mediator, CreateItemCommand command) => await mediator.Send(command);
    private static readonly Delegate PutItemAsync =
        async (IMediator mediator, UpdateItemCommand command) => await mediator.Send(command);
    private static readonly Delegate DeleteItemAsync =
        async (IMediator mediator, [AsParameters] DeleteItemByIdCommand command) => await mediator.Send(command);


    internal static WebApplication MapECommerceEndpoints(this WebApplication app) =>
        app.MapItemsManagementEndpoints();

    private static WebApplication MapItemsManagementEndpoints(this WebApplication app) =>
        app
            .Tee(_ => _.MapGet("/items", GetItemAsync))
            .Tee(_ => _.MapGet("/items/{id}", GetItemByIdAsync))
            .Tee(_ => _.MapPost("/item", PostItemAsync))
            .Tee(_ => _.MapPut("/item", PutItemAsync))
            .Tee(_ => _.MapDelete("/item/{id}", DeleteItemAsync))
            ;
}
