using ClothingStore.Domain.Entities;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class PhotoTests
    {
        [Fact]
        public void CreatePhoto_WithValidParameters_ShouldSucceed()
        {
            string url = "http://example.com/photo.jpg";
            string description = "A sample photo";
            Photo photo = new Photo(url, description);
            Assert.NotNull(photo);
            Assert.Equal(url, photo.Url);
            Assert.Equal(description, photo.Description);
            Assert.NotEqual(Guid.Empty, photo.PhotoId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CreatePhoto_WithInvalidUrl_ShouldThrowArgumentNullException(string invalidUrl)
        {
            string description = "A sample photo";
            Assert.Throws<ArgumentNullException>(() => new Photo(invalidUrl, description));
        }

        [Fact]
        public void UpdateURL_WithValidURL_ShouldSucceed()
        {
            string initialUrl = "http://example.com/initial.jpg";
            string newUrl = "http://example.com/new.jpg";
            string description = "A sample photo";

            Photo photo = new Photo(initialUrl, description);

            photo.UpdateUrl(newUrl);
            Assert.Equal(newUrl, photo.Url);
        }
    }
}
