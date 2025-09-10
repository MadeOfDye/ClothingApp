using ClothingStore.Persistence.Context;
using ClothingStore.Persistence.Seed;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.API.APIExtentions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            await ApplicationDbContextSeed.SeedAsync(context);
        }
    }
}
