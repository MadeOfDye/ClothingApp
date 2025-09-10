using ClothingStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Persistence.Seed
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Only seed if no items exist
            if (!await context.Items.AnyAsync())
            {
                var items = SeedData.GetItems();

                await context.Items.AddRangeAsync(items);
                await context.SaveChangesAsync();
            }
        }
    }
}
