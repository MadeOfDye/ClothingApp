namespace ClothingStore.Domain.Entities
{
    public class Photo
    {
        public Guid PhotoId { get; private set; }
        public Guid VariantId { get; private set; } 
        public Variant Variant { get; private set; }
        public string Url { get; private set; }
        public string? Description { get; private set; }
        public DateTimeOffset UploadedAt { get; private set; }

        protected Photo() { }

        public Photo(string url, string? description)
        {
            PhotoId = Guid.NewGuid();
            Url = !string.IsNullOrWhiteSpace(url)
                             ? url
                             : throw new ArgumentException("URL required");
            UploadedAt = DateTime.UtcNow;
            Description = description;
        }

        public void UpdateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL cannot be null or empty", nameof(url));
            Url = url;
        }
    }

}
