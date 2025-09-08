namespace ClothingStore.Application.DTOs
{
    public record class SizeDto
    {
        public Guid SizeID { get; set; }
        public string Letter { get; set; } = string.Empty;
    }

    public record class ShirtSizeDto : SizeDto
    {
        public float Length { get; set; }
        public float ShoulderWidth { get; set; }
        public float ChestWidth { get; set; }
        public float SleeveLength { get; set; }
        public float SleeveCircumference { get; set; }
        public float NeckCircumference { get; set; }
    }

    public record class PantSizeDto: SizeDto
    {         
        public float Waist { get; set; }
        public float Inseam { get; set; }
        public float PantLegCircumference { get; set; }
    }

    public record class ShoeSizeDto: SizeDto
    {         
        public float Length { get; set; }
        public float Width { get; set; }
        public float? HeelHeight { get; set; }
    }

    public record class HatSizeDto: SizeDto
    {         
        public float Circumference { get; set; }
    }

    public record class DressSizeDto: SizeDto
    {         
        public float Bust { get; set; }
        public float Waist { get; set; }
        public float Hip { get; set; }
        public float Length { get; set; }
    }
}