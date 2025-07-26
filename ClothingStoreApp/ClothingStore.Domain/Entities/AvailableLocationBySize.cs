namespace ClothingStore.Domain.Entities
{
    using ClothingStore.Domain.ValueObjects;

    public class AvailableLocationBySize
    {
        public Guid LocationId { get; set; }
        public Guid VariantId { get; set; }

        //Navigation property for EFCore
        public Variant Variant { get; set; }

        public Size Size { get; set; }
        private readonly HashSet<StockByLocation> _availableLocationsOfGivenSize = new();
        public IReadOnlyCollection<StockByLocation> AvailableLocationsOfGivenSize => _availableLocationsOfGivenSize;
        public int TotalStockOfSize => _availableLocationsOfGivenSize.Sum(s => s.Stock);

        protected AvailableLocationBySize() { }

        public AvailableLocationBySize(Size size)
        {
            LocationId = Guid.NewGuid();
            if (size == null)
                throw new ArgumentNullException(nameof(size) + " does not exist");
            Size = size;
        }

        public void AddStock(StockByLocation stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "Stock cannot be null");
            //if (stock.LocationBySizeId != LocationId)
            //    throw new InvalidOperationException("Stock must belong to this AvailableLocationBySize Object.");
            if (_availableLocationsOfGivenSize.Contains(stock))
                throw new InvalidOperationException("Stock already exists in the available locations for this size");
            _availableLocationsOfGivenSize.Add(stock);
        }

        public void AddStockRange(IEnumerable<StockByLocation> stocks)
        {
            if (stocks == null || !stocks.Any())
                throw new ArgumentNullException(nameof(stocks), "Stocks cannot be null or empty");
            foreach (var stock in stocks)
            {
                AddStock(stock);
            }
        }

        public void RemoveStock(Guid stockId)
        {
            if (stockId == Guid.Empty)
                throw new ArgumentNullException(nameof(stockId), "Stock cannot be null");
            StockByLocation stock = _availableLocationsOfGivenSize.FirstOrDefault(s => s.StockId == stockId)
                ?? throw new InvalidOperationException("Stock not found");
            _availableLocationsOfGivenSize.Remove(stock);
        }
    }
}
