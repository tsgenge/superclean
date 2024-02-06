using SuperClean.Application.Shared.ValueObjects;

namespace SuperClean.Application.Aggregates.Users.Entities
{
    internal class User
    {
        public Guid Id { get; private set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public MobileNumber MobileNumber { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public bool Disabled { get; set; }
        public UserState State { get; set; }
        public DateTimeOffset LastLogin { get; set; }
    }

    enum UserState
    {
        LoggedIn,
        LoggedOut,
        Disabled
    }
}
