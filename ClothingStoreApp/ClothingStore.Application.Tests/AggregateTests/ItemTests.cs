using ClothingStore.Application.Aggregates.Item.Query;
using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;
using ClothingStore.Application.Tests.TestIQueryableAsyncExtension;

namespace ClothingStore.Application.Tests.AggregateTests
{
    public class ItemTests
    {
        private readonly Mock<IItemRepository> _itemRepositoryMock;
        private readonly ItemQueryHandler _itemQueryHandler;

        public ItemTests()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemQueryHandler = new ItemQueryHandler(_itemRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllItemsQuery_ShouldReturnItems()
        {
            var items = new List<Item>
            {
                new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water"),
                new Item("Jeans", "Stylish jeans", 49.99m, "BrandB", "WinterCollection", "Machine Wash Cold")
            };

            // Create an async-compatible queryable
            var asyncQueryable = new TestAsyncEnumerable<Item>(items);

            _itemRepositoryMock
                .Setup(r => r.Query(It.IsAny<Expression<Func<Item, bool>>>()))
                .Returns((Expression<Func<Item, bool>> expr) =>
                    expr == null ? asyncQueryable : asyncQueryable.Where(expr));

            var query = new GetAllItemsQuery();
            var result = await _itemQueryHandler.Handle(query);

            Assert.Equal(2, result.TotalNumberOfRecords);
            Assert.Contains(result.Records, r => r.Name == "T-Shirt");
            Assert.Contains(result.Records, r => r.Name == "Jeans");
        }

        [Fact]
        public async Task GetItemByIdQuery_ShouldReturnItem_WhenItemExists()
        {
            var item = new Item("T-Shirt", "A cool t-shirt", 19.99m, "BrandA", "SummerCollection", "Wash With Warm Water");
            var itemId = item.ItemId;

            var items = new List<Item> { item };
            var asyncQueryable = new TestAsyncEnumerable<Item>(items);

            _itemRepositoryMock
                .Setup(r => r.Query(It.IsAny<Expression<Func<Item, bool>>>()))
                .Returns((Expression<Func<Item, bool>> expr) =>
                    expr == null ? asyncQueryable : asyncQueryable.Where(expr));

            var query = new GetItemByIdQuery { Id = itemId };
            var result = await _itemQueryHandler.Handle(query);

            Assert.NotNull(result);
            Assert.Equal("T-Shirt", result.Name);
            Assert.Equal("A cool t-shirt", result.Description);
            Assert.Equal(19.99m, result.Price);
            Assert.Equal("BrandA", result.Brand);
            Assert.Equal("SummerCollection", result.Collection);
            Assert.Equal("Wash With Warm Water", result.CareGuide);
            Assert.Equal(0, result.Discount);
            Assert.False(result.Hot);
            Assert.False(result.LastChance);
            Assert.Equal(itemId, result.ItemId);
        }
    }
}