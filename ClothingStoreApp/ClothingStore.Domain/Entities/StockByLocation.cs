using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Entities
{
    public class StockByLocation
    {
        public Guid StockId { get; set; }
        public int Stock {  get; set; }
        public Location location { get; set; }

        protected StockByLocation() { }

        public StockByLocation(int quantity)
        {
            StockId = Guid.NewGuid();
            Stock = quantity >= 0 ? quantity
                                  : throw new ArgumentException("Quantity >= 0");
        }
    }
}
