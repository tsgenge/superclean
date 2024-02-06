namespace SuperClean.Application.Shared.Interfaces
{
    internal interface ICommandHandler<TCommand>
    {
        Task<IEnumerable<IEvent>> HandleAsync(TCommand command);
    }
}
