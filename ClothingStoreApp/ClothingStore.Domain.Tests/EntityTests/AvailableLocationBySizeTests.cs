namespace ClothingStore.Domain.Tests.EntityTests
{
    using ClothingStore.Domain.Entities;
    using ClothingStore.Domain.ValueObjects;    

    public class AvailableLocationBySizeTests
    {
        [Fact]
        public void Constructor_WithValidSize_ShouldInitializeProperties()
        {
            Size size = new Size("M");
            AvailableLocationBySize availableLocation = new AvailableLocationBySize(size);
            Assert.Equal(size, availableLocation.Size);
            Assert.Empty(availableLocation.AvailableLocationsOfGivenSize);
        }

        [Fact]
        public void Constructor_WithNullSize_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AvailableLocationBySize(null));
        }

        [Fact]
        public void AddStock_WithValidStock_ShouldAddToAvailableLocations()
        {
            Size size = new Size("M");
            AvailableLocationBySize availableLocation = new AvailableLocationBySize(size);
            Location location = new Location(123.2, 123.3);
            StockByLocation stock = new StockByLocation(10, location);
            availableLocation.AddStock(stock);
            Assert.Contains(stock, availableLocation.AvailableLocationsOfGivenSize);
            Assert.Equal(10, availableLocation.TotalStockOfSize);
        }

        [Fact]
        public void AddStock_WithNullStock_ShouldThrowArgumentNullException()
        {
            Size size = new Size("M");
            AvailableLocationBySize availableLocation = new AvailableLocationBySize(size);
            Assert.Throws<ArgumentNullException>(() => availableLocation.AddStock(null));
        }
    }
}
