using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ClothingStore.Persistence.Context
{
    public class ClothingAppDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            IConfigurationRoot configuration = configurationBuilder
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ClothingStore.API"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();
            Console.WriteLine(Directory.GetCurrentDirectory());

            string connectionString = configuration.GetConnectionString("DeveloperConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
