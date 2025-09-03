using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(item => item.ItemId);

            builder.Property(item => item.Name)
                .IsRequired();

            builder.Property(item => item.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(item => item.Brand)
                .IsRequired();

            builder.Property(item => item.Collection)
                .HasDefaultValue(string.Empty);

            builder.Property(item => item.Discount)
                .HasColumnType("decimal(5,2)");

            builder.Property(item => item.MaterialDistribution)
                .IsRequired();

            builder.Property(item => item.CreatedAt)
                       .IsRequired();

            builder.HasMany(item => item.Variants)
                .WithOne(variant => variant.Item)
                .HasForeignKey(variant => variant.ItemId)
                .HasConstraintName("FK_Items_Variants")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(item => item.Tags)
                .WithOne(tag => tag.Item)
                .HasForeignKey(tag => tag.ItemId)
                .HasConstraintName("FK_Items_Tags")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(item => item.Reviews)
                .WithOne(review => review.Item)
                .HasForeignKey(review => review.ItemId)
                .HasConstraintName("FK_Items_Reviews")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
