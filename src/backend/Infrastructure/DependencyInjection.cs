using System.Reflection;
using System.Text;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
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
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]))
        });
        return services;
    }
}