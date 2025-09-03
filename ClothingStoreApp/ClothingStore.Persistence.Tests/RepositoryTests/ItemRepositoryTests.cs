using ClothingStore.Domain.Entities;
using ClothingStore.Persistence.Context;
using ClothingStore.Persistence.Repositories;
using ClothingStore.Persistence.Tests.TestsContext;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Persistence.Tests.RepositoryTests
{
    public class ItemRepositoryTests
    {
        [Fact]
        public async Task AddAsync_SingleValidEntity_ShouldAddEntity()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            Item item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");
            Item result = await repository.AddAsync(item);
            await repository.SaveChangesAsync();
            Assert.NotNull(result);
            Assert.Equal(item.ItemId, result.ItemId);
            Assert.Equal(1, await context.Items.CountAsync());
        }

        [Fact]
        public async Task AddAsync_NullEntity_ThrowsArgumentNullException()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.AddAsync(null!));
        }

        [Fact]
        public async Task AddRangeAsync_ValidEntities_ShouldAddEntities()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold")
            };
            await repository.AddRangeAsync(items, CancellationToken.None);
            await repository.SaveChangesAsync();
            Assert.Equal(2, await context.Items.CountAsync());
        }

        [Fact]
        public async Task AddRangeAsync_NullEntities_ThrowsArgumentNullException()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.AddRangeAsync(null!, CancellationToken.None));
        }

        [Fact]
        public async Task AddRangeAsync_MixedValidAndNullEntities_ThrowsArgumentNullException()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            IEnumerable<Item> items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                null!,
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold")
            };
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.AddRangeAsync(items, CancellationToken.None));
        }

        [Fact]
        public void Delete_ValidEntity_ShouldRemoveEntity()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");

            context.Items.Add(item);
            repository.Delete(item);
            context.SaveChanges();

            Assert.Equal(0, context.Items.Count());
        }

        [Fact]
        public void Delete_NullEntity_ThrowsArgumentNullException()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            Assert.Throws<ArgumentNullException>(() => repository.Delete(null!));
        }

        [Fact]
        public async Task DeleteRangeAsync_ValidEntities_ShouldRemoveEntities()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold")
            };
            context.Items.AddRange(items);
            repository.DeleteRange(items);
            await repository.SaveChangesAsync();
            Assert.Equal(0, context.Items.Count());
        }

        [Fact]
        public async Task DeleteRangeAsync_NullEntities_ThrowsArgumentNullException()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            Assert.Throws<ArgumentNullException>(() => repository.DeleteRange(null!));
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsEntity()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");
            await repository.AddAsync(item);
            await repository.SaveChangesAsync();
            var result = await repository.GetByIdAsync(item.ItemId);
            Assert.NotNull(result);
            Assert.Equal(item.ItemId, result!.ItemId);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ReturnsNull()
        {
            using ContextFactory factory = new ContextFactory();
            ApplicationDbContext context = factory.Context;
            ItemRepository repository = new ItemRepository(context);

            var result = await repository.GetByIdAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task ListAllAsync_NoEntities_ReturnsEmptyList()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var result = await repository.ListAllAsync();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ListAllAsync_WithEntities_ReturnsAllEntities()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var result = await repository.ListAllAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task ListAsync_FilteredItems_ReturnsFilteredItems()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold"),
                new Item("Jacket", "Warm jacket", 89.99m, "BrandA", "WinterCollection", "Dry Clean Only")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var result = await repository.ListAsync(i => i.Brand == "BrandA");
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task ListAsync_NoMatchingItems_ReturnsEmptyList()
        {
            using ContextFactory factory = new ContextFactory();
            ApplicationDbContext context = factory.Context;
            ItemRepository repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold"),
                new Item("Jacket", "Warm jacket", 89.99m, "BrandA", "WinterCollection", "Dry Clean Only")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var result = await repository.ListAsync(i => i.Brand == "NonExistentBrand");
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task Query_WithFilter_ReturnsFilteredQueryable()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold"),
                new Item("Jacket", "Warm jacket", 89.99m, "BrandA", "WinterCollection", "Dry Clean Only")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var query = repository.Query(i => i.Brand == "BrandA");
            var result = await query.ToListAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Query_WithoutFilter_ReturnsAllEntities()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold"),
                new Item("Jacket", "Warm jacket", 89.99m, "BrandA", "WinterCollection", "Dry Clean Only")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var query = repository.Query();
            var result = await query.ToListAsync();
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task Query_WithInvalidFilter_ShouldReturnEmptyList()
        {
            using ContextFactory factory = new ContextFactory();
            ApplicationDbContext context = factory.Context;
            ItemRepository repository = new ItemRepository(context);
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold"),
                new Item("Jacket", "Warm jacket", 89.99m, "BrandA", "WinterCollection", "Dry Clean Only")
            };
            await repository.AddRangeAsync(items);
            await repository.SaveChangesAsync();
            var query = repository.Query(i => i.Brand == "NonExistentBrand");
            var result = await query.ToListAsync();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task Update_ExistingEntity_ShouldUpdateEntity()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            var item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");
            await repository.AddAsync(item);
            await repository.SaveChangesAsync();
            item.UpdateName("Updated T-Shirt");
            context.Items.Update(item);
            await repository.SaveChangesAsync();
            var updatedItem = await repository.GetByIdAsync(item.ItemId);
            Assert.NotNull(updatedItem);
            Assert.Equal("Updated T-Shirt", updatedItem!.Name);
        }

        [Fact]
        public async Task Update_NonExistingEntity_ShouldDoNothing()
        {
            using var factory = new ContextFactory();
            var context = factory.Context;
            var repository = new ItemRepository(context);
            Item item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");
            item.UpdateName("Updated T-Shirt");
            context.Items.Update(item);
            await repository.SaveChangesAsync();
            var result = await repository.GetByIdAsync(item.ItemId);
            Assert.Null(result);
        }
    }
}
