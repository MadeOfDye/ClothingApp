using ClothingStore.Domain.Entities;
namespace ClothingStore.Domain.Tests.EntityTests
{
    public class TagTests
    {
        [Fact]
        public void CreateTag_ValidName_ShouldCreateTag()
        {
            // Arrange
            string tagName = "Summer Collection";
            // Act
            var tag = new Tag(tagName, 1);
            // Assert
            Assert.NotNull(tag);
            Assert.Equal(tagName, tag.Name);
            Assert.NotEqual(Guid.Empty, tag.TagId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CreateTag_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Tag(invalidName, 1));
            Assert.Equal("Tag name cannot be null or empty (Parameter 'name')", exception.Message);
        }
    }
}
