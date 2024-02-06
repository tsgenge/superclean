using SuperClean.Application.Aggregates.Users;

namespace SuperClean.Storage.CosmosDb
{
    public class AggregateHydrator<TAggregate> : IAggregateHydrator<TAggregate, Guid>
    {
        public Task<TAggregate> HydrateAsync(Guid key)
        {
            var events = new List<Event>();
            return Task.FromResult(new UserAggregate(events));
        }
    }
}
