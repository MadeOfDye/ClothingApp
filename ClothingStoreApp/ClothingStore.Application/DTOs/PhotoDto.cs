namespace ClothingStore.Application.DTOs
{
    public record class PhotoDto
    {
        public Guid PhotoId { get; set; }
        public Guid VariantId { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset UploadedAt { get; set; }
    }
}
