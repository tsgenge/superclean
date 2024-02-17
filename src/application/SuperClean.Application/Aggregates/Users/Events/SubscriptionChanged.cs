using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users.Events
{
    internal record SubscriptionChanged(DateTimeOffset When, Guid UserId, Guid SubscriptionId) : IEvent
    {
    }
}
