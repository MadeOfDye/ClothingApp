namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    using ClothingStore.Domain.ValueObjects;
    public class ColorTests
    {
        [Fact]
        public void FromHex_ValidHex_ReturnsColor()
        {
            string hex = "#FF5733";
            var color = Color.FromHex(hex);
            Assert.Equal("FF5733", color.Hexadecimal);
            Assert.Equal(255, color.Red);
            Assert.Equal(87, color.Green);
            Assert.Equal(51, color.Blue);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("#GGGGGG")]
        [InlineData("#12345")]
        [InlineData("#1234567")]
        public void FromHex_InvalidHex_ThrowsArgumentException(string hex)
        {
            if (hex == null)
                Assert.Throws<ArgumentNullException>(() => Color.FromHex(hex));
            else
                Assert.Throws<ArgumentException>(() => Color.FromHex(hex));
        }
        [Fact]
        public void FromRGB_ValidRGB_ReturnsColor()
        {
            byte red = 255;
            byte green = 87;
            byte blue = 51;
            var color = Color.FromRGB(red, green, blue);
            Assert.Equal("FF5733", color.Hexadecimal);
            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
        }
    }
}
