using SuperClean.Application.Aggregates.Users.ValueObjects;

namespace SuperClean.Application.Aggregates.Users.Entities
{
    internal class Subscription
    {
        public SubscriptionId Id { get; private set; }
        public Subscription(SubscriptionId id)
        {
            Id = id;
        }
    }
}
