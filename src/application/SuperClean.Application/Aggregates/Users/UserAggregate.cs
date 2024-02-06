using SuperClean.Application.Aggregates.Users.Commands;
using SuperClean.Application.Aggregates.Users.Entities;
using SuperClean.Application.Aggregates.Users.Events;
using SuperClean.Application.Infrastructure;
using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users
{
    public class UserAggregate : IAggregate
    {
        private List<IEvent> _events = new List<IEvent>();
        public IReadOnlyList<IEvent> Events { get { return _events; } }
        private User User { get; set; }
        public UserAggregate(List<IEvent> events)
        {
            foreach (var evt in events)
            {
                Apply(evt);
            }
        }
        public void Execute(Login command, TimeProvider provider)
        {
            //Can they login?
            if (!User.Disabled)
            {
                Apply(new LoggedIn(provider.GetUtcNow(), User.Id));
            }
        }
        public void Execute(Logoff command)
        {

        }
        public async Task ExecuteAsync(ChangeSubscription command, IServiceChargeProvider provider)
        {
            //Validate command
            //Perform command
            //Add event
        }

        private void Apply(LoggedIn @event)
        {
            User.State = UserState.LoggedIn;
            User.LastLogin = @event.When;
        }

        private void Apply(LoggedOut @event)
        {
            User.State = UserState.LoggedOut;
        }
    }
}
