namespace ClothingStore.Application.DTOs
{
    public record class ColorDto
    {
        public string Hexadecimal { get; set; } = string.Empty;
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}
