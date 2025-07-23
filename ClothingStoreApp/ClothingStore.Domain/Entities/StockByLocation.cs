using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Entities
{
    public class StockByLocation
    {
        public Guid StockId { get; private set; }
        public Guid LocationBySizeId { get; private set; }
        public AvailableLocationBySize LocationBySize { get; private set; }
        public int Stock {  get; private set; }
        public Location Location { get; private set; }

        protected StockByLocation() { }

        public StockByLocation(int quantity)
        {
            StockId = Guid.NewGuid();
            Stock = quantity >= 0 ? quantity
                                  : throw new ArgumentException("Quantity >= 0");
        }
    }
}
