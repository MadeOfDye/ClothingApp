using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;
using ClothingStore.Shared.Constants;

namespace ClothingStore.Persistence.Seed
{
    public static class SeedData
    {
        public static List<Item> GetItems()
        {
            var items = new List<Item>();

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
            tshirtVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant#FF0000/Variant#FF0000-1.jpg", "Front view"));
            tshirtVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant#FF0000/Variant#FF0000-2.jpg", "Back view"));

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
            items.Add(tshirt);

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
            jeansVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant%23FF0000/Variant%23FF0000-1.jpg", "Front view"));

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
            items.Add(jeans);

            // ITEM 3: Hoodie
            var hoodie = new Item(
                "Classic Hoodie",
                "Warm and comfortable cotton hoodie for casual wear.",
                39.99m,
                "BrandC",
                "WinterCollection",
                "Machine wash warm"
            );
            hoodie.SetMaterialDistribution("Cotton: 100%");
            hoodie.SetHot(true);

            var hoodieVariant = new Variant(Color.FromHex("#808080"));
            hoodieVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant#FF0000/Variant#FF0000-1.jpg", "Front view"));

            var hoodieSizeL = SizeFactory.CreateShirtSize("L", 74, 52, 55, 22);
            var hoodieSizeXL = SizeFactory.CreateShirtSize("XL", 76, 54, 57, 23);

            var hoodieLocationL = new AvailableLocationBySize(hoodieSizeL);
            hoodieLocationL.AddStock(new StockByLocation(30, new Location(123, 323)));

            var hoodieLocationXL = new AvailableLocationBySize(hoodieSizeXL);
            hoodieLocationXL.AddStock(new StockByLocation(25, new Location(123, 323)));

            hoodieVariant.AddLocation(hoodieLocationL);
            hoodieVariant.AddLocation(hoodieLocationXL);
            hoodie.AddVariant(hoodieVariant);
            hoodie.AddTag(new Tag("Casual", 1));
            hoodie.AddTag(new Tag("Winter", 2));
            items.Add(hoodie);

            // ITEM 4: Dress Shirt
            var dressShirt = new Item(
                "Formal Dress Shirt",
                "Crisp white shirt for formal occasions.",
                29.99m,
                "BrandD",
                "FormalCollection",
                "Dry clean only"
            );
            dressShirt.SetMaterialDistribution("Cotton: 100%");

            var shirtVariant = new Variant(Color.FromHex("#FFFFFF"));
            shirtVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant%23FF0000/Variant%23FF0000-1.jpg", "Front view"));

            var shirtSize15 = SizeFactory.CreateShirtSize("15", 70, 40, 48, 18);
            var shirtSize16 = SizeFactory.CreateShirtSize("16", 72, 42, 50, 19);

            var shirtLocation15 = new AvailableLocationBySize(shirtSize15);
            shirtLocation15.AddStock(new StockByLocation(40, new Location(123, 323)));

            var shirtLocation16 = new AvailableLocationBySize(shirtSize16);
            shirtLocation16.AddStock(new StockByLocation(35, new Location(123, 323)));

            shirtVariant.AddLocation(shirtLocation15);
            shirtVariant.AddLocation(shirtLocation16);
            dressShirt.AddVariant(shirtVariant);
            dressShirt.AddTag(new Tag("Formal", 1));
            dressShirt.AddTag(new Tag("Office", 2));
            items.Add(dressShirt);

            // ITEM 5: Shorts
            var shorts = new Item(
                "Casual Shorts",
                "Comfortable cotton shorts for summer activities.",
                24.99m,
                "BrandA",
                "SummerCollection",
                "Machine wash cold"
            );
            shorts.SetMaterialDistribution("Cotton: 100%");
            shorts.SetHot(true);

            var shortsVariant = new Variant(Color.FromHex("#000000"));
            shortsVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant#FF0000/Variant#FF0000-1.jpg", "Front view"));

            var shortsSizeM = SizeFactory.CreatePantSize("M", 45, 40);
            var shortsSizeL = SizeFactory.CreatePantSize("L", 47, 42);

            var shortsLocationM = new AvailableLocationBySize(shortsSizeM);
            shortsLocationM.AddStock(new StockByLocation(50, new Location(123, 323)));

            var shortsLocationL = new AvailableLocationBySize(shortsSizeL);
            shortsLocationL.AddStock(new StockByLocation(45, new Location(123, 323)));

            shortsVariant.AddLocation(shortsLocationM);
            shortsVariant.AddLocation(shortsLocationL);
            shorts.AddVariant(shortsVariant);
            shorts.AddTag(new Tag("Casual", 1));
            shorts.AddTag(new Tag("Summer", 2));
            items.Add(shorts);

            // ITEM 6: Jacket
            var jacket = new Item(
                "Denim Jacket",
                "Classic denim jacket for all seasons.",
                59.99m,
                "BrandB",
                "AllSeasonCollection",
                "Machine wash cold"
            );
            jacket.SetMaterialDistribution("Cotton: 100%");

            var jacketVariant = new Variant(Color.FromHex("#0000FF"));
            jacketVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant%23FF0000/Variant%23FF0000-1.jpg", "Front view"));

            var jacketSizeM = SizeFactory.CreateShirtSize("M", 72, 50, 52, 21);
            var jacketSizeL = SizeFactory.CreateShirtSize("L", 74, 52, 54, 22);

            var jacketLocationM = new AvailableLocationBySize(jacketSizeM);
            jacketLocationM.AddStock(new StockByLocation(25, new Location(123, 323)));

            var jacketLocationL = new AvailableLocationBySize(jacketSizeL);
            jacketLocationL.AddStock(new StockByLocation(20, new Location(123, 323)));

            jacketVariant.AddLocation(jacketLocationM);
            jacketVariant.AddLocation(jacketLocationL);
            jacket.AddVariant(jacketVariant);
            jacket.AddTag(new Tag("Denim", 1));
            jacket.AddTag(new Tag("Casual", 2));
            items.Add(jacket);

            // ITEM 7: Skirt
            var skirt = new Item(
                "A-Line Skirt",
                "Elegant A-line skirt for office or casual wear.",
                34.99m,
                "BrandE",
                "FormalCollection",
                "Dry clean only"
            );
            skirt.SetMaterialDistribution("Polyester: 100%");

            var skirtVariant = new Variant(Color.FromHex("#FFC0CB"));
            skirtVariant.AddPhoto(new Photo(Shared.Constants.Domain.LOCAL_DOMAIN + "/ProductPhotos/BasicShirt/Variant#FF0000/Variant#FF0000-1.jpg", "Front view"));

            var skirtSizeS = SizeFactory.CreatePantSize("S", 40, 35);
            var skirtSizeM = SizeFactory.CreatePantSize("M", 42, 37);

            var skirtLocationS = new AvailableLocationBySize(skirtSizeS);
            skirtLocationS.AddStock(new StockByLocation(30, new Location(123, 323)));

            var skirtLocationM = new AvailableLocationBySize(skirtSizeM);
            skirtLocationM.AddStock(new StockByLocation(28, new Location(123, 323)));

            skirtVariant.AddLocation(skirtLocationS);
            skirtVariant.AddLocation(skirtLocationM);
            skirt.AddVariant(skirtVariant);
            skirt.AddTag(new Tag("Formal", 1));
            skirt.AddTag(new Tag("Office", 2));
            items.Add(skirt);

            return items;
        }
    }
}