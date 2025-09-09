namespace ClothingStore.Application.DTOs
{
    public record class TagDto
    {
        public Guid TagId { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; }
    }
}
