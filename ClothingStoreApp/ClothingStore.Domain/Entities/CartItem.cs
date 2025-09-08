namespace ClothingStore.Domain.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; private set; }
        public Guid ShoppingCartId { get; private set; }
        public virtual ShoppingCart ShoppingCart { get; private set; }
        public Guid ItemId { get; private set; }
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        protected CartItem() { }

        public CartItem(Item item, int quantity)
        {
            CartItemId = Guid.NewGuid();
            Item = item ?? throw new ArgumentNullException(nameof(item), "Item cannot be null");
            ItemId = item.ItemId;
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

        public override bool Equals(object? obj)
        {
            if (obj is not CartItem other)
                return false;
            return Item.Equals(other.Item) && Quantity == other.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Item, Quantity);
        }

        public override string ToString()
        {
            return $"{Item.Name} (Quantity: {Quantity})";
        }
    }
}
