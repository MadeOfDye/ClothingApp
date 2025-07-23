using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.ValueObjects
{
    public class CartItem
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }
        public CartItem(Item item, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item), "Item cannot be null");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            Quantity = quantity;
        }

        public int IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            Quantity += amount;
            return Quantity;
        }
        public int DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            if (Quantity - amount < 0)
                throw new InvalidOperationException("Cannot decrease quantity below zero");
            Quantity -= amount;
            return Quantity;
        }

    }
}
