using Microsoft.Extensions.DependencyInjection;
using tfm.api.dal.Repos.Contracts;
using tfm.api.dal.Repos.Implementation;

namespace tfm.api.bll.Extensions;

public static class RepositoryInjectExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepo, UserRepo>();
        serviceCollection.AddScoped<IRolesRepo, RoleRepo>();
        serviceCollection.AddScoped<IStyleRepo, StyleRepo>();
        serviceCollection.AddScoped<IStylePriceRepo, StylePriceRepo>();
        serviceCollection.AddScoped<IExamplesRepo, ExamplesRepo>();
        serviceCollection.AddScoped<IMasterRepo, MasterRepo>();
        serviceCollection.AddScoped<IPhotoFileRepo, PhotoFileRepo>();
        serviceCollection.AddScoped<IScheduleRepo, ScheduleRepo>();
        serviceCollection.AddScoped<IScheduleBlockerRepo, ScheduleBlockerRepo>();

        return serviceCollection;
    }
}