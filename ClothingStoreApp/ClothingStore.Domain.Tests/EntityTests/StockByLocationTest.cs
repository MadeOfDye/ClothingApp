using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class StockByLocationTest
    {

        [Fact]
        public void Constructor_WithValidQuantity_ShouldInitializeProperties()
        {
            int quantity = 10;
            Location location = new Location(123.2, 123.3);
            StockByLocation stock = new StockByLocation(quantity, location);
            Assert.Equal(quantity, stock.Stock);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1000)]
        public void Constructor_WithNegativeQuantity_ShouldThrowArgumentException(int quantity)
        {
            Location location = new Location(123.2, 123.3);
            Assert.Throws<ArgumentException>(() => new StockByLocation(quantity, location));
        }

        [Fact]
        public void Constructor_WithNullLocation_ShouldSetLocationToNull()
        {
            int quantity = 10;
            StockByLocation stock = new StockByLocation(quantity, null);
            Assert.Null(stock.Location);
        }

        [Fact]
        public void SetLocation_WithValidLocation_ShouldUpdateLocation()
        {
            int quantity = 10;
            Location location = new Location(123.2, 123.3);
            StockByLocation stock = new StockByLocation(quantity, null);
            stock.SetLocation(location);
            Assert.Equal(location, stock.Location);
        }

        [Fact]
        public void SetLocation_WithNullLocation_ShouldThrowArgumentNullException()
        {
            int quantity = 10;
            StockByLocation stock = new StockByLocation(quantity, null);
            Assert.Throws<ArgumentNullException>(() => stock.SetLocation(null));
        }
    }
}
