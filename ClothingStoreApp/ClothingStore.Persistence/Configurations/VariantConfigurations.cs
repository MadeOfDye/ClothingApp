using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class VariantConfigurations : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.ToTable("Variants");
            builder.HasKey(variant => variant.VariantId)
                .HasName("PK_Variants");
            builder.OwnsOne(v => v.Color, colorBuilder =>
            {
                colorBuilder.Property(c => c.Hexadecimal)
                            .HasColumnName("ColorHex")
                            .IsRequired();
                colorBuilder.Property(c => c.Red)
                            .HasColumnName("ColorRed")
                            .IsRequired();
                colorBuilder.Property(c => c.Green)
                            .HasColumnName("ColorGreen")
                            .IsRequired();
                colorBuilder.Property(c => c.Blue)
                            .HasColumnName("ColorBlue")
                            .IsRequired();
                colorBuilder.ToTable("Variants");
            });
            builder.HasOne(variant => variant.Item)
                .WithMany(item => item.Variants)
                .HasForeignKey(variant => variant.ItemId)
                .HasConstraintName("FK_Items_Variants")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(variant => variant.AvailableLocations)
                .WithOne(location => location.Variant)
                .HasForeignKey(location => location.VariantId)
                .HasConstraintName("FK_Variants_AvailableLocations")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(variant => variant.Gallery)
                .WithOne(photo => photo.Variant)
                .HasForeignKey(photo => photo.VariantId)
                .HasConstraintName("FK_Variants_Photos")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
