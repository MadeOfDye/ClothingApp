using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Application.DTOs
{
    public record class StockByLocationDto
    {
        public Guid StockByLocationId { get; set; }
        public Guid AvailableLocationBySizeId { get; set; }
        public Guid LocationId { get; set; }
        public int Stock { get; set; }
        public LocationDto? Location { get; set; }
    }
}
