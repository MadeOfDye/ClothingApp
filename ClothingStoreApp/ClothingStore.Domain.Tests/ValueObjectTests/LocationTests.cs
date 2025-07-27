using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    public class LocationTests
    {
        [Fact]
        public void Constructor_ValidCoordinates_CreatesLocation()
        {
            double latitude = 40.7128;
            double longitude = -74.0060;
            string? address = "New York, NY";
            var location = new Location(latitude, longitude, address);
            Assert.Equal(latitude, location.Latitude);
            Assert.Equal(longitude, location.Longitude);
            Assert.Equal(address, location.Address);
        }
        [Theory]
        [InlineData(-200, 0)]
        [InlineData(200, 0)]
        [InlineData(0, -200)]
        [InlineData(0, 200)]
        public void Constructor_InvalidCoordinates_ThrowsArgumentOutOfRangeException(double latitude, double longitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Location(latitude, longitude));
        }
        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            var loc1 = new Location(40.7128, -74.0060);
            var loc2 = new Location(40.7128, -74.0060);
            Assert.True(loc1.Equals(loc2));
        }
        [Fact]
        public void Equals_DifferentCoordinates_ReturnsFalse()
        {
            var loc1 = new Location(40.7128, -74.0060);
            var loc2 = new Location(34.0522, -118.2437);
            Assert.False(loc1.Equals(loc2));
        }
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            var location = new Location(40.7128, -74.0060, "New York, NY");
            Assert.Equal("40.7128, -74.006, (New York, NY)", location.ToString());
        }
    }
}
