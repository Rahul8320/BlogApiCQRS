using CQRSAndMediatorPattern.Domain.Repository;
using CQRSAndMediatorPattern.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAndMediatorPattern.Infra;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (connectionString == null)
        {
            throw new Exception("Connection string for blog db context not found!");
        }

        services.AddDbContext<BlogDbContext>(options => options.UseSqlite(connectionString));

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
