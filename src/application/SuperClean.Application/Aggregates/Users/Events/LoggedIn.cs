using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users.Events
{
    internal record LoggedIn(DateTimeOffset When, Guid UserId) : IEvent;
}
