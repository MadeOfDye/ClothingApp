using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ClothingStore.Persistence.Configurations
{
    public class AvailableLocationsConfigurations: IEntityTypeConfiguration<AvailableLocationBySize>
    {
        public void Configure(EntityTypeBuilder<AvailableLocationBySize> builder)
        {
            builder.ToTable("AvailableLocations");
            builder.HasKey(location => location.LocationId);
            //builder.Property(location => location.TotalStockOfSize)
            //    .IsRequired()
            //    .HasColumnType("int");
            builder.HasOne(location => location.Size)
            .WithMany()
            .HasForeignKey("SizeId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(location => location.Variant)
                .WithMany(variant => variant.AvailableLocations)
                .HasForeignKey(location => location.VariantId)
                .HasConstraintName("FK_Variants_AvailableLocations")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(location => location.AvailableLocationsOfGivenSize)
                .WithOne(stock => stock.LocationBySize)
                .HasForeignKey(stock => stock.LocationBySizeId)
                .HasConstraintName("FK_StockByLocation_AvailableLocations")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
