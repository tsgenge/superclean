namespace SuperClean.Application.Shared.Interfaces
{
    public interface IAggregate
    {
        IReadOnlyList<IEvent> Events { get; }
    }
}
