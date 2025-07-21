using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Entities
{
   public class AvailableLocationBySize
    {
        public Guid LocationId { get; set; }
        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
        public string Size {  get; set; }
        private readonly HashSet<StockByLocation> _availableLocationsOfGivenSize = new();
        public IReadOnlyCollection<StockByLocation> AvailableLocationsOfGivenSize => _availableLocationsOfGivenSize;
        public int TotalStockOfSize => _availableLocationsOfGivenSize.Sum(s => s.Stock);

        protected AvailableLocationBySize() { }

        public AvailableLocationBySize(Guid locationId, Guid variantId, string size)
        {
            LocationId = locationId;
            VariantId = variantId;
            Size = !string.IsNullOrWhiteSpace(size) ? size : throw new ArgumentException("Size is required");
        }

        public void AddStock(StockByLocation stock) => _availableLocationsOfGivenSize.Add(stock);
    }
}
