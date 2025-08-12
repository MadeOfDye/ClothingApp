namespace ClothingStore.Application.DTOs
{
    public record class VariantDto
    {
        public Guid VariantId { get; set; }
        public Guid ItemId { get; set; }
        public ColorDto Color { get; set; }
        public int TotalQuantity { get; set; }
        public IEnumerable<AvailableLocationBySizeDto> AvailableLocations { get; init; } = Array.Empty<AvailableLocationBySizeDto>();
        public IEnumerable<PhotoDto> Gallery { get; init; } = Array.Empty<PhotoDto>();
    }
}
