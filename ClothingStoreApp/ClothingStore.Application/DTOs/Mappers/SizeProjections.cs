using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.DTOs.Mappers
{
    public static class SizeProjections
    {
        public static SizeDto toDto(Size size) => size switch
        {
            ShirtSize shirtSize => new ShirtSizeDto
            {
                SizeID = shirtSize.SizeId,
                Letter = shirtSize.Letter,
                Length = shirtSize.Length,
                ShoulderWidth = shirtSize.ShoulderWidth,
                ChestWidth = shirtSize.ChestWidth,
                SleeveLength = shirtSize.SleeveLength,
                SleeveCircumference = shirtSize.SleeveCircumference,
                NeckCircumference = shirtSize.NeckCircumference
            },
            PantSize pantSize => new PantSizeDto
            {
                SizeID = pantSize.SizeId,
                Letter = pantSize.Letter,
                Waist = pantSize.Waist,
                Inseam = pantSize.Inseam,
                PantLegCircumference = pantSize.PantLegCircumference
            },
            ShoeSize shoeSize => new ShoeSizeDto
            {
                SizeID = shoeSize.SizeId,
                Letter = shoeSize.Letter,
                Length = shoeSize.Length,
                Width = shoeSize.Width,
                HeelHeight = shoeSize.HeelHeight
            },
            HatSize hatSize => new HatSizeDto
            {
                SizeID = hatSize.SizeId,
                Letter = hatSize.Letter,
                Circumference = hatSize.Circumference
            },
            DressSize dressSize => new DressSizeDto
            {
                SizeID = dressSize.SizeId,
                Letter = dressSize.Letter,
                Bust = dressSize.Bust,
                Waist = dressSize.Waist,
                Hip = dressSize.Hip,
                Length = dressSize.Length
            },
            _ => throw new ArgumentException("Unknown size type", nameof(size))
        };
    }
}
