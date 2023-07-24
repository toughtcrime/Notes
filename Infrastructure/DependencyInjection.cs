using System.Reflection;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, 
                                        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MainConnection");
        var jwtSection = config.GetSection("Jwt");
        services.AddDbContext<MainDbContext>(options => 
            options.UseNpgsql(connectionString, x => 
                x.MigrationsAssembly(typeof(DependencyInjection).Assembly.GetName().Name)));
        
        services.AddJwt();
        services.Configure<JwtOptions>(jwtSection);
        services.ConfigureOptions<JwtOptionsSetup>();
        

    }
}