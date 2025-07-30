using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ClothingStore.Persistence.Configurations
{
    public class StockByLocationConfigurations: IEntityTypeConfiguration<StockByLocation>
    {
        public void Configure(EntityTypeBuilder<StockByLocation> builder)
        {
            builder.ToTable("StocksByLocations");
            builder.HasKey(stock => stock.StockId)
                .HasName("PK_Stock");
            builder.Property(stock => stock.Stock)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValue(0);
            builder.OwnsOne(stock => stock.Location, locationBuilder => {
                locationBuilder.Property(s => s.Latitude)
                    .HasColumnName("Latitude")
                    .IsRequired();

                locationBuilder.Property(s => s.Longitude)
                .HasColumnName("Longitude")
                .IsRequired();

                locationBuilder.Property(s => s.Address)
                    .HasColumnName("Address")
                    .HasMaxLength(255);

                locationBuilder.ToTable("StocksByLocations");
            });

            builder.HasOne(stock => stock.LocationBySize)
                .WithMany(location => location.AvailableLocationsOfGivenSize)
                .HasForeignKey(stock => stock.LocationBySizeId)
                .HasConstraintName("FK_StockByLocation_AvailableLocations")
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
