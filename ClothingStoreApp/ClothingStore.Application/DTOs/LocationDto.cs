namespace ClothingStore.Application.DTOs
{
    public record class LocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
    }
}
