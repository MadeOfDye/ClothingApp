using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;
using ClothingStore.Domain.Enumerators;
namespace ClothingStore.Domain.Tests.EntityTests
{
    public class ItemTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            string name = "Test Item";
            string description = "This is a test item.";
            decimal price = 99.99m;
            string brand = "Test Brand";
            string collection = "Test Collection";
            string careGuide = "Wash with care";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Assert.Equal(name, item.Name);
            Assert.Equal(price, item.Price);
            Assert.Equal(brand, item.Brand);
            Assert.Equal(collection, item.Collection);
            Assert.Equal(careGuide, item.CareGuide);
            Assert.Empty(item.Variants);
        }

        [Theory]
        [InlineData("", 12, "valid_brand", "valid_collection", "valid_care_guide")]
        [InlineData(" ", 12, "valid_brand", "valid_collection", "valid_care_guide")]
        [InlineData(null, 12, "valid_brand", "valid_collection", "valid_care_guide")]
        [InlineData("valid_name", -1, "valid_brand", "valid_collection", "valid_care_guide")]
        [InlineData("valid_name", 12, "", "valid_collection", "valid_care_guide")]
        [InlineData("valid_name", 12, " ", "valid_collection", "valid_care_guide")]
        [InlineData("valid_name", 12, null, "valid_collection", "valid_care_guide")]
        [InlineData("valid_name", 12, "valid_brand", "valid_collection", "")]
        [InlineData("valid_name", 12, "valid_brand", "valid_collection", " ")]
        [InlineData("valid_name", 12, "valid_brand", "valid_collection", null)]
        public void Constructor_WithInvalidParameters_ShouldThrowArgumentException(string name, decimal price, string brand, string collection, string careGuide)
        {
            Assert.Throws<ArgumentException>(() => new Item(name, price, brand, collection, careGuide));
        }

        [Fact]
        public void DiscountItem_WithValidDiscount_ShouldUpdateDiscount()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            decimal discount = 0.2m; // 20% discount
            item.DiscountItem(discount);
            Assert.Equal(discount, item.Discount);
        }
        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void DiscountItem_WithInvalidDiscount_ShouldThrowArgumentOutOfRangeException(decimal discount)
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Assert.Throws<ArgumentOutOfRangeException>(() => item.DiscountItem(discount));
        }
        [Fact]
        public void SetMaterialDistribution_WithValidDistribution_ShouldUpdateProperty()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            string distribution = "Cotton: 50%, Polyester: 50%";
            item.SetMaterialDistribution(distribution);
            Assert.Equal(distribution, item.MaterialDistribution);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("Invalid Distribution")]
        public void SetMaterialDistribution_WithInvalidDistribution_ShouldThrowArgumentException(string? distribution)
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Assert.Throws<ArgumentException>(() => item.SetMaterialDistribution(distribution!));
        }
        [Fact]
        public void AddVariant_WithValidVariant_ShouldAddToVariants()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant = new Variant(Color.FromHex("#FFFFFF"));
            item.AddVariant(variant);
            Assert.Contains(variant, item.Variants);
        }
        [Fact]
        public void AddVariant_WithNullVariant_ShouldThrowArgumentNullException()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Assert.Throws<ArgumentNullException>(() => item.AddVariant(null!));
        }
        [Fact]
        public void AddVariant_WithVariantAlreadyExists_ShouldThrowInvalidOperationException()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant = new Variant(Color.FromHex("#FFFFFF"));
            item.AddVariant(variant);
            Assert.Throws<InvalidOperationException>(() => item.AddVariant(variant));
        }
        [Fact]
        public void SetHot_ShouldUpdateHotProperty()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            item.SetHot(true);
            Assert.True(item.Hot);
        }
        [Fact]
        public void SetLastChance_ShouldUpdateLastChanceProperty()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            item.SetLastChance(true);
            Assert.True(item.LastChance);
        }

        [Fact]
        public void TotalStock_ShouldReturnSumOfAllVariantQuantities()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant1 = new Variant(Color.FromHex("#FFFFFF"));
            AvailableLocationBySize location1 = new AvailableLocationBySize(new Size("M"));
            location1.AddStock(new StockByLocation(10, new Location(123.0, 123.1)));
            variant1.AddLocation(location1);
            Variant variant2 = new Variant(Color.FromHex("#000000"));
            AvailableLocationBySize location2 = new AvailableLocationBySize(new Size("L"));
            location2.AddStock(new StockByLocation(5, new Location(123.2, 123.3)));
            variant2.AddLocation(location2);
            item.AddVariant(variant1);
            item.AddVariant(variant2);
            Assert.Equal(15, item.TotalStock);
        }
        [Fact]
        public void TotalStock_ShouldReturnZero_WhenNoVariants()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Assert.Equal(0, item.TotalStock);
        }
        [Fact]
        public void TotalStock_ShouldReturnZero_WhenVariantsHaveNoStock()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant = new Variant(Color.FromHex("#FFFFFF"));
            item.AddVariant(variant);
            Assert.Equal(0, item.TotalStock);
        }
        [Fact]
        public void AddTag_WithValidTag_ShouldAddToTags()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Tag tag = new Tag("Coats", (int)TagEnum.Coats);
            item.AddTag(tag);
            Assert.Contains(tag, item.Tags);
        }
        [Fact]
        public void AddTag_WithTagAlreadyExists_ShouldThrowInvalidOperationException()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Tag tag = new Tag("Coats", (int)TagEnum.Coats);
            item.AddTag(tag);
            Assert.Throws<InvalidOperationException>(() => item.AddTag(tag));
        }
        [Fact]
        public void AddReview_WithValidReview_ShouldAddToReviews()
        {
            Item item = new Item("Test Name", 12, "Test Brand", "Test Collection", "Test Care Guide");
            Review review = new Review("Test Review");
            item.AddReview(review);
        }
        [Fact]
        public void RemoveTag_WithValidTag_ShouldRemoveFromTags()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Tag tag = new Tag("Coats", (int)TagEnum.Coats);
            item.AddTag(tag);
            item.RemoveTag(tag);
            Assert.DoesNotContain(tag, item.Tags);
        }
        [Fact]
        public void RemoveTag_WithTagNotExists_ShouldThrowInvalidOperationException()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Tag tag = new Tag("Coats", (int)TagEnum.Coats);
            Assert.Throws<InvalidOperationException>(() => item.RemoveTag(tag));
        }
        [Fact]
        public void RemoveVariant_WithValidVariant_ShouldRemoveFromVariants()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant = new Variant(Color.FromHex("#FFFFFF"));
            item.AddVariant(variant);
            item.RemoveVariant(variant.VariantId);
            Assert.DoesNotContain(variant, item.Variants);
        }
        [Fact]
        public void RemoveVariant_WithVariantNotExists_ShouldThrowInvalidOperationException()
        {
            Item item = new Item("Test Item", 100m, "Test Brand", "Test Collection", "Test Care Guide");
            Variant variant = new Variant(Color.FromHex("#FFFFFF"));
            Assert.Throws<InvalidOperationException>(() => item.RemoveVariant(variant.VariantId));
        }
     }
}
