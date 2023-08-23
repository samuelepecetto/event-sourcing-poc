using EventSourcing.Application.Common.Events;

namespace EventSourcing.Application.Items.Events;
public interface IItemEvents : IEvent
{
    public const string StreamName = "Items";
}
