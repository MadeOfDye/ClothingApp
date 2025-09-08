using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Tests.EntityTests
{
    public class ItemTests
    {
        [Fact]
        public void CreateItem_ValidParameters_ShouldCreateItem()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            Assert.Equal(name, item.Name);
            Assert.Equal(description, item.Description);
            Assert.Equal(price, item.Price);
            Assert.Equal(brand, item.Brand);
            Assert.Equal(String.Empty, item.Collection);
            Assert.Equal(String.Empty, item.MaterialDistribution);
            Assert.Equal(careGuide, item.CareGuide);
            Assert.False(item.Hot);
            Assert.False(item.LastChance);
            Assert.Equal(0, item.Discount);
        }

        [Theory]
        [InlineDataAttribute("", "Valid Description", 42, "Valid Brand", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute(null, "Valid Description", 42, "Valid Brand", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute(" ", "Valid Description", 42, "Valid Brand", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("          ", "Valid Description", 42, "Valid Brand", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", -42, "Valid Brand", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, null, "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, " ", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "              ", "Valid Collection", "Valid CareGuide")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "Valid Brand", "Valid Collection", null)]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "Valid Brand", "Valid Collection", "")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "Valid Brand", "Valid Collection", " ")]
        [InlineDataAttribute("Valid Name", "Valid Description", 42, "Valid Brand", "Valid Collection", "        ")]
        public void CreateItem_InvalidParameters_ShouldThrowArgumentException(string name, string description, decimal price, string brand, string collection, string careGuide)
        {
            Assert.Throws<ArgumentException>(() => new Item(name, description, price, brand, collection, careGuide));
        }

        [Fact]
        public void UpdateName_ValidName_ShouldUpdateName()
        {
            string name = "T-Shirt";
            string newName = "cool T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);
            item.UpdateName(newName);

            Assert.Equal(newName, item.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("                   ")]
        [InlineData(null)]
        public void UpdateName_NullOrWhitespaceName_ShouldThrowArgumentException(string newName)
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            Assert.Throws<ArgumentException>(() => item.UpdateName(newName));
        }

        [Fact]
        public void UpdateDescription_ValidDescription_ShouldUpdateDescription()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string newDescription = "even cooler T-Shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);
            item.UpdateDescription(newDescription);

            Assert.Equal(newDescription, item.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData("                   ")]
        [InlineData(null)]
        public void UpdateDescription_NullOrWhitespaceDescription_ShouldThrowArgumentException(string newDescription)
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            Assert.Throws<ArgumentException>(() => item.UpdateDescription(newDescription));
        }

        [Fact]
        public void SetHot_ShouldUpdateHotProperty()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            item.SetHot(true);
            Assert.True(item.Hot);
            item.SetHot(false);
            Assert.False(item.Hot);
        }

        [Fact]
        public void SetLastChance_ShouldUpdateLastChanceProperty()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            item.SetLastChance(true);
            Assert.True(item.LastChance);
            item.SetLastChance(false);
            Assert.False(item.LastChance);
        }

        [Fact]
        public void DiscountItem_DiscountBetween0And1_ShouldUpdateDiscount()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);

            item.DiscountItem(0.2m);

            Assert.Equal(0.2m, item.Discount);
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void DiscountItem_DiscountLessThan0OrGreaterThan1_ShouldThrowArgumentOutOfRangeException(decimal discount)
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Assert.Throws<ArgumentOutOfRangeException>(() => item.DiscountItem(discount));
        }

        [Fact]
        public void SetMaterialDistribution_ValidMaterialDistribution_ShouldUpdateMaterialDistribution()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            string materialDistribution = "Cotton: 80%, Polyester: 20%";

            Item item = new Item(name, description, price, brand, collection, careGuide);
            item.SetMaterialDistribution(materialDistribution);
            Assert.Equal(materialDistribution, item.MaterialDistribution);
        }

        [Theory]
        [InlineData("")]
        [InlineData("                   ")]
        [InlineData(null)]
        [InlineData("Cotton 50%, Polyester 50%")] // Missing colons
        [InlineData("Cotton: 50%, Polyester")] // Missing percentage
        [InlineData("Cotton: fifty%, Polyester: fifty%")] // Non-numeric percentage
        public void SetMaterialDistribution_InvalidMaterialDistribution_ShouldThrowArgumentException(string materialDistribution)
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Assert.Throws<ArgumentException>(() => item.SetMaterialDistribution(materialDistribution));
        }

        [Fact]
        public void AddVariant_ShouldAddVariant()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Variant variant = new Variant(Color.FromRGB(23, 23, 23));

            item.AddVariant(variant);

            Assert.Contains(variant, item.Variants);
        }

        [Fact]
        public void AddVariant_NullVariant_ShouldThrowArgumentNullException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";

            Item item = new Item(name, description, price, brand, collection, careGuide);
            Assert.Throws<ArgumentNullException>(() => item.AddVariant(null));
        }

        [Fact]
        public void AddVariant_DuplicateVariant_ShouldThrowInvalidOperationException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Variant variant = new Variant(Color.FromRGB(23, 23, 23));
            item.AddVariant(variant);
            Assert.Throws<InvalidOperationException>(() => item.AddVariant(variant));
        }

        [Fact]
        public void AddTag_ShouldAddTag()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Tag tag = new Tag("summer", 21);
            item.AddTag(tag);
            Assert.Contains(tag, item.Tags);
        }

        [Fact]
        public void AddTag_NullTag_ShouldThrowArgumentNullException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Assert.Throws<ArgumentNullException>(() => item.AddTag(null));
        }

        [Fact]
        public void AddTag_DuplicateTag_ShouldThrowInvalidOperationException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Tag tag = new Tag("summer", 21);
            item.AddTag(tag);
            Assert.Throws<InvalidOperationException>(() => item.AddTag(tag));
        }

        // TODO: Review tests go here after implementing Review entity and functionality

        [Fact]
        public void RemoveTag_ValidTag_ShouldRemoveTag()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Tag tag = new Tag("summer", 21);
            item.AddTag(tag);
            item.RemoveTag(tag);
            Assert.DoesNotContain(tag, item.Tags);
        }

        [Fact]
        public void RemoveTag_TagNotInCollection_ShouldThrowInvalidOperationException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Tag tag = new Tag("summer", 21);
            Assert.Throws<InvalidOperationException>(() => item.RemoveTag(tag));
        }

        [Fact]
        public void RemoveVariant_ValidVariant_ShouldRemoveVariant()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Variant variant = new Variant(Color.FromRGB(23, 23, 23));
            item.AddVariant(variant);
            item.RemoveVariant(variant.VariantId);
            Assert.DoesNotContain(variant, item.Variants);
        }

        [Fact]
        public void RemoveVariant_VariantNotInCollection_ShouldThrowInvalidOperationException()
        {
            string name = "T-Shirt";
            string description = "A cool shirt";
            string collection = String.Empty;
            decimal price = 23.99m;
            string brand = "Abibas";
            string careGuide = "Machine wash cold";
            Item item = new Item(name, description, price, brand, collection, careGuide);
            Variant variant = new Variant(Color.FromRGB(23, 23, 23));
            Assert.Throws<InvalidOperationException>(() => item.RemoveVariant(variant.VariantId));
        }
    }

}
