using Application.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class ServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContextFactory<EfContext>(
            dbContextOptions => dbContextOptions
                .UseMySql("server=localhost;port=4310;database=MigrationsTestProject;user=root;password=root",
                    new MariaDbServerVersion("11.3.2-jammy"), options => options.EnableRetryOnFailure())
        );
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}