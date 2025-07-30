using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class ReviewConfigurations: IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(review => review.ReviewId)
                .HasName("PK_Reviews");
            
            builder.HasOne(review => review.Item)
                .WithMany(item => item.Reviews)
                .HasForeignKey(review => review.ItemId)
                .HasConstraintName("FK_Items_Reviews")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }   
    {
    }
}
