namespace SuperClean.Application.Aggregates.Users.ValueObjects
{
    internal record SubscriptionId(Guid Id)
    {
        public static SubscriptionId Empty()
        {
            return new(Guid.Empty);
        }
    }
}
