using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class SizeConfigurations : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");
            builder.HasKey(size => size.SizeId)
                .HasName("PK_Sizes");
            builder.Property(size => size.Letter)
                .IsRequired()
                .HasMaxLength(12);

            builder.HasDiscriminator<string>("SizeType")
                .HasValue<ShirtSize>("Shirt")
                .HasValue<PantSize>("Pant")
                .HasValue<ShoeSize>("Shoe")
                .HasValue<DressSize>("Dress")
                .HasValue<HatSize>("Hat");
        }
    }

    public class ShirtSizeConfigurations : IEntityTypeConfiguration<ShirtSize>
    {
        public void Configure(EntityTypeBuilder<ShirtSize> builder)
        {
            builder.Property(s => s.Length).HasColumnName("Shirt_Length");
            builder.Property(s => s.ShoulderWidth).HasColumnName("Shirt_ShoulderWidth");
            builder.Property(s => s.ChestWidth).HasColumnName("Shirt_ChestWidth");
            builder.Property(s => s.SleeveLength).HasColumnName("Shirt_SleeveLength");
        }
    }

    public class PantSizeConfigurations : IEntityTypeConfiguration<PantSize>
    {
        public void Configure(EntityTypeBuilder<PantSize> builder)
        {
            builder.Property(s => s.Waist).HasColumnName("Pant_Waist");
            builder.Property(s => s.Inseam).HasColumnName("Pant_Inseam");
            builder.Property(s => s.PantLegCircumference).HasColumnName("Pant_PantLegCircumference");
        }
    }

    public class ShoeSizeConfigurations : IEntityTypeConfiguration<ShoeSize>
    {
        public void Configure(EntityTypeBuilder<ShoeSize> builder)
        {
            builder.Property(s => s.Length).HasColumnName("Shoe_Length");
            builder.Property(s => s.Width).HasColumnName("Shoe_Width");
            builder.Property(s => s.HeelHeight).HasColumnName("Shoe_HeelHight");
        }
    }

    public class HatSizeConfigurations : IEntityTypeConfiguration<HatSize>
    {
        public void Configure(EntityTypeBuilder<HatSize> builder)
        {
            builder.Property(s => s.Circumference).HasColumnName("Hat_Circumference");
        }
    }

    public class DressSizeConfigurations : IEntityTypeConfiguration<DressSize>
    {
        public void Configure(EntityTypeBuilder<DressSize> builder)
        {
            builder.Property(s => s.Bust).HasColumnName("Dress_Bust");
            builder.Property(s => s.Waist).HasColumnName("Dress_Waist");
            builder.Property(s => s.Hip).HasColumnName("Dress_Hip");
        }
    }
}
