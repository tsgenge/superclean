using SuperClean.Application.Shared.CommandHandlers;
using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users.Commands
{
    internal class LogoffCommandHandler : CommandHandlerBase<Logoff, UserAggregate>
    {
        public LogoffCommandHandler(IAggregateHydrator<UserAggregate> hydrator) : base(hydrator)
        {
        }

        protected override Task ExecuteCommandAsync(UserAggregate aggregate, Logoff command)
        {
            aggregate.Execute(command);
            return Task.CompletedTask;
        }
    }
}
