using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    public class LocationTests
    {
        [Fact]
        public void CreateLocation_WithValidParameters_ShouldSucceed()
        {
            string address = "New York";
            double latitude = 40.7128;
            double longitude = -74.0060;

            Location location = new Location(latitude, longitude, address);

            Assert.NotNull(location);
            Assert.Equal(address, location.Address);
            Assert.Equal(latitude, location.Latitude);
            Assert.Equal(longitude, location.Longitude);
        }
    }
}
