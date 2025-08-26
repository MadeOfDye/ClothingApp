using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;
namespace ClothingStore.Domain.Tests.EntityTests
{
    public class StockByLocationTests
    {
        [Fact]
        public void CreateStockByLocation_WithValidParameters_ShouldSucceed()
        {
            Location location = new Location(100, 200, "Main Warehouse");
            int Stock = 23;

            StockByLocation stockByLocation = new StockByLocation(Stock, location);

            Assert.NotNull(stockByLocation);
        }

        [Fact]
        public void CreateStockByLocation_WithNegativeStock_ShouldThrowArgumentException()
        {
            Location location = new Location(100, 200, "Main Warehouse");
            Assert.Throws<ArgumentException>(() => new StockByLocation(-5, location));
        }

        [Fact]
        public void SetLocation_WithValidLocation_ShouldUpdateLocation()
        {
            Location initialLocation = new Location(100, 200, "Main Warehouse");
            Location newLocation = new Location(150, 250, "Secondary Warehouse");
            StockByLocation stockByLocation = new StockByLocation(10, initialLocation);
            stockByLocation.SetLocation(newLocation);
            Assert.Equal(newLocation, stockByLocation.Location);
        }

        [Fact]
        public void SetLocation_WithNullLocation_ShouldThrowArgumentNullException()
        {
            Location initialLocation = new Location(100, 200, "Main Warehouse");
            StockByLocation stockByLocation = new StockByLocation(10, initialLocation);
            Assert.Throws<ArgumentNullException>(() => stockByLocation.SetLocation(null));
        }

        [Fact]
        public void UpdateStock_WithValidQuantity_ShouldUpdateStock()
        {
            Location location = new Location(100, 200, "Main Warehouse");
            StockByLocation stockByLocation = new StockByLocation(10, location);
            stockByLocation.UpdateStock(20);
            Assert.Equal(20, stockByLocation.Stock);
        }

        [Fact]
        public void UpdateStock_WithNegativeQuantity_ShouldThrowArgumentException()
        {
            Location location = new Location(100, 200, "Main Warehouse");
            StockByLocation stockByLocation = new StockByLocation(10, location);
            Assert.Throws<ArgumentException>(() => stockByLocation.UpdateStock(-10));
        }
    }
}
