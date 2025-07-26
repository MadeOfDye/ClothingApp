namespace ClothingStore.Domain.Tests.EntityTests
{
    using ClothingStore.Domain.Entities;
    public class PhotoTests
    {
        [Fact]
        public void Constructor_WithValidUrl_ShouldInitializeProperties()
        {

            string url = "http://example.com/photo.jpg";
            string? description = "A sample photo";
            var photo = new Photo(url, description);

            Assert.Equal(url, photo.Url);
            Assert.Equal(description, photo.Description);
        }

        [Theory]
        [InlineData(null, "asset/photo1")]
        [InlineData("", "asset/photo2")]
        public void Constructor_WithNullOrEmptyUrl_ShouldThrowArgumentException(string? url, string description)
        {
            Assert.Throws<ArgumentNullException>(() => new Photo(url, description));
        }



        [Fact]
        public void UpdateUrl_WithValidUrl_ShouldUpdateUrl()
        {
            string initialUrl = "http://example.com/photo.jpg";
            string newUrl = "http://example.com/newphoto.jpg";
            var photo = new Photo(initialUrl, null);
            photo.UpdateUrl(newUrl);
            Assert.Equal(newUrl, photo.Url);
        }

        [Fact]
        public void UpdateUrl_WithNullUrl_ShouldThrowArgumentException()
        {
            string initialUrl = "http://example.com/photo.jpg";
            var photo = new Photo(initialUrl, null);
            Assert.Throws<ArgumentException>(() => photo.UpdateUrl(null));
        }

        [Fact]
        public void UpdateUrl_WithEmptyUrl_ShouldThrowArgumentException()
        {
            string initialUrl = "http://example.com/photo.jpg";
            var photo = new Photo(initialUrl, null);
            Assert.Throws<ArgumentException>(() => photo.UpdateUrl(string.Empty));
        }
    }
}
