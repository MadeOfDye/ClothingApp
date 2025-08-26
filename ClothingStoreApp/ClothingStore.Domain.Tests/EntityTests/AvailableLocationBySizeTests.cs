using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class AvailableLocationBySizeTests
    {
        [Fact]
        public void CreateAvailableLocationBySize_WithValidSize_ShouldSucceed()
        {
            // Arrange
            Size size = new HatSize("M", 28);
            // Act
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);
            // Assert
            Assert.NotNull(availableLocationBySize);
            Assert.Equal(size, availableLocationBySize.Size);
            Assert.NotEqual(Guid.Empty, availableLocationBySize.AvailableLocationBySizeId);
        }

        [Fact]
        public void CreateAvailableLocationBySize_WithNullSize_ShouldThrowArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AvailableLocationBySize(null));
        }

        [Fact]
        public void AddStock_ValidStock_ShouldAddStock()
        {
            // Arrange
            Size size = new HatSize("L", 30);
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);
            Location location = new Location(123, 123, "Warehouse A");
            StockByLocation stock = new StockByLocation(10, location);
            // Act
            availableLocationBySize.AddStock(stock);
            // Assert
            Assert.Contains(stock, availableLocationBySize.AvailableLocationsOfGivenSize);
        }

        [Fact]
        public void AddStock_NullStock_ShouldThrowArgumentNullException()
        {
            Size size = new DressSize("L", 30f, 12f, 32f);
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);

            Assert.Throws<ArgumentNullException>(() => availableLocationBySize.AddStock(null));
        }

        [Fact]
        public void AddStock_DuplicateStock_ShouldThrowInvalidOperationException()
        {
            Size size = new DressSize("M", 28f, 10f, 30f);
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);
            Location location = new Location(156, 156, "Warehouse B");
            StockByLocation stock = new StockByLocation(5, location);
            availableLocationBySize.AddStock(stock);
            Assert.Throws<InvalidOperationException>(() => availableLocationBySize.AddStock(stock));
        }

        [Fact]
        public void RemoveStock_ValidStockId_ShouldRemoveStock()
        {
            Size size = SizeFactory.CreateShirtSize("S", 30f, 20f, 11f, 22f);
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);
            Location location = new Location(149, 149, "Warehouse C");
            StockByLocation stock = new StockByLocation(15, location);
            availableLocationBySize.AddStock(stock);
            availableLocationBySize.RemoveStock(stock.StockByLocationId);
            Assert.DoesNotContain(stock, availableLocationBySize.AvailableLocationsOfGivenSize);
        }

        [Fact]
        public void RemoveStock_StockIdNotInCollection_ShouldThrowInvalidOperationException()
        {
            Size size = SizeFactory.CreateShoeSizeWithHeels("L", 23f, 21f, 11f);
            AvailableLocationBySize availableLocationBySize = new AvailableLocationBySize(size);
            Location location = new Location(101, 102, "Warehouse D");
            StockByLocation stock = new StockByLocation(20, location);

            Assert.Throws<InvalidOperationException>(() => availableLocationBySize.RemoveStock(stock.StockByLocationId));
        }
    }
}
