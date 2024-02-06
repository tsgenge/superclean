using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Shared.CommandHandlers
{
    public abstract class CommandHandlerBase<TCommand, TAggregate> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TAggregate : IAggregate
    {
        private readonly IAggregateHydrator<TAggregate> _hydrator;

        protected CommandHandlerBase(IAggregateHydrator<TAggregate> hydrator)
        {
            _hydrator = hydrator ?? throw new ArgumentNullException(nameof(hydrator));
        }

        public async Task<IEnumerable<IEvent>> HandleAsync(TCommand command)
        {
            var aggregate = await _hydrator.HydrateAsync(command.AggregateId);
            await ExecuteCommandAsync(aggregate, command);
            return aggregate.Events;
        }

        protected abstract Task ExecuteCommandAsync(TAggregate aggregate, TCommand command);
    }
}
