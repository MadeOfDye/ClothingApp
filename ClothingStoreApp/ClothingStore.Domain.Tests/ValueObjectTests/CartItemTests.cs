using ClothingStore.Domain.Entities;
using ClothingStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Tests.ValueObjectTests
{
    public class CartItemTests
    {
        [Fact]
        public void Constructor_WithValidParameters_InitialisezParameters()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = 42;

            CartItem cartItem = new CartItem(item, quantity);

            Assert.Equal(quantity, cartItem.Quantity);
            Assert.Equal(item.ItemId, cartItem.Item.ItemId);
        }
        [Fact]
        public void Constructor_WithInvalidParameters_ThrowsArgumentException()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = -42;

            Assert.Throws<ArgumentException>(() => new CartItem(item, quantity));
        }
        [Fact]
        public void IncreaseQuantity_WithPositiveAmount_IncreasesQuantityByAmount()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = 12;
            int amount = 3;

            CartItem cartItem = new CartItem(item, quantity);
            cartItem.IncreaseQuantity(amount);

            Assert.Equal(15, cartItem.Quantity);
        }
        [Fact]
        public void IncreaseQuantity_WithNegativeAmount_ThrowsArgumentException()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = 12;
            int amount = -3;

            CartItem cartItem = new CartItem(item, quantity);

            Assert.Throws<ArgumentException>(() => cartItem.IncreaseQuantity(amount));
        }
        [Fact]
        public void DecreaseQuantity_WithPositiveAmount_DecreasesQuantityByAmount()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = 12;
            int amount = 3;
            CartItem cartItem = new CartItem(item, quantity);
            cartItem.DecreaseQuantity(amount);
            Assert.Equal(9, cartItem.Quantity);
        }
        [Fact]
        public void DecreaseQuantity_WithNegativeAmount_ThrowsArgumentException()
        {
            Item item = new Item("Item Name", 12m, "Valid Brand", "Valid Collection", "Test Guide");
            int quantity = 12;
            int amount = -3;
            CartItem cartItem = new CartItem(item, quantity);
            Assert.Throws<ArgumentException>(() => cartItem.DecreaseQuantity(amount));
        }
    }
}
