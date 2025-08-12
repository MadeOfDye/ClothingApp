namespace ClothingStore.Application.DTOs
{
    public record class AvailableLocationBySizeDto
    {
        public Guid AvailableLocationBySizeId { get; set; }
        public Guid VariantId { get; set; }
        public Guid SizeId { get; set; }
        public IEnumerable<StockByLocationDto> AvailableLocationsOfGivenSize { get; set; } = Array.Empty<StockByLocationDto>();
    }
}
