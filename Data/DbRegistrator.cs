using DbApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbApp.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
                .AddDbContext<AppDB>(opt =>
                {
                    opt.UseNpgsql(Configuration.GetConnectionString("postgresConnection"));
                })
            .AddTransient<DbInitializer>()
            ;
    }
}
