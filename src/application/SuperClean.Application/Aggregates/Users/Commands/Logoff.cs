﻿using SuperClean.Application.Shared.Interfaces;
using SuperClean.Application.Shared.Models;

namespace SuperClean.Application.Aggregates.Users.Commands
{
    public record Logoff(Guid UserId, ClaimUser Actor) : ICommand
    {
        public Guid AggregateId { get; } = UserId;
    }
}
