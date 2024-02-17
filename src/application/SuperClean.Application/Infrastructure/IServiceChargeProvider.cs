namespace SuperClean.Application.Infrastructure
{
    public interface IServiceChargeProvider
    {
        Task<Guid> ChangeSubscriptionAsync(Guid userId, string subscriptionId);
    }
}
