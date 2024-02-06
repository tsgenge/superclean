using SuperClean.Application.Shared.CommandHandlers;
using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users.Commands
{
    internal class LoginCommandHandler : CommandHandlerBase<Login, UserAggregate>
    {
        private readonly TimeProvider _timeProvider;

        public LoginCommandHandler(TimeProvider timeProvider, IAggregateHydrator<UserAggregate> hydrator) : base(hydrator)
        {
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        protected override Task ExecuteCommandAsync(UserAggregate aggregate, Login command)
        {
            aggregate.Execute(command, _timeProvider);
            return Task.CompletedTask;
        }
    }
}
