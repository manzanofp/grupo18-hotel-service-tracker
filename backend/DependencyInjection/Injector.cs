using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace DependencyInjection;

public static class Injector
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.RegisterServices(configuration);
        
        return services;
    }

    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITicketService, TicketService>();

        ConfigurePostgresSql<ApplicationDbContext>(services, configuration);
    }

    private static void ConfigurePostgresSql<T>(IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            var connectionString = configuration.GetConnectionString("PostgresSql") ?? throw new Exception("Not found ConnectionString for PostgresSql");
            options.UseNpgsql(connectionString);
        });
    }
}