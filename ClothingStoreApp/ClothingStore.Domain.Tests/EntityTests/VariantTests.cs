using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class VariantTests
    {
        [Fact]
        public void Constructor_WithValidColor_ShouldInitializeProperty()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Assert.Equal(color, variant.Color);
        }
        [Fact]
        public void Constructor_WithNullColor_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Variant(null!));
        }
        [Fact]
        public void UpdateColor_WithValidColor_ShouldUpdateProperty()
        {
            Color initialColor = Color.FromHex("#faffff");
            Color newColor = Color.FromHex("#123456");
            Variant variant = new Variant(initialColor);
            variant.UpdateColor(newColor);
            Assert.Equal(newColor, variant.Color);
        }
        [Fact]
        public void UpdateColor_WithNullColor_ShouldThrowArgumentNullException()
        {
            Color initialColor = Color.FromHex("#faffff");
            Variant variant = new Variant(initialColor);
            Assert.Throws<ArgumentNullException>(() => variant.UpdateColor(null!));
        }
        [Fact]
        public void AddPhoto_WithValidPhoto_ShouldAddToGallery()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Photo photo = new Photo("assets/photo.jpg", "A random photo");
            variant.AddPhoto(photo);
            Assert.Contains(photo, variant.Gallery);
        }

        [Fact]
        public void AddLocation_WithValidLocation_ShouldAddToAvailableLocations()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Size size = new Size("M");

            AvailableLocationBySize location = new AvailableLocationBySize(size);
            variant.AddLocation(location);

            Assert.Contains(location, variant.AvailableLocations);
        }

        [Fact]
        public void AddLocation_WithDuplicateLocation_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Size size = new Size("M");
            AvailableLocationBySize location1 = new AvailableLocationBySize(size);
            variant.AddLocation(location1);
            Assert.Throws<InvalidOperationException>(() => variant.AddLocation(location1));
        }
        [Fact]
        public void RemoveLocation_WithValidLocationId_ShouldRemoveFromAvailableLocations()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Size size = new Size("M");
            AvailableLocationBySize location = new AvailableLocationBySize(size);
            variant.AddLocation(location);
            variant.RemoveLocation(location.AvailableLocationBySizeId);
            Assert.DoesNotContain(location, variant.AvailableLocations);
        }
        [Fact]
        public void RemoveLocation_WithInvalidLocationId_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Assert.Throws<InvalidOperationException>(() => variant.RemoveLocation(Guid.NewGuid()));
        }
        [Fact]
        public void RemovePhoto_WithValidPhotoId_ShouldRemoveFromGallery()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Photo photo = new Photo("assets/photo.jpg", "A random photo");
            variant.AddPhoto(photo);
            variant.RemovePhoto(photo.PhotoId);
            Assert.DoesNotContain(photo, variant.Gallery);
        }
        [Fact]
        public void RemovePhoto_WithInvalidPhotoId_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Assert.Throws<InvalidOperationException>(() => variant.RemovePhoto(Guid.NewGuid()));
        }
        [Fact]
        public void RemovePhoto_WithPhotoNotInGallery_ShouldThrowInvalidOperationException()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Photo photo = new Photo("assets/photo.jpg", "A random photo");
            Assert.Throws<InvalidOperationException>(() => variant.RemovePhoto(photo.PhotoId));
        }
        [Fact]
        public void TotalQuantity_ShouldReturnSumOfAvailableLocations()
        {
            Color color = Color.FromHex("#faffff");
            Variant variant = new Variant(color);
            Size size1 = new Size("M");
            Size size2 = new Size("L");
            AvailableLocationBySize availableLocation1 = new AvailableLocationBySize(size1);
            AvailableLocationBySize availableLocation2 = new AvailableLocationBySize(size2);
            Location location1 = new Location(123.0, 123.1);
            StockByLocation stock1 = new StockByLocation(10, location1);
            Location location2 = new Location(123.2, 123.3);
            StockByLocation stock2 = new StockByLocation(5, location2);

            availableLocation1.AddStock(stock1);
            availableLocation2.AddStock(stock2);
            variant.AddLocation(availableLocation1);
            variant.AddLocation(availableLocation2);

            Assert.Equal(15, variant.TotalQuantity);
        }
    }
}
