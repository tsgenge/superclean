namespace SuperClean.Application.Shared.Interfaces
{
    public interface IAggregateHydrator<TAggregate>
    {
        Task<TAggregate> HydrateAsync(Guid key);
    }
}
