using ClothingStore.Domain.ValueObjects;

namespace ClothingStore.Domain.Entities
{
    public class ShoppingCart
    {
        public Guid CartId { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        private HashSet<CartItem> _items = new();
        public IReadOnlyCollection<CartItem> Items => _items;
        public DateTimeOffset CreatedAt { get; private set; }
        protected ShoppingCart() { }
        public ShoppingCart(Guid userId)
        {
            CartId = Guid.NewGuid();
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(Item item, int quantity)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            var existingItem = _items.FirstOrDefault(i => i.Item.ItemId == item.ItemId);
            if (existingItem.Item != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new CartItem(item, quantity));
            }
        }
        public void RemoveItem(Item item) {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            var existingItem = _items.FirstOrDefault(i => i.Item.ItemId == item.ItemId);
            if (existingItem.Item == null)
                throw new InvalidOperationException("Item not found in cart");
            if (existingItem.Quantity > 1)
            {
                existingItem.DecreaseQuantity(1);
            }
            else
            {
                _items.Remove(existingItem);
            }
        }
    }
}
