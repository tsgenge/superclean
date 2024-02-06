using Microsoft.Extensions.DependencyInjection;
using SuperClean.Application.Infrastructure;

namespace SuperClean.Storage.Sql
{
    public static class CompositionRoot
    {
        public static IServiceCollection AddSqlStorage(this IServiceCollection services)
        {
            services.AddTransient<ICabbageStore, SqlCabbageStore>();
            return services;
        }
    }
}
