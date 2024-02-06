using SuperClean.Application.Shared.Interfaces;

namespace SuperClean.Application.Infrastructure
{
    public interface IEventWriterStore
    {
        void Add(IEvent @event);
        Task SaveAsync();
    }
}
