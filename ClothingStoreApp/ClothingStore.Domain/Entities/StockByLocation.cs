namespace ClothingStore.Domain.Entities
{
    using ClothingStore.Domain.ValueObjects;

    public class StockByLocation
    {
        public Guid StockId { get; private set; }
        public Guid LocationBySizeId { get; private set; }
        public AvailableLocationBySize LocationBySize { get; private set; }
        public int Stock {  get; private set; }
        public Location? Location { get; private set; }

        protected StockByLocation() { }

        public StockByLocation(int quantity, Location location)
        {
            StockId = Guid.NewGuid();
            Stock = quantity >= 0 ? quantity
                                  : throw new ArgumentException("Quantity >= 0");
            Location = location;
        }

        public void SetLocation(Location location)
        {
             Location = location ?? throw new ArgumentNullException(nameof(location), "Location cannot be null");
        }

        public void UpdateStock(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity must be greater than or equal to zero", nameof(quantity));
            }
            Stock = quantity;
        }
    }
}
