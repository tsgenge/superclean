﻿using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Aggregates.Users.Events
{
    internal record LoggedOut(DateTimeOffset When) : IEvent
    {

    }
}
