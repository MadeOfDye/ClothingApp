using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Persistence.Configurations
{
    public class CartItemConfigurations: IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(cartItem => cartItem.CartItemId);
            builder.Property(cartItem => cartItem.Quantity)
                .IsRequired()
                .HasDefaultValue(1);
            builder.HasOne(cartItem => cartItem.ShoppingCart)
                .WithMany(cart => cart.Items)
                .HasForeignKey(cartItem => cartItem.ShoppingCartId)
                .HasConstraintName("FK_CartItems_ShoppingCarts")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    {
    }
}
