using ClothingStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Persistence.Seed
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            var items = SeedData.GetItems();

            await context.Items.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }
    }
}
