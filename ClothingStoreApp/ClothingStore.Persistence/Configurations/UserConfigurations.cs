using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class UserConfigurations: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.UserId)
                .HasName("PK_Users");
            builder.Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(100);

            //guest users only have one shopping cart

            builder.HasOne(user => user.ShoppingCart)
                .WithOne(cart => cart.User)
                .HasForeignKey<ShoppingCart>(cart => cart.UserId)
                .HasConstraintName("FK_Users_ShoppingCarts")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
