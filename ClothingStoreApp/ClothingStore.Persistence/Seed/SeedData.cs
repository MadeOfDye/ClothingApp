using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Persistence.Seed
{
    public static class SeedData
    {
        public static List<Item> GetItems()
        {
            // ITEM 1: T-Shirt
            var tshirt = new Item(
                "Basic T-Shirt",
                "A soft cotton t-shirt, perfect for summer.",
                19.99m,
                "BrandA",
                "SummerCollection",
                "Machine wash cold"
            );

            tshirt.SetMaterialDistribution("Cotton: 100%");
            tshirt.SetHot(true);

            var tshirtVariant = new Variant(Color.FromHex("#FF0000"));
            tshirtVariant.AddPhoto(new Photo("https://example.com/tshirt-red-front.jpg", "Front view"));
            tshirtVariant.AddPhoto(new Photo("https://example.com/tshirt-red-back.jpg", "Back view"));

            // Sizes
            var sizeM = SizeFactory.CreateShirtSize("M", 70, 45, 50, 20);
            var sizeL = SizeFactory.CreateShirtSize("L", 72, 47, 53, 21);

            var locationBySizeM = new AvailableLocationBySize(sizeM);
            locationBySizeM.AddStock(new StockByLocation(100, new Location(123, 323)));
            locationBySizeM.AddStock(new StockByLocation(20, new Location(123, 323)));

            var locationBySizeL = new AvailableLocationBySize(sizeL);
            locationBySizeL.AddStock(new StockByLocation(50, new Location(123, 323)));
            locationBySizeL.AddStock(new StockByLocation(10, new Location(123, 323)));

            tshirtVariant.AddLocation(locationBySizeM);
            tshirtVariant.AddLocation(locationBySizeL);

            tshirt.AddVariant(tshirtVariant);
            tshirt.AddTag(new Tag("Casual", 1));
            tshirt.AddTag(new Tag("Summer", 2));

            // ITEM 2: Jeans
            var jeans = new Item(
                "Slim Fit Jeans",
                "Blue slim fit jeans with stretch fabric.",
                49.99m,
                "BrandB",
                "WinterCollection",
                "Machine wash cold"
            );

            jeans.SetMaterialDistribution("Cotton: 80%, Elastane: 20%");

            var jeansVariant = new Variant(Color.FromHex("#0000FF"));
            jeansVariant.AddPhoto(new Photo("https://example.com/jeans-blue-front.jpg", "Front view"));

            var pantSize32 = SizeFactory.CreatePantSize("32", 80, 80);
            var pantSize34 = SizeFactory.CreatePantSize("34", 85, 82);

            var jeansLocation32 = new AvailableLocationBySize(pantSize32);
            jeansLocation32.AddStock(new StockByLocation(60, new Location(123, 323)));
            jeansLocation32.AddStock(new StockByLocation(15, new Location(123, 323)));

            var jeansLocation34 = new AvailableLocationBySize(pantSize34);
            jeansLocation34.AddStock(new StockByLocation(40, new Location(123, 323)));

            jeansVariant.AddLocation(jeansLocation32);
            jeansVariant.AddLocation(jeansLocation34);

            jeans.AddVariant(jeansVariant);
            jeans.AddTag(new Tag("Denim", 1));
            jeans.AddTag(new Tag("Winter", 2));

            return new List<Item> { tshirt, jeans };
        }
    }
 }
