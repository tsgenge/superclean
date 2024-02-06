using SuperClean.Application.Infrastructure;
using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Shared.CommandHandlers
{
    internal class StoringCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _inner;
        private readonly IEventWriterStore _eventWriter;

        public StoringCommandHandler(ICommandHandler<TCommand> inner, IEventWriterStore eventWriter)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _eventWriter = eventWriter ?? throw new ArgumentNullException(nameof(eventWriter));
        }

        public async Task<IEnumerable<IEvent>> HandleAsync(TCommand command)
        {
            var events = await _inner.HandleAsync(command);

            foreach (var evt in events)
            {
                _eventWriter.Add(evt);
            }

            await _eventWriter.SaveAsync();

            return events;
        }
    }
}
