using SuperClean.Application.Shared.Models;

namespace SuperClean.Application.Shared.Interfaces
{
    public interface ICommand
    {
        Guid AggregateId { get; }
        ClaimUser Actor { get; }
    }
}
