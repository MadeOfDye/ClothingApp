using ClothingStore.Domain.Entities;

namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    public class SizeTests
    {
        [Fact]
        public void ShirtSize_ValidParameters_CreatesInstance()
        {
            var shirtSize = new ShirtSize("M", 30.5f, 18.0f, 20.0f, 25.0f);
            Assert.Equal("M", shirtSize.Letter);
            Assert.Equal(30.5f, shirtSize.Length);
            Assert.Equal(18.0f, shirtSize.ShoulderWidth);
            Assert.Equal(20.0f, shirtSize.ChestWidth);
            Assert.Equal(25.0f, shirtSize.SleeveLength);
        }
        [Fact]
        public void ShirtSize_InvalidParameters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ShirtSize("M", -30.5f, 18.0f, 20.0f, 25.0f));
            Assert.Throws<ArgumentException>(() => new ShirtSize("M", 30.5f, -18.0f, 20.0f, 25.0f));
            Assert.Throws<ArgumentException>(() => new ShirtSize("M", 30.5f, 18.0f, -20.0f, 25.0f));
            Assert.Throws<ArgumentException>(() => new ShirtSize("M", 30.5f, 18.0f, 20.0f, -25.0f));
        }
        [Fact]
        public void PantSize_ValidParameters_CreatesInstance()
        {
            var pantSize = new PantSize("32", 32.0f, 30.0f);
            Assert.Equal("32", pantSize.Letter);
            Assert.Equal(32.0f, pantSize.Waist);
            Assert.Equal(30.0f, pantSize.Inseam);
        }
        [Fact]
        public void PantSize_InvalidParameters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PantSize("32", -32.0f, 30.0f));
            Assert.Throws<ArgumentException>(() => new PantSize("32", 32.0f, -30.0f));
        }
        [Fact]
        public void ShoeSize_ValidParameters_CreatesInstance()
        {
            var shoeSize = new ShoeSize("10", 26.0f, 10.0f);
            Assert.Equal("10", shoeSize.Letter);
            Assert.Equal(26.0f, shoeSize.Length);
            Assert.Equal(10.0f, shoeSize.Width);
        }
        [Fact]
        public void ShoeSize_InvalidParameters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ShoeSize("10", -26.0f, 10.0f));
            Assert.Throws<ArgumentException>(() => new ShoeSize("10", 26.0f, -10.0f));
        }
        [Fact]
        public void ShoeSize_WithHeelHeight_ValidParameters_CreatesInstance()
        {
            var shoeSize = new ShoeSize("10", 26.0f, 10.0f, 2.0f);
            Assert.Equal("10", shoeSize.Letter);
            Assert.Equal(26.0f, shoeSize.Length);
            Assert.Equal(10.0f, shoeSize.Width);
            Assert.Equal(2.0f, shoeSize.HeelHeight);
        }
        [Fact]
        public void ShoeSize_WithHeelHeight_InvalidParameters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ShoeSize("10", -26.0f, 10.0f, 2.0f));
            Assert.Throws<ArgumentException>(() => new ShoeSize("10", 26.0f, -10.0f, 2.0f));
            Assert.Throws<ArgumentException>(() => new ShoeSize("10", 26.0f, 10.0f, -2.0f));
        }
        [Fact]
        public void Size_ValidLetter_CreatesInstance()
        {
            var size = new Size("M");
            Assert.Equal("M", size.Letter);
        }
        [Fact]
        public void Size_NullLetter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Size(null!));
        }
    }
}
