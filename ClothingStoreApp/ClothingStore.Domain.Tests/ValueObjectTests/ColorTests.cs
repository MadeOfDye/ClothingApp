using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    public class ColorTests
    {
        [Fact]
        public void CreateColorFromHexFactory_WithValidHex_ShouldSucceed()
        {
            // Arrange
            string hex = "#FF5733";
            // Act
            Color color = Color.FromHex(hex);
            // Assert
            Assert.NotNull(color);
            Assert.Equal(hex, color.Hexadecimal);
        }

        [Fact]
        public void CreateColorFromHexFactory_WithNullHex_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Color.FromHex(null));
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("1234567")]
        [InlineData("zasdar")]
        public void CreateColorFromHexFactory_WithInvalidHex_ShouldThrowArgumentException(string invalidHex)
        {
            Assert.Throws<ArgumentException>(() => Color.FromHex(invalidHex));
        }

        [Fact]
        public void CreateColorFromRGBFactory_WithValidRGB_ShouldSucceed()
        {
            // Arrange
            byte r = 255, g = 87, b = 51;
            // Act
            Color color = Color.FromRGB(r, g, b);
            // Assert
            Assert.NotNull(color);
            Assert.Equal("#FF5733", color.Hexadecimal);
        }
    }
}
