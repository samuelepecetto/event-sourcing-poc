using EventSourcing.Application.Items.Models;

namespace EventSourcing.Application.Items.Events;
public record ItemCreated(Guid Id, string DisplayName, decimal Price, ItemCategory Category);
public record ItemUpdated(Guid Id, string DisplayName, decimal Price, ItemCategory Category);
