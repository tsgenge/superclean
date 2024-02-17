using SuperClean.Application.Aggregates.Users.Commands;
using SuperClean.Application.Aggregates.Users.Entities;
using SuperClean.Application.Aggregates.Users.Events;
using SuperClean.Application.Aggregates.Users.ValueObjects;
using SuperClean.Application.Infrastructure;
using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users
{
    public class UserAggregate : AggregateBase, IAggregate
    {
        private List<IEvent> _events = new List<IEvent>();
        public IReadOnlyList<IEvent> Events { get { return _events; } }
        private User User { get; set; }
        private Subscription Subscription { get; set; }
        public UserAggregate(List<IEvent> events)
        {
            User = new User();
            Subscription = new Subscription(SubscriptionId.Empty());
            foreach (var evt in events)
            {
                Apply(evt);
            }
        }
        public void Execute(Login command, TimeProvider provider)
        {
            if (!User.Disabled)
            {
                Apply(new LoggedIn(provider.GetUtcNow(), User.Id));
            }
        }
        public void Execute(Logoff command)
        {
            if (!User.Disabled && User.State == UserState.LoggedIn)
            {
                Apply(new LoggedOut(command.When));
            }
        }

        public async Task ExecuteAsync(ChangeSubscription command, IServiceChargeProvider provider)
        {
            var subscriptionId = await provider.ChangeSubscriptionAsync(command.AggregateId, command.SubscriptionName);
            Apply(new SubscriptionChanged(command.When, command.AggregateId, subscriptionId));
        }

        private void Apply(LoggedIn @event)
        {
            User.State = UserState.LoggedIn;
            User.LastLogin = @event.When;
            _events.Add(@event);
        }

        private void Apply(LoggedOut @event)
        {
            User.State = UserState.LoggedOut;
            _events.Add(@event);
        }

        private void Apply(SubscriptionChanged @event)
        {
            Subscription = new Subscription(new(@event.SubscriptionId));
            _events.Add(@event);
        }
    }
}
