using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class VariantTests
    {
        [Fact]
        public void CreateVariant_WithValidColor_ShouldSucceed()
        {
            // Arrange
            Color color = Color.FromHex("#FF5733");
            // Act
            Variant variant = new Variant(color);
            // Assert
            Assert.NotNull(variant);
            Assert.Equal(color, variant.Color);
            Assert.NotEqual(Guid.Empty, variant.VariantId);
        }

        [Fact]
        public void CreateVariant_WithNullColor_ShouldThrowArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Variant(null));
        }

        [Fact]
        public void UpdateColor_WithValidColor_ShouldSucceed()
        {
            Color initialColor = Color.FromRGB(255, 0, 0);
            Variant variant = new Variant(initialColor);
            Color newColor = Color.FromHex("#00FF00");
            variant.UpdateColor(newColor);
            Assert.Equal(newColor, variant.Color);
        }

        [Fact]
        public void UpdateColor_WithNullColor_ShouldThrowArgumentNullException()
        {
            Color color = Color.FromRGB(0, 0, 255);
            Variant variant = new Variant(color);

            Assert.Throws<ArgumentNullException>(() => variant.UpdateColor(null));
        }

        [Fact]
        public void AddPhoto_ShouldAddPhotoToGallery()
        {
            Color color = Color.FromHex("#123456");
            Variant variant = new Variant(color);
            Photo photo = new Photo("http://example.com/photo1.jpg", "a cool photo");
            variant.AddPhoto(photo);
            Assert.Contains(photo, variant.Gallery);
        }

        [Fact]
        public void AddLocation_ShouldAddLocationToAvailableLocations()
        {
            Color color = Color.FromHex("#654321");
            Variant variant = new Variant(color);
            AvailableLocationBySize location = new AvailableLocationBySize(new ShirtSize("M", 32f, 23f, 12f, 12f));
            variant.AddLocation(location);
            Assert.Contains(location, variant.AvailableLocations);
        }

        [Fact]
        public void AddLocation_DuplicateLocation_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#abcdef");
            Variant variant = new Variant(color);
            AvailableLocationBySize location = new AvailableLocationBySize(new PantSize("L", 34f, 24f));
            variant.AddLocation(location);
            Assert.Throws<InvalidOperationException>(() => variant.AddLocation(location));
        }

        [Fact]
        public void RemoveLocation_ShouldRemoveLocationFromAvailableLocations()
        {
            Color color = Color.FromHex("#fedcba");
            Variant variant = new Variant(color);
            AvailableLocationBySize location = new AvailableLocationBySize(new ShirtSize("S", 30f, 22f, 11f, 11f));
            variant.AddLocation(location);
            variant.RemoveLocation(location.AvailableLocationBySizeId);
            Assert.DoesNotContain(location, variant.AvailableLocations);
        }

        [Fact]
        public void RemoveLocation_NonExistentLocation_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#112233");
            Variant variant = new Variant(color);
            Guid nonExistentId = Guid.NewGuid();
            Assert.Throws<InvalidOperationException>(() => variant.RemoveLocation(nonExistentId));
        }
    }
}
