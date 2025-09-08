using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class ShoppingCartConfigurations : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts");
            builder.HasKey(cart => cart.ShoppingCartId);
            builder.Property(cart => cart.UserId)
                .IsRequired();
            builder.Property(cart => cart.CreatedAt)
                .IsRequired();
            //builder.HasOne(cart => cart.User)
            //    .WithMany(user => user.ShoppingCarts)
            //    .HasForeignKey(cart => cart.UserId)
            //    .HasConstraintName("FK_Users_ShoppingCarts")
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Items)
               .WithOne(ci => ci.ShoppingCart)
               .HasForeignKey(ci => ci.ShoppingCartId)
                .HasConstraintName("FK_ShoppingCartItems_ShoppingCarts")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
