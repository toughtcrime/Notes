using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var parent = Directory.GetParent(path: Directory.GetCurrentDirectory())
                                     .ToString();
            var basePath = Path.Combine(parent,"Presentation");
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath!)
                                .AddJsonFile("appsettings.json", optional:false)
                                .Build();

            
            var connectionString = configuration.GetConnectionString("MainConnection");
            var dbContextBuilder = new DbContextOptionsBuilder<MainDbContext>()
                .UseNpgsql(connectionString);

            return new MainDbContext(dbContextBuilder.Options);
        }
    }

}

