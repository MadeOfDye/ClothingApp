namespace ClothingStore.Application.DTOs
{
    public record class ItemDto
    {
        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Hot { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool LastChance { get; set; }
        public string Brand { get; set; }
        public string Collection { get; set; }
        public string? CareGuide { get; set; }
        public string? MaterialDistribution { get; set; }
        public int TotalStock { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public IReadOnlyList<VariantDto> Variants { get; init; } = Array.Empty<VariantDto>();
        public IReadOnlyList<TagDto> Tags { get; init; } = Array.Empty<TagDto>();
    }
}
