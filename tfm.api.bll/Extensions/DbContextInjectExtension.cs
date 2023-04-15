using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tfm.api.dal.Db;

namespace tfm.api.bll.Extensions;

public static class DbContextInjectExtension
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection serviceCollection, string connString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connString));

        return serviceCollection;
    }
}